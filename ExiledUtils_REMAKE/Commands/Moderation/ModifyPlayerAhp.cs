using CommandSystem;
using System;
using Exiled.Permissions.Extensions;
using Exiled.API.Features;

namespace ExiledUtils_REMAKE.Commands.Moderation
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ModifyPlayerAhp : ICommand
    {
        public string Command { get; } = "modifyplayerahp";
        public string[] Aliases { get; } = new string[] { "mpahp" };
        public string Description { get; } = "Modify a player's ahp.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player target = Player.Get(arguments.At(0));
            
            Player senderPlayer = Player.Get(sender);
            if (!senderPlayer.CheckPermission("eu.modifyplayerahp"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }
            
            if (target == null)
            {
                response = "Player not found.";
                return false;
            }
            
            if (arguments.At(1) == null)
            {
                response = "Please specify a value.";
                return false;
            }
            target.ArtificialHealth = float.Parse(arguments.At(1));
            response = "Successfully modified " + target.Nickname + "'s ahp to " + arguments.At(1) + ".";
            return true;
        }
    }
}