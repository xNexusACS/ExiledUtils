using Exiled.API.Interfaces;
using ExiledUtils.Configs;

namespace ExiledUtils
{
    public class Cfg : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        public RadioConfig RadioCfg { get; set; } = new RadioConfig();
        public WeaponDamages WDMG { get; set; } = new WeaponDamages();
        public Scp939Damage Scp939Damage { get; set; } = new Scp939Damage();
        public FlippingCoin FC { get; set; } = new FlippingCoin();
        public Scp106FeaturesConfig Containing106 { get; set; } = new Scp106FeaturesConfig();
        public TantrumConfig TantrumConfig { get; set; } = new TantrumConfig();
        public InfiniteAmmoConfig InfiniteAmmoConfig { get; set; } = new InfiniteAmmoConfig();
        public AddingTargetConfig AddingTargetConfig { get; set; } = new AddingTargetConfig(); 
    }
}
