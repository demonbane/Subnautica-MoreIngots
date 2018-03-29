using Harmony;

namespace MoreIngots.Patches
{
    [HarmonyPatch(typeof(CraftTree))]
    [HarmonyPatch("FabricatorScheme")]
    public class FabricatorScheme_Patch
    {
        static void Postfix(CraftNode __result)
        {
            __result["Resources"].AddNode(new CraftNode[] { new CraftNode("Craft", TreeAction.Expand, TechType.None) });
            __result["Resources"].AddNode(new CraftNode[] { new CraftNode("Unpack", TreeAction.Expand, TechType.None) });
        }
    }
}