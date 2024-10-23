using Discord.Commands;
using System.Threading.Tasks;

public class InfoModule : ModuleBase<SocketCommandContext>
{
    [Command("ping")]
    public async Task PingAsync()
    {
        await Context.Channel.SendMessageAsync("Pong!");
    }
}
