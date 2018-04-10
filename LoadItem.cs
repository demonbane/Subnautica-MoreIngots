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
        Salt
    }

    /// <summary>
    /// Main class for loading an item
    /// </summary>
    public static class LoadItem
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
        public static void Load(string name, string languageName, string languageTooltip, TechType from, string fromstring, string alt_assetPath, string assetPath, InAssetBundles inassetbundles = InAssetBundles.All)
        {
            try
            {
                var _x = 1;
                var _y = 1;
                var _a = 10;
                var Config = Cfg.Config;
                var moreingots = LoadAssetBundles.moreingots;
                var ingotsplus = LoadAssetBundles.ingotsplus;
                var moreingots_salt = LoadAssetBundles.moreingots_salt;
                var ingotsplus_salt = LoadAssetBundles.ingotsplus_salt;
                Config.TryGet(ref _x, languageName, "Size", "x");
                Config.TryGet(ref _y, languageName, "Size", "y");
                Config.TryGet(ref _a, languageName, "Craft amount");
                Log.Debug(languageName, Status.Start);
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
                Cfg.Save(languageName);
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
                KnownTechPatcher.unlockedAtStart.Add(TechType.Gold);
                Log.Debug(languageName, "Unlock on start added for " + from);
                if (inassetbundles == InAssetBundles.All)
                {
                    if (Cfg._alttextures)
                    {
                        Log.Debug(languageName, "Asset bundle \"moreingots\" selected");
                        Log.Debug(languageName, "Obtaining sprite...");
                        var alt_sprite = moreingots.LoadAsset<Sprite>(alt_assetPath);
                        if (alt_sprite == null)
                        {
                            Log.Error(languageName, "Sprite is null");
                        }
                        Log.Debug(languageName, "Sprite obtained");
                        Log.Debug(languageName, "Applying sprite...");
                        CustomSpriteHandler.customSprites.Add(new CustomSprite(techType, alt_sprite));
                        Log.Debug(languageName, "Sprite applied");
                    }
                    else
                    {
                        Log.Debug(languageName, "Asset bundle \"yenzen-ingotsplus\" selected");
                        Log.Debug(languageName, "Obtaining sprite...");
                        var sprite = ingotsplus.LoadAsset<Sprite>(assetPath);
                        if (sprite == null)
                        {
                            Log.Error(languageName, "Sprite is null");
                        }
                        Log.Debug(languageName, "Sprite obtained");
                        Log.Debug(languageName, "Applying sprite...");
                        CustomSpriteHandler.customSprites.Add(new CustomSprite(techType, sprite));
                        Log.Debug(languageName, "Sprite applied");
                    }
                }
                if (inassetbundles == InAssetBundles.Salt)
                {
                    if (Cfg._alttextures)
                    {
                        Log.Debug(languageName, "Asset bundle \"salt-alexejheroytb\" selected");
                        Log.Debug(languageName, "Obtaining sprite...");
                        var alt_sprite = moreingots_salt.LoadAsset<Sprite>(alt_assetPath);
                        if (alt_sprite == null)
                        {
                            Log.Error(languageName, "Sprite is null");
                        }
                        Log.Debug(languageName, "Sprite obtained");
                        Log.Debug(languageName, "Applying sprite...");
                        CustomSpriteHandler.customSprites.Add(new CustomSprite(techType, alt_sprite));
                        Log.Debug(languageName, "Sprite applied");
                    }
                    else
                    {
                        Log.Debug(languageName, "Asset bundle \"salt-yenzen\" selected");
                        Log.Debug(languageName, "Obtaining sprite...");
                        var sprite = ingotsplus_salt.LoadAsset<Sprite>(assetPath);
                        if (sprite == null)
                        {
                            Log.Error(languageName, "Sprite is null");
                        }
                        Log.Debug(languageName, "Sprite obtained");
                        Log.Debug(languageName, "Applying sprite...");
                        CustomSpriteHandler.customSprites.Add(new CustomSprite(techType, sprite));
                        Log.Debug(languageName, "Sprite applied");
                    }
                }
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
                Log.Debug(languageName, Status.Stop);
            }
            catch (Exception e)
            {
                e.Log(LogType.Console);
            }

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
                var Config = Cfg.Config;
                var titname = "Titanium Ingot";
                Config.TryGet(ref _xTitaniumIngot, titname, "Size", "x");
                Config.TryGet(ref _yTitaniumIngot, titname, "Size", "y");
                Log.Debug(titname, Start);
                Log.Debug(titname, "Checking config data for errors... (0/4)");
                if (_xTitaniumIngot <= 0)
                {
                    _xTitaniumIngot = 1;
                    Config["Titanium Ingot", "Size", "x"] = _xTitaniumIngot;
                    Log.Warning(titname, "X can't be less than 1");
                    Log.Info(titname, "X was set to 1");
                }
                Log.Debug(titname, "Checking config data for errors... (1/4)");
                if (_xTitaniumIngot > 6)
                {
                    _xTitaniumIngot = 1;
                    Config["Titanium Ingot", "Size", "x"] = _xTitaniumIngot;
                    Log.Warning(titname, "X can't be greater than 6");
                    Log.Info(titname, "X was set to 1");
                }
                Log.Debug(titname, "Checking config data for errors... (2/4)");
                if (_yTitaniumIngot <= 0)
                {
                    _yTitaniumIngot = 1;
                    Config["Titanium Ingot", "Size", "y"] = _yTitaniumIngot;
                    Log.Warning(titname, "Y can't be less than 0");
                    Log.Info(titname, "Y was set to 1");
                }
                Log.Debug(titname, "Checking config data for errors... (3/4)");
                if (_yTitaniumIngot > 8)
                {
                    _yTitaniumIngot = 1;
                    Config["Titanium Ingot", "Size", "y"] = _yTitaniumIngot;
                    Log.Warning(titname, "Y can't be greater than 8");
                    Log.Info(titname, "Y was set to 1");
                }
                Log.Debug(titname, "Checking config data for errors... (4/4)");
                Log.Debug(titname, "Error check complete");
                Cfg.Save("Titanium Ingot");
                Log.Debug(titname, "Applying item size...");
                CraftDataPatcher.customItemSizes[key: TechType.TitaniumIngot] = new Vector2int(_xTitaniumIngot, _yTitaniumIngot);
                Log.Debug(titname, "Item size applied");
                Log.Debug(titname, Stop);
            }
            catch (Exception e)
            {
                e.Log(LogType.Console);
            }
        }
    }
}
