using SMLHelper.V2.Crafting;
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
    /// Where the mod should look for the asset
    /// </summary>
    public enum InAssetBundles
    {
        /// <summary>
        /// Asset bundles for all of the items except for ones listed below
        /// </summary>
        All,

        /// <summary>
        /// Asset bundles for salt
        /// </summary>
        Salt,

        /// <summary>
        /// Asset bundles for sulphur
        /// </summary>
        Sulphur,

        /// <summary>
        /// Built-in asset for the Ion Crystal Matrix
        /// </summary>
        IonCrystalMatrix
    }

    /// <summary>
    /// Main class for loading an item
    /// </summary>
    public partial class Load
    {
        public partial class Item
        {
            /// <summary>
            /// Loads a custom item
            /// </summary>
            /// <param name="name">Item's internal name</param>
            /// <param name="languageName">Item's display name</param>
            /// <param name="languageTooltip">Item's tooltip</param>
            /// <param name="from">Item's ingredient</param>
            /// <param name="fromstring">Item's ingredient's name</param>
            /// <param name="inassetbundles">What assetbundle the sprite of the item is in</param>
            /// <param name="assetPath">The name of the sprite</param>
            public static void Custom(string name, string languageName, string languageTooltip, TechType from, string assetPath, InAssetBundles inassetbundles = InAssetBundles.All)
            {
                try
                {
                    TechType techType;
                    var _x = 1;
                    var _y = 1;
                    var _a = 10;
                    var _e = true;

                    var fromstring = from.ToString();

                    Log.Debug(languageName, Status.Start);
                    if (ConfigCheck(languageName))
                    {
                        var Config = MI.Config.cfgfile;
                        Config.TryGet(ref _x, languageName, "Size", "x");
                        Config.TryGet(ref _y, languageName, "Size", "y");
                        Config.TryGet(ref _a, languageName, "Craft amount");
                        Config.TryGet(ref _e, languageName, "Enabled");
                    }
                    else
                    {
                        return;
                    }
                    Log.Debug(languageName, "Starting sprite loading...");
                    if (inassetbundles == InAssetBundles.IonCrystalMatrix)
                    {
                        Log.Debug(languageName, "Sprite obtained");
                        Log.Debug(languageName, "Adding TechType...");
                        techType = TechTypeHandler.AddTechType(name, languageName, languageTooltip, SpriteManager.Get(TechType.PrecursorIonCrystalMatrix));
                    }
                    else
                    {
                        var sprite = LoadSprite(languageName, assetPath, inassetbundles);
                        if (sprite == null)
                        {
                            return;
                        }
                        Log.Debug(languageName, "Adding TechType...");
                        techType = TechTypeHandler.AddTechType(name, languageName, languageTooltip, sprite);
                    }
                    Log.Debug(languageName, "TechType added");
                    Log.Debug(languageName, "Loading TechDatas... (0/2)");
                    var techData = new TechData()
                    {
                        craftAmount = 1,
                        Ingredients = new List<Ingredient>()
                            {
                                new Ingredient(from, _a)
                            }
                    };
                    Log.Debug(languageName, "Loading TechDatas... (1/2)");
                    var techDataB = new TechData()
                    {
                        craftAmount = _a,
                        Ingredients = new List<Ingredient>()
                        {
                            new Ingredient(techType, 1)
                        }
                    };
                    Log.Debug(languageName, "Loading TechDatas... (2/2)");
                    Log.Debug(languageName, "TechDatas loaded");
                    #region Add to PDA/Fabricator
                    Log.Debug(languageName, "Adding TechTypes to the PDA Databank... (0/2)");
                    CraftDataHandler.AddToGroup(TechGroup.Resources, TechCategory.BasicMaterials, techType);
                    Log.Debug(languageName, "Adding TechTypes to the PDA Databank... (1/2)");
                    CraftDataHandler.AddToGroup(TechGroup.Resources, TechCategory.BasicMaterials, from);
                    Log.Debug(languageName, "Adding TechTypes to the PDA Databank... (2/2)");
                    Log.Debug(languageName, "TechTypes added to the PDA Databank");
                    Log.Debug(languageName, "Linking TechDatas with TechTypes... (0/2)");
                    CraftDataHandler.SetTechData(techType, techData);
                    Log.Debug(languageName, "Linking TechDatas with TechTypes... (1/2)");
                    CraftDataHandler.SetTechData(from, techDataB);
                    Log.Debug(languageName, "Linking TechDatas with TechTypes... (2/2)");
                    Log.Debug(languageName, "TechDatas linked with TechTypes");
                    Log.Debug(languageName, "Adding Fabricator nodes... (0/2)");
                    CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, techType, "Resources", "Craft");
                    Log.Debug(languageName, "Adding Fabricator nodes... (1/2)");
                    CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, from, "Resources", "Unpack");
                    Log.Debug(languageName, "Adding Fabricator nodes... (2/2)");
                    Log.Debug(languageName, "Fabricator nodes added");
                    Log.Debug(languageName, "Applying item sizes...");
                    CraftDataHandler.SetItemSize(techType, new Vector2int(_x, _y));
                    Log.Debug(languageName, "Item sizes applied");
                    #endregion
                    Log.Debug(languageName, Status.Stop);
                }
                catch (Exception e)
                {
                    Log.e(e);
                }
            }

            /// <summary>
            /// Loads titanium ingot
            /// </summary>
            public static void TitaniumIngot()
            {
                var _x = 1;
                var _y = 1;
                var _a = 10;
                var _e = true;

                var languageName = "Titanium Ingot";
                try
                {
                    Log.Debug(languageName, Status.Start);
                    if (ConfigCheck(languageName))
                    {
                        var Config = MI.Config.cfgfile;
                        Config.TryGet(ref _x, languageName, "Size", "x");
                        Config.TryGet(ref _y, languageName, "Size", "y");
                        Config.TryGet(ref _a, languageName, "Craft amount");
                        Config.TryGet(ref _e, languageName, "Enabled");
                    }
                    Log.Debug(languageName, "Adding TechType...");
                    var sprite = SpriteManager.Get(TechType.Titanium);
                    //var techType = TechTypeHandler.AddTechType("MITitanium", languageName, "Turn one titanium ingot into 10 titanium", sprite);
                    var techType = TechType.ScrapMetal;
                    Log.Debug(languageName, "Adding TechData...");
                    var techDataB = new TechData()
                    {
                        craftAmount = 1,
                        Ingredients = new List<Ingredient>()
                        {
                            new Ingredient(TechType.TitaniumIngot, 1)
                        },
                        LinkedItems = new List<TechType>()
                        {
                            TechType.Titanium,
                            //TechType.Titanium,
                            //TechType.Titanium,
                            //TechType.Titanium,
                            //TechType.Titanium,
                            TechType.Titanium,
                            TechType.Titanium,
                            TechType.Titanium,
                            TechType.Titanium,
                            TechType.Titanium
                        }

                    };
                    Log.Debug(languageName, $"Linked item count is {techDataB.linkedItemCount.ToString()}");
                    Log.Debug(languageName, "Linking TechData with TechType...");
                    CraftDataHandler.SetTechData(techType, techDataB);
                    Log.Debug(languageName, "TechData linked with TechType");
                    Log.Debug(languageName, "Adding Fabricator node...");
                    CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, techType, "Resources", "Unpack");
                    Log.Debug(languageName, "Fabricator node added");
                    Log.Debug(languageName, "Applying item size...");
                    CraftDataHandler.SetItemSize(TechType.TitaniumIngot, new Vector2int(_x, _y));
                    Log.Debug(languageName, "Item size applied");
                    Log.Debug(languageName, Status.Stop);
                }
                catch (Exception e)
                {
                    Log.e(e);
                }
            }
            /// <summary>
            /// Loads item sizes for plasteel ingot
            /// </summary>
            public static void PlasteelIngot()
            {
                var _x = 1;
                var _y = 1;
                var _a = 10;
                var _e = true;

                var languageName = "Plasteel Ingot";
                try
                {
                    Log.Debug(languageName, Status.Start);
                    if (ConfigCheck(languageName))
                    {
                        var Config = MI.Config.cfgfile;
                        Config.TryGet(ref _x, languageName, "Size", "x");
                        Config.TryGet(ref _y, languageName, "Size", "y");
                        Config.TryGet(ref _a, languageName, "Craft amount");
                        Config.TryGet(ref _e, languageName, "Enabled");
                    }
                    Log.Debug(languageName, "Adding TechType...");
                    var sprite = SpriteManager.Get(TechType.Lithium);
                    var techType = TechTypeHandler.AddTechType("MIPlasteel", languageName, "Turn one plasteel ingot into 1 titanium ingot and 2 lithium", sprite);
                    //var techType = TechType.Lithium;
                    Log.Debug(languageName, "Adding TechData...");
                    var techDataB = new TechData()
                    {
                        craftAmount = 0,
                        Ingredients = new List<Ingredient>()
                        {
                            new Ingredient(TechType.PlasteelIngot, 1)
                        },
                        LinkedItems = new List<TechType>()
                        {
                            //TechType.TitaniumIngot
                            TechType.Lithium,
                            TechType.Lithium,
                            TechType.Titanium,
                            TechType.Titanium,
                            TechType.Titanium,
                            TechType.Titanium,
                            TechType.Titanium,
                            TechType.Titanium,
                            TechType.Titanium,
                            TechType.Titanium,
                            TechType.Titanium,
                            TechType.Titanium
                        }
                    };
                    Log.Debug(languageName, "Linking TechData with TechType...");
                    CraftDataHandler.SetTechData(techType, techDataB);
                    Log.Debug(languageName, "TechData linked with TechType");
                    Log.Debug(languageName, "Adding Fabricator node...");
                    CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, techType, "Resources", "Unpack");
                    Log.Debug(languageName, "Fabricator node added");
                    Log.Debug(languageName, "Applying item size...");
                    CraftDataHandler.SetItemSize(TechType.PlasteelIngot, new Vector2int(_x, _y));
                    Log.Debug(languageName, "Item size applied");
                    Log.Debug(languageName, Status.Stop);
                }
                catch (Exception e)
                {
                    Log.e(e);
                }
            }

            private static Sprite LoadSprite(string languageName, string assetPath, InAssetBundles inassetbundles = InAssetBundles.All)
            {
                var ingotsplus = Load.ingotDict["yenzen-ingotsplus"];
                var ingotsplus_salt = Load.ingotDict["salt-yenzen"];
                var sulphur = Load.ingotDict["sulphur"];

                Log.Debug(languageName, "Starting sprite loading...");
                if (inassetbundles == InAssetBundles.All)
                {
                    Log.Debug(languageName, "Asset bundle \"yenzen-ingotsplus\" selected");
                    Log.Debug(languageName, "Obtaining sprite...");
                    if (ingotsplus.LoadAsset<Sprite>(assetPath) == null)
                    {
                        Log.Error(languageName, "Sprite is null");
                        Log.Debug(languageName, Status.Stop);
                        return null;
                    }
                    Log.Debug(languageName, "Sprite obtained");
                    return ingotsplus.LoadAsset<Sprite>(assetPath);
                }
                else if (inassetbundles == InAssetBundles.Salt)
                {
                    Log.Debug(languageName, "Asset bundle \"salt-yenzen\" selected");
                    Log.Debug(languageName, "Obtaining sprite...");
                    if (ingotsplus_salt.LoadAsset<Sprite>(assetPath) == null)
                    {
                        Log.Error(languageName, "Sprite is null");
                        Log.Debug(languageName, Status.Stop);
                        return null;
                    }

                    Log.Debug(languageName, "Sprite obtained");
                    return ingotsplus_salt.LoadAsset<Sprite>(assetPath);
                }
                else if (inassetbundles == InAssetBundles.Sulphur)
                {
                    Log.Debug(languageName, "Asset bundle \"sulphur\" selected");
                    Log.Debug(languageName, "Obtaining sprite...");
                    if (sulphur.LoadAsset<Sprite>(assetPath) == null)
                    {
                        Log.Error(languageName, "Sprite is null");
                        Log.Debug(languageName, Status.Stop);
                        return null;
                    }
                    Log.Debug(languageName, "Sprite obtained");
                    return sulphur.LoadAsset<Sprite>(assetPath);
                }
                Log.Error(languageName, "Found no matching sprites");
                return null;
            }

            private static bool ConfigCheck(string languageName)
            {
                try
                {
                    var _x = 1;
                    var _y = 1;
                    var _a = 10;
                    var _e = true;

                    var Config = MI.Config.cfgfile;
                    Config.TryGet(ref _x, languageName, "Size", "x");
                    Config.TryGet(ref _y, languageName, "Size", "y");
                    Config.TryGet(ref _a, languageName, "Craft amount");
                    Config.TryGet(ref _e, languageName, "Enabled");

                    if (_e == false)
                    {
                        Log.Debug(languageName, "Item is disabled");
                        return false;
                    }
                    Log.Debug(languageName, "Checking config data for errors... (0/6)");
                    if (_x <= 0)
                    {
                        _x = 1;
                        Config[languageName, "Size", "x"] = _x;
                        Log.Warning(languageName, "X can't be less than 1");
                        Log.Info(languageName, $"X was set to {_x.ToString()}");
                    }
                    Log.Debug(languageName, "Checking config data for errors... (1/6)");
                    if (_x > 6)
                    {
                        _x = 1;
                        Config[languageName, "Size", "x"] = _x;
                        Log.Warning(languageName, "X can't be greater than 6");
                        Log.Info(languageName, $"X was set to {_x.ToString()}");
                    }
                    Log.Debug(languageName, "Checking config data for errors... (2/6)");
                    if (_y <= 0)
                    {
                        _y = 1;
                        Config[languageName, "Size", "y"] = _y;
                        Log.Warning(languageName, "Y can't be less than 1");
                        Log.Info(languageName, $"Y was set to {_y.ToString()}");
                    }
                    Log.Debug(languageName, "Checking config data for errors... (3/6)");
                    if (_y > 8)
                    {
                        _y = 1;
                        Config[languageName, "Size", "y"] = _y;
                        Log.Warning(languageName, "Y can't be greater than 8");
                        Log.Info(languageName, $"Y was set to {_y.ToString()}");
                    }
                    Log.Debug(languageName, "Checking config data for errors... (4/6)");
                    if (_a <= 0)
                    {
                        _a = 10;
                        Config[languageName, "Craft amount"] = _a;
                        Log.Warning(languageName, "Craft amount can't be less than 1");
                        Log.Info(languageName, $"Craft amount was set to {_a.ToString()}");
                    }
                    Log.Debug(languageName, "Checking config data for errors... (5/6)");
                    if (_a > 10)
                    {
                        _a = 10;
                        Config[languageName, "Craft amount"] = _a;
                        Log.Warning(languageName, "Craft amount can't be greater than 10");
                        Log.Info(languageName, $"Craft amount was set to {_a.ToString()}");
                    }
                    Log.Debug(languageName, "Checking config data for errors... (6/6)");
                    Log.Debug(languageName, "Error check complete");
                    MI.Config.Save(languageName);
                }
                catch (Exception e)
                {
                    Log.e(e);
                }
                return true;
            }
        }
    }
}
