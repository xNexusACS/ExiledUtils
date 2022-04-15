using System;
using Exiled.API.Features;
using ExiledUtilsRemake_PlayerHandler = Exiled.Events.Handlers.Player;
using ExiledUtilsRemake_Scp096Handler = Exiled.Events.Handlers.Scp096;
using ExiledUtilsRemake_Scp049Handler = Exiled.Events.Handlers.Scp049;
using ExiledUtilsRemake_Scp106Handler = Exiled.Events.Handlers.Scp106;
using ExiledUtils_REMAKE.Enums;

namespace ExiledUtils_REMAKE
{
    public class MainClass : Plugin<Config>
    {
        public override string Author { get; } = "xNexus-ACS";
        public override string Name { get; } = "ExiledUtils-Remake";
        public override string Prefix { get; } = "exiled_utils_remake";
        public override Version Version { get; } = new Version(3, 1, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 1, 3);
        public const VersionType type = VersionType.Remake;

        public EventHandlers Ev;

        public override void OnEnabled()
        {
            if (type == VersionType.RemakeBeta)
            {
                Log.Debug("WARNING: You are running a Beta version of ExiledUtils-Remake!", Config.DebugLogs);
            }

            Ev = new EventHandlers(this);

            ExiledUtilsRemake_PlayerHandler.UsingRadioBattery += Ev.OnUsingRadioBattery;
            ExiledUtilsRemake_PlayerHandler.Shooting += Ev.OnShooting;
            ExiledUtilsRemake_PlayerHandler.WalkingOnTantrum += Ev.OnWalkingOnTantrum;
            ExiledUtilsRemake_PlayerHandler.FlippingCoin += Ev.OnFlippingCoin;
            ExiledUtilsRemake_PlayerHandler.UsingMicroHIDEnergy += Ev.OnUsingMicroEnergy;
            ExiledUtilsRemake_PlayerHandler.PreAuthenticating += Ev.OnPreAuthenticating;
            ExiledUtilsRemake_PlayerHandler.Dying += Ev.OnDying;
            ExiledUtilsRemake_Scp096Handler.AddingTarget += Ev.OnAddingTarget;
            ExiledUtilsRemake_Scp049Handler.FinishingRecall += Ev.OnReviving;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            ExiledUtilsRemake_PlayerHandler.UsingRadioBattery -= Ev.OnUsingRadioBattery;
            ExiledUtilsRemake_PlayerHandler.Shooting -= Ev.OnShooting;
            ExiledUtilsRemake_PlayerHandler.WalkingOnTantrum -= Ev.OnWalkingOnTantrum;
            ExiledUtilsRemake_PlayerHandler.FlippingCoin -= Ev.OnFlippingCoin;
            ExiledUtilsRemake_PlayerHandler.UsingMicroHIDEnergy -= Ev.OnUsingMicroEnergy;
            ExiledUtilsRemake_PlayerHandler.PreAuthenticating -= Ev.OnPreAuthenticating;
            ExiledUtilsRemake_PlayerHandler.Dying -= Ev.OnDying;
            ExiledUtilsRemake_Scp096Handler.AddingTarget -= Ev.OnAddingTarget;
            ExiledUtilsRemake_Scp049Handler.FinishingRecall -= Ev.OnReviving;

            Ev = null;
            base.OnDisabled();
        }
    }
}
