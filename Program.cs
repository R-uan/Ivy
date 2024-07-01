using Discord.WebSocket;
using Ivy.EventHandlers;
using Ivy.Utils;
using Microsoft.Extensions.Configuration;

var config = new DiscordSocketConfig
{
	GatewayIntents = Discord.GatewayIntents.All
};

var client = new DiscordSocketClient(config);

var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
.AddJsonFile("appsettings.secret.json", optional: false, reloadOnChange: true).Build();
var appSettings = new AppSettings();
configuration.GetSection("AppSettings").Bind(appSettings);

await client.LoginAsync(Discord.TokenType.Bot, appSettings.IvyToken);

client.Ready += ReadAsync;
client.MessageReceived += MessageHandler.MessageHandlerDelegator;
await client.StartAsync();

await Task.Delay(Timeout.Infinite);

Task ReadAsync()
{
	Console.WriteLine($"{client.CurrentUser} is logged in!");
	client
	.GetGuild(1052664028087992402)
	.GetTextChannel(1257102853772808294)
	.SendMessageAsync("Ivy arrived bitches!");
	return Task.CompletedTask;
}