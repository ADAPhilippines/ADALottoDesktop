using System.Text.Json.Serialization;

namespace ADALotto.Models
{
	public class DaedalusLauncherConfig
	{
		[JsonPropertyName("stateDir")]
		public string StateDir { get; set; }
	}
}