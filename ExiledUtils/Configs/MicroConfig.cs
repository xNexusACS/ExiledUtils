using System.ComponentModel;

namespace ExiledUtils.Configs
{
    public class MicroConfig
    {
        [Description("IS the MicroHID power unlimited?")]
        public bool UnlimitedMicroHID { get; set; } = false;
    }
}
