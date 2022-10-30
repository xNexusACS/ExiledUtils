using Exiled.API.Features;
using HarmonyLib;

namespace ExiledUtils_REMAKE.Patches
{
    [HarmonyPatch(typeof(Radio), nameof(Radio.UserCode_CmdSyncTransmissionStatus))]
    public class ScpVoiceChatPatch
    {
        public static bool Prefix(Radio __instance, bool b)
        {
            if (Player.Get(__instance._hub).IsScp)
                __instance._dissonanceSetup.MimicAs939 = b;
            return true;
        }
    }
}