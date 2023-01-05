using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.Loader;
using ExiledUtilsRemake_PlayerHandler = Exiled.Events.Handlers.Player;
using ExiledUtilsRemake_Scp096Handler = Exiled.Events.Handlers.Scp096;
using ExiledUtilsRemake_Scp049Handler = Exiled.Events.Handlers.Scp049;
using ExiledUtilsRemake_Scp106Handler = Exiled.Events.Handlers.Scp106;
using ExiledUtilsRemake_ServerHandler = Exiled.Events.Handlers.Server;
using ExiledUtils_REMAKE.Enums;
using HarmonyLib;

namespace ExiledUtils_REMAKE
{
    public class MainClass : Plugin<Config>
    {
        public static MainClass hub;
        public override string Author { get; } = "xNexus-ACS";
        public override string Name { get; } = "ExiledUtils-Remake";
        public override string Prefix { get; } = "exiled_utils_remake";
        public override Version Version { get; } = new Version(5, 0, 2);
        public override Version RequiredExiledVersion { get; } = new Version(6, 0, 0);
        public const VersionType type = VersionType.RemakeBeta;
        
        private static Harmony harmony;
        
        public bool CommonUtilsDetector = Loader.Plugins.Any(p => p.Name == "Common Utilities" && p.Config.IsEnabled);
        
        public List<Player> JailedPlayers = new();

        public EventHandlers Ev { get; private set; }

        public override void OnEnabled()
        {
            if (type == VersionType.RemakeBeta)
            {
                Log.Warn("WARNING: You are running a Beta version of ExiledUtils-Remake!");
            }

            hub = this;
            Ev = new EventHandlers(this);
            harmony = new Harmony("exiledutils.remake");
            harmony.PatchAll();

            ExiledUtilsRemake_PlayerHandler.UsingRadioBattery += Ev.OnUsingRadioBattery;
            ExiledUtilsRemake_PlayerHandler.Shooting += Ev.OnShooting;
            ExiledUtilsRemake_PlayerHandler.FlippingCoin += Ev.OnFlippingCoin;
            ExiledUtilsRemake_PlayerHandler.UsingMicroHIDEnergy += Ev.OnUsingMicroEnergy;
            ExiledUtilsRemake_PlayerHandler.Dying += Ev.OnDying;
            ExiledUtilsRemake_Scp096Handler.AddingTarget += Ev.OnAddingTarget;
            ExiledUtilsRemake_Scp049Handler.FinishingRecall += Ev.OnRevived;
            ExiledUtilsRemake_Scp049Handler.StartingRecall += Ev.OnReviving;
            ExiledUtilsRemake_PlayerHandler.PreAuthenticating += Ev.OnPreAuth;
            ExiledUtilsRemake_PlayerHandler.ChangingRole += Ev.OnChangingRole;
            ExiledUtilsRemake_PlayerHandler.Verified += Ev.OnVerified;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            ExiledUtilsRemake_PlayerHandler.UsingRadioBattery -= Ev.OnUsingRadioBattery;
            ExiledUtilsRemake_PlayerHandler.Shooting -= Ev.OnShooting;
            ExiledUtilsRemake_PlayerHandler.FlippingCoin -= Ev.OnFlippingCoin;
            ExiledUtilsRemake_PlayerHandler.UsingMicroHIDEnergy -= Ev.OnUsingMicroEnergy;
            ExiledUtilsRemake_PlayerHandler.Dying -= Ev.OnDying;
            ExiledUtilsRemake_Scp096Handler.AddingTarget -= Ev.OnAddingTarget;
            ExiledUtilsRemake_Scp049Handler.FinishingRecall -= Ev.OnRevived;
            ExiledUtilsRemake_Scp049Handler.StartingRecall -= Ev.OnReviving;
            ExiledUtilsRemake_PlayerHandler.PreAuthenticating -= Ev.OnPreAuth;
            ExiledUtilsRemake_PlayerHandler.ChangingRole -= Ev.OnChangingRole;
            ExiledUtilsRemake_PlayerHandler.Verified -= Ev.OnVerified;

            JailedPlayers.Clear();
            
            Ev = null;
            hub = null;
            harmony.UnpatchAll(harmony.Id);
            base.OnDisabled();
        }
    }
}
