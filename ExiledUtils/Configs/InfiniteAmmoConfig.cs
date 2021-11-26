using System.ComponentModel;

namespace ExiledUtils.Configs
{
    public class InfiniteAmmoConfig
    {
        [Description("Enable infinite ammo?")]
        public bool InfiniteAmmoEnable { get; set; } = false;
    }
}
