using SMLHelper;
using SMLHelper.Patchers;
using System.Collections.Generic;
using UnityEngine;
using Utilites.Config;
using Logger = Utilites.Logger.Logger;
using LogType = Utilites.Logger.LogType;

namespace MoreIngots
{
    public class QPatch
    {
        private static readonly ConfigFile Config = new ConfigFile("config");

        private static bool _alttextures = false;

        private static int _xTitaniumIngot = 1;
        private static int _yTitaniumIngot = 1;
        private static int _xMIGold = 1;
        private static int _yMIGold = 1;
        private static int _xMIDiamond = 1;
        private static int _yMIDiamond = 1;
        private static int _xMILithium = 1;
        private static int _yMILithium = 1;
        private static int _xMICopper = 1;
        private static int _yMICopper = 1;
        private static int _xMILead = 1;
        private static int _yMILead = 1;
        private static int _xMISilver = 1;
        private static int _yMISilver = 1;
        private static int _xMIMagnetite = 1;
        private static int _yMIMagnetite = 1;
        private static int _xMINickel = 1;
        private static int _yMINickel = 1;
        private static int _xMIKyanite = 1;
        private static int _yMIKyanite = 1;
        private static int _xMIRuby = 1;
        private static int _yMIRuby = 1;
        private static int _xMIUraninite = 1;
        private static int _yMIUraninite = 1;
        private static int _xMIQuartz = 1;
        private static int _yMIQuartz = 1;
        private static int _xMISalt = 1;
        private static int _yMISalt = 1;

        private static int _aMIGold = 10;
        private static int _aMIDiamond = 10;
        private static int _aMILithium = 10;
        private static int _aMICopper = 10;
        private static int _aMILead = 10;
        private static int _aMISilver = 10;
        private static int _aMIMagnetite = 10;
        private static int _aMINickel = 10;
        private static int _aMIKyanite = 10;
        private static int _aMIRuby = 10;
        private static int _aMIUraninite = 10;
        private static int _aMIQuartz = 10;
        private static int _aMISalt = 10;
        public static void Patch()
        {
            Logger.Debug("Started loading", LogType.Console);
            Logger.Debug("Loading asset bundles... (0/4)", LogType.Console);
            var assetBundle = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/Assets/moreingots.assets");
            Logger.Debug("Loading asset bundles... (1/4)", LogType.Console);
            var assetBundlealt = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/Assets/yenzen-ingotsplus.assets");
            Logger.Debug("Loading asset bundles... (2/4)", LogType.Console);
            var saltassetsalex = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/Assets/salt-alexejheroytb.assets");
            Logger.Debug("Loading asset bundles... (3/4)", LogType.Console);
            //var saltassetsyenz = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/Assets/salt-yenzen.assets");
            Logger.Info("Asset bundle \"salt-yenzen\" missing! We'll use \"salt-alexejheroytb\" for the missing assets. (This message is harmless)");
            Logger.Debug("Loading asset bundles... (4/4)", LogType.Console);
            Logger.Debug("Asset bundles loaded", LogType.Console);

            Logger.Debug("Loading config...", LogType.Console);
            Config.Load();
            Logger.Debug("Config loaded", LogType.Console);

            Logger.Debug("Obtaining config data...", LogType.Console);
            var configChanged =
            Config.TryGet(ref _alttextures, "Alternative textures")
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
            Logger.Debug("Config data obtained", LogType.Console);

            Logger.Debug("Checking config for errors... (0/82)", LogType.Console);
            if (_xTitaniumIngot <= 0)
            {
                _xTitaniumIngot = 1;
                Config["Titanium Ingot", "Size", "x"] = _xTitaniumIngot;
                Logger.Warning("Size of Titanium Ingot can't be less or equal to 0. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xTitaniumIngot > 6)
            {
                _xTitaniumIngot = 1;
                Config["Titanium Ingot", "Size", "x"] = _xTitaniumIngot;
                Logger.Warning("Size of Titanium Ingot can't be greater than 6. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yTitaniumIngot <= 0)
            {
                _yTitaniumIngot = 1;
                Config["Titanium Ingot", "Size", "y"] = _yTitaniumIngot;
                Logger.Warning("Size of Titanium Ingot can't be less or equal to 0. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yTitaniumIngot > 8)
            {
                _yTitaniumIngot = 1;
                Config["Titanium Ingot", "Size", "y"] = _yTitaniumIngot;
                Logger.Warning("Size of Titanium Ingot can't be greater than 8. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMIGold <= 0)
            {
                _xMIGold = 1;
                Config["Gold Ingot", "Size", "x"] = _xMIGold;
                Logger.Warning("Size of Gold Ingot can't be less or equal to 0. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMIGold > 6)
            {
                _xMIGold = 1;
                Config["Gold Ingot", "Size", "x"] = _xMIGold;
                Logger.Warning("Size of Gold Ingot can't be greater than 6. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMIGold <= 0)
            {
                _yMIGold = 1;
                Config["Gold Ingot", "Size", "y"] = _yMIGold;
                Logger.Warning("Size of Gold Ingot can't be less or equal to 0. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMIGold > 8)
            {
                _yMIGold = 1;
                Config["Gold Ingot", "Size", "y"] = _yMIGold;
                Logger.Warning("Size of Gold Ingot can't be greater than 8. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMIDiamond <= 0)
            {
                _xMIDiamond = 1;
                Config["Diamond Ingot", "Size", "x"] = _xMIDiamond;
                Logger.Warning("Size of Diamond Ingot can't be less or equal to 0. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMIDiamond > 6)
            {
                _xMIDiamond = 1;
                Config["Diamond Ingot", "Size", "x"] = _xMIDiamond;
                Logger.Warning("Size of Diamond Ingot can't be greater than 6. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Checking config for errors... (10/82)", LogType.Console);
            if (_yMIDiamond <= 0)
            {
                _yMIDiamond = 1;
                Config["Diamond Ingot", "Size", "y"] = _yMIDiamond;
                Logger.Warning("Size of Diamond Ingot can't be less or equal to 0. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMIDiamond > 8)
            {
                _yMIDiamond = 1;
                Config["Diamond Ingot", "Size", "y"] = _yMIDiamond;
                Logger.Warning("Size of Diamond Ingot can't be greater than 8. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMILithium <= 0)
            {
                _xMILithium = 1;
                Config["Lithium Ingot", "Size", "x"] = _xMILithium;
                Logger.Warning("Size of Lithium Ingot can't be less or equal to 0. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMILithium > 6)
            {
                _xMILithium = 1;
                Config["Lithium Ingot", "Size", "x"] = _xMILithium;
                Logger.Warning("Size of Lithium Ingot can't be greater than 6. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMILithium <= 0)
            {
                _yMILithium = 1;
                Config["Lithium Ingot", "Size", "y"] = _yMILithium;
                Logger.Warning("Size of Lithium Ingot can't be less or equal to 0. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMILithium > 8)
            {
                _yMILithium = 1;
                Config["Lithium Ingot", "Size", "y"] = _yMILithium;
                Logger.Warning("Size of Lithium Ingot can't be greater than 8. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMICopper <= 0)
            {
                _xMICopper = 1;
                Config["Copper Ingot", "Size", "x"] = _xMICopper;
                Logger.Warning("Size of Copper Ingot can't be less or equal to 0. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMICopper > 6)
            {
                _xMICopper = 1;
                Config["Copper Ingot", "Size", "x"] = _xMICopper;
                Logger.Warning("Size of Copper Ingot can't be greater than 6. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMICopper <= 0)
            {
                _yMICopper = 1;
                Config["Copper Ingot", "Size", "y"] = _yMICopper;
                Logger.Warning("Size of Copper Ingot can't be less or equal to 0. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMICopper > 8)
            {
                _yMICopper = 1;
                Config["Copper Ingot", "Size", "y"] = _yMICopper;
                Logger.Warning("Size of Copper Ingot can't be greater than 8. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Checking config for errors... (20/82)", LogType.Console);
            if (_xMILead <= 0)
            {
                _xMILead = 1;
                Config["Lead Ingot", "Size", "x"] = _xMILead;
                Logger.Warning("Size of Lead Ingot can't be less or equal to 0. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMILead > 6)
            {
                _xMILead = 1;
                Config["Lead Ingot", "Size", "x"] = _xMILead;
                Logger.Warning("Size of Lead Ingot can't be greater than 6. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMILead <= 0)
            {
                _yMILead = 1;
                Config["Lead Ingot", "Size", "y"] = _yMILead;
                Logger.Warning("Size of Lead Ingot can't be less or equal to 0. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMILead > 8)
            {
                _yMILead = 1;
                Config["Lead Ingot", "Size", "y"] = _yMILead;
                Logger.Warning("Size of Lead Ingot can't be greater than 8. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMISilver <= 0)
            {
                _xMISilver = 1;
                Config["Silver Ingot", "Size", "x"] = _xMISilver;
                Logger.Warning("Size of Silver Ingot can't be less or equal to 0. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMISilver > 6)
            {
                _xMISilver = 1;
                Config["Silver Ingot", "Size", "x"] = _xMISilver;
                Logger.Warning("Size of Silver Ingot can't be greater than 6. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMISilver <= 0)
            {
                _yMISilver = 1;
                Config["Silver Ingot", "Size", "y"] = _yMISilver;
                Logger.Warning("Size of Silver Ingot can't be less or equal to 0. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMISilver > 8)
            {
                _yMISilver = 1;
                Config["Silver Ingot", "Size", "y"] = _yMISilver;
                Logger.Warning("Size of Silver Ingot can't be greater than 8. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMIMagnetite <= 0)
            {
                _xMIMagnetite = 1;
                Config["Magnetite Ingot", "Size", "x"] = _xMIMagnetite;
                Logger.Warning("Size of Magnetite Ingot can't be less or equal to 0. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMIMagnetite > 6)
            {
                _xMIMagnetite = 1;
                Config["Magnetite Ingot", "Size", "x"] = _xMIMagnetite;
                Logger.Warning("Size of Magnetite Ingot can't be greater than 6. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Checking config for errors... (30/82)", LogType.Console);
            if (_yMIMagnetite <= 0)
            {
                _yMIMagnetite = 1;
                Config["Magnetite Ingot", "Size", "y"] = _yMIMagnetite;
                Logger.Warning("Size of Magnetite Ingot can't be less or equal to 0. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMIMagnetite > 8)
            {
                _yMIMagnetite = 1;
                Config["Magnetite Ingot", "Size", "y"] = _yMIMagnetite;
                Logger.Warning("Size of Magnetite Ingot can't be greater than 8. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMINickel <= 0)
            {
                _xMINickel = 1;
                Config["Nickel Ingot", "Size", "x"] = _xMINickel;
                Logger.Warning("Size of Nickel Ingot can't be less or equal to 0. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMINickel > 6)
            {
                _xMINickel = 1;
                Config["Nickel Ingot", "Size", "x"] = _xMINickel;
                Logger.Warning("Size of Nickel Ingot can't be greater than 6. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMINickel <= 0)
            {
                _yMINickel = 1;
                Config["Nickel Ingot", "Size", "y"] = _yMINickel;
                Logger.Warning("Size of Nickel Ingot can't be less or equal to 0. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMINickel > 8)
            {
                _yMINickel = 1;
                Config["Nickel Ingot", "Size", "y"] = _yMINickel;
                Logger.Warning("Size of Nickel Ingot can't be greater than 8. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMIKyanite <= 0)
            {
                _xMIKyanite = 1;
                Config["Kyanite Ingot", "Size", "x"] = _xMIKyanite;
                Logger.Warning("Size of Kyanite Ingot can't be less or equal to 0. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMIKyanite > 6)
            {
                _xMIKyanite = 1;
                Config["Kyanite Ingot", "Size", "x"] = _xMIKyanite;
                Logger.Warning("Size of Kyanite Ingot can't be greater than 6. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMIKyanite <= 0)
            {
                _yMIKyanite = 1;
                Config["Kyanite Ingot", "Size", "y"] = _yMIKyanite;
                Logger.Warning("Size of Kyanite Ingot can't be less or equal to 0. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMIKyanite > 8)
            {
                _yMIKyanite = 1;
                Config["Kyanite Ingot", "Size", "y"] = _yMIKyanite;
                Logger.Warning("Size of Kyanite Ingot can't be greater than 8. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Checking config for errors... (40/82)", LogType.Console);
            if (_xMIRuby <= 0)
            {
                _xMIRuby = 1;
                Config["Ruby Ingot", "Size", "x"] = _xMIRuby;
                Logger.Warning("Size of Ruby Ingot can't be less or equal to 0. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMIRuby > 6)
            {
                _xMIRuby = 1;
                Config["Ruby Ingot", "Size", "x"] = _xMIRuby;
                Logger.Warning("Size of Ruby Ingot can't be greater than 6. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMIRuby <= 0)
            {
                _yMIRuby = 1;
                Config["Ruby Ingot", "Size", "y"] = _yMIRuby;
                Logger.Warning("Size of Ruby Ingot can't be less or equal to 0. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMIRuby > 8)
            {
                _yMIRuby = 1;
                Config["Ruby Ingot", "Size", "y"] = _yMIRuby;
                Logger.Warning("Size of Ruby Ingot can't be greater than 8. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMIUraninite <= 0)
            {
                _xMIUraninite = 1;
                Config["Uraninite Ingot", "Size", "x"] = _xMIUraninite;
                Logger.Warning("Size of Uraninite Ingot can't be less or equal to 0. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMIUraninite > 6)
            {
                _xMIUraninite = 1;
                Config["Uraninite Ingot", "Size", "x"] = _xMIUraninite;
                Logger.Warning("Size of Uraninite Ingot can't be greater than 6. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMIUraninite <= 0)
            {
                _yMIUraninite = 1;
                Config["Uraninite Ingot", "Size", "y"] = _yMIUraninite;
                Logger.Warning("Size of Uraninite Ingot can't be less or equal to 0. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMIUraninite > 8)
            {
                _yMIUraninite = 1;
                Config["Uraninite Ingot", "Size", "y"] = _yMIUraninite;
                Logger.Warning("Size of Uraninite Ingot can't be greater than 8. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMIQuartz <= 0)
            {
                _xMIQuartz = 1;
                Config["Quartz Ingot", "Size", "x"] = _xMIQuartz;
                Logger.Warning("Size of Quartz Ingot can't be less or equal to 0. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMIQuartz > 6)
            {
                _xMIQuartz = 1;
                Config["Quartz Ingot", "Size", "x"] = _xMIQuartz;
                Logger.Warning("Size of Quartz Ingot can't be greater than 6. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Checking config for errors... (50/82)", LogType.Console);
            if (_yMIQuartz <= 0)
            {
                _yMIQuartz = 1;
                Config["Quartz Ingot", "Size", "y"] = _yMIQuartz;
                Logger.Warning("Size of Quartz Ingot can't be less or equal to 0. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMIQuartz > 8)
            {
                _yMIQuartz = 1;
                Config["Quartz Ingot", "Size", "y"] = _yMIQuartz;
                Logger.Warning("Size of Quartz Ingot can't be greater than 8. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMISalt <= 0)
            {
                _xMISalt = 1;
                Config["Salt Lick", "Size", "x"] = _xMISalt;
                Logger.Warning("Size of Salt Lick can't be less or equal to 0. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_xMISalt > 6)
            {
                _xMISalt = 1;
                Config["Salt Lick", "Size", "x"] = _xMISalt;
                Logger.Warning("Size of Salt Lick can't be greater than 6. X was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMISalt <= 0)
            {
                _yMISalt = 1;
                Config["Salt Lick", "Size", "y"] = _yMISalt;
                Logger.Warning("Size of Salt Lick can't be less or equal to 0. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_yMISalt > 8)
            {
                _yMISalt = 1;
                Config["Salt Lick", "Size", "y"] = _yMISalt;
                Logger.Warning("Size of Salt Lick can't be greater than 8. Y was set to 1", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMIGold <= 0)
            {
                _aMIGold = 10;
                Config["Gold Ingot", "Craft amount"] = _aMIGold;
                Logger.Warning("Craft amount of Gold Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMIGold > 10)
            {
                _aMIGold = 10;
                Config["Gold Ingot", "Craft amount"] = _aMIGold;
                Logger.Warning("Craft amount of Gold Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMIDiamond <= 0)
            {
                _aMIDiamond = 10;
                Config["Diamond Ingot", "Craft amount"] = _aMIDiamond;
                Logger.Warning("Craft amount of Diamond Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMIDiamond > 10)
            {
                _aMIDiamond = 10;
                Config["Diamond Ingot", "Craft amount"] = _aMIDiamond;
                Logger.Warning("Craft amount of Diamond Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Checking config for errors... (60/82)", LogType.Console);
            if (_aMILithium <= 0)
            {
                _aMILithium = 10;
                Config["Lithium Ingot", "Craft amount"] = _aMILithium;
                Logger.Warning("Craft amount of Lithium Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMILithium > 10)
            {
                _aMILithium = 10;
                Config["Lithium Ingot", "Craft amount"] = _aMILithium;
                Logger.Warning("Craft amount of Lithium Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMICopper <= 0)
            {
                _aMICopper = 10;
                Config["Copper Ingot", "Craft amount"] = _aMICopper;
                Logger.Warning("Craft amount of Copper Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMICopper > 10)
            {
                _aMICopper = 10;
                Config["Copper Ingot", "Craft amount"] = _aMICopper;
                Logger.Warning("Craft amount of Copper Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMILead <= 0)
            {
                _aMILead = 10;
                Config["Lead Ingot", "Craft amount"] = _aMILead;
                Logger.Warning("Craft amount of Lead Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMILead > 10)
            {
                _aMILead = 10;
                Config["Lead Ingot", "Craft amount"] = _aMILead;
                Logger.Warning("Craft amount of Lead Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMISilver <= 0)
            {
                _aMISilver = 10;
                Config["Silver Ingot", "Craft amount"] = _aMISilver;
                Logger.Warning("Craft amount of Silver Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMISilver > 10)
            {
                _aMISilver = 10;
                Config["Silver Ingot", "Craft amount"] = _aMISilver;
                Logger.Warning("Craft amount of Silver Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMIMagnetite <= 0)
            {
                _aMIMagnetite = 10;
                Config["Magnetite Ingot", "Craft amount"] = _aMIMagnetite;
                Logger.Warning("Craft amount of Magnetite Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMIMagnetite > 10)
            {
                _aMIMagnetite = 10;
                Config["Magnetite Ingot", "Craft amount"] = _aMIMagnetite;
                Logger.Warning("Craft amount of Magnetite Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Checking config for errors... (70/82)", LogType.Console);
            if (_aMINickel <= 0)
            {
                _aMINickel = 10;
                Config["Nickel Ingot", "Craft amount"] = _aMINickel;
                Logger.Warning("Craft amount of Nickel Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMINickel > 10)
            {
                _aMINickel = 10;
                Config["Nickel Ingot", "Craft amount"] = _aMINickel;
                Logger.Warning("Craft amount of Nickel Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMIKyanite <= 0)
            {
                _aMIKyanite = 10;
                Config["Kyanite Ingot", "Craft amount"] = _aMIKyanite;
                Logger.Warning("Craft amount of Kyanite Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMIKyanite > 10)
            {
                _aMIKyanite = 10;
                Config["Kyanite Ingot", "Craft amount"] = _aMIKyanite;
                Logger.Warning("Craft amount of Kyanite Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMIRuby <= 0)
            {
                _aMIRuby = 10;
                Config["Ruby Ingot", "Craft amount"] = _aMIRuby;
                Logger.Warning("Craft amount of Ruby Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMIRuby > 10)
            {
                _aMIRuby = 10;
                Config["Ruby Ingot", "Craft amount"] = _aMIRuby;
                Logger.Warning("Craft amount of Ruby Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMIUraninite <= 0)
            {
                _aMIUraninite = 10;
                Config["Uraninite Ingot", "Craft amount"] = _aMIUraninite;
                Logger.Warning("Craft amount of Uraninite Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMIUraninite > 10)
            {
                _aMIUraninite = 10;
                Config["Uraninite Ingot", "Craft amount"] = _aMIUraninite;
                Logger.Warning("Craft amount of Uraninite Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMIQuartz <= 0)
            {
                _aMIQuartz = 10;
                Config["Quartz Ingot", "Craft amount"] = _aMIQuartz;
                Logger.Warning("Craft amount of Quartz Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMIQuartz > 10)
            {
                _aMIQuartz = 10;
                Config["Quartz Ingot", "Craft amount"] = _aMIQuartz;
                Logger.Warning("Craft amount of Quartz Ingot can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Checking config for errors... (80/82)", LogType.Console);
            if (_aMISalt <= 0)
            {
                _aMISalt = 10;
                Config["Salt Lick", "Craft amount"] = _aMISalt;
                Logger.Warning("Craft amount of Salt Lick can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            if (_aMISalt > 10)
            {
                _aMISalt = 10;
                Config["Salt Lick", "Craft amount"] = _aMISalt;
                Logger.Warning("Craft amount of Salt Lick can't be less than 1 or more than 10. It was set to 10", LogType.Custom | LogType.Console);
                configChanged = true;
            }
            Logger.Debug("Checking config for errors... (82/82)", LogType.Console);
            if (configChanged)
            {
                Logger.Debug("Error check complete. Some errors found and fixed", LogType.Console);
                Logger.Debug("Saving config...", LogType.Console);
                Config.Save();
                Logger.Debug("Config saved...", LogType.Console);
            }
            else
            {
                Logger.Debug("Error check complete. No errors found", LogType.Console);
            }

            Logger.Debug("Loading TechTypes... (0/13)", LogType.Console);
            var techTypeMIGold = TechTypePatcher.AddTechType("MIGold", "Gold Ingot", "Au. Condensed gold. Added by MoreIngots mod. ");
            var techTypeMIDiamond = TechTypePatcher.AddTechType("MIDiamond", "Compressed Diamond", "C. Condensed diamond. Added by MoreIngots mod");
            var techTypeMILithium = TechTypePatcher.AddTechType("MILithium", "Lithium Ingot", "Li. Condensed lithium. Added by MoreIngots mod");
            var techTypeMICopper = TechTypePatcher.AddTechType("MICopper", "Copper Ingot", "Cu. Condensed copper. Added by MoreIngots mod");
            var techTypeMILead = TechTypePatcher.AddTechType("MILead", "Lead Ingot", "Pb. Condensed lead. Added by MoreIngots mod");
            Logger.Debug("Loading TechTypes... (5/13)", LogType.Console);
            var techTypeMISilver = TechTypePatcher.AddTechType("MISilver", "Silver Ingot", "Ag. Condensed silver. Added by MoreIngots mod");
            var techTypeMIMagnetite = TechTypePatcher.AddTechType("MIMagnetite", "Magnetite Ingot", "γ-Fe2O3. Condensed magnetite. Added by MoreIngots mod");
            var techTypeMINickel = TechTypePatcher.AddTechType("MINickel", "Nickel Ingot", "Ni. Condensed nickel. Added by MoreIngots mod");
            var techTypeMIKyanite = TechTypePatcher.AddTechType("MIKyanite", "Kyanite Ingot", "Al2(F,OH)2SiO4. Condensed kyanite. Added by MoreIngots mod");
            var techTypeMIRuby = TechTypePatcher.AddTechType("MIRuby", "Ruby Ingot", "Al(OH)3. Condensed ruby. Added by MoreIngots mod");
            Logger.Debug("Loading TechTypes... (10/13)", LogType.Console);
            var techTypeMIUraninite = TechTypePatcher.AddTechType("MIUraninite", "Uraninite Ingot", "U3O8. Condensed uraninite. Added by MoreIngots mod");
            var techTypeMIQuartz = TechTypePatcher.AddTechType("MIQuartz", "Compressed Quartz", "SiO4. Condensed quartz. Added by MoreIngots mod");
            var techTypeMISalt = TechTypePatcher.AddTechType("MISalt", "Salt Lick", "NaCl. Salt. Added by MoreIngtos mod");
            Logger.Debug("Loading TechTypes... (13/13)", LogType.Console);
            Logger.Debug("TechTypes loaded", LogType.Console);

            Logger.Debug("Loading TechDatas... (0/26)", LogType.Console);
            var techDataMIGold = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.Gold, _aMIGold)
                },
                _techType = techTypeMIGold
            };
            var techDataMIGoldB = new TechDataHelper
            {
                _craftAmount = _aMIGold,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(techTypeMIGold, 1)
                },
                _techType = TechType.Gold
            };
            KnownTechPatcher.unlockedAtStart.Add(TechType.Gold);
            var techDataMIDiamond = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.Diamond, _aMIDiamond)
                },
                _techType = techTypeMIDiamond
            };
            var techDataMIDiamondB = new TechDataHelper
            {
                _craftAmount = _aMIDiamond,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(techTypeMIDiamond, 1)
                },
                _techType = TechType.Diamond
            };
            KnownTechPatcher.unlockedAtStart.Add(TechType.Diamond);
            var techDataMILithium = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.Lithium, _aMILithium)
                },
                _techType = techTypeMILithium
            };
            Logger.Debug("Loading TechDatas... (5/26)", LogType.Console);
            var techDataMILithiumB = new TechDataHelper
            {
                _craftAmount = _aMILithium,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(techTypeMILithium, 1)
}               ,
                _techType = TechType.Lithium
            };
            KnownTechPatcher.unlockedAtStart.Add(TechType.Lithium);
            var techDataMICopper = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.Copper, _aMICopper)
                },
                _techType = techTypeMICopper
            };
            var techDataMICopperB = new TechDataHelper
            {
                _craftAmount = _aMICopper,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(techTypeMICopper, 1)
                },
                _techType = TechType.Copper
            };
            KnownTechPatcher.unlockedAtStart.Add(TechType.Copper);
            var techDataMILead = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.Lead, _aMILead)
                },
                _techType = techTypeMILead
            };
            var techDataMILeadB = new TechDataHelper
            {
                _craftAmount = _aMILead,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(techTypeMILead, 1)
                },
                _techType = TechType.Lead
            };
            Logger.Debug("Loading TechDatas... (10/26)", LogType.Console);
            KnownTechPatcher.unlockedAtStart.Add(TechType.Lead);
            var techDataMISilver = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.Silver, _aMISilver)
                },
                _techType = techTypeMISilver
            };
            var techDataMISilverB = new TechDataHelper
            {
                _craftAmount = _aMISilver,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(techTypeMISilver, 1)
                },
                _techType = TechType.Silver
            };
            KnownTechPatcher.unlockedAtStart.Add(TechType.Silver);
            var techDataMIMagnetite = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.Magnetite, _aMIMagnetite)
                },
                _techType = techTypeMIMagnetite
            };
            var techDataMIMagnetiteB = new TechDataHelper
            {
                _craftAmount = _aMIMagnetite,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(techTypeMIMagnetite, 1)
                },
                _techType = TechType.Magnetite
            };
            KnownTechPatcher.unlockedAtStart.Add(TechType.Magnetite);
            var techDataMINickel = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.Nickel, _aMINickel)
                },
                _techType = techTypeMINickel
            };
            Logger.Debug("Loading TechDatas... (15/26)", LogType.Console);
            var techDataMINickelB = new TechDataHelper
            {
                _craftAmount = _aMINickel,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(techTypeMINickel, 1)
                },
                _techType = TechType.Nickel
            };
            KnownTechPatcher.unlockedAtStart.Add(TechType.Nickel);
            var techDataMIKyanite = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.Kyanite, _aMIKyanite)
                },
                _techType = techTypeMIKyanite
            };
            var techDataMIKyaniteB = new TechDataHelper
            {
                _craftAmount = _aMIKyanite,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(techTypeMIKyanite, 1)
                },
                _techType = TechType.Kyanite
            };
            KnownTechPatcher.unlockedAtStart.Add(TechType.Kyanite);
            var techDataMIRuby = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.AluminumOxide, _aMIRuby)
                },
                _techType = techTypeMIRuby
            };
            var techDataMIRubyB = new TechDataHelper
            {
                _craftAmount = _aMIRuby,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(techTypeMIRuby, 1)
                },
                _techType = TechType.AluminumOxide
            };
            Logger.Debug("Loading TechDatas... (20/26)", LogType.Console);
            KnownTechPatcher.unlockedAtStart.Add(TechType.AluminumOxide);
            var techDataMIUraninite = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.UraniniteCrystal, _aMIUraninite)
                },
                _techType = techTypeMIUraninite
            };
            var techDataMIUraniniteB = new TechDataHelper
            {
                _craftAmount = _aMIUraninite,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(techTypeMIUraninite, 1)
                },
                _techType = TechType.UraniniteCrystal
            };
            KnownTechPatcher.unlockedAtStart.Add(TechType.UraniniteCrystal);
            var techDataMIQuartz = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.Quartz, _aMIQuartz)
                },
                _techType = techTypeMIQuartz
            };
            var techDataMIQuartzB = new TechDataHelper
            {
                _craftAmount = _aMIQuartz,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(techTypeMIQuartz, 1)
                },
                _techType = TechType.Quartz
            };
            KnownTechPatcher.unlockedAtStart.Add(TechType.Quartz);
            var techDataMISalt = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(TechType.Salt, _aMISalt)
                },
                _techType = techTypeMISalt
            };
            Logger.Debug("Loading TechDatas... (25/26)", LogType.Console);
            var techDataMISaltB = new TechDataHelper
            {
                _craftAmount = _aMISalt,
                _ingredients = new List<IngredientHelper>()
                {
                    new IngredientHelper(techTypeMISalt, 1)
                },
                _techType = TechType.Salt
            };
            KnownTechPatcher.unlockedAtStart.Add(TechType.Salt);
            Logger.Debug("Loading TechDatas... (26/26)", LogType.Console);
            Logger.Debug("TechDatas loaded", LogType.Console);

            Logger.Debug("Loading sprites... (0/15)", LogType.Console);
            var spriteMIGold2 = assetBundlealt.LoadAsset<Sprite>("IPGold");
            var spriteMIDiamond2 = assetBundlealt.LoadAsset<Sprite>("IPDiamond");
            var spriteMILithium2 = assetBundlealt.LoadAsset<Sprite>("IPLithium");
            var spriteMICopper2 = assetBundlealt.LoadAsset<Sprite>("IPCopper");
            var spriteMILead2 = assetBundlealt.LoadAsset<Sprite>("IPLead");
            Logger.Debug("Loading sprites... (5/15)", LogType.Console);
            var spriteMISilver2 = assetBundlealt.LoadAsset<Sprite>("IPSilver");
            var spriteMIMagnetite2 = assetBundlealt.LoadAsset<Sprite>("IPMagnetite");
            var spriteMINickel2 = assetBundlealt.LoadAsset<Sprite>("IPNickel");
            var spriteMIKyanite2 = assetBundlealt.LoadAsset<Sprite>("IPKyanite");
            var spriteMIRuby2 = assetBundlealt.LoadAsset<Sprite>("IPRuby");
            Logger.Debug("Loading sprites... (10/15)", LogType.Console);
            var spriteMIUraninite2 = assetBundlealt.LoadAsset<Sprite>("IPUraninite");
            var spriteMIQuartz2 = assetBundlealt.LoadAsset<Sprite>("IPQuartz");
            var spritetabcraft2 = assetBundlealt.LoadAsset<Sprite>("IPFabTabCraft");
            var spritetabunpack2 = assetBundlealt.LoadAsset<Sprite>("IPFabTabUnpack");
            Logger.Debug("Loading sprites... (14/15)", LogType.Console);
            //var SpriteSaltYenz = saltassetsyenz.LoadAsset<Sprite>("Salt");
            Logger.Warning("Asset \"Salt\" from asset bundle \"salt-yenzen\" is missing. We'll use \"Salt\" from \"salt-alexejheroytb\" instead. (This message is harmless)");
            Logger.Debug("Loading sprites... (15/15)", LogType.Console);
            Logger.Debug("Sprites loaded", LogType.Console);

            Logger.Debug("Loading alternative sprites... (0/15)", LogType.Console);
            var spriteMIGold = assetBundle.LoadAsset<Sprite>("MIGold");
            var spriteMIDiamond = assetBundle.LoadAsset<Sprite>("MIDiamond");
            var spriteMILithium = assetBundle.LoadAsset<Sprite>("MILithium");
            var spriteMICopper = assetBundle.LoadAsset<Sprite>("MICopper");
            var spriteMILead = assetBundle.LoadAsset<Sprite>("MILead");
            Logger.Debug("Loading alternative sprites... (5/15)", LogType.Console);
            var spriteMISilver = assetBundle.LoadAsset<Sprite>("MISilver");
            var spriteMIMagnetite = assetBundle.LoadAsset<Sprite>("MIMagnetite");
            var spriteMINickel = assetBundle.LoadAsset<Sprite>("MINickel");
            var spriteMIKyanite = assetBundle.LoadAsset<Sprite>("MIKyanite");
            var spriteMIRuby = assetBundle.LoadAsset<Sprite>("MIRuby");
            Logger.Debug("Loading alternative sprites... (10/15)", LogType.Console);
            var spriteMIUraninite = assetBundle.LoadAsset<Sprite>("MIUraninite");
            var spriteMIQuartz = assetBundle.LoadAsset<Sprite>("MIQuartz");
            var spritetabcraft = assetBundle.LoadAsset<Sprite>("MIFabTabCraft");
            var spritetabunpack = assetBundle.LoadAsset<Sprite>("MIFabTabUnpack");
            var SpriteSaltAlex = saltassetsalex.LoadAsset<Sprite>("Salt");
            Logger.Debug("Loading alternative sprites... (15/15)", LogType.Console);
            Logger.Debug("Alternative sprites loaded", LogType.Console);

            if (_alttextures == true)
            {
                Logger.Info("Alternative textures is true");
                Logger.Debug("Applying alternative sprites... (0/13)", LogType.Console);
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIGold, spriteMIGold));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIDiamond, spriteMIDiamond));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMILithium, spriteMILithium));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMICopper, spriteMICopper));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMILead, spriteMILead));
                Logger.Debug("Applying alternative sprites... (5/13)", LogType.Console);
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMISilver, spriteMISilver));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIMagnetite, spriteMIMagnetite));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMINickel, spriteMINickel));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIKyanite, spriteMIKyanite));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIRuby, spriteMIRuby));
                Logger.Debug("Applying alternative sprites... (10/13)", LogType.Console);
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIUraninite, spriteMIUraninite));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIQuartz, spriteMIQuartz));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMISalt, SpriteSaltAlex));
                Logger.Debug("Applying alternative sprites... (13/13)", LogType.Console);
                Logger.Debug("Alernative sprites applied", LogType.Console);
                Logger.Debug("Loading fabricator tabs with alternative sprites... (0/2)", LogType.Console);
                CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/Craft", "Craft MoreIngots", CraftScheme.Fabricator, spritetabcraft));
                Logger.Debug("Loading fabricator tabs with alternative sprites... (1/2)", LogType.Console);
                CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/Unpack", "Unpack MoreIngots", CraftScheme.Fabricator, spritetabunpack));
                Logger.Debug("Loading fabricator tabs with alternative sprites... (2/2)", LogType.Console);
                Logger.Debug("Fabricator tabs with alternative sprites loaded", LogType.Console);
            }
            else
            {
                Logger.Info("Alternative textures is false");
                Logger.Debug("Applying sprites... (0/13)", LogType.Console);
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIGold, spriteMIGold2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIDiamond, spriteMIDiamond2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMILithium, spriteMILithium2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMICopper, spriteMICopper2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMILead, spriteMILead2));
                Logger.Debug("Applying sprites... (5/13)", LogType.Console);
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMISilver, spriteMISilver2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIMagnetite, spriteMIMagnetite2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMINickel, spriteMINickel2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIKyanite, spriteMIKyanite2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIRuby, spriteMIRuby2));
                Logger.Debug("Applying sprites... (10/13)", LogType.Console);
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIUraninite, spriteMIUraninite2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIQuartz, spriteMIQuartz2));
                Logger.Debug("Applying sprites... (12/13)", LogType.Console);
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMISalt, SpriteSaltAlex));
                //CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMISalt, SpriteSaltYenz));
                Logger.Warning("Applied sprite \"Salt\" from asset bundle \"salt-alexejheroytb\" instead of asset \"Salt\" from asset bundle \"salt-yenzen\" for techtype \"MISalt\" (This message is harmless)");
                Logger.Debug("Applying sprites... (13/13)", LogType.Console);
                Logger.Debug("Sprites applied", LogType.Console);
                Logger.Debug("Loading fabricator tabs... (0/2)", LogType.Console);
                CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/Craft", "Craft MoreIngots", CraftScheme.Fabricator, spritetabcraft2));
                Logger.Debug("Loading fabricator tabs... (1/2)", LogType.Console);
                CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/Unpack", "Unpack MoreIngots", CraftScheme.Fabricator, spritetabunpack2));
                Logger.Debug("Loading fabricator tabs... (2/2)", LogType.Console);
                Logger.Debug("Fabricator tabs loaded", LogType.Console);
            }

            Logger.Debug("Adding TechTypes to the PDA Databank... (0/26)", LogType.Console);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMIGold);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMIDiamond);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMILithium);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMICopper);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMILead);
            Logger.Debug("Adding TechTypes to the PDA Databank... (5/26)", LogType.Console);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMISilver);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMIMagnetite);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMINickel);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMIKyanite);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMIRuby);
            Logger.Debug("Adding TechTypes to the PDA Databank... (10/26)", LogType.Console);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMIUraninite);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMIQuartz);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMISalt);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Gold);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Diamond);
            Logger.Debug("Adding TechTypes to the PDA Databank... (15/26)", LogType.Console);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Lithium);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Copper);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Lead);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Silver);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Magnetite);
            Logger.Debug("Adding TechTypes to the PDA Databank... (20/26)", LogType.Console);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Nickel);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Kyanite);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.AluminumOxide);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.UraniniteCrystal);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Quartz);
            Logger.Debug("Adding TechTypes to the PDA Databank... (25/26)", LogType.Console);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Salt);
            Logger.Debug("Adding TechTypes to the PDA Databank... (26/26)", LogType.Console);
            Logger.Debug("TechTypes added to the PDA Databank", LogType.Console);

            Logger.Debug("Linking recipes... (0/26)", LogType.Console);
            CraftDataPatcher.customTechData.Add(techTypeMIGold, techDataMIGold);
            CraftDataPatcher.customTechData.Add(TechType.Gold, techDataMIGoldB);
            CraftDataPatcher.customTechData.Add(techTypeMIDiamond, techDataMIDiamond);
            CraftDataPatcher.customTechData.Add(TechType.Diamond, techDataMIDiamondB);
            CraftDataPatcher.customTechData.Add(techTypeMILithium, techDataMILithium);
            Logger.Debug("Linking recipes... (5/26)", LogType.Console);
            CraftDataPatcher.customTechData.Add(TechType.Lithium, techDataMILithiumB);
            CraftDataPatcher.customTechData.Add(techTypeMICopper, techDataMICopper);
            CraftDataPatcher.customTechData.Add(TechType.Copper, techDataMICopperB);
            CraftDataPatcher.customTechData.Add(techTypeMILead, techDataMILead);
            CraftDataPatcher.customTechData.Add(TechType.Lead, techDataMILeadB);
            Logger.Debug("Linking recipes... (10/26)", LogType.Console);
            CraftDataPatcher.customTechData.Add(techTypeMISilver, techDataMISilver);
            CraftDataPatcher.customTechData.Add(TechType.Silver, techDataMISilverB);
            CraftDataPatcher.customTechData.Add(techTypeMIMagnetite, techDataMIMagnetite);
            CraftDataPatcher.customTechData.Add(TechType.Magnetite, techDataMIMagnetiteB);
            CraftDataPatcher.customTechData.Add(techTypeMINickel, techDataMINickel);
            Logger.Debug("Linking recipes... (15/26)", LogType.Console);
            CraftDataPatcher.customTechData.Add(TechType.Nickel, techDataMINickelB);
            CraftDataPatcher.customTechData.Add(techTypeMIKyanite, techDataMIKyanite);
            CraftDataPatcher.customTechData.Add(TechType.Kyanite, techDataMIKyaniteB);
            CraftDataPatcher.customTechData.Add(techTypeMIRuby, techDataMIRuby);
            CraftDataPatcher.customTechData.Add(TechType.AluminumOxide, techDataMIRubyB);
            Logger.Debug("Linking recipes... (20/26)", LogType.Console);
            CraftDataPatcher.customTechData.Add(techTypeMIUraninite, techDataMIUraninite);
            CraftDataPatcher.customTechData.Add(TechType.UraniniteCrystal, techDataMIUraniniteB);
            CraftDataPatcher.customTechData.Add(techTypeMIQuartz, techDataMIQuartz);
            CraftDataPatcher.customTechData.Add(TechType.Quartz, techDataMIQuartzB);
            CraftDataPatcher.customTechData.Add(techTypeMISalt, techDataMISalt);
            Logger.Debug("Linking recipes... (25/26)", LogType.Console);
            CraftDataPatcher.customTechData.Add(TechType.Salt, techDataMISaltB);
            Logger.Debug("Linking recipes... (26/26)", LogType.Console);
            Logger.Debug("Recipes linked", LogType.Console);

            Logger.Debug("Adding fabricator nodes... (0/26)", LogType.Console);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMIGold, CraftScheme.Fabricator, "Resources/Craft/MIGold"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Gold, CraftScheme.Fabricator, "Resources/Unpack/Gold"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMIDiamond, CraftScheme.Fabricator, "Resources/Craft/MIDiamond"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Diamond, CraftScheme.Fabricator, "Resources/Unpack/Diamond"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMILithium, CraftScheme.Fabricator, "Resources/Craft/MILithium"));
            Logger.Debug("Adding fabricator nodes... (5/26)", LogType.Console);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Lithium, CraftScheme.Fabricator, "Resources/Unpack/Lithium"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMICopper, CraftScheme.Fabricator, "Resources/Craft/MICopper"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Copper, CraftScheme.Fabricator, "Resources/Unpack/Copper"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMILead, CraftScheme.Fabricator, "Resources/Craft/MILead"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Lead, CraftScheme.Fabricator, "Resources/Unpack/Lead"));
            Logger.Debug("Adding fabricator nodes... (10/26)", LogType.Console);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMISilver, CraftScheme.Fabricator, "Resources/Craft/MISilver"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Silver, CraftScheme.Fabricator, "Resources/Unpack/Silver"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMIMagnetite, CraftScheme.Fabricator, "Resources/Craft/MIMagnetite"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Magnetite, CraftScheme.Fabricator, "Resources/Unpack/Magnetite"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMINickel, CraftScheme.Fabricator, "Resources/Craft/MINickel"));
            Logger.Debug("Adding fabricator nodes... (15/26)", LogType.Console);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Nickel, CraftScheme.Fabricator, "Resources/Unpack/Nickel"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMIKyanite, CraftScheme.Fabricator, "Resources/Craft/MIKyanite"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Kyanite, CraftScheme.Fabricator, "Resources/Unpack/Kyanite"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMIRuby, CraftScheme.Fabricator, "Resources/Craft/MIRuby"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.AluminumOxide, CraftScheme.Fabricator, "Resources/Unpack/AluminumOxide"));
            Logger.Debug("Adding fabricator nodes... (20/26)", LogType.Console);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMIUraninite, CraftScheme.Fabricator, "Resources/Craft/MIUraninite"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.UraniniteCrystal, CraftScheme.Fabricator, "Resources/Unpack/UraniniteCrystal"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMIQuartz, CraftScheme.Fabricator, "Resources/Craft/MIQuartz"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Quartz, CraftScheme.Fabricator, "Resources/Unpack/Quartz"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMISalt, CraftScheme.Fabricator, "Resources/Craft/MISalt"));
            Logger.Debug("Adding fabricator nodes... (25/26)", LogType.Console);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Salt, CraftScheme.Fabricator, "Resources/Unpack/Salt"));
            Logger.Debug("Adding fabricator nodes... (26/26)", LogType.Console);
            Logger.Debug("Fabricator nodes added", LogType.Console);

            Logger.Debug("Setting custom item sizes... (0/14)", LogType.Console);
            CraftDataPatcher.customItemSizes[key: techTypeMIGold] = new Vector2int(x: _xMIGold, y: _yMIGold);
            CraftDataPatcher.customItemSizes[key: techTypeMIDiamond] = new Vector2int(x: _xMIDiamond, y: _yMIDiamond);
            CraftDataPatcher.customItemSizes[key: techTypeMILithium] = new Vector2int(x: _xMILithium, y: _yMILithium);
            CraftDataPatcher.customItemSizes[key: techTypeMICopper] = new Vector2int(x: _xMICopper, y: _yMICopper);
            CraftDataPatcher.customItemSizes[key: techTypeMILead] = new Vector2int(x: _xMILead, y: _yMILead);
            Logger.Debug("Setting custom item sizes... (5/14)", LogType.Console);
            CraftDataPatcher.customItemSizes[key: techTypeMISilver] = new Vector2int(x: _xMISilver, y: _yMISilver);
            CraftDataPatcher.customItemSizes[key: techTypeMIMagnetite] = new Vector2int(x: _xMIMagnetite, y: _yMIMagnetite);
            CraftDataPatcher.customItemSizes[key: techTypeMINickel] = new Vector2int(x: _xMINickel, y: _yMINickel);
            CraftDataPatcher.customItemSizes[key: techTypeMIKyanite] = new Vector2int(x: _xMIKyanite, y: _yMIKyanite);
            CraftDataPatcher.customItemSizes[key: techTypeMIRuby] = new Vector2int(x: _xMIRuby, y: _yMIRuby);
            Logger.Debug("Setting custom item sizes... (10/14)", LogType.Console);
            CraftDataPatcher.customItemSizes[key: techTypeMIUraninite] = new Vector2int(x: _xMIUraninite, y: _yMIUraninite);
            CraftDataPatcher.customItemSizes[key: techTypeMIQuartz] = new Vector2int(x: _xMIQuartz, y: _yMIQuartz);
            CraftDataPatcher.customItemSizes[key: techTypeMISalt] = new Vector2int(x: _xMISalt, y: _yMISalt);
            CraftDataPatcher.customItemSizes[key: TechType.TitaniumIngot] = new Vector2int(x: _xTitaniumIngot, y: _yTitaniumIngot);
            Logger.Debug("Setting custom item sizes... (14/14)", LogType.Console);
            Logger.Debug("Custom item sizes set", LogType.Console);
            Logger.Debug("Finished loading", LogType.Console);
        }
    }
} 
