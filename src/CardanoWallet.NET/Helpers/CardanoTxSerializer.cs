using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace SAIB.CardanoWallet.NET.Helpers
{
    public abstract class CardanoTxSerializer
    {
        public static string? Serialize(object? o)
        {
            if (o != null)
            {
                var cardanoObject = ConvertToCardanoObject(o);
                return JsonConvert.SerializeObject(cardanoObject);
            }
            else
            {
                return null;
            }
        }

        public static object? ToMetaDataPayload(object? o)
        {
            if (o != null)
            {
                var cardanoObject = ConvertToCardanoObject(o);
                var result = new Dictionary<string, object>();
                result.Add("0", new { map = cardanoObject });
                return result;
            }
            else
            {
                return null;
            }
        }

        private static object ConvertToCardanoObject(object o)
        {
            var result = new List<object>();
            var propInfos = o.GetType().GetProperties();
            foreach (var pI in propInfos)
            {
                var propVal = pI.GetValue(o);
                var cardanoPropertyObject = ProcessProperty(pI.Name, propVal);
                if (cardanoPropertyObject != null)
                    result.Add(cardanoPropertyObject);
            }
            return result;
        }

        private static Dictionary<object, object>? ProcessProperty(string name, object value)
        {
            Dictionary<object, object>? resultDict = null;
            var processedValue = ProcessPropertyValue(value);
            if (processedValue != null)
            {
                resultDict = new Dictionary<object, object>();
                resultDict.Add("k", new Dictionary<string, string>() { { "string", name } });
                resultDict.Add("v", processedValue);
            }
            return resultDict;
        }

        private static object? ProcessPropertyValue(object value)
        {
            object? result = null;
            if (value != null && IsValueAllowed(value))
            {
                if (value is string)
                {
                    result = new Dictionary<string, string>() { { "string", (value as string) ?? string.Empty } };
                }
                else if (value is int)
                {
                    result = new Dictionary<string, int>() { { "int", (int)value } };
                }
                else if (value is IEnumerable<byte>)
                {
                    var bytes = value as IEnumerable<byte>;
                    var hex = string.Concat(bytes.Select(item => item.ToString("x2")));
                    result = new Dictionary<string, string>() { { "bytes", hex } };
                }
            }
            else if (value is IEnumerable)
            {
                var listResult = new List<object>();
                var valueEnumerable = value as IEnumerable;
                if (valueEnumerable != null)
                {
                    foreach (object o in valueEnumerable)
                    {
                        var pv = ProcessPropertyValue(o);

                        if (pv != null)
                            listResult.Add(pv);
                    }
                    result = new Dictionary<string, IEnumerable<object>>() { { "list", listResult } };
                }
            }
            else if (value is object)
            {
                result = new Dictionary<string, object>() { { "map", ConvertToCardanoObject(value) } };
            }
            return result;
        }

        private static bool IsValueAllowed(object value)
        {
            return value is string || value is int || value is IEnumerable<byte>;
        }
    }
}