using SMLHelper;
using SMLHelper.Patchers;
using System.Collections.Generic;
using UnityEngine;
using Utilites.Config;
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
        public static void Patch()
        {
            var assetBundle = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/Assets/moreingots.assets");
            var assetBundlealt = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/Assets/yenzen-ingotsplus.assets");
            Config.Load();
            var configChanged =
            Config.TryGet(ref _alttextures, "Alternative textures")
            | Config.TryGet(ref _xTitaniumIngot, "TItanium Ingot", "Size", "x")
            | Config.TryGet(ref _yTitaniumIngot, "TItanium Ingot", "Size", "y")
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
            | Config.TryGet(ref _xMISilver, "SIlver Ingot", "Size", "x")
            | Config.TryGet(ref _yMISilver, "SIlver Ingot", "Size", "y")
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
            ;
            if (_alttextures == false) { }
            else if (_alttextures == true) { }
            else
            {
                _alttextures = false;
                Config["Alternative textures"] = _alttextures;
                Utilites.Logger.Logger.Error("Alternative textures must be \"true\" or \"false\"", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xTitaniumIngot <= 0)
            {
                _xTitaniumIngot = 1;
                Config["TItanium Ingot", "Size", "x"] = _xTitaniumIngot;
                Utilites.Logger.Logger.Error("Size of Titanium Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yTitaniumIngot <= 0)
            {
                _yTitaniumIngot = 1;
                Config["TItanium Ingot", "Size", "y"] = _yTitaniumIngot;
                Utilites.Logger.Logger.Error("Size of Titanium Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMIGold <= 0)
            {
                _xMIGold = 1;
                Config["Gold Ingot", "Size", "x"] = _xMIGold;
                Utilites.Logger.Logger.Error("Size of Gold Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMIGold <= 0)
            {
                _yMIGold = 1;
                Config["Gold Ingot", "Size", "y"] = _yMIGold;
                Utilites.Logger.Logger.Error("Size of Gold Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMIDiamond <= 0)
            {
                _xMIDiamond = 1;
                Config["Diamond Ingot", "Size", "x"] = _xMIDiamond;
                Utilites.Logger.Logger.Error("Size of Diamond Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMIDiamond <= 0)
            {
                _yMIDiamond = 1;
                Config["Diamond Ingot", "Size", "y"] = _yMIDiamond;
                Utilites.Logger.Logger.Error("Size of Diamond Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMILithium <= 0)
            {
                _xMILithium = 1;
                Config["Lithium Ingot", "Size", "x"] = _xMILithium;
                Utilites.Logger.Logger.Error("Size of Lithium Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMILithium <= 0)
            {
                _yMILithium = 1;
                Config["Lithium Ingot", "Size", "y"] = _yMILithium;
                Utilites.Logger.Logger.Error("Size of Lithium Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMICopper <= 0)
            {
                _xMICopper = 1;
                Config["Copper Ingot", "Size", "x"] = _xMICopper;
                Utilites.Logger.Logger.Error("Size of Copper Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMICopper <= 0)
            {
                _yMICopper = 1;
                Config["Copper Ingot", "Size", "y"] = _yMICopper;
                Utilites.Logger.Logger.Error("Size of Copper Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMILead <= 0)
            {
                _xMILead = 1;
                Config["Lead Ingot", "Size", "x"] = _xMILead;
                Utilites.Logger.Logger.Error("Size of Lead Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMILead <= 0)
            {
                _yMILead = 1;
                Config["Lead Ingot", "Size", "y"] = _yMILead;
                Utilites.Logger.Logger.Error("Size of Lead Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMISilver <= 0)
            {
                _xMISilver = 1;
                Config["SIlver Ingot", "Size", "x"] = _xMISilver;
                Utilites.Logger.Logger.Error("Size of Silver Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMISilver <= 0)
            {
                _yMISilver = 1;
                Config["SIlver Ingot", "Size", "y"] = _yMISilver;
                Utilites.Logger.Logger.Error("Size of Silver Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMIMagnetite <= 0)
            {
                _xMIMagnetite = 1;
                Config["Magnetite Ingot", "Size", "x"] = _xMIMagnetite;
                Utilites.Logger.Logger.Error("Size of Magnetite Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMIMagnetite <= 0)
            {
                _yMIMagnetite = 1;
                Config["Magnetite Ingot", "Size", "y"] = _yMIMagnetite;
                Utilites.Logger.Logger.Error("Size of Magnetite Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMINickel <= 0)
            {
                _xMINickel = 1;
                Config["Nickel Ingot", "Size", "x"] = _xMINickel;
                Utilites.Logger.Logger.Error("Size of Nickel Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMINickel <= 0)
            {
                _yMINickel = 1;
                Config["Nickel Ingot", "Size", "y"] = _yMINickel;
                Utilites.Logger.Logger.Error("Size of Nickel Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMIKyanite <= 0)
            {
                _xMIKyanite = 1;
                Config["Kyanite Ingot", "Size", "x"] = _xMIKyanite;
                Utilites.Logger.Logger.Error("Size of Kyanite Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMIKyanite <= 0)
            {
                _yMIKyanite = 1;
                Config["Kyanite Ingot", "Size", "y"] = _yMIKyanite;
                Utilites.Logger.Logger.Error("Size of Kyanite Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMIRuby <= 0)
            {
                _xMIRuby = 1;
                Config["Ruby Ingot", "Size", "x"] = _xMIRuby;
                Utilites.Logger.Logger.Error("Size of Ruby Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMIRuby <= 0)
            {
                _yMIRuby = 1;
                Config["Ruby Ingot", "Size", "y"] = _yMIRuby;
                Utilites.Logger.Logger.Error("Size of Ruby Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMIUraninite <= 0)
            {
                _xMIUraninite = 1;
                Config["Uraninite Ingot", "Size", "x"] = _xMIUraninite;
                Utilites.Logger.Logger.Error("Size of Uraninite Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMIUraninite <= 0)
            {
                _yMIUraninite = 1;
                Config["Uraninite Ingot", "Size", "y"] = _yMIUraninite;
                Utilites.Logger.Logger.Error("Size of Uraninite Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMIQuartz <= 0)
            {
                _xMIQuartz = 1;
                Config["Quartz Ingot", "Size", "x"] = _xMIQuartz;
                Utilites.Logger.Logger.Error("Size of Quartz Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMIQuartz <= 0)
            {
                _yMIQuartz = 1;
                Config["Quartz Ingot", "Size", "y"] = _yMIQuartz;
                Utilites.Logger.Logger.Error("Size of Quartz Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (configChanged)
            {
                Config.Save();
            }
            var techTypeMIGold = TechTypePatcher.AddTechType("MIGold", "Gold Ingot", "Au. Condensed gold. Added by MoreIngots mod. ");
            var techTypeMIDiamond = TechTypePatcher.AddTechType("MIDiamond", "Diamond Ingot", "C. Condensed diamond. Added by MoreIngots mod");
            var techTypeMILithium = TechTypePatcher.AddTechType("MILithium", "Lithium Ingot", "Li. Condensed lithium. Added by MoreIngots mod");
            var techTypeMICopper = TechTypePatcher.AddTechType("MICopper", "Copper Ingot", "Cu. Condensed copper. Added by MoreIngots mod");
            var techTypeMILead = TechTypePatcher.AddTechType("MILead", "Lead Ingot", "Pb. Condensed lead. Added by MoreIngots mod");
            var techTypeMISilver = TechTypePatcher.AddTechType("MISilver", "Silver Ingot", "Ag. Condensed silver. Added by MoreIngots mod");
            var techTypeMIMagnetite = TechTypePatcher.AddTechType("MIMagnetite", "Magnetite Ingot", "γ-Fe2O3. Condensed magnetite. Added by MoreIngots mod");
            var techTypeMINickel = TechTypePatcher.AddTechType("MINickel", "Nickel Ingot", "Ni. Condensed nickel. Added by MoreIngots mod");
            var techTypeMIKyanite = TechTypePatcher.AddTechType("MIKyanite", "Kyanite Ingot", "Al2(F,OH)2SiO4. Condensed kyanite. Added by MoreIngots mod");
            var techTypeMIRuby = TechTypePatcher.AddTechType("MIRuby", "Ruby Ingot", "Al(OH)3. Condensed ruby. Added by MoreIngots mod");
            var techTypeMIUraninite = TechTypePatcher.AddTechType("MIUraninite", "Uraninite Ingot", "U3O8. Condensed uraninite. Added by MoreIngots mod");
            var techTypeMIQuartz = TechTypePatcher.AddTechType("MIQuartz", "Quartz Ingot", "SiO4. Condensed quartz. Added by MoreIngots mod");
            var techDataMIGold = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
{
new IngredientHelper(TechType.Gold, 10)
},
                _techType = techTypeMIGold
            };
            var techDataMIGoldB = new TechDataHelper
            {
                _craftAmount = 10,
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
new IngredientHelper(TechType.Diamond, 10)
},
                _techType = techTypeMIDiamond
            };
            var techDataMIDiamondB = new TechDataHelper
            {
                _craftAmount = 10,
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
new IngredientHelper(TechType.Lithium, 10)
},
                _techType = techTypeMILithium
            };
            var techDataMILithiumB = new TechDataHelper
            {
                _craftAmount = 10,
                _ingredients = new List<IngredientHelper>()
{
new IngredientHelper(techTypeMILithium, 1)
},
                _techType = TechType.Lithium
            };
            KnownTechPatcher.unlockedAtStart.Add(TechType.Lithium);
            var techDataMICopper = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
{
new IngredientHelper(TechType.Copper, 10)
},
                _techType = techTypeMICopper
            };
            var techDataMICopperB = new TechDataHelper
            {
                _craftAmount = 10,
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
new IngredientHelper(TechType.Lead, 10)
},
                _techType = techTypeMILead
            };
            var techDataMILeadB = new TechDataHelper
            {
                _craftAmount = 10,
                _ingredients = new List<IngredientHelper>()
{
new IngredientHelper(techTypeMILead, 1)
},
                _techType = TechType.Lead
            };
            KnownTechPatcher.unlockedAtStart.Add(TechType.Lead);
            var techDataMISilver = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
{
new IngredientHelper(TechType.Silver, 10)
},
                _techType = techTypeMISilver
            };
            var techDataMISilverB = new TechDataHelper
            {
                _craftAmount = 10,
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
new IngredientHelper(TechType.Magnetite, 10)
},
                _techType = techTypeMIMagnetite
            };
            var techDataMIMagnetiteB = new TechDataHelper
            {
                _craftAmount = 10,
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
new IngredientHelper(TechType.Nickel, 10)
},
                _techType = techTypeMINickel
            };
            var techDataMINickelB = new TechDataHelper
            {
                _craftAmount = 10,
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
new IngredientHelper(TechType.Kyanite, 10)
},
                _techType = techTypeMIKyanite
            };
            var techDataMIKyaniteB = new TechDataHelper
            {
                _craftAmount = 10,
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
new IngredientHelper(TechType.AluminumOxide, 10)
},
                _techType = techTypeMIRuby
            };
            var techDataMIRubyB = new TechDataHelper
            {
                _craftAmount = 10,
                _ingredients = new List<IngredientHelper>()
{
new IngredientHelper(techTypeMIRuby, 1)
},
                _techType = TechType.AluminumOxide
            };
            KnownTechPatcher.unlockedAtStart.Add(TechType.AluminumOxide);
            var techDataMIUraninite = new TechDataHelper
            {
                _craftAmount = 1,
                _ingredients = new List<IngredientHelper>()
{
new IngredientHelper(TechType.UraniniteCrystal, 10)
},
                _techType = techTypeMIUraninite
            };
            var techDataMIUraniniteB = new TechDataHelper
            {
                _craftAmount = 10,
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
new IngredientHelper(TechType.Quartz, 10)
},
                _techType = techTypeMIQuartz
            };
            var techDataMIQuartzB = new TechDataHelper
            {
                _craftAmount = 10,
                _ingredients = new List<IngredientHelper>()
{
new IngredientHelper(techTypeMIQuartz, 1)
},
                _techType = TechType.Quartz
            };
            KnownTechPatcher.unlockedAtStart.Add(TechType.Quartz);
            var spriteMIGold = assetBundle.LoadAsset<Sprite>("MIGold");
            var spriteMIDiamond = assetBundle.LoadAsset<Sprite>("MIDiamond");
            var spriteMILithium = assetBundle.LoadAsset<Sprite>("MILithium");
            var spriteMICopper = assetBundle.LoadAsset<Sprite>("MICopper");
            var spriteMILead = assetBundle.LoadAsset<Sprite>("MILead");
            var spriteMISilver = assetBundle.LoadAsset<Sprite>("MISilver");
            var spriteMIMagnetite = assetBundle.LoadAsset<Sprite>("MIMagnetite");
            var spriteMINickel = assetBundle.LoadAsset<Sprite>("MINickel");
            var spriteMIKyanite = assetBundle.LoadAsset<Sprite>("MIKyanite");
            var spriteMIRuby = assetBundle.LoadAsset<Sprite>("MIRuby");
            var spriteMIUraninite = assetBundle.LoadAsset<Sprite>("MIUraninite");
            var spriteMIQuartz = assetBundle.LoadAsset<Sprite>("MIQuartz");
            var spritetabcraft = assetBundle.LoadAsset<Sprite>("MIFabTabCraft");
            var spritetabunpack = assetBundle.LoadAsset<Sprite>("MIFabTabUnpack");
            var spriteMIGold2 = assetBundlealt.LoadAsset<Sprite>("IPGold");
            var spriteMIDiamond2 = assetBundlealt.LoadAsset<Sprite>("IPDiamond");
            var spriteMILithium2 = assetBundlealt.LoadAsset<Sprite>("IPLithium");
            var spriteMICopper2 = assetBundlealt.LoadAsset<Sprite>("IPCopper");
            var spriteMILead2 = assetBundlealt.LoadAsset<Sprite>("IPLead");
            var spriteMISilver2 = assetBundlealt.LoadAsset<Sprite>("IPSilver");
            var spriteMIMagnetite2 = assetBundlealt.LoadAsset<Sprite>("IPMagnetite");
            var spriteMINickel2 = assetBundlealt.LoadAsset<Sprite>("IPNickel");
            var spriteMIKyanite2 = assetBundlealt.LoadAsset<Sprite>("IPKyanite");
            var spriteMIRuby2 = assetBundlealt.LoadAsset<Sprite>("IPRuby");
            var spriteMIUraninite2 = assetBundlealt.LoadAsset<Sprite>("IPUraninite");
            var spriteMIQuartz2 = assetBundlealt.LoadAsset<Sprite>("IPQuartz");
            var spritetabcraft2 = assetBundlealt.LoadAsset<Sprite>("IPFabTabCraft");
            var spritetabunpack2 = assetBundlealt.LoadAsset<Sprite>("IPFabTabUnpack");
            if (_alttextures == true)
            {
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIGold, spriteMIGold));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIDiamond, spriteMIDiamond));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMILithium, spriteMILithium));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMICopper, spriteMICopper));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMILead, spriteMILead));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMISilver, spriteMISilver));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIMagnetite, spriteMIMagnetite));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMINickel, spriteMINickel));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIKyanite, spriteMIKyanite));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIRuby, spriteMIRuby));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIUraninite, spriteMIUraninite));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIQuartz, spriteMIQuartz));
                CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/Craft", "Craft MoreIngots", CraftScheme.Fabricator, spritetabcraft));
                CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/Unpack", "Unpack MoreIngots", CraftScheme.Fabricator, spritetabunpack));
            }
            else
            {
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIGold, spriteMIGold2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIDiamond, spriteMIDiamond2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMILithium, spriteMILithium2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMICopper, spriteMICopper2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMILead, spriteMILead2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMISilver, spriteMISilver2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIMagnetite, spriteMIMagnetite2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMINickel, spriteMINickel2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIKyanite, spriteMIKyanite2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIRuby, spriteMIRuby2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIUraninite, spriteMIUraninite2));
                CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIQuartz, spriteMIQuartz2));
                CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/Craft", "Craft MoreIngots", CraftScheme.Fabricator, spritetabcraft2));
                CraftTreePatcher.customTabs.Add(new CustomCraftTab("Resources/Unpack", "Unpack MoreIngots", CraftScheme.Fabricator, spritetabunpack2));
            }
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMIGold);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMIDiamond);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMILithium);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMICopper);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMILead);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMISilver);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMIMagnetite);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMINickel);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMIKyanite);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMIRuby);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMIUraninite);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techTypeMIQuartz);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Gold);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Diamond);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Lithium);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Copper);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Lead);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Silver);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Magnetite);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Nickel);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Kyanite);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.AluminumOxide);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.UraniniteCrystal);
            CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, TechType.Quartz);
            CraftDataPatcher.customTechData.Add(techTypeMIGold, techDataMIGold);
            CraftDataPatcher.customTechData.Add(TechType.Gold, techDataMIGoldB);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMIGold, CraftScheme.Fabricator, "Resources/Craft/MIGold"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Gold, CraftScheme.Fabricator, "Resources/Unpack/Gold"));
            CraftDataPatcher.customItemSizes[key: techTypeMIGold] = new Vector2int(x: _xMIGold, y: _yMIGold);
            CraftDataPatcher.customTechData.Add(techTypeMIDiamond, techDataMIDiamond);
            CraftDataPatcher.customTechData.Add(TechType.Diamond, techDataMIDiamondB);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMIDiamond, CraftScheme.Fabricator, "Resources/Craft/MIDiamond"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Diamond, CraftScheme.Fabricator, "Resources/Unpack/Diamond"));
            CraftDataPatcher.customItemSizes[key: techTypeMIDiamond] = new Vector2int(x: _xMIDiamond, y: _yMIDiamond);
            CraftDataPatcher.customTechData.Add(techTypeMILithium, techDataMILithium);
            CraftDataPatcher.customTechData.Add(TechType.Lithium, techDataMILithiumB);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMILithium, CraftScheme.Fabricator, "Resources/Craft/MILithium"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Lithium, CraftScheme.Fabricator, "Resources/Unpack/Lithium"));
            CraftDataPatcher.customItemSizes[key: techTypeMILithium] = new Vector2int(x: _xMILithium, y: _yMILithium);
            CraftDataPatcher.customTechData.Add(techTypeMICopper, techDataMICopper);
            CraftDataPatcher.customTechData.Add(TechType.Copper, techDataMICopperB);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMICopper, CraftScheme.Fabricator, "Resources/Craft/MICopper"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Copper, CraftScheme.Fabricator, "Resources/Unpack/Copper"));
            CraftDataPatcher.customItemSizes[key: techTypeMICopper] = new Vector2int(x: _xMICopper, y: _yMICopper);
            CraftDataPatcher.customTechData.Add(techTypeMILead, techDataMILead);
            CraftDataPatcher.customTechData.Add(TechType.Lead, techDataMILeadB);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMILead, CraftScheme.Fabricator, "Resources/Craft/MILead"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Lead, CraftScheme.Fabricator, "Resources/Unpack/Lead"));
            CraftDataPatcher.customItemSizes[key: techTypeMILead] = new Vector2int(x: _xMILead, y: _yMILead);
            CraftDataPatcher.customTechData.Add(techTypeMISilver, techDataMISilver);
            CraftDataPatcher.customTechData.Add(TechType.Silver, techDataMISilverB);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMISilver, CraftScheme.Fabricator, "Resources/Craft/MISilver"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Silver, CraftScheme.Fabricator, "Resources/Unpack/Silver"));
            CraftDataPatcher.customItemSizes[key: techTypeMISilver] = new Vector2int(x: _xMISilver, y: _yMISilver);
            CraftDataPatcher.customTechData.Add(techTypeMIMagnetite, techDataMIMagnetite);
            CraftDataPatcher.customTechData.Add(TechType.Magnetite, techDataMIMagnetiteB);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMIMagnetite, CraftScheme.Fabricator, "Resources/Craft/MIMagnetite"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Magnetite, CraftScheme.Fabricator, "Resources/Unpack/Magnetite"));
            CraftDataPatcher.customItemSizes[key: techTypeMIMagnetite] = new Vector2int(x: _xMIMagnetite, y: _yMIMagnetite);
            CraftDataPatcher.customTechData.Add(techTypeMINickel, techDataMINickel);
            CraftDataPatcher.customTechData.Add(TechType.Nickel, techDataMINickelB);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMINickel, CraftScheme.Fabricator, "Resources/Craft/MINickel"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Nickel, CraftScheme.Fabricator, "Resources/Unpack/Nickel"));
            CraftDataPatcher.customItemSizes[key: techTypeMINickel] = new Vector2int(x: _xMINickel, y: _yMINickel);
            CraftDataPatcher.customTechData.Add(techTypeMIKyanite, techDataMIKyanite);
            CraftDataPatcher.customTechData.Add(TechType.Kyanite, techDataMIKyaniteB);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMIKyanite, CraftScheme.Fabricator, "Resources/Craft/MIKyanite"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Kyanite, CraftScheme.Fabricator, "Resources/Unpack/Kyanite"));
            CraftDataPatcher.customItemSizes[key: techTypeMIKyanite] = new Vector2int(x: _xMIKyanite, y: _yMIKyanite);
            CraftDataPatcher.customTechData.Add(techTypeMIRuby, techDataMIRuby);
            CraftDataPatcher.customTechData.Add(TechType.AluminumOxide, techDataMIRubyB);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMIRuby, CraftScheme.Fabricator, "Resources/Craft/MIRuby"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.AluminumOxide, CraftScheme.Fabricator, "Resources/Unpack/AluminumOxide"));
            CraftDataPatcher.customItemSizes[key: techTypeMIRuby] = new Vector2int(x: _xMIRuby, y: _yMIRuby);
            CraftDataPatcher.customTechData.Add(techTypeMIUraninite, techDataMIUraninite);
            CraftDataPatcher.customTechData.Add(TechType.UraniniteCrystal, techDataMIUraniniteB);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMIUraninite, CraftScheme.Fabricator, "Resources/Craft/MIUraninite"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.UraniniteCrystal, CraftScheme.Fabricator, "Resources/Unpack/UraniniteCrystal"));
            CraftDataPatcher.customItemSizes[key: techTypeMIUraninite] = new Vector2int(x: _xMIUraninite, y: _yMIUraninite);
            CraftDataPatcher.customTechData.Add(techTypeMIQuartz, techDataMIQuartz);
            CraftDataPatcher.customTechData.Add(TechType.Quartz, techDataMIQuartzB);
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(techTypeMIQuartz, CraftScheme.Fabricator, "Resources/Craft/MIQuartz"));
            CraftTreePatcher.customNodes.Add(new CustomCraftNode(TechType.Quartz, CraftScheme.Fabricator, "Resources/Unpack/Quartz"));
            CraftDataPatcher.customItemSizes[key: techTypeMIQuartz] = new Vector2int(x: _xMIQuartz, y: _yMIQuartz);
            CraftDataPatcher.customItemSizes[key: TechType.TitaniumIngot] = new Vector2int(x: _xTitaniumIngot, y: _yTitaniumIngot);
        }
    }
} 
