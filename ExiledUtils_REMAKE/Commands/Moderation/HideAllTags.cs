using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using RemoteAdmin;

namespace ExiledUtils_REMAKE.Commands.Moderation
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class HideAllTags : ICommand
    {
        public string Command { get; } = "hidealltags";
        public string[] Aliases { get; } = new string[] { "hdat" };
        public string Description { get; } = "Hides all tags from players";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender player)
            {
                if (player.CheckPermission("eu.hidealltags"))
                {
                    if (arguments.Count == 0)
                    {
                        if (MainClass.hub.Config.HideTags)
                        {
                            MainClass.hub.Config.HideTags = false;

                            foreach (Player targets in Player.List)
                                targets.BadgeHidden = false;
                            
                            response = "HideAllTags is now disabled";
                            return true;
                        }
                        MainClass.hub.Config.HideTags = true;
                        
                        foreach (Player targets in Player.List)
                            targets.BadgeHidden = true;
                        
                        response = "HideAllTags is now enabled";
                        return true;
                    }
                    response = "Usage: hidealltags <true/false>";
                    return false;
                }
                response = "You don't have permission to use this command";
                return false;
            }
            response = "You must be a player to use this command";
            return false;
        }
    }
}