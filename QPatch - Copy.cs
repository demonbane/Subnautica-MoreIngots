using Harmony; 
using SMLHelper; 
using SMLHelper.Patchers; 
using System; 
using System.Collections.Generic; 
using System.Reflection; 
using UnityEngine; 
using Utilites.Config;
namespace MoreIngots
{
    public class QPatch
    {
        private static readonly ConfigFile Config = new ConfigFile("config");
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
            try
            {
                var harmony = HarmonyInstance.Create("com.alexejheroytb.moreingots");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception e)
            {
                Console.WriteLine($"MoreIngots patch failed\n{FormatException(e)}");
            }
            var assetBundle = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/moreingots.assets");
            Config.Load();
            var configChanged =
            Config.TryGet(ref _xTitaniumIngot, "Titanium Ingot - Titanium", "Size", "x")
            | Config.TryGet(ref _yTitaniumIngot, "Titanium Ingot - Titanium", "Size", "y")
            | Config.TryGet(ref _xMIGold, "Gold Ingot - Gold", "Size", "x")
            | Config.TryGet(ref _yMIGold, "Gold Ingot - Gold", "Size", "y")
            | Config.TryGet(ref _xMIDiamond, "Graphite - Diamond", "Size", "x")
            | Config.TryGet(ref _yMIDiamond, "Graphite - Diamond", "Size", "y")
            | Config.TryGet(ref _xMILithium, "Lithium Bar - Lithium", "Size", "x")
            | Config.TryGet(ref _yMILithium, "Lithium Bar - Lithium", "Size", "y")
            | Config.TryGet(ref _xMICopper, "Copper Ingot - Copper", "Size", "x")
            | Config.TryGet(ref _yMICopper, "Copper Ingot - Copper", "Size", "y")
            | Config.TryGet(ref _xMILead, "Lead Bar - Lead", "Size", "x")
            | Config.TryGet(ref _yMILead, "Lead Bar - Lead", "Size", "y")
            | Config.TryGet(ref _xMISilver, "Silver Ingot - Silver", "Size", "x")
            | Config.TryGet(ref _yMISilver, "Silver Ingot - Silver", "Size", "y")
            | Config.TryGet(ref _xMIMagnetite, "Maghemite - Magnetite", "Size", "x")
            | Config.TryGet(ref _yMIMagnetite, "Maghemite - Magnetite", "Size", "y")
            | Config.TryGet(ref _xMINickel, "Nickel Sheets - Nickel", "Size", "x")
            | Config.TryGet(ref _yMINickel, "Nickel Sheets - Nickel", "Size", "y")
            | Config.TryGet(ref _xMIKyanite, "Topaz - Kyanite", "Size", "x")
            | Config.TryGet(ref _yMIKyanite, "Topaz - Kyanite", "Size", "y")
            | Config.TryGet(ref _xMIRuby, "Bauxite - AluminumOxide", "Size", "x")
            | Config.TryGet(ref _yMIRuby, "Bauxite - AluminumOxide", "Size", "y")
            | Config.TryGet(ref _xMIUraninite, "Triuranium octoxide - UraniniteCrystal", "Size", "x")
            | Config.TryGet(ref _yMIUraninite, "Triuranium octoxide - UraniniteCrystal", "Size", "y")
            | Config.TryGet(ref _xMIQuartz, "Silicate - Quartz", "Size", "x")
            | Config.TryGet(ref _yMIQuartz, "Silicate - Quartz", "Size", "y")
            ;
            if (_xTitaniumIngot <= 0)
            {
                _xTitaniumIngot = 1;
                Config["Titanium Ingot - Titanium", "Size", "x"] = _xTitaniumIngot;
                Utilites.Logger.Logger.Error("Size of Titanium Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yTitaniumIngot <= 0)
            {
                _yTitaniumIngot = 1;
                Config["Titanium Ingot - Titanium", "Size", "y"] = _yTitaniumIngot;
                Utilites.Logger.Logger.Error("Size of Titanium Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMIGold <= 0)
            {
                _xMIGold = 1;
                Config["Gold Ingot - Gold", "Size", "x"] = _xMIGold;
                Utilites.Logger.Logger.Error("Size of Gold Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMIGold <= 0)
            {
                _yMIGold = 1;
                Config["Gold Ingot - Gold", "Size", "y"] = _yMIGold;
                Utilites.Logger.Logger.Error("Size of Gold Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMIDiamond <= 0)
            {
                _xMIDiamond = 1;
                Config["Graphite - Diamond", "Size", "x"] = _xMIDiamond;
                Utilites.Logger.Logger.Error("Size of Graphite can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMIDiamond <= 0)
            {
                _yMIDiamond = 1;
                Config["Graphite - Diamond", "Size", "y"] = _yMIDiamond;
                Utilites.Logger.Logger.Error("Size of Graphite can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMILithium <= 0)
            {
                _xMILithium = 1;
                Config["Lithium Bar - Lithium", "Size", "x"] = _xMILithium;
                Utilites.Logger.Logger.Error("Size of Lithium Bar can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMILithium <= 0)
            {
                _yMILithium = 1;
                Config["Lithium Bar - Lithium", "Size", "y"] = _yMILithium;
                Utilites.Logger.Logger.Error("Size of Lithium Bar can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMICopper <= 0)
            {
                _xMICopper = 1;
                Config["Copper Ingot - Copper", "Size", "x"] = _xMICopper;
                Utilites.Logger.Logger.Error("Size of Copper Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMICopper <= 0)
            {
                _yMICopper = 1;
                Config["Copper Ingot - Copper", "Size", "y"] = _yMICopper;
                Utilites.Logger.Logger.Error("Size of Copper Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMILead <= 0)
            {
                _xMILead = 1;
                Config["Lead Bar - Lead", "Size", "x"] = _xMILead;
                Utilites.Logger.Logger.Error("Size of Lead Bar can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMILead <= 0)
            {
                _yMILead = 1;
                Config["Lead Bar - Lead", "Size", "y"] = _yMILead;
                Utilites.Logger.Logger.Error("Size of Lead Bar can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMISilver <= 0)
            {
                _xMISilver = 1;
                Config["Silver Ingot - Silver", "Size", "x"] = _xMISilver;
                Utilites.Logger.Logger.Error("Size of Silver Ingot can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMISilver <= 0)
            {
                _yMISilver = 1;
                Config["Silver Ingot - Silver", "Size", "y"] = _yMISilver;
                Utilites.Logger.Logger.Error("Size of Silver Ingot can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMIMagnetite <= 0)
            {
                _xMIMagnetite = 1;
                Config["Maghemite - Magnetite", "Size", "x"] = _xMIMagnetite;
                Utilites.Logger.Logger.Error("Size of Maghemite can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMIMagnetite <= 0)
            {
                _yMIMagnetite = 1;
                Config["Maghemite - Magnetite", "Size", "y"] = _yMIMagnetite;
                Utilites.Logger.Logger.Error("Size of Maghemite can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMINickel <= 0)
            {
                _xMINickel = 1;
                Config["Nickel Sheets - Nickel", "Size", "x"] = _xMINickel;
                Utilites.Logger.Logger.Error("Size of Nickel Sheets can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMINickel <= 0)
            {
                _yMINickel = 1;
                Config["Nickel Sheets - Nickel", "Size", "y"] = _yMINickel;
                Utilites.Logger.Logger.Error("Size of Nickel Sheets can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMIKyanite <= 0)
            {
                _xMIKyanite = 1;
                Config["Topaz - Kyanite", "Size", "x"] = _xMIKyanite;
                Utilites.Logger.Logger.Error("Size of Topaz can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMIKyanite <= 0)
            {
                _yMIKyanite = 1;
                Config["Topaz - Kyanite", "Size", "y"] = _yMIKyanite;
                Utilites.Logger.Logger.Error("Size of Topaz can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMIRuby <= 0)
            {
                _xMIRuby = 1;
                Config["Bauxite - AluminumOxide", "Size", "x"] = _xMIRuby;
                Utilites.Logger.Logger.Error("Size of Bauxite can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMIRuby <= 0)
            {
                _yMIRuby = 1;
                Config["Bauxite - AluminumOxide", "Size", "y"] = _yMIRuby;
                Utilites.Logger.Logger.Error("Size of Bauxite can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMIUraninite <= 0)
            {
                _xMIUraninite = 1;
                Config["Triuranium octoxide - UraniniteCrystal", "Size", "x"] = _xMIUraninite;
                Utilites.Logger.Logger.Error("Size of Triuranium octoxide can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMIUraninite <= 0)
            {
                _yMIUraninite = 1;
                Config["Triuranium octoxide - UraniniteCrystal", "Size", "y"] = _yMIUraninite;
                Utilites.Logger.Logger.Error("Size of Triuranium octoxide can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_xMIQuartz <= 0)
            {
                _xMIQuartz = 1;
                Config["Silicate - Quartz", "Size", "x"] = _xMIQuartz;
                Utilites.Logger.Logger.Error("Size of Silicate can't be less or equal to 0 X was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (_yMIQuartz <= 0)
            {
                _yMIQuartz = 1;
                Config["Silicate - Quartz", "Size", "y"] = _yMIQuartz;
                Utilites.Logger.Logger.Error("Size of Silicate can't be less or equal to 0 Y was set to 1", Utilites.Logger.LogType.Custom | Utilites.Logger.LogType.Console);
                configChanged = true;
            }
            if (configChanged)
            {
                Config.Save();
            }
            var techTypeMIGold = TechTypePatcher.AddTechType("MIGold", "Gold Ingot", "Au. Condensed gold. Added by MoreIngots mod. ");
            var techTypeMIDiamond = TechTypePatcher.AddTechType("MIDiamond", "Graphite", "C. Condensed diamond. Added by MoreIngots mod");
            var techTypeMILithium = TechTypePatcher.AddTechType("MILithium", "Lithium Bar", "Li. Condensed lithium. Added by MoreIngots mod");
            var techTypeMICopper = TechTypePatcher.AddTechType("MICopper", "Copper Ingot", "Cu. Condensed copper. Added by MoreIngots mod");
            var techTypeMILead = TechTypePatcher.AddTechType("MILead", "Lead Bar", "Pb. Condensed lead. Added by MoreIngots mod");
            var techTypeMISilver = TechTypePatcher.AddTechType("MISilver", "Silver Ingot", "Ag. Condensed silver. Added by MoreIngots mod");
            var techTypeMIMagnetite = TechTypePatcher.AddTechType("MIMagnetite", "Maghemite", "γ-Fe2O3. Condensed magnetite. Added by MoreIngots mod");
            var techTypeMINickel = TechTypePatcher.AddTechType("MINickel", "Nickel Sheets", "Ni. Condensed nickel. Added by MoreIngots mod");
            var techTypeMIKyanite = TechTypePatcher.AddTechType("MIKyanite", "Topaz", "Al2(F,OH)2SiO4. Condensed kyanite. Added by MoreIngots mod");
            var techTypeMIRuby = TechTypePatcher.AddTechType("MIRuby", "Bauxite", "Al(OH)3. Condensed ruby. Added by MoreIngots mod");
            var techTypeMIUraninite = TechTypePatcher.AddTechType("MIUraninite", "Triuranium octoxide", "U3O8. Condensed uraninite. Added by MoreIngots mod");
            var techTypeMIQuartz = TechTypePatcher.AddTechType("MIQuartz", "Silicate", "SiO4. Condensed quartz. Added by MoreIngots mod");
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
            CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIGold, spriteMIGold));
            CraftDataPatcher.customTechData.Add(techTypeMIGold, techDataMIGold);
            CraftDataPatcher.customTechData.Add(TechType.Gold, techDataMIGoldB);
            CraftTreePatcher.customCraftNodes.Add("Resources/Craft/MIGold", techTypeMIGold);
            CraftTreePatcher.customCraftNodes.Add("Resources/Unpack/Gold", TechType.Gold);
            CraftDataPatcher.customItemSizes[key: techTypeMIGold] = new Vector2int(x: _xMIGold, y: _yMIGold);
            var spriteMIDiamond = assetBundle.LoadAsset<Sprite>("MIDiamond");
            CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIDiamond, spriteMIDiamond));
            CraftDataPatcher.customTechData.Add(techTypeMIDiamond, techDataMIDiamond);
            CraftDataPatcher.customTechData.Add(TechType.Diamond, techDataMIDiamondB);
            CraftTreePatcher.customCraftNodes.Add("Resources/Craft/MIDiamond", techTypeMIDiamond);
            CraftTreePatcher.customCraftNodes.Add("Resources/Unpack/Diamond", TechType.Diamond);
            CraftDataPatcher.customItemSizes[key: techTypeMIDiamond] = new Vector2int(x: _xMIDiamond, y: _yMIDiamond);
            var spriteMILithium = assetBundle.LoadAsset<Sprite>("MILithium");
            CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMILithium, spriteMILithium));
            CraftDataPatcher.customTechData.Add(techTypeMILithium, techDataMILithium);
            CraftDataPatcher.customTechData.Add(TechType.Lithium, techDataMILithiumB);
            CraftTreePatcher.customCraftNodes.Add("Resources/Craft/MILithium", techTypeMILithium);
            CraftTreePatcher.customCraftNodes.Add("Resources/Unpack/Lithium", TechType.Lithium);
            CraftDataPatcher.customItemSizes[key: techTypeMILithium] = new Vector2int(x: _xMILithium, y: _yMILithium);
            var spriteMICopper = assetBundle.LoadAsset<Sprite>("MICopper");
            CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMICopper, spriteMICopper));
            CraftDataPatcher.customTechData.Add(techTypeMICopper, techDataMICopper);
            CraftDataPatcher.customTechData.Add(TechType.Copper, techDataMICopperB);
            CraftTreePatcher.customCraftNodes.Add("Resources/Craft/MICopper", techTypeMICopper);
            CraftTreePatcher.customCraftNodes.Add("Resources/Unpack/Copper", TechType.Copper);
            CraftDataPatcher.customItemSizes[key: techTypeMICopper] = new Vector2int(x: _xMICopper, y: _yMICopper);
            var spriteMILead = assetBundle.LoadAsset<Sprite>("MILead");
            CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMILead, spriteMILead));
            CraftDataPatcher.customTechData.Add(techTypeMILead, techDataMILead);
            CraftDataPatcher.customTechData.Add(TechType.Lead, techDataMILeadB);
            CraftTreePatcher.customCraftNodes.Add("Resources/Craft/MILead", techTypeMILead);
            CraftTreePatcher.customCraftNodes.Add("Resources/Unpack/Lead", TechType.Lead);
            CraftDataPatcher.customItemSizes[key: techTypeMILead] = new Vector2int(x: _xMILead, y: _yMILead);
            var spriteMISilver = assetBundle.LoadAsset<Sprite>("MISilver");
            CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMISilver, spriteMISilver));
            CraftDataPatcher.customTechData.Add(techTypeMISilver, techDataMISilver);
            CraftDataPatcher.customTechData.Add(TechType.Silver, techDataMISilverB);
            CraftTreePatcher.customCraftNodes.Add("Resources/Craft/MISilver", techTypeMISilver);
            CraftTreePatcher.customCraftNodes.Add("Resources/Unpack/Silver", TechType.Silver);
            CraftDataPatcher.customItemSizes[key: techTypeMISilver] = new Vector2int(x: _xMISilver, y: _yMISilver);
            var spriteMIMagnetite = assetBundle.LoadAsset<Sprite>("MIMagnetite");
            CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIMagnetite, spriteMIMagnetite));
            CraftDataPatcher.customTechData.Add(techTypeMIMagnetite, techDataMIMagnetite);
            CraftDataPatcher.customTechData.Add(TechType.Magnetite, techDataMIMagnetiteB);
            CraftTreePatcher.customCraftNodes.Add("Resources/Craft/MIMagnetite", techTypeMIMagnetite);
            CraftTreePatcher.customCraftNodes.Add("Resources/Unpack/Magnetite", TechType.Magnetite);
            CraftDataPatcher.customItemSizes[key: techTypeMIMagnetite] = new Vector2int(x: _xMIMagnetite, y: _yMIMagnetite);
            var spriteMINickel = assetBundle.LoadAsset<Sprite>("MINickel");
            CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMINickel, spriteMINickel));
            CraftDataPatcher.customTechData.Add(techTypeMINickel, techDataMINickel);
            CraftDataPatcher.customTechData.Add(TechType.Nickel, techDataMINickelB);
            CraftTreePatcher.customCraftNodes.Add("Resources/Craft/MINickel", techTypeMINickel);
            CraftTreePatcher.customCraftNodes.Add("Resources/Unpack/Nickel", TechType.Nickel);
            CraftDataPatcher.customItemSizes[key: techTypeMINickel] = new Vector2int(x: _xMINickel, y: _yMINickel);
            var spriteMIKyanite = assetBundle.LoadAsset<Sprite>("MIKyanite");
            CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIKyanite, spriteMIKyanite));
            CraftDataPatcher.customTechData.Add(techTypeMIKyanite, techDataMIKyanite);
            CraftDataPatcher.customTechData.Add(TechType.Kyanite, techDataMIKyaniteB);
            CraftTreePatcher.customCraftNodes.Add("Resources/Craft/MIKyanite", techTypeMIKyanite);
            CraftTreePatcher.customCraftNodes.Add("Resources/Unpack/Kyanite", TechType.Kyanite);
            CraftDataPatcher.customItemSizes[key: techTypeMIKyanite] = new Vector2int(x: _xMIKyanite, y: _yMIKyanite);
            var spriteMIRuby = assetBundle.LoadAsset<Sprite>("MIRuby");
            CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIRuby, spriteMIRuby));
            CraftDataPatcher.customTechData.Add(techTypeMIRuby, techDataMIRuby);
            CraftDataPatcher.customTechData.Add(TechType.AluminumOxide, techDataMIRubyB);
            CraftTreePatcher.customCraftNodes.Add("Resources/Craft/MIRuby", techTypeMIRuby);
            CraftTreePatcher.customCraftNodes.Add("Resources/Unpack/AluminumOxide", TechType.AluminumOxide);
            CraftDataPatcher.customItemSizes[key: techTypeMIRuby] = new Vector2int(x: _xMIRuby, y: _yMIRuby);
            var spriteMIUraninite = assetBundle.LoadAsset<Sprite>("MIUraninite");
            CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIUraninite, spriteMIUraninite));
            CraftDataPatcher.customTechData.Add(techTypeMIUraninite, techDataMIUraninite);
            CraftDataPatcher.customTechData.Add(TechType.UraniniteCrystal, techDataMIUraniniteB);
            CraftTreePatcher.customCraftNodes.Add("Resources/Craft/MIUraninite", techTypeMIUraninite);
            CraftTreePatcher.customCraftNodes.Add("Resources/Unpack/UraniniteCrystal", TechType.UraniniteCrystal);
            CraftDataPatcher.customItemSizes[key: techTypeMIUraninite] = new Vector2int(x: _xMIUraninite, y: _yMIUraninite);
            var spriteMIQuartz = assetBundle.LoadAsset<Sprite>("MIQuartz");
            CustomSpriteHandler.customSprites.Add(new CustomSprite(techTypeMIQuartz, spriteMIQuartz));
            CraftDataPatcher.customTechData.Add(techTypeMIQuartz, techDataMIQuartz);
            CraftDataPatcher.customTechData.Add(TechType.Quartz, techDataMIQuartzB);
            CraftTreePatcher.customCraftNodes.Add("Resources/Craft/MIQuartz", techTypeMIQuartz);
            CraftTreePatcher.customCraftNodes.Add("Resources/Unpack/Quartz", TechType.Quartz);
            CraftDataPatcher.customItemSizes[key: techTypeMIQuartz] = new Vector2int(x: _xMIQuartz, y: _yMIQuartz);
            CraftDataPatcher.customItemSizes[key: TechType.TitaniumIngot] = new Vector2int(x: _xTitaniumIngot, y: _yTitaniumIngot);
            LanguagePatcher.customLines.Add("FabricatorMenu_Craft", "Craft MoreIngots");
            LanguagePatcher.customLines.Add("FabricatorMenu_Unpack", "Unpack MoreIngots");
        }
        private static string FormatException(Exception e)
        {
            if (e == null)
                return string.Empty;
            return $"\"Exception: {e.GetType()}\"\n\tMessage: {e.Message}\n\tStacktrace: {e.StackTrace}\n" +
            FormatException(e.InnerException);
        }
    }
} 
