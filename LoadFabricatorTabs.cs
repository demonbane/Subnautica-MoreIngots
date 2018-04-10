using SMLHelper;
using SMLHelper.Patchers;
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
    public class LoadFabricatorTabs
    {
        /// <summary>
        /// Loads the fabricator tabs
        /// </summary>
        public static void Load()
        {
            try
            {
                var spritetabcraft = LoadAssetBundles.moreingots.LoadAsset<Sprite>("MIFabTabCraft");
                var spritetabunpack = LoadAssetBundles.moreingots.LoadAsset<Sprite>("MIFabTabUnpack");
                var spritetabcraft2 = LoadAssetBundles.ingotsplus.LoadAsset<Sprite>("IPFabTabCraft");
                var spritetabunpack2 = LoadAssetBundles.ingotsplus.LoadAsset<Sprite>("IPFabTabUnpack");
                if (Cfg._alttextures)
                {
                    MI.Log.Debug("Loading fabricator tabs with alternative sprites... (0/2)");
                    CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/Craft", "Craft MoreIngots", CraftScheme.Fabricator, spritetabcraft));
                    MI.Log.Debug("Loading fabricator tabs with alternative sprites... (1/2)");
                    CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/Unpack", "Unpack MoreIngots", CraftScheme.Fabricator, spritetabunpack));
                    MI.Log.Debug("Loading fabricator tabs with alternative sprites... (2/2)");
                    MI.Log.Debug("Fabricator tabs with alternative sprites loaded");
                }
                else
                {
                    MI.Log.Debug("Loading fabricator tabs... (0/2)");
                    CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/Craft", "Craft MoreIngots", CraftScheme.Fabricator, spritetabcraft2));
                    MI.Log.Debug("Loading fabricator tabs... (1/2)");
                    CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/Unpack", "Unpack MoreIngots", CraftScheme.Fabricator, spritetabunpack2));
                    MI.Log.Debug("Loading fabricator tabs... (2/2)");
                    MI.Log.Debug("Fabricator tabs loaded");
                }
            }
            catch (Exception e)
            {
                e.Log(LogType.Console);
            }
        }
    }
}
