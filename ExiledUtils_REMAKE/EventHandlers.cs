using Exiled.Events.EventArgs;
using Exiled.API.Features.Items;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Extensions;
using System.Collections.Generic;
using System.Linq;
using ExiledUtils_REMAKE.Components;

namespace ExiledUtils_REMAKE
{
    public class EventHandlers
    {
        public MainClass plugin;
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
            if (plugin.Config.InfiniteAmmo && ev.Shooter?.CurrentItem is Firearm firearm)
                firearm.Ammo++;
        }
        public void OnAddingTarget(AddingTargetEventArgs ev)
        {
            ev.Scp096.ShowHint(plugin.Config.AddingTarget096Hint, plugin.Config.AddingTargetHintDuration);
            ev.Target.ShowHint(plugin.Config.AddingTargetHint, plugin.Config.AddingTargetHintDuration);
        }
        public void OnWalkingOnTantrum(WalkingOnTantrumEventArgs ev)
        {
            ev.Tantrum.SCPImmune = plugin.Config.SCPInmuneToTantrum;
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
        public void OnPreAuthenticating(PreAuthenticatingEventArgs ev)
        {
            var group = Server.PermissionsHandler.GetUserGroup(ev.UserId);
            if (group == null) return;

            bool reserved = plugin.Config.ReservedGroups.Contains(group.GetKey());
            if (reserved) ev.IsAllowed = true;
            Log.Debug($"{ev.UserId}: {group.GetKey()} | {reserved}", plugin.Config.DebugLogs);
        }
        public void OnDying(DyingEventArgs ev)
        {
            if (plugin.Config.EnableLastPlayerText)
            {
                List<Player> player = Player.Get(ev.Target.Role.Team).ToList();
                if (player.Count - 1 == 1)
                {
                    if (player[0] == ev.Target)
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
        public void OnReviving(FinishingRecallEventArgs ev)
        {
            if (plugin.Config.Enable049BuffWhenReviving)
            {
                ev.Scp049.ArtificialHealth += 20;
                ev.Scp049.EnableEffect(EffectType.MovementBoost, 10);
            }
        }
        // RainbowTags
        private bool TryGetColors(string rank, out string[] availableColors)
        {
            availableColors = this.plugin.Config.RTSequences;
            return !string.IsNullOrEmpty(rank) && this.plugin.Config.RoleRainbowTags.Contains(rank);
        }
        private bool EqualsTo(UserGroup @this, UserGroup other)
        {
            return @this.BadgeColor == other.BadgeColor && @this.BadgeText == other.BadgeText && @this.Permissions == other.Permissions && @this.Cover == other.Cover && @this.HiddenByDefault == other.HiddenByDefault && @this.Shared == other.Shared && @this.KickPower == other.KickPower && @this.RequiredKickPower == other.RequiredKickPower;
        }
        private string GetGroupKey(UserGroup group)
        {
            if (group == null)
            {
                return string.Empty;
            }
            return ServerStatic.PermissionsHandler._groups.FirstOrDefault((KeyValuePair<string, UserGroup> g) => this.EqualsTo(g.Value, group)).Key ?? string.Empty;
        }
        public void OnChangingGroup(ChangingGroupEventArgs ev)
        {
            if (!ev.IsAllowed)
            {
                return;
            }
            string[] colors;
            bool flag = this.TryGetColors(this.GetGroupKey(ev.NewGroup), out colors);
            if (ev.NewGroup != null && ev.Player.Group == null && flag)
            {
                RainbowTagController rtController = ev.Player.GameObject.AddComponent<RainbowTagController>();
                rtController.Colors = colors;
                rtController.Interval = this.plugin.Config.ColorInterval;
                return;
            }
            if (flag)
            {
                ev.Player.GameObject.GetComponent<RainbowTagController>().Colors = colors;
                return;
            }
            UnityEngine.Object.Destroy(ev.Player.GameObject.GetComponent<RainbowTagController>());
        }
    }
}
