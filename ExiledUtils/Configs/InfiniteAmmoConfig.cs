using System.ComponentModel;

namespace ExiledUtils.Configs
{
    public class InfiniteAmmoConfig
    {
        [Description("Amount of ammo to add when shooting with a gun")]
        public ushort AmmoValues { get; set; } = 3000;
        [Description("Enable infinite ammo? (Have some bugs, activate at your own risk)")]
        public bool InfiniteAmmoEnable { get; set; } = false;
    }
}
