using System.Text.Json.Serialization;

namespace Ivy.DataTypes
{
	public readonly struct WarframeInvasion
	{
		[JsonPropertyName("id")]
		public string Id { get; init; }

		[JsonPropertyName("activation")]
		public DateTime Activation { get; init; }

		[JsonPropertyName("startString")]
		public string StartString { get; init; }

		[JsonPropertyName("node")]
		public string Node { get; init; }

		[JsonPropertyName("nodeKey")]
		public string NodeKey { get; init; }

		[JsonPropertyName("desc")]
		public string Desc { get; init; }

		[JsonPropertyName("attackingFaction")]
		public string AttackingFaction { get; init; }

		[JsonPropertyName("attacker")]
		public FactionDetails Attacker { get; init; }

		[JsonPropertyName("defender")]
		public FactionDetails Defender { get; init; }

		[JsonPropertyName("vsInfestation")]
		public bool VsInfestation { get; init; }

		[JsonPropertyName("count")]
		public int Count { get; init; }

		[JsonPropertyName("requiredRuns")]
		public int RequiredRuns { get; init; }

		[JsonPropertyName("completion")]
		public double Completion { get; init; }

		[JsonPropertyName("completed")]
		public bool Completed { get; init; }

		[JsonPropertyName("eta")]
		public string Eta { get; init; }

		[JsonPropertyName("rewardTypes")]
		public List<string> RewardTypes { get; init; }
	}

	public readonly struct FactionDetails
	{
		[JsonPropertyName("reward")]
		public Reward Reward { get; init; }

		[JsonPropertyName("faction")]
		public string Faction { get; init; }

		[JsonPropertyName("factionKey")]
		public string FactionKey { get; init; }
	}

	public readonly struct Reward
	{
		[JsonPropertyName("items")]
		public List<string> Items { get; init; }

		[JsonPropertyName("countedItems")]
		public List<CountedItem> CountedItems { get; init; }

		[JsonPropertyName("credits")]
		public int Credits { get; init; }

		[JsonPropertyName("asString")]
		public string AsString { get; init; }

		[JsonPropertyName("itemString")]
		public string ItemString { get; init; }

		[JsonPropertyName("thumbnail")]
		public string Thumbnail { get; init; }

		[JsonPropertyName("color")]
		public int Color { get; init; }
	}

	public readonly struct CountedItem
	{
		[JsonPropertyName("count")]
		public int Count { get; init; }

		[JsonPropertyName("type")]
		public string Type { get; init; }

		[JsonPropertyName("key")]
		public string Key { get; init; }
	}
}
