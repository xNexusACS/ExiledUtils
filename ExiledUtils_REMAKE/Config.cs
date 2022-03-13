﻿using Exiled.API.Interfaces;
using System.ComponentModel;
using System.Collections.Generic;

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
        public bool EnableCoinFeatures { get; set; } = false;
        public float EffectDuration { get; set; } = 5f;
        [Description("ReservedSlots")]
        public List<string> ReservedGroups { get; set; } = new List<string>()
        {
            "owner", "admin", "moderator", "donator"
        };
        [Description("Last Player")]
        public bool EnableLastPlayerText { get; set; } = true;
        public float LastPlayerHintDuration { get; set; } = 10f;
        public string LastPlayerHint { get; set; } = string.Empty;
        [Description("Scp049 Features")]
        public bool Enable049BuffWhenReviving { get; set; } = true;
        [Description("RainbowTags config")]
        public string[] RTSequences { get; set; } = new string[]
        {
            "red",
            "orange",
            "yellow",
            "green",
            "blue_green",
            "magenta",
            "silver",
            "crimson"
        };
        public List<string> RoleRainbowTags { get; set; } = new List<string>
        {
            "owner",
            "admin",
            "moderator"
        };
        public float ColorInterval { get; set; } = 0.5f;
    }
}
