using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using NuggieBot.Commands.Handler;

namespace NuggieBot
{
    class MainClass
    {
        public static void Main(string[] args) => new MainClass().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient? _client;
        private static CommandService? _commands;
        private CommandHandler? _commandHandler;

        public async Task MainAsync()
        {
            var config = new DiscordSocketConfig
            {
                // Configure the necesary Gateway Intents 
                GatewayIntents = GatewayIntents.Guilds
                               | GatewayIntents.GuildMessages
                               | GatewayIntents.MessageContent
                               | GatewayIntents.GuildMembers 
                               | GatewayIntents.GuildWebhooks
                               | GatewayIntents.GuildEmojis,
                AlwaysDownloadUsers = true
            };

            _client = new DiscordSocketClient(config); // Make sure to put the config here

            var token = Configuration.Token;

            // Logs to console
            _client.Log += Log;

            _commands = new CommandService();

            _commandHandler = new CommandHandler(_client, _commands);
            await _commandHandler.InstallCommandsAsync();

            // Uses the token to start the bot
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await _client.SetGameAsync("n!help");

            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}