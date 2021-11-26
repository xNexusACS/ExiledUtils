using System.ComponentModel;

namespace ExiledUtils.Configs
{
    public class InfiniteAmmoConfig
    {
        [Description("Enable infinite ammo? (Have some bugs, activate at your own risk)")]
        public bool InfiniteAmmoEnable { get; set; } = false;
    }
}
