using SMLHelper;
using SMLHelper.Patchers;
using System.Collections.Generic;
using UnityEngine;
using Logger = Utilites.Logger.Logger;
using LogType = Utilites.Logger.LogType;
using LogLevel = Utilites.Logger.LogLevel;
using System;
using Utilites.Logger;
using MoreIngots.MI;
using Utilites.Config;

namespace MoreIngots.MI
{
    /// <summary>
    /// Main class for loading or saving the config
    /// </summary>
    public class Config
    {
        public static readonly ConfigFile cfgfile = new ConfigFile("config");
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
                var _xPlasteel = 1;
                var _yPlasteel = 1;

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
                var _xMISulphur = 1;
                var _yMISulphur = 1;

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
                var _aMISulphur = 10;

                var _eMIGold = true;
                var _eMIDiamond = true;
                var _eMILithium = true;
                var _eMICopper = true;
                var _eMILead = true;
                var _eMISilver = true;
                var _eMIMagnetite = true;
                var _eMINickel = true;
                var _eMIKyanite = true;
                var _eMIRuby = true;
                var _eMIUraninite = true;
                var _eMIQuartz = true;
                var _eMISalt = true;
                var _eMISulphur = true;

                cfgfile.Load();
                var configChanged =
                cfgfile.TryGet(ref _alttextures, "Alternative textures")
                | cfgfile.TryGet(ref _debug, "Enable debugging")

                | cfgfile.TryGet(ref _xTitaniumIngot, "Titanium Ingot", "Size", "x")
                | cfgfile.TryGet(ref _yTitaniumIngot, "Titanium Ingot", "Size", "y")
                | cfgfile.TryGet(ref _xPlasteel, "Plasteel Ingot", "Size", "x")
                | cfgfile.TryGet(ref _yPlasteel, "Plasteel Ingot", "Size", "y")

                | cfgfile.TryGet(ref _xMIGold, "Gold Ingot", "Size", "x")
                | cfgfile.TryGet(ref _yMIGold, "Gold Ingot", "Size", "y")
                | cfgfile.TryGet(ref _xMIDiamond, "Compressed Diamond", "Size", "x")
                | cfgfile.TryGet(ref _yMIDiamond, "Compressed Diamond", "Size", "y")
                | cfgfile.TryGet(ref _xMILithium, "Lithium Ingot", "Size", "x")
                | cfgfile.TryGet(ref _yMILithium, "Lithium Ingot", "Size", "y")
                | cfgfile.TryGet(ref _xMICopper, "Copper Ingot", "Size", "x")
                | cfgfile.TryGet(ref _yMICopper, "Copper Ingot", "Size", "y")
                | cfgfile.TryGet(ref _xMILead, "Lead Ingot", "Size", "x")
                | cfgfile.TryGet(ref _yMILead, "Lead Ingot", "Size", "y")
                | cfgfile.TryGet(ref _xMISilver, "Silver Ingot", "Size", "x")
                | cfgfile.TryGet(ref _yMISilver, "Silver Ingot", "Size", "y")
                | cfgfile.TryGet(ref _xMIMagnetite, "Compressed Magnetite", "Size", "x")
                | cfgfile.TryGet(ref _yMIMagnetite, "Compressed Magnetite", "Size", "y")
                | cfgfile.TryGet(ref _xMINickel, "Nickel Ingot", "Size", "x")
                | cfgfile.TryGet(ref _yMINickel, "Nickel Ingot", "Size", "y")
                | cfgfile.TryGet(ref _xMIKyanite, "Compressed Kyanite", "Size", "x")
                | cfgfile.TryGet(ref _yMIKyanite, "Compressed Kyanite", "Size", "y")
                | cfgfile.TryGet(ref _xMIRuby, "Compressed Ruby", "Size", "x")
                | cfgfile.TryGet(ref _yMIRuby, "Compressed Ruby", "Size", "y")
                | cfgfile.TryGet(ref _xMIUraninite, "Uraninite Ingot", "Size", "x")
                | cfgfile.TryGet(ref _yMIUraninite, "Uraninite Ingot", "Size", "y")
                | cfgfile.TryGet(ref _xMIQuartz, "Compressed Quartz", "Size", "x")
                | cfgfile.TryGet(ref _yMIQuartz, "Compressed Quartz", "Size", "y")
                | cfgfile.TryGet(ref _xMISalt, "Salt Lick", "Size", "x")
                | cfgfile.TryGet(ref _yMISalt, "Salt Lick", "Size", "y")
                | cfgfile.TryGet(ref _xMISulphur, "Compressed Sulphur", "Size", "y")
                | cfgfile.TryGet(ref _yMISulphur, "Compressed Sulphur", "Size", "y")

                | cfgfile.TryGet(ref _aMIGold, "Gold Ingot", "Craft amount")
                | cfgfile.TryGet(ref _aMIDiamond, "Compressed Diamond", "Craft amount")
                | cfgfile.TryGet(ref _aMILithium, "Lithium Ingot", "Craft amount")
                | cfgfile.TryGet(ref _aMICopper, "Copper Ingot", "Craft amount")
                | cfgfile.TryGet(ref _aMILead, "Lead Ingot", "Craft amount")
                | cfgfile.TryGet(ref _aMISilver, "Silver Ingot", "Craft amount")
                | cfgfile.TryGet(ref _aMIMagnetite, "Compressed Magnetite", "Craft amount")
                | cfgfile.TryGet(ref _aMINickel, "Nickel Ingot", "Craft amount")
                | cfgfile.TryGet(ref _aMIKyanite, "Compressed Kyanite", "Craft amount")
                | cfgfile.TryGet(ref _aMIRuby, "Compressed Ruby", "Craft amount")
                | cfgfile.TryGet(ref _aMIUraninite, "Uraninite Ingot", "Craft amount")
                | cfgfile.TryGet(ref _aMIQuartz, "Compressed Quartz", "Craft amount")
                | cfgfile.TryGet(ref _aMISalt, "Salt Lick", "Craft amount")
                | cfgfile.TryGet(ref _aMISulphur, "Compressed Sulphur", "Craft amount")

                | cfgfile.TryGet(ref _eMIGold, "Gold Ingot", "Enabled")
                | cfgfile.TryGet(ref _eMIDiamond, "Compressed Diamond", "Enabled")
                | cfgfile.TryGet(ref _eMILithium, "Lithium Ingot", "Enabled")
                | cfgfile.TryGet(ref _eMICopper, "Copper Ingot", "Enabled")
                | cfgfile.TryGet(ref _eMILead, "Lead Ingot", "Enabled")
                | cfgfile.TryGet(ref _eMISilver, "Silver Ingot", "Enabled")
                | cfgfile.TryGet(ref _eMIMagnetite, "Compressed Magnetite", "Enabled")
                | cfgfile.TryGet(ref _eMINickel, "Nickel Ingot", "Enabled")
                | cfgfile.TryGet(ref _eMIKyanite, "Compressed Kyanite", "Enabled")
                | cfgfile.TryGet(ref _eMIRuby, "Compressed Ruby", "Enabled")
                | cfgfile.TryGet(ref _eMIUraninite, "Uraninite Ingot", "Enabled")
                | cfgfile.TryGet(ref _eMIQuartz, "Compressed Quartz", "Enabled")
                | cfgfile.TryGet(ref _eMISalt, "Salt Lick", "Enabled")
                | cfgfile.TryGet(ref _eMISulphur, "Compressed Sulphur", "Enabled");

                if (configChanged)
                {
                    Log.Info("cfgfile", "Some values are missing from the config, adding them now...");
                    Save("cfgfile");
                    Log.Info("cfgfile", "Missing values added");
                }
                Log.Debug("cfgfile", Status.Stop);
            }
            catch (Exception e)
            {
                Log.e(e);
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
                cfgfile.Save();
                Log.Debug("cfgfile saved");
            }
            catch (Exception e)
            {
                Log.e(e);
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
                cfgfile.Save();
                Log.Debug("[" + prefix + "] " + "cfgfile saved");
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }
    }
    public partial class Load
    {
        /// <summary>
        /// Initializes the config
        /// </summary>
        public static void Config()
        {
            try
            {
                Logger.ClearCustomLog();
                MI.Config.Load();
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }
    }
}
