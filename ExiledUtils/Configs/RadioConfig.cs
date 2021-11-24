using System.ComponentModel;

namespace ExiledUtils.Configs
{
    public class RadioConfig
    {
        [Description("Does the radio have infinite battery?")]
        public bool InfiniteRadio { get; set; } = true;
    }
}
