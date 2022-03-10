using System;
using CommandSystem;
using Exiled.API.Features;

namespace ExiledUtils_REMAKE.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class BringZombies049 : ICommand
    {
        public string Command { get; } = "recall";
        public string[] Aliases { get; } = null;
        public string Description { get; } = "[EXILED-UTILS] Bring all Zombies, you need to be 049";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "";
            Player player = Player.Get(((CommandSender)sender).SenderId);
            if (player.Role.Type == RoleType.Scp049)
            {
                foreach (Player players in Player.List)
                {
                    if (players.Role.Type == RoleType.Scp0492)
                    {
                        players.Position = player.Position;
                        response = "Bringed All zombies";
                    }
                }
                if (response == "")
                {
                    response = "There aren't 049-2 alive";
                }
            }
            else
            {
                response = "You need to be 049 to execute this command";
            }
            return true;
        }
    }
}
