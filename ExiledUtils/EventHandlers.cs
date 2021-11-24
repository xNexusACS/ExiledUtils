using Exiled.Events.EventArgs;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace ExiledUtils
{
    public class EventHandlers
    {
        public void OnUsingRadioBattery(UsingRadioBatteryEventArgs ev)
        {
            ev.IsAllowed = Main.Singleton.Config.RadioCfg.InfiniteRadio;
        }
        public void OnHurting(HurtingEventArgs ev)
        {
            switch (ev.DamageType.Weapon)
            {
                case ItemType.GunRevolver:
                    {
                        ev.Amount = Main.Singleton.Config.WDMG.RevolverDMG;
                        break;
                    }
                case ItemType.GunShotgun:
                    {
                        ev.Amount = Main.Singleton.Config.WDMG.ShotgunDMG;
                        break;
                    }
                case ItemType.GunLogicer:
                    {
                        ev.Amount = Main.Singleton.Config.WDMG.LogicerDMG;
                        break;
                    }
                case ItemType.GunAK:
                    {
                        ev.Amount = Main.Singleton.Config.WDMG.AKDMG;
                        break;
                    }
                case ItemType.GrenadeHE:
                    {
                        ev.Amount = Main.Singleton.Config.WDMG.FragGrenadeDMG;
                        break;
                    }
            }
            switch (ev.DamageType.Scp)
            {
                case RoleType.Scp93953:
                    {
                        ev.Amount = Main.Singleton.Config.Scp939Damage.Scp93953DMG;
                        break;
                    }
                case RoleType.Scp93989:
                    {
                        ev.Amount = Main.Singleton.Config.Scp939Damage.Scp93989DMG;
                        break;
                    }
            }
        }
        public void OnFlippingCoin(FlippingCoinEventArgs ev)
        {
            if (ev.IsTails)
            {
                ev.Player.ArtificialHealth += Main.Singleton.Config.FC.AHPGained;
                ev.Player.ShowHint(Main.Singleton.Config.FC.Hint, Main.Singleton.Config.FC.HintDuration);
                ev.Player.EnableEffect(EffectType.Scp207, Main.Singleton.Config.FC.EffectDuration);
            }
        }
        public void OnWalkingOnSinkhole(WalkingOnSinkholeEventArgs ev)
        {
            ev.Player.EnableEffect(EffectType.Corroding);
            ev.Player.EnableEffect(EffectType.SinkHole);
        }
        public void OnWalkingOnTantrum(WalkingOnTantrumEventArgs ev)
        {
            ev.Tantrum.SCPImmune = Main.Singleton.Config.TantrumConfig.SCPInmune;
            ev.Player.EnableEffect(EffectType.Hemorrhage, Main.Singleton.Config.TantrumConfig.TantrumEffectDuration);
        }
        public void OnContaining106(ContainingEventArgs ev)
        {
            ev.ButtonPresser.ShowHint(Main.Singleton.Config.Containing106.ButtonPresserHint, Main.Singleton.Config.Containing106.ButtonPresserHintDuration);
            ev.ButtonPresser.EnableEffect(EffectType.SinkHole, Main.Singleton.Config.Containing106.ButtonPresserEffectDuration);
        }
        public void OnPlacingTantrum(PlacingTantrumEventArgs ev)
        {
            ev.Cooldown = Main.Singleton.Config.TantrumConfig.TantrumCooldown;
            ev.Player.ShowHint(Main.Singleton.Config.TantrumConfig.Hint, Main.Singleton.Config.TantrumConfig.HintDuration);
        }
        public void OnActivating914(ActivatingEventArgs ev)
        {
            Log.Debug("914 Activated", Main.Singleton.Config.Debug);
        }
        public void OnRoundStarted()
        {
            Log.Debug("Round Started", Main.Singleton.Config.Debug);
        }
        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            Log.Debug("Round Ended", Main.Singleton.Config.Debug);
        }
    }
}
