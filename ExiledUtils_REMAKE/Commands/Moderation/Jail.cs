using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using PlayerRoles;

namespace ExiledUtils_REMAKE.Commands.Moderation
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Jail : ICommand
    {
        public string Command { get; }  = "prison";
        public string[] Aliases { get; } = null;
        public string Description { get; } = "Jails a player.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player target = Player.Get(arguments.At(0));

            if (!sender.CheckPermission("eu.jail"))
            {
                response = "You do not have permission to use this command.";
                return false;
            }
            
            if (arguments.Count is 0 || target is null)
            {
                response = "Unknown Target";
                return false;
            }

            if (!MainClass.hub.JailedPlayers.Contains(target))
            {
                target.Role.Set(RoleTypeId.Tutorial);
                MainClass.hub.JailedPlayers.Add(target);
                response = "Player has been jailed.";
                return true;
            }
            target.Role.Set(RoleTypeId.Spectator);
            MainClass.hub.JailedPlayers.Remove(target);
            response = "Player has been unjailed.";
            return true;
        }
    }
}