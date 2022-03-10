using Exiled.API.Interfaces;
using System.ComponentModel;

namespace ExiledUtils_REMAKE
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool DebugLogs { get; set; } = true;
        [Description("Enable Infinte Radio?")]
        public bool InfiniteRadio { get; set; } = true;
        [Description("Enable infinite ammo? (On Shooting)")]
        public bool InfiniteAmmo { get; set; } = false;
        [Description("Enable Infinite MicroHID?")]
        public bool InfiniteMicroHID { get; set; } = false;
        [Description("Scp096 Feature")]
        public string AddingTarget096Hint { get; set; } = string.Empty;
        public float AddingTargetHintDuration { get; set; } = 5f;
        public string AddingTargetHint { get; set; } = string.Empty;
        [Description("Are the SCPs inmune to the Tantrum?")]
        public bool SCPInmuneToTantrum { get; set; } = false;
        [Description("Coin Features")]
        public float CoinAHPGained { get; set; } = 10f;
        public string CoinHint { get; set; } = "<i><color=green>+10AHP</color></i>";
        public float CoinHintDuration { get; set; } = 5f;
        public bool EnableEffect207 { get; set; } = true;
        public float EffectDuration { get; set; } = 5f;
        [Description("Configurable Damage for 939 and 0492")]
        public bool EnableCustomDamages { get; set; } = true;
        public float Scp939Damage { get; set; } = 45f;
        public float Scp0492Damage { get; set; } = 40f;
    }
}
