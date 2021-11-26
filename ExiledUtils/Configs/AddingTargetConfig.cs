using System.ComponentModel;

namespace ExiledUtils.Configs
{
    public class AddingTargetConfig
    {
        [Description("Hint that appear when the target see the 096 face")]
        public string TargetHint { get; set; } = "<color=red> Now you are a target for 096! </color>";
        [Description("Hint that appear to 096")]
        public string Scp096Hint { get; set; } = "<color=red> A player looked at your face </color>";
        [Description("Hint duration")]
        public float HintsDuration { get; set; } = 5;
    }
}
