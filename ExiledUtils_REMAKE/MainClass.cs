using System;
using Exiled.API.Features;
using ExiledUtilsRemake_PlayerHandler = Exiled.Events.Handlers.Player;
using ExiledUtilsRemake_Scp096Handler = Exiled.Events.Handlers.Scp096;
using ExiledUtilsRemake_Scp049Handler = Exiled.Events.Handlers.Scp049;
using ExiledUtilsRemake_Scp106Handler = Exiled.Events.Handlers.Scp106;
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
        public override Version Version { get; } = new Version(5, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(6, 0, 0);
        public const VersionType type = VersionType.RemakeBeta;
        
        private static Harmony harmony;

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
            
            Ev = null;
            hub = null;
            harmony.UnpatchAll(harmony.Id);
            base.OnDisabled();
        }
    }
}
