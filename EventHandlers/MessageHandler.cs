using Discord;
using Ivy.Requests;
using Ivy.DataTypes;
using Discord.WebSocket;

namespace Ivy.EventHandlers
{
	public static class MessageHandler
	{

		public static async Task MessageHandlerDelegator(SocketMessage message)
		{
			if (message.Content.StartsWith("!invasions")) await WarframeInvasions(message);
		}
		public static async Task WarframeInvasions(SocketMessage message)
		{
			try
			{
				if (message.Content.StartsWith("!invasions"))
				{
					List<WarframeInvasion>? invasions = await WarframeRequests.GetInvasions();
					if (invasions != null)
					{
						foreach (var invasion in invasions)
						{
							var embed = new EmbedBuilder() { Color = Color.DarkRed };

							var confrontField = new EmbedFieldBuilder()
							.WithName("Location & ETA")
							.WithValue($"{invasion.Node} \n {invasion.Eta}")
							.WithIsInline(true);

							var rewardsField = new EmbedFieldBuilder()
							.WithName("Possible Rewards")
							.WithValue($"{invasion.Attacker.Reward.AsString} \n {invasion.Defender.Reward.AsString}")
							.WithIsInline(true);

							embed.WithTitle($"{invasion.Attacker.Faction} x {invasion.Defender.Faction}")
							.WithFields([rewardsField, confrontField]).WithCurrentTimestamp()
							.WithFooter(footer => footer.Text = "Data got from official API");
							await message.Channel.SendMessageAsync(embed: embed.Build());
						}
					}
					return;
				}
			}
			catch (System.Exception ex)
			{
				var embed = new EmbedBuilder() { Color = Color.Red };
				embed
				.WithTitle("Someone tell r.uan there's a problem with his bot.")
				.WithDescription(ex.Message);
				await message.Channel.SendMessageAsync(embed: embed.Build());
			}
		}
	}
}