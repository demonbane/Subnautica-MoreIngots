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
    /// Main class for loading the asset bundles
    /// </summary>
    public partial class Load
    {
        public static AssetBundle moreingots;
        public static AssetBundle ingotsplus;
        public static AssetBundle moreingots_salt;
        public static AssetBundle ingotsplus_salt;
        public static AssetBundle sulphur;
        /// <summary>
        /// Loads the asset bundles
        /// </summary>
        public static void AssetBundles()
        {
            try
            {
                Log.Debug("Loading asset bundles... (0/5)");
                moreingots = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/Assets/moreingots.assets");
                Log.Debug("\"moreingots\" asset bundle loaded");
                Log.Debug("Loading asset bundles... (1/5)");
                ingotsplus = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/Assets/yenzen-ingotsplus.assets");
                Log.Debug("\"yenzen-ingotsplus\" asset bundle loaded");
                Log.Debug("Loading asset bundles... (2/5)");
                moreingots_salt = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/Assets/salt-alexejheroytb.assets");
                Log.Debug("\"salt-alexejheroytb\" asset bundle loaded");
                Log.Debug("Loading asset bundles... (3/5)");
                ingotsplus_salt = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/Assets/salt-yenzen.assets");
                Log.Debug("\"salt-yenzen\" asset bundle loaded");
                Log.Debug("Loading asset bundles... (4/5)");
                sulphur = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/Assets/sulphur.assets");
                Log.Debug("\"sulphur\" asset bundle loaded");
                Log.Debug("Loading asset bundles... (5/5)");
                Log.Debug("Asset bundles loaded");
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }
    }
}
