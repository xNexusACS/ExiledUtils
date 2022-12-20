using Exiled.API.Features.Items;
using Exiled.API.Enums;
using Exiled.API.Features;
using System.Collections.Generic;
using System.Linq;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp049;
using Exiled.Events.EventArgs.Scp096;
using MEC;
using PlayerRoles;

namespace ExiledUtils_REMAKE
{
    public class EventHandlers
    {
        public readonly MainClass plugin;
        public EventHandlers(MainClass plugin)
        {
            this.plugin = plugin;
        }
        public void OnUsingRadioBattery(UsingRadioBatteryEventArgs ev)
        {
            if (plugin.Config.InfiniteRadio)
            {
                ev.IsAllowed = false;
            }
        }
        public void OnShooting(ShootingEventArgs ev)
        {
            if (plugin.Config.InfiniteAmmo && ev.Player?.CurrentItem is Firearm firearm)
                firearm.Ammo++;
        }
        public void OnAddingTarget(AddingTargetEventArgs ev)
        {
            ev.Player.ShowHint(plugin.Config.AddingTarget096Hint, plugin.Config.AddingTargetHintDuration);
            ev.Target.ShowHint(plugin.Config.AddingTargetHint, plugin.Config.AddingTargetHintDuration);
        }
        public void OnFlippingCoin(FlippingCoinEventArgs ev)
        {
            if (plugin.Config.EnableCoinFeatures)
            {
                if (ev.IsTails)
                {
                    ev.Player.EnableEffect(EffectType.MovementBoost, plugin.Config.EffectDuration);
                }
            }
        }
        public void OnUsingMicroEnergy(UsingMicroHIDEnergyEventArgs ev)
        {
            if (plugin.Config.InfiniteMicroHID)
            {
                ev.IsAllowed = false;
            }
        }
        public void OnDying(DyingEventArgs ev)
        {
            if (plugin.Config.EnableLastPlayerText)
            {
                List<Player> player = Player.Get(ev.Player.Role.Team).ToList();
                if (player.Count - 1 == 1)
                {
                    if (player[0] == ev.Player)
                    {
                        player[1].ShowHint(plugin.Config.LastPlayerHint, plugin.Config.LastPlayerHintDuration);
                    }
                    else
                    {
                        player[0].ShowHint(plugin.Config.LastPlayerHint, plugin.Config.LastPlayerHintDuration);
                    }
                }
            }
        }
        public void OnRevived(FinishingRecallEventArgs ev)
        {
            if (plugin.Config.Enable049BuffWhenReviving)
            {
                ev.Player.ActiveArtificialHealthProcesses.First().CurrentAmount = 100;
                ev.Player.ActiveArtificialHealthProcesses.First().DecayRate = 0;
                ev.Player.EnableEffect(EffectType.MovementBoost, 10);
                
                if (plugin.Config.EnableHealthWhenReviving)
                    ev.Player.Heal(plugin.Config.HealthWhenReviving);
            }
        }

        public void OnReviving(StartingRecallEventArgs ev)
        {
            if (plugin.Config.Enable049InstantRevive)
            {
                ev.IsAllowed = false;
                ev.Target.SetRole(RoleTypeId.Scp0492, SpawnReason.Revived);
                ev.Target.ClearInventory();
                ev.Ragdoll.Delete();

                Timing.CallDelayed(0.8f, () =>
                {
                    ev.Target.Position = ev.Player.Position;
                });
            }
        }
    }
}
