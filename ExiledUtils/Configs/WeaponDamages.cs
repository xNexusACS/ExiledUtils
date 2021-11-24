using System.ComponentModel;

namespace ExiledUtils.Configs
{
    public class WeaponDamages
    {
        [Description("Revolver Damage")]
        public float RevolverDMG { get; set; } = 45;
        [Description("Shotgun Damage")]
        public float ShotgunDMG { get; set; } = 35;
        [Description("Logicer Damage")]
        public float LogicerDMG { get; set; } = 30;
        [Description("AK Damage")]
        public float AKDMG { get; set; } = 35;
        [Description("Frag Grenade Damage")]
        public float FragGrenadeDMG { get; set; } = 250;
    }
}
