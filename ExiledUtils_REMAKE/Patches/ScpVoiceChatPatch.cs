using System.Collections.Generic;
using System.Reflection.Emit;
using Assets._Scripts.Dissonance;
using HarmonyLib;
using NorthwoodLib.Pools;
using static HarmonyLib.AccessTools;

namespace ExiledUtils_REMAKE.Patches
{
    [HarmonyPatch(typeof(Radio), nameof(Radio.UserCode_CmdSyncTransmissionStatus))]
    public class ScpVoiceChatPatch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            List<CodeInstruction> newInstructions = ListPool<CodeInstruction>.Shared.Rent(instructions);

            Label generatorLabel = generator.DefineLabel();

            newInstructions.InsertRange(0, new []
            {
                new CodeInstruction(OpCodes.Ldsfld, Field(typeof(MainClass), nameof(MainClass.hub))),
                new CodeInstruction(OpCodes.Callvirt, PropertyGetter(typeof(MainClass), nameof(MainClass.Config))),
                new CodeInstruction(OpCodes.Callvirt, PropertyGetter(typeof(Config), nameof(Config.ScpVoiceChatRoles))),
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldfld, Field(typeof(Radio), nameof(Radio._hub))),
                new CodeInstruction(OpCodes.Ldfld, Field(typeof(ReferenceHub), nameof(ReferenceHub.characterClassManager))),
                new CodeInstruction(OpCodes.Callvirt, PropertyGetter(typeof(CharacterClassManager), nameof(CharacterClassManager.NetworkCurClass))),
                new CodeInstruction(OpCodes.Callvirt, Method(typeof(List<RoleType>), nameof(List<RoleType>.Contains))),
                new CodeInstruction(OpCodes.Brfalse_S, generatorLabel),
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldfld, Field(typeof(Radio), nameof(Radio._dissonanceSetup))),
                new CodeInstruction(OpCodes.Ldarg_1),
                new CodeInstruction(OpCodes.Callvirt, PropertySetter(typeof(DissonanceUserSetup), nameof(DissonanceUserSetup.MimicAs939))),
                new CodeInstruction(OpCodes.Nop).WithLabels(generatorLabel)
            });

            foreach (CodeInstruction instruction in newInstructions)
                yield return instruction;

            ListPool<CodeInstruction>.Shared.Return(newInstructions);
        }
    }
}