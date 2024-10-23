using Discord;
using Discord.Commands;
using System.Threading.Tasks;

public class GeneralCommandsController : ModuleBase<SocketCommandContext>
{
    [Command("ping")]
    public async Task PingAsync()
    {
        var latency = Context.Client.Latency;
        var embed = new EmbedBuilder()
            .WithDescription(
                "**Latencia:** " + $"**{latency}** ms" 
            )
            .Build();

        await Context.Channel.SendMessageAsync(embed: embed);
    }

    [Command("help")]
    public async Task HelpAsync()
    {
        var embed = new EmbedBuilder()
            .WithTitle("Ayuda")
            .WithTimestamp(DateTime.Now)
            .WithDescription(
            "**Lista de comandos**" +
            Environment.NewLine +
            Environment.NewLine +
            "**----- GENERAL --------** " +
            Environment.NewLine +
            "**dance:**: Hazme bailar" +
            Environment.NewLine +
            "**roleinfo @rol:** Te da información de un rol especifico" +
            Environment.NewLine +
            Environment.NewLine +
            "**----- USUARIO --------** " +
            Environment.NewLine +
            "**avatar:** Muestra tu avatar" +
            Environment.NewLine +
            "**userinfo:** Muestra la información del usuario"
            )
            .Build();

        await Context.Channel.SendMessageAsync(embed: embed);
    }

    [Command("dance")]
    public async Task DanceAsync()
    {
        //Gif list
        var links = new[]
        {
            "https://tenor.com/view/nugget-chicken-meme-tt-tiktok-gif-9283300680097326569",
            "https://tenor.com/view/daitroksgiphy-roblox-nugget-nugget-nugget-man-face-roblox-man-face-gif-10810858097811346437",
            "https://tenor.com/view/%D0%BC%D0%B5%D0%BC-%D0%BD%D0%B0%D0%B3%D0%B5%D1%82%D1%81-%D0%BA%D1%83%D1%80%D0%BE%D1%87%D0%BA%D0%B0-%D0%B5%D0%B4%D0%B0-%D0%BF%D1%80%D0%B8%D0%BA%D0%BE%D0%BB-gif-4455959319203028247",
            "https://tenor.com/view/nuggets-gif-832260538225332835",
            "https://tenor.com/view/roblox-nugget-roblox-man-face-roblox-man-face-nugget-gif-736314989309895412",
            "https://tenor.com/view/%D0%BA%D0%BE%D1%82-%D1%87%D0%B0%D0%B2%D0%BA%D0%B0%D0%B5%D1%82-gif-18213250336849401449"
        };

        var random = new Random();
        var randomLink = links[random.Next(links.Length)];
        await Context.Channel.SendMessageAsync(randomLink);
    }

    [Command("roleinfo")]
    public async Task RoleInfoAsync(IRole role)
    {
        var embed = new EmbedBuilder()
            .WithTitle($"Información de rol: {role.Name}")
            .WithTimestamp( DateTime.Now )
            .WithDescription("Rol ID : " + role.Id + 
            Environment.NewLine + 
            "Nombre : " + role.Name + 
            Environment.NewLine + 
            "Mención : " + role.Mention + 
            Environment.NewLine + 
            "Color (HEX) : " + role.Color.ToString() + 
            Environment.NewLine + 
            "Creado en : " + role.CreatedAt.DateTime)
            .Build();
        await Context.Channel.SendMessageAsync(embed: embed);
    }
}
