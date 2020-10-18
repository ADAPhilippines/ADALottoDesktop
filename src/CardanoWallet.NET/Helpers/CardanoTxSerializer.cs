using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace SAIB.CardanoWallet.NET.Helpers
{
    public abstract class CardanoTxSerializer
    {
        public static string Serialize(object o)
        {
            Dictionary<string, object[]> resultDict = new Dictionary<string,  object[]>();
            KeyValuePair<string, string> kv = new KeyValuePair<string, string>("string", "key");
            var propInfos = o.GetType().GetProperties();
            foreach(var pI in propInfos)
            {
                var propVal = pI.GetValue(o);
                ProcessValue(propVal);
            };
            return string.Empty;
        }

        private static void ProcessValue(object propertyValue)
        {

        }
    }
}