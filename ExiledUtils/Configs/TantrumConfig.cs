using System.ComponentModel;

namespace ExiledUtils.Configs
{
    public class TantrumConfig
    {
        [Description("Tantrum Cooldown")]
        public float TantrumCooldown { get; set; } = 20f;
        [Description("Hint Config")]
        public float HintDuration { get; set; } = 5;
        public string Hint { get; set; } = "<color=yellow> Tantrum Placed </color>";
        [Description("Are the SCPs inmune to the tantrum?")]
        public bool SCPInmune { get; set; } = true;
        [Description("Effect Duration when a player walk on a tantrum (SCP173 Included) (Effect: Hemorraghe)")]
        public float TantrumEffectDuration { get; set; } = 5;
    }
}
