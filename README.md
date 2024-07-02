# Ivy
Ivy is a personal discord bot created using Discord.NET library. This bot is made for a one man discord server that I use as a notebook.

## Usage
1. Clone the repository: `git clone https://github.com/R-uan/Ivy.git`
2. On the root folder, create a file named `appsettings.secrets.json` where you will store your secret token in the format:
```
{
"AppSettings": {
  "YourBotToken": "super-secret-token-that-you-get-on-discord-developer-page"
	}
}
```
3. Run the application with `dotnet run` and wait until the console logs the successful connection with the Discord Gateway.
