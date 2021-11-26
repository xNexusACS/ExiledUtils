using System;
using Exiled.API.Features;
using ExiledUtils.Enums;
using PlayerHandler = Exiled.Events.Handlers.Player;
using ServerHandler = Exiled.Events.Handlers.Server;
using SCP173Handler = Exiled.Events.Handlers.Scp173;
using SCP106Handler = Exiled.Events.Handlers.Scp106;
using SCP914Handler = Exiled.Events.Handlers.Scp914;
using SCP096Handler = Exiled.Events.Handlers.Scp096;

namespace ExiledUtils
{
    public class Main : Plugin<Cfg>
    {
        public static Main Singleton;
        public override string Author { get; } = "xNexus-ACS";
        public override string Name { get; } = "ExiledUtils";
        public override string Prefix { get; } = "exiled_utils";
        public override Version Version { get; } = new Version(2, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);
        public const VersionType Type = VersionType.PluginRelease;
        public EventHandlers Ev;

        public override void OnEnabled()
        {
            Singleton = this;
            Log.Debug($"Plugin Version Type: {Type}", Main.Singleton.Config.Debug);
            Ev = new EventHandlers();

            PlayerHandler.UsingRadioBattery += Ev.OnUsingRadioBattery;
            PlayerHandler.Hurting += Ev.OnHurting;
            PlayerHandler.FlippingCoin += Ev.OnFlippingCoin;
            PlayerHandler.WalkingOnSinkhole += Ev.OnWalkingOnSinkhole;
            PlayerHandler.WalkingOnTantrum += Ev.OnWalkingOnTantrum;
            PlayerHandler.Shooting += Ev.OnShooting;
            ServerHandler.RoundStarted += Ev.OnRoundStarted;
            ServerHandler.RoundEnded += Ev.OnRoundEnded;
            SCP106Handler.Containing += Ev.OnContaining106;
            SCP173Handler.PlacingTantrum += Ev.OnPlacingTantrum;
            SCP914Handler.Activating += Ev.OnActivating914;
            SCP096Handler.AddingTarget += Ev.OnAddingTarget;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            PlayerHandler.UsingRadioBattery -= Ev.OnUsingRadioBattery;
            PlayerHandler.Hurting -= Ev.OnHurting;
            PlayerHandler.FlippingCoin -= Ev.OnFlippingCoin;
            PlayerHandler.WalkingOnSinkhole -= Ev.OnWalkingOnSinkhole;
            PlayerHandler.WalkingOnTantrum -= Ev.OnWalkingOnTantrum;
            PlayerHandler.Shooting -= Ev.OnShooting;
            ServerHandler.RoundStarted -= Ev.OnRoundStarted;
            ServerHandler.RoundEnded -= Ev.OnRoundEnded;
            SCP106Handler.Containing -= Ev.OnContaining106;
            SCP173Handler.PlacingTantrum -= Ev.OnPlacingTantrum;
            SCP914Handler.Activating -= Ev.OnActivating914;
            SCP096Handler.AddingTarget -= Ev.OnAddingTarget;

            Ev = null;
            base.OnDisabled();
        }
    }
}
