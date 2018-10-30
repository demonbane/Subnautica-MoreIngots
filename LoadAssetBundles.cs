using SMLHelper;
using SMLHelper.Patchers;
using System.Collections.Generic;
using UnityEngine;
using Utilites.Config;
using Logger = Utilites.Logger.Logger;
using LogType = Utilites.Logger.LogType;
using LogLevel = Utilites.Logger.LogLevel;
using System;
using System.IO;
using Utilites.Logger;
using MoreIngots.MI;

namespace MoreIngots.MI
{
    /// <summary>
    /// Main class for loading the asset bundles
    /// </summary>
    public partial class Load
    {
        public static AssetBundle ingotsplus;
        public static AssetBundle ingotsplus_salt;
        public static AssetBundle sulphur;
        public static Dictionary<string, AssetBundle> ingotDict;
        /// <summary>
        /// Loads the asset bundles
        /// </summary>
        public static void AssetBundles()
        {
            try
            {
                ingotDict = new Dictionary<string, AssetBundle>();
                //string[] assetNames = { "yenzen-ingotsplus", "salt-yenzen", "sulphur", "unpackingotsassets" };
                string[] assetNames = { "yenzen-ingotsplus", "salt-yenzen", "sulphur" };
                for (int i = 0; i < assetNames.Length; i++)
                {
                    Log.Debug($"Loading asset bundles... ({i.ToString()}/{assetNames.Length.ToString()})");
                    ingotDict.Add(assetNames[i], AssetBundle.LoadFromFile($@"./QMods/MoreIngots/Assets/{assetNames[i]}.assets"));
                    Log.Debug($"\"{assetNames[i]}\" asset bundle loaded");
                }
                Log.Debug("Asset bundles loaded");
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }
    }
}
