using Exiled.Events.EventArgs;
using Exiled.API.Features.Items;
using Exiled.API.Enums;

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
            if (ev.IsTails)
            {
                ev.Player.ArtificialHealth += plugin.Config.CoinAHPGained;
                ev.Player.ShowHint(plugin.Config.CoinHint, plugin.Config.CoinHintDuration);
                if (plugin.Config.EnableEffect207)
                {
                    ev.Player.EnableEffect(EffectType.Scp207, plugin.Config.EffectDuration);
                }
            }
        }
        public void OnHurting(HurtingEventArgs ev)
        {
            if (plugin.Config.EnableCustomDamages)
            {
                if (ev.Attacker.Role.Type == RoleType.Scp93953 && ev.Attacker.Role.Type == RoleType.Scp93989)
                {
                    ev.Amount = plugin.Config.Scp939Damage;
                }
                if (ev.Attacker.Role.Type == RoleType.Scp0492)
                {
                    ev.Amount = plugin.Config.Scp0492Damage;
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
    }
}
