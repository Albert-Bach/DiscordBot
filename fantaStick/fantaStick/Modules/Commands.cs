using Discord.Commands;
using System.Threading.Tasks;

namespace fantaStick.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task PingAsync()
        {
            await ReplyAsync("Hello World!");
        }

        [Command("mifajta")]
        public async Task WhatKindOfAsync()
        {
            await ReplyAsync("https://www.youtube.com/watch?v=RaV-TY3ajk4");
        }
        
        [Command("fa")]
        public async Task WoodAsync()
        {
            await ReplyAsync("https://www.youtube.com/watch?v=jrbp0WoIBIs");
        }

        [Command("hova")]
        public async Task WhereAsync()
        {
            await ReplyAsync("Rácsra!");
        }

        [Command("rács")]
        public async Task CageAsync()
        {
            await ReplyAsync(" Az egyetlen hely a fejlődésre!");
        }

        [Command("ez")]
        public async Task ThisAsync()
        {
            await ReplyAsync("Már az.");
        }
    }
}