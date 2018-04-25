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
        Sulphur
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
            /// <param name="alt_assetPath">The name of the alternative sprite</param>
            public static void Custom(string name, string languageName, string languageTooltip, TechType from, string alt_assetPath, string assetPath, InAssetBundles inassetbundles = InAssetBundles.All)
            {
                try
                {
                    var _x = 1;
                    var _y = 1;
                    var _a = 10;
                    var _e = true;
                    var Config = MI.Config.cfgfile;
                    var moreingots = Load.moreingots;
                    var ingotsplus = Load.ingotsplus;
                    var moreingots_salt = Load.moreingots_salt;
                    var ingotsplus_salt = Load.ingotsplus_salt;
                    var fromstring = from.ToString();
                    Config.TryGet(ref _x, languageName, "Size", "x");
                    Config.TryGet(ref _y, languageName, "Size", "y");
                    Config.TryGet(ref _a, languageName, "Craft amount");
                    Config.TryGet(ref _e, languageName, "Enabled");
                    Log.Debug(languageName, Status.Start);
                    if (_e == false)
                    {
                        Log.Debug(languageName, "Item is disabled");
                        return;
                    }
                    Log.Debug(languageName, "Checking config data for errors... (0/6)");
                    if (_x <= 0)
                    {
                        _x = 1;
                        Config[languageName, "Size", "x"] = _x;
                        Log.Warning(languageName, "X can't be less than 1");
                        Log.Info(languageName, "X was set to 1");
                    }
                    Log.Debug(languageName, "Checking config data for errors... (1/6)");
                    if (_x > 6)
                    {
                        _x = 1;
                        Config[languageName, "Size", "x"] = _x;
                        Log.Warning(languageName, "X can't be greater than 6");
                        Log.Info(languageName, "X was set to 1");
                    }
                    Log.Debug(languageName, "Checking config data for errors... (2/6)");
                    if (_y <= 0)
                    {
                        _y = 1;
                        Config[languageName, "Size", "y"] = _y;
                        Log.Warning(languageName, "Y can't be less than 1");
                        Log.Info(languageName, "Y was set to 1");
                    }
                    Log.Debug(languageName, "Checking config data for errors... (3/6)");
                    if (_y > 8)
                    {
                        _y = 1;
                        Config[languageName, "Size", "y"] = _y;
                        Log.Warning(languageName, "Y can't be greater than 8");
                        Log.Info(languageName, "Y was set to 1");
                    }
                    Log.Debug(languageName, "Checking config data for errors... (4/6)");
                    if (_a <= 0)
                    {
                        _a = 10;
                        Config[languageName, "Craft amount"] = _a;
                        Log.Warning(languageName, "Craft amount can't be less than 1");
                        Log.Info(languageName, "Craft amount was set to 10");
                    }
                    Log.Debug(languageName, "Checking config data for errors... (5/6)");
                    if (_a > 10)
                    {
                        _a = 10;
                        Config[languageName, "Craft amount"] = _a;
                        Log.Warning(languageName, "Craft amount can't be greater than 10");
                        Log.Info(languageName, "Craft amount was set to 10");
                    }
                    Log.Debug(languageName, "Checking config data for errors... (6/6)");
                    Log.Debug(languageName, "Error check complete");
                    MI.Config.Save(languageName);
                    Log.Debug(languageName, "Adding TechType...");
                    var techType = TechTypePatcher.AddTechType(name, languageName, languageTooltip);
                    Log.Debug(languageName, "TechType added");
                    Log.Debug(languageName, "Loading TechDatas... (0/2)");
                    var techData = new TechDataHelper
                    {
                        _craftAmount = 1,
                        _ingredients = new List<IngredientHelper>()
                    {
                        new IngredientHelper(from, _a)
                    },
                        _techType = techType
                    };
                    Log.Debug(languageName, "Loading TechDatas... (1/2)");
                    var techDataB = new TechDataHelper
                    {
                        _craftAmount = _a,
                        _ingredients = new List<IngredientHelper>()
                    {
                        new IngredientHelper(techType, 1)
                    },
                        _techType = from
                    };
                    Log.Debug(languageName, "Loading TechDatas... (2/2)");
                    Log.Debug(languageName, "TechDatas loaded");
                    Log.Debug(languageName, "Adding unlock on start for " + from + "...");
                    KnownTechPatcher.unlockedAtStart.Add(from);
                    Log.Debug(languageName, "Unlock on start added for " + from);
                    Log.Debug(languageName, "Adding TechTypes to the PDA Databank... (0/2)");
                    CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, techType);
                    Log.Debug(languageName, "Adding TechTypes to the PDA Databank... (1/2)");
                    CraftDataPatcher.AddToCustomGroup(TechGroup.Resources, TechCategory.BasicMaterials, from);
                    Log.Debug(languageName, "Adding TechTypes to the PDA Databank... (2/2)");
                    Log.Debug(languageName, "TechTypes added to the PDA Databank");
                    Log.Debug(languageName, "Linking TechDatas with TechTypes... (0/2)");
                    CraftDataPatcher.customTechData.Add(techType, techData);
                    Log.Debug(languageName, "Linking TechDatas with TechTypes... (1/2)");
                    CraftDataPatcher.customTechData.Add(from, techDataB);
                    Log.Debug(languageName, "Linking TechDatas with TechTypes... (2/2)");
                    Log.Debug(languageName, "TechDatas linked with TechTypes");
                    Log.Debug(languageName, "Adding Fabricator nodes... (0/2)");
                    CraftTreePatcher.customNodes.Add(new CustomCraftNode(techType, CraftScheme.Fabricator, "Resources/Craft/" + name));
                    Log.Debug(languageName, "Adding Fabricator nodes... (1/2)");
                    CraftTreePatcher.customNodes.Add(new CustomCraftNode(from, CraftScheme.Fabricator, "Resources/Unpack/" + fromstring));
                    Log.Debug(languageName, "Adding Fabricator nodes... (2/2)");
                    Log.Debug(languageName, "Fabricator nodes added");
                    Log.Debug(languageName, "Applying item sizes...");
                    CraftDataPatcher.customItemSizes[key: techType] = new Vector2int(_x, _y);
                    Log.Debug(languageName, "Item sizes applied");
                    Log.Debug(languageName, "Starting sprite loading...");
                    if (inassetbundles == InAssetBundles.All)
                    {
                        if (MI.Config._alttextures)
                        {
                            Log.Debug(languageName, "Asset bundle \"moreingots\" selected");
                            Log.Debug(languageName, "Obtaining sprite...");
                            if (moreingots.LoadAsset<Sprite>(alt_assetPath) == null)
                            {
                                Log.Error(languageName, "Sprite is null");
                                Log.Debug(languageName, Status.Stop);
                                return;
                            }
                            var alt_sprite = moreingots.LoadAsset<Sprite>(alt_assetPath);
                            Log.Debug(languageName, "Sprite obtained");
                            Log.Debug(languageName, "Applying sprite...");
                            CustomSpriteHandler.customSprites.Add(new CustomSprite(techType, alt_sprite));
                            Log.Debug(languageName, "Sprite applied");
                        }
                        else
                        {
                            Log.Debug(languageName, "Asset bundle \"yenzen-ingotsplus\" selected");
                            Log.Debug(languageName, "Obtaining sprite...");
                            if (ingotsplus.LoadAsset<Sprite>(assetPath) == null)
                            {
                                Log.Error(languageName, "Sprite is null");
                                Log.Debug(languageName, Status.Stop);
                                return;
                            }
                            var sprite = ingotsplus.LoadAsset<Sprite>(assetPath);
                            Log.Debug(languageName, "Sprite obtained");
                            Log.Debug(languageName, "Applying sprite...");
                            CustomSpriteHandler.customSprites.Add(new CustomSprite(techType, sprite));
                            Log.Debug(languageName, "Sprite applied");
                        }
                    }
                    if (inassetbundles == InAssetBundles.Salt)
                    {
                        if (MI.Config._alttextures)
                        {
                            Log.Debug(languageName, "Asset bundle \"salt-alexejheroytb\" selected");
                            Log.Debug(languageName, "Obtaining sprite...");
                            if (moreingots_salt.LoadAsset<Sprite>(alt_assetPath) == null)
                            {
                                Log.Error(languageName, "Sprite is null");
                                Log.Debug(languageName, Status.Stop);
                                return;
                            }
                            var alt_sprite = moreingots_salt.LoadAsset<Sprite>(alt_assetPath);
                            Log.Debug(languageName, "Sprite obtained");
                            Log.Debug(languageName, "Applying sprite...");
                            CustomSpriteHandler.customSprites.Add(new CustomSprite(techType, alt_sprite));
                            Log.Debug(languageName, "Sprite applied");
                        }
                        else
                        {
                            Log.Debug(languageName, "Asset bundle \"salt-yenzen\" selected");
                            Log.Debug(languageName, "Obtaining sprite...");
                            if (ingotsplus_salt.LoadAsset<Sprite>(assetPath) == null)
                            {
                                Log.Error(languageName, "Sprite is null");
                                Log.Debug(languageName, Status.Stop);
                                return;
                            }
                            var sprite = ingotsplus_salt.LoadAsset<Sprite>(assetPath);
                            Log.Debug(languageName, "Sprite obtained");
                            Log.Debug(languageName, "Applying sprite...");
                            CustomSpriteHandler.customSprites.Add(new CustomSprite(techType, sprite));
                            Log.Debug(languageName, "Sprite applied");
                        }
                    }
                    if (inassetbundles == InAssetBundles.Sulphur)
                    {
                        Log.Debug(languageName, "Asset bundle \"sulphur\" selected");
                        Log.Debug(languageName, "Obtaining sprite...");
                        if (sulphur.LoadAsset<Sprite>(assetPath) == null)
                        {
                            Log.Error(languageName, "Sprite is null");
                            Log.Debug(languageName, Status.Stop);
                            return;
                        }
                        var s_sprite = sulphur.LoadAsset<Sprite>(assetPath);
                        Log.Debug(languageName, "Sprite obtained");
                        Log.Debug(languageName, "Applying sprite...");
                        CustomSpriteHandler.customSprites.Add(new CustomSprite(techType, s_sprite));
                        Log.Debug(languageName, "Sprite applied");
                    }
                    Log.Debug(languageName, Status.Stop);
                }
                catch (Exception e)
                {
                    Log.e(e);
                }
            }
            /// <summary>
            /// Loads a custom item
            /// Only for new items that dont have an alternative sprite
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
                Custom(name, languageName, languageTooltip, from, null, assetPath, inassetbundles);
            }
            /// <summary>
            /// Loads item sizes for titanium ingot
            /// </summary>
            public static void TitaniumIngot()
            {
                var _xTitaniumIngot = 1;
                var _yTitaniumIngot = 1;
                var Start = Status.Start;
                var Stop = Status.Stop;
                try
                {
                    var Config = MI.Config.cfgfile;
                    var titname = "Titanium Ingot";
                    Config.TryGet(ref _xTitaniumIngot, titname, "Size", "x");
                    Config.TryGet(ref _yTitaniumIngot, titname, "Size", "y");
                    Log.Debug(titname, Start);
                    Log.Debug(titname, "Checking config data for errors... (0/4)");
                    if (_xTitaniumIngot <= 0)
                    {
                        _xTitaniumIngot = 1;
                        Config[titname, "Size", "x"] = _xTitaniumIngot;
                        Log.Warning(titname, "X can't be less than 1");
                        Log.Info(titname, "X was set to 1");
                    }
                    Log.Debug(titname, "Checking config data for errors... (1/4)");
                    if (_xTitaniumIngot > 6)
                    {
                        _xTitaniumIngot = 1;
                        Config[titname, "Size", "x"] = _xTitaniumIngot;
                        Log.Warning(titname, "X can't be greater than 6");
                        Log.Info(titname, "X was set to 1");
                    }
                    Log.Debug(titname, "Checking config data for errors... (2/4)");
                    if (_yTitaniumIngot <= 0)
                    {
                        _yTitaniumIngot = 1;
                        Config[titname, "Size", "y"] = _yTitaniumIngot;
                        Log.Warning(titname, "Y can't be less than 0");
                        Log.Info(titname, "Y was set to 1");
                    }
                    Log.Debug(titname, "Checking config data for errors... (3/4)");
                    if (_yTitaniumIngot > 8)
                    {
                        _yTitaniumIngot = 1;
                        Config[titname, "Size", "y"] = _yTitaniumIngot;
                        Log.Warning(titname, "Y can't be greater than 8");
                        Log.Info(titname, "Y was set to 1");
                    }
                    Log.Debug(titname, "Checking config data for errors... (4/4)");
                    Log.Debug(titname, "Error check complete");
                    MI.Config.Save(titname);
                    Log.Debug(titname, "Applying item size...");
                    CraftDataPatcher.customItemSizes[key: TechType.TitaniumIngot] = new Vector2int(_xTitaniumIngot, _yTitaniumIngot);
                    Log.Debug(titname, "Item size applied");
                    Log.Debug(titname, Stop);
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
                var _xPlasteel = 1;
                var _yPlasteel = 1;
                var Start = Status.Start;
                var Stop = Status.Stop;
                try
                {
                    var Config = MI.Config.cfgfile;
                    var pname = "Plasteel Ingot";
                    Config.TryGet(ref _xPlasteel, pname, "Size", "x");
                    Config.TryGet(ref _yPlasteel, pname, "Size", "y");
                    Log.Debug(pname, Start);
                    Log.Debug(pname, "Checking config data for errors... (0/4)");
                    if (_xPlasteel <= 0)
                    {
                        _xPlasteel = 1;
                        Config[pname, "Size", "x"] = _xPlasteel;
                        Log.Warning(pname, "X can't be less than 1");
                        Log.Info(pname, "X was set to 1");
                    }
                    Log.Debug(pname, "Checking config data for errors... (1/4)");
                    if (_xPlasteel > 6)
                    {
                        _xPlasteel = 1;
                        Config[pname, "Size", "x"] = _xPlasteel;
                        Log.Warning(pname, "X can't be greater than 6");
                        Log.Info(pname, "X was set to 1");
                    }
                    Log.Debug(pname, "Checking config data for errors... (2/4)");
                    if (_yPlasteel <= 0)
                    {
                        _yPlasteel = 1;
                        Config[pname, "Size", "y"] = _yPlasteel;
                        Log.Warning(pname, "Y can't be less than 0");
                        Log.Info(pname, "Y was set to 1");
                    }
                    Log.Debug(pname, "Checking config data for errors... (3/4)");
                    if (_yPlasteel > 8)
                    {
                        _yPlasteel = 1;
                        Config[pname, "Size", "y"] = _yPlasteel;
                        Log.Warning(pname, "Y can't be greater than 8");
                        Log.Info(pname, "Y was set to 1");
                    }
                    Log.Debug(pname, "Checking config data for errors... (4/4)");
                    Log.Debug(pname, "Error check complete");
                    MI.Config.Save("Titanium Ingot");
                    Log.Debug(pname, "Applying item size...");
                    CraftDataPatcher.customItemSizes[key: TechType.PlasteelIngot] = new Vector2int(_xPlasteel, _yPlasteel);
                    Log.Debug(pname, "Item size applied");
                    Log.Debug(pname, Stop);
                }
                catch (Exception e)
                {
                    Log.e(e);
                }
            }
        }
    }
}
