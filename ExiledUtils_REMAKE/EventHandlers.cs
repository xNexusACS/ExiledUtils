using Exiled.API.Features.Items;
using Exiled.API.Enums;
using Exiled.API.Features;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Extensions;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp049;
using Exiled.Events.EventArgs.Scp096;
using LiteNetLib;
using MEC;
using PlayerRoles;
using UnityEngine;

namespace ExiledUtils_REMAKE
{
    public class EventHandlers
    {
        private readonly MainClass plugin;
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
                ev.Target.Role.Set(RoleTypeId.Scp0492, SpawnReason.Revived);
                ev.Target.ClearInventory();
                ev.Ragdoll.Destroy();

                Timing.CallDelayed(0.8f, () =>
                {
                    ev.Target.Position = ev.Player.Position;
                });
            }
        }

        public void OnPreAuth(PreAuthenticatingEventArgs ev)
        {
            var group = Server.PermissionsHandler.GetUserGroup(ev.UserId);
            if (group != null)
            {
                if (MainClass.hub.Config.ReservedGroups.Contains(group.GetKey()))
                    ev.Request.Result = ConnectionRequestResult.Accept;
                Log.Debug($"{ev.UserId}: {group} || {ev.IsAllowed}");
            }
        }

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (MainClass.hub.Config.FixTutorialPosition)
                if (ev.NewRole is RoleTypeId.Tutorial)
                    ev.Player.Position = new Vector3(40.297f, 1014.110f, -31.918f);
        }

        public void OnVerified(VerifiedEventArgs ev)
        {
            if (MainClass.hub.Config.HideTags)
                if (ev.Player.ReferenceHub.serverRoles.RemoteAdmin)
                    ev.Player.BadgeHidden = true;

            if (MainClass.hub.JailedPlayers.Contains(ev.Player) && ev.Player.Role.Type is not RoleTypeId.Tutorial && Round.IsStarted)
            {
                ev.Player.Role.Set(RoleTypeId.Tutorial);
                
                // Just in case if the FixTutorialPosition is disabled or fails to move the player
                Timing.CallDelayed(1f, () => ev.Player.Position = new Vector3(40.185f, 1014.109f, -30.439f));
            }
        }
    }
}
