using Discord;
using Discord.Commands;
using Discord.WebSocket;

public class UserCommandsController : ModuleBase<SocketCommandContext>
{
    [Command("avatar")] //Only avatar command without mentions for the moment
    public async Task AvatarAsync(SocketGuildUser? user = null)
    {
        //If it's not a user mentioned, it uses the author of the message
        user ??= (SocketGuildUser)Context.User;

        //Get de avatar URL
        string avatarUrl = user.GetAvatarUrl(size:1024) ?? user.GetDefaultAvatarUrl();

        //Send the message with the avatar URL
        var embed = new EmbedBuilder()
            .WithTitle($"Avatar de {user.Username}")
            .WithImageUrl(avatarUrl)
            .WithTimestamp(DateTime.Now)
            .WithColor(Color.Blue)
            .Build();

        await Context.Channel.SendMessageAsync(embed: embed);
    }

    [Command("userinfo")]
    public async Task UserInfoAsync(SocketGuildUser? user = null)
    {
        user ??= (SocketGuildUser)Context.User;

        //Get de avatar URL
        string avatarUrl = user.GetAvatarUrl(size: 1024) ?? user.GetDefaultAvatarUrl();

        var embed = new EmbedBuilder()
            .WithTitle($"Datos del usuario {user.DisplayName}")
            .WithTimestamp(DateTime.Now)
            .WithImageUrl(avatarUrl)
            .WithDescription("**ID:** " + user.Id + 
            Environment.NewLine + 
            "**Nombre:** " + user.Username +
            Environment.NewLine +
            "**Roles:** " + user.Roles.Count() +
            Environment.NewLine + 
            "**Fecha de ingreso:** " + user.JoinedAt + 
            Environment.NewLine + 
            "**Fecha de creación:** " + user.CreatedAt +
            Environment.NewLine + 
            Environment.NewLine + 
            "**Avatar:**" 
            )
            .Build();

        await Context.Channel.SendMessageAsync(embed: embed);
    }
}
