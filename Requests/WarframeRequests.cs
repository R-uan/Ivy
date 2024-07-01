using System.Text.Json;
using Ivy.DataTypes;

namespace Ivy.Requests
{
	public static class WarframeRequests
	{
		private static readonly Uri BaseURL = new("https://api.warframestat.us/pc/");
		private static readonly JsonSerializerOptions JsonConfig = new(JsonSerializerDefaults.Web);
		public static async Task<List<WarframeInvasion>?> GetInvasions()
		{
			HttpClient client = new() { BaseAddress = BaseURL };
			var request = await client.GetAsync("invasions");
			var response = request.Content.ReadAsStream();
			var invasions = await JsonSerializer.DeserializeAsync<List<WarframeInvasion>>(response, JsonConfig);
			return invasions;
		}
	}
}