using Exiled.API.Interfaces;
using System.ComponentModel;
using System.Collections.Generic;

namespace ExiledUtils_REMAKE
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        
        [Description("Fix the tutorial position when changing the role to tutorial?")]
        public bool FixTutorialPosition { get; set; } = true;
        [Description("Hide all tags player tags? (Can be toggled with the command hdat")]
        public bool HideTags { get; set; } = false;
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
        [Description("Coin Features")]
        public bool EnableCoinFeatures { get; set; } = false;
        public float EffectDuration { get; set; } = 5f;
        [Description("ReservedSlots")]
        public List<string> ReservedGroups { get; set; } = new List<string>
        {
            "owner", "admin", "moderator", "donator"
        };
        [Description("Last Player")]
        public bool EnableLastPlayerText { get; set; } = true;
        public float LastPlayerHintDuration { get; set; } = 10f;
        public string LastPlayerHint { get; set; } = string.Empty;
        [Description("Scp049 Features")]
        public bool Enable049BuffWhenReviving { get; set; } = true;

        public bool Enable049InstantRevive { get; set; } = true;
        public bool EnableBringZombiesCommand { get; set; } = false;
        public bool EnableHealthWhenReviving { get; set; } = true;
        public float HealthWhenReviving { get; set; } = 50f;
    }
}
