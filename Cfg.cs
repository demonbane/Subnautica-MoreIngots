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
    /// Main class for loading or saving the config
    /// </summary>
    public class Cfg
    {
        public static readonly ConfigFile Config = new ConfigFile("config");
        public static bool _alttextures;
        public static bool _debug;

        /// <summary>
        /// Loads the config
        /// </summary>
        public static void Load()
        {
            try
            {
                _alttextures = false;
                _debug = false;

                var _xTitaniumIngot = 1;
                var _yTitaniumIngot = 1;
                var _xMIGold = 1;
                var _yMIGold = 1;
                var _xMIDiamond = 1;
                var _yMIDiamond = 1;
                var _xMILithium = 1;
                var _yMILithium = 1;
                var _xMICopper = 1;
                var _yMICopper = 1;
                var _xMILead = 1;
                var _yMILead = 1;
                var _xMISilver = 1;
                var _yMISilver = 1;
                var _xMIMagnetite = 1;
                var _yMIMagnetite = 1;
                var _xMINickel = 1;
                var _yMINickel = 1;
                var _xMIKyanite = 1;
                var _yMIKyanite = 1;
                var _xMIRuby = 1;
                var _yMIRuby = 1;
                var _xMIUraninite = 1;
                var _yMIUraninite = 1;
                var _xMIQuartz = 1;
                var _yMIQuartz = 1;
                var _xMISalt = 1;
                var _yMISalt = 1;

                var _aMIGold = 10;
                var _aMIDiamond = 10;
                var _aMILithium = 10;
                var _aMICopper = 10;
                var _aMILead = 10;
                var _aMISilver = 10;
                var _aMIMagnetite = 10;
                var _aMINickel = 10;
                var _aMIKyanite = 10;
                var _aMIRuby = 10;
                var _aMIUraninite = 10;
                var _aMIQuartz = 10;
                var _aMISalt = 10;

                Config.Load();
                var configChanged =
                Config.TryGet(ref _alttextures, "Alternative textures")
                | Config.TryGet(ref _debug, "Enable debugging")
                | Config.TryGet(ref _xTitaniumIngot, "Titanium Ingot", "Size", "x")
                | Config.TryGet(ref _yTitaniumIngot, "Titanium Ingot", "Size", "y")
                | Config.TryGet(ref _xMIGold, "Gold Ingot", "Size", "x")
                | Config.TryGet(ref _yMIGold, "Gold Ingot", "Size", "y")
                | Config.TryGet(ref _xMIDiamond, "Diamond Ingot", "Size", "x")
                | Config.TryGet(ref _yMIDiamond, "Diamond Ingot", "Size", "y")
                | Config.TryGet(ref _xMILithium, "Lithium Ingot", "Size", "x")
                | Config.TryGet(ref _yMILithium, "Lithium Ingot", "Size", "y")
                | Config.TryGet(ref _xMICopper, "Copper Ingot", "Size", "x")
                | Config.TryGet(ref _yMICopper, "Copper Ingot", "Size", "y")
                | Config.TryGet(ref _xMILead, "Lead Ingot", "Size", "x")
                | Config.TryGet(ref _yMILead, "Lead Ingot", "Size", "y")
                | Config.TryGet(ref _xMISilver, "Silver Ingot", "Size", "x")
                | Config.TryGet(ref _yMISilver, "Silver Ingot", "Size", "y")
                | Config.TryGet(ref _xMIMagnetite, "Magnetite Ingot", "Size", "x")
                | Config.TryGet(ref _yMIMagnetite, "Magnetite Ingot", "Size", "y")
                | Config.TryGet(ref _xMINickel, "Nickel Ingot", "Size", "x")
                | Config.TryGet(ref _yMINickel, "Nickel Ingot", "Size", "y")
                | Config.TryGet(ref _xMIKyanite, "Kyanite Ingot", "Size", "x")
                | Config.TryGet(ref _yMIKyanite, "Kyanite Ingot", "Size", "y")
                | Config.TryGet(ref _xMIRuby, "Ruby Ingot", "Size", "x")
                | Config.TryGet(ref _yMIRuby, "Ruby Ingot", "Size", "y")
                | Config.TryGet(ref _xMIUraninite, "Uraninite Ingot", "Size", "x")
                | Config.TryGet(ref _yMIUraninite, "Uraninite Ingot", "Size", "y")
                | Config.TryGet(ref _xMIQuartz, "Quartz Ingot", "Size", "x")
                | Config.TryGet(ref _yMIQuartz, "Quartz Ingot", "Size", "y")
                | Config.TryGet(ref _xMISalt, "Salt Lick", "Size", "x")
                | Config.TryGet(ref _yMISalt, "Salt Lick", "Size", "y")
                | Config.TryGet(ref _aMIGold, "Gold Ingot", "Craft amount")
                | Config.TryGet(ref _aMIDiamond, "Diamond Ingot", "Craft amount")
                | Config.TryGet(ref _aMILithium, "Lithium Ingot", "Craft amount")
                | Config.TryGet(ref _aMICopper, "Copper Ingot", "Craft amount")
                | Config.TryGet(ref _aMILead, "Lead Ingot", "Craft amount")
                | Config.TryGet(ref _aMISilver, "Silver Ingot", "Craft amount")
                | Config.TryGet(ref _aMIMagnetite, "Magnetite Ingot", "Craft amount")
                | Config.TryGet(ref _aMINickel, "Nickel Ingot", "Craft amount")
                | Config.TryGet(ref _aMIKyanite, "Kyanite Ingot", "Craft amount")
                | Config.TryGet(ref _aMIRuby, "Ruby Ingot", "Craft amount")
                | Config.TryGet(ref _aMIUraninite, "Uraninite Ingot", "Craft amount")
                | Config.TryGet(ref _aMIQuartz, "Quartz Ingot", "Craft amount")
                | Config.TryGet(ref _aMISalt, "Salt Lick", "Craft amount");
                if (configChanged)
                {
                    Log.Info("Config", "Some values are missing from the config, adding them now...");
                    Save("Config");
                    Log.Info("Config", "Missing values added");
                }
                Log.Debug("Config", Status.Stop);
            }
            catch (Exception e)
            {
                e.Log(LogType.Console);
            }
        }

        /// <summary>
        /// Saves the config
        /// </summary>
        public static void Save()
        {
            try
            {
                Log.Debug("Saving config...");
                Config.Save();
                Log.Debug("Config saved");
            }
            catch (Exception e)
            {
                e.Log(LogType.Console);
            }
        }
        /// <summary>
        /// Saves the config with a prefix for debugging
        /// </summary>
        /// <param name="prefix">Prefix for debugging</param>
        public static void Save(string prefix)
        {
            try
            {
                Log.Debug("[" + prefix + "] " + "Saving config...");
                Config.Save();
                Log.Debug("[" + prefix + "] " + "Config saved");
            }
            catch (Exception e)
            {
                e.Log(LogType.Console);
            }
        }
    }
}
