using Ivy.Utils;
using Discord.WebSocket;
using Ivy.EventHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var client = new DiscordSocketClient(config: new DiscordSocketConfig()
{
	GatewayIntents = Discord.GatewayIntents.All
});

//
//	What do:
//		Who doesn't love dependency injection :)))).
//		Totally not an overcomplication of this application.
//
var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped<MessageHandler>();
serviceCollection.AddSingleton<LoggerConfig>();
var serviceProvider = serviceCollection.BuildServiceProvider();
var logger = serviceProvider.GetService<LoggerConfig>()!.Log;
//
//	What do:
//		Configuration of appsettings to use it's secret values.
//
//	Warning:
//		If you cloned this repository you need to create the file yourself.
//
var appSettings = new AppSettings();
new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
.AddJsonFile("appsettings.secret.json", optional: false, reloadOnChange: true).Build()
.GetSection("AppSettings").Bind(appSettings);
//
//	What do:
//		Subscribes to client events.
//		The bot listen to the events sent by on the discord gateway.
//
client.Ready += HandleReadyEvent;
client.LoggedOut += HandleDisconnectEvent;
client.MessageReceived += serviceProvider.GetService<MessageHandler>()!.MessageHandlerDelegator;
//
//	What do:
//		Logs in the bot and starts the application.
//
//	Warning:
//		You must provide the token on the appsettings.
//		The `Timeout.Infinite`delay so the program doesnt end once all is run.
//
await client.LoginAsync(Discord.TokenType.Bot, appSettings.IvyToken);
await client.StartAsync();
await Task.Delay(Timeout.Infinite);
//
//	What do:
//		Handles the Ready event.
//		The BOT sends a message on the provided server/channel.
//
//	Warning:
//		You need to change it to your server and channel ID.
//
Task HandleReadyEvent()
{
	logger.Info($"{client.CurrentUser.Username} is now connected!");
	client.GetGuild(1052664028087992402).GetTextChannel(1257102853772808294)
	.SendMessageAsync("Hello");
	return Task.CompletedTask;
}
//
//	Summary:
//		Handles the Logout event.
//		Just logs it on the console.
//
Task HandleDisconnectEvent()
{
	logger.Info($"{client.CurrentUser.Username} f'ing died!");
	return Task.CompletedTask;
}