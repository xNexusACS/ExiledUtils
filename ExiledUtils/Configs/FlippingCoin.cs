using System.ComponentModel;

namespace ExiledUtils.Configs
{
    public class FlippingCoin
    {
        [Description("AHP Gained when you flipping the coin (Tails)")]
        public float AHPGained { get; set; } = 15;
        [Description("Hint Config")]
        public float HintDuration { get; set; } = 3;
        public string Hint { get; set; } = "<color=green><size=25><align=right> +30 AHP </align></size></color>";
        [Description("Effect Duration when you flipping the coin (Tails) (Effect: Scp207)")]
        public float EffectDuration { get; set; } = 5;
    }
}
