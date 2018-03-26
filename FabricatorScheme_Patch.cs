using Harmony;

namespace MoreIngots.Patches
{
    [HarmonyPatch(typeof(CraftTree))]
    [HarmonyPatch("FabricatorScheme")]
    public class FabricatorScheme_Patch
    {
        static bool Postfix()
        {
            
        }
    }
}
