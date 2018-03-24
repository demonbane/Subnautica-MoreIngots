using Harmony;

namespace MoreIngots.Patches
{
    [HarmonyPatch(typeof(CraftTree))]
    [HarmonyPatch("FabricatorTabAdd")]
    public class FabricatorTabAdd_Patch
    {
        static bool PostfixCraftTreeInitialize()
        {
            
        }
    }
}
