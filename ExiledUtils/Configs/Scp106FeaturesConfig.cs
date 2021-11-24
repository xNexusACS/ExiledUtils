using System.ComponentModel;

namespace ExiledUtils.Configs
{
    public class Scp106FeaturesConfig
    {
        [Description("Hint Config")]
        public float ButtonPresserHintDuration { get; set; } = 5;
        public string ButtonPresserHint { get; set; } = "<color=yellow> Congratulations, you killed the SCP106 </color>";
        [Description("Effect Duration (Effect: Sinkhole)")]
        public float ButtonPresserEffectDuration { get; set; } = 2;
    }
}
