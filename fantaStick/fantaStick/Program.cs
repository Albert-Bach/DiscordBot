using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace fantaStick
{
    class Program
    {
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

        private DiscordSocketClient client;
        private CommandService commands;
        private IServiceProvider services;

        public async Task RunBotAsync()
        {
            client = new DiscordSocketClient();
            commands = new CommandService();

            services = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton(client)
                .BuildServiceProvider();

            string botToken = "NDAwOTk2ODQ2MzI5MTM1MTE1.DTj4tQ.nZA3RBGv5hfVJJNygz3l-FdAUHU";


            // event subscriptions
            client.Log += Log;

            await RegisterCommandAsync();

            await client.LoginAsync(TokenType.Bot, botToken);

            await client.StartAsync();

            await Task.Delay(-1);

        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);

            return Task.CompletedTask;
        }

        public async Task RegisterCommandAsync()
        {
            client.MessageReceived += HandleCommandAsync;

            await commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            if (message is null || message.Author.IsBot) return;

            int argumentPosition = 0;

            if (message.HasStringPrefix("!", ref argumentPosition) || message.HasMentionPrefix(client.CurrentUser, ref argumentPosition))
            {
                var context = new SocketCommandContext(client, message);

                var result = await commands.ExecuteAsync(context, argumentPosition, services);

                if (!result.IsSuccess)
                    Console.WriteLine(result.ErrorReason);

            }
        }
    }
}
