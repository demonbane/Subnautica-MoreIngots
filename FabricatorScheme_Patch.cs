using Harmony;

namespace MoreIngots.Patches
{
    [HarmonyPatch(typeof(CraftTree))]
    [HarmonyPatch("FabricatorScheme")]
    public class FabricatorScheme_Patch
    {
        static bool Postfix(CraftNode result)
        {
            result["Resources"].AddNode(new CraftNode[] { new CraftNode("MoreIngots", TreeAction.Expand, TechType.None) });
            result["Resources"]["MoreIngots"].AddNode(new CraftNode[] { new CraftNode("Craft", TreeAction.Expand, TechType.None) });
            result["Resources"]["MoreIngots"].AddNode(new CraftNode[] { new CraftNode("Unpack", TreeAction.Expand, TechType.None) });
            return true;
        }
    }
}