using SMLHelper.V2.Handlers;
using System.Collections.Generic;
using UnityEngine;
using Utilites.Config;
using Logger = Utilites.Logger.Logger;
using LogType = Utilites.Logger.LogType;
using LogLevel = Utilites.Logger.LogLevel;
using System;
using Utilites.Logger;
using MoreIngots.MI;

namespace MoreIngots.MI
{
    /// <summary>
    /// Main class for loading the fabricator tabs
    /// </summary>
    public partial class Load
    {
        /// <summary>
        /// Loads the fabricator tabs
        /// </summary>
        public static void FabricatorTabs()
        {
            try
            {
                Log.Debug("Loading fabricator tabs... (0/2)");
                ingotsplus = ingotDict["yenzen-ingotsplus"];
                var spritetabcraft2 = ingotsplus.LoadAsset<Sprite>("IPFabTabCraft");
                var spritetabunpack2 = ingotsplus.LoadAsset<Sprite>("IPFabTabUnpack");
                CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "Craft", "Craft MoreIngots", spritetabcraft2, "Resources");
                Log.Debug("Loading fabricator tabs... (1/2)");
                CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "Unpack", "Unpack MoreIngots", spritetabunpack2, "Resources");
                Log.Debug("Loading fabricator tabs... (2/2)");
                Log.Debug("Fabricator tabs loaded");
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }
    }
}
