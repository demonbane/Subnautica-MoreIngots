setlocal EnableDelayedExpansion

rem Titanium
set x[0]=1
set y[0]=1

rem Gold
set e[1]=1
set namespace[1]=MIGold
set name[1]=Gold Ingot
set tooltip[1]=Au. Condensed gold. Added by MoreIngots mod. 
set from[1]=Gold
set fromcount[1]=10
set x[1]=1
set y[1]=1

rem Diamond
set e[2]=2
rem set namespace[2]=MIDiamond
rem set name[2]=Graphite
rem set tooltip[2]=C. Condensed diamond. Added by MoreIngots mod
rem set from[2]=Diamond
rem set fromcount[2]=10
rem set x[2]=1
rem set y[2]=1

rem Lithium
set e[3]=1
set namespace[3]=MILithium
set name[3]=Lithium Bar
set tooltip[3]=Li. Condensed lithium. Added by MoreIngots mod
set from[3]=Lithium
set fromcount[3]=10
set x[3]=1
set y[3]=1

rem Copper
set e[4]=1
set namespace[4]=MICopper
set name[4]=Copper Ingot
set tooltip[4]=Cu. Condensed copper. Added by MoreIngots mod
set from[4]=Copper
set fromcount[4]=10
set x[4]=1
set y[4]=1

rem Lead
set e[5]=1
set namespace[5]=MILead
set name[5]=Lead Bar
set tooltip[5]=Pb. Condensed lead. Added by MoreIngots mod
set from[5]=Lead
set fromcount[5]=10
set x[5]=1
set y[5]=1

rem Silver
set e[6]=1
set namespace[6]=MISilver
set name[6]=Silver Ingot
set tooltip[6]=Ag. Condensed silver. Added by MoreIngots mod
set from[6]=Silver
set fromcount[6]=10
set x[6]=1
set y[6]=1

rem Magnetite
set e[7]=1
set namespace[7]=MIMagnetite
set name[7]=Maghemite
set tooltip[7]=γ-Fe2O3. Condensed magnetite. Added by MoreIngots mod
set from[7]=Magnetite
set fromcount[7]=10
set x[7]=1
set y[7]=1

rem Nickel
set e[8]=1
set namespace[8]=MINickel
set name[8]=Nickel Sheets
set tooltip[8]=Ni. Condensed nickel. Added by MoreIngots mod
set from[8]=Nickel
set fromcount[8]=10
set x[8]=1
set y[8]=1

rem Kyanite
set e[9]=2
rem set namespace[9]=MIKyanite
rem set name[9]=Topaz
rem set tooltip[9]=Al2(F,OH)2SiO4. Condensed kyanite. Added by MoreIngots mod
rem set from[9]=Kyanite
rem set fromcount[9]=10
rem set x[9]=1
rem set y[9]=1

rem Uraninite
set e[10]=1
set namespace[10]=MIUraninite
set name[10]=Triuranium octoxide
set tooltip[10]=U3O8. Condensed uraninite. Added by MoreIngots mod
set from[10]=UraniniteCrystal
set fromcount[10]=10
set x[10]=1
set y[10]=1

rem Ruby
set e[11]=2
rem set namespace[11]=MIRuby
rem set name[11]=Bauxite
rem set tooltip[11]=Al(OH)3. Condensed ruby. Added by MoreIngots mod
rem set from[11]=AluminumOxide
rem set fromcount[11]=10
rem set x[11]=1
rem set y[11]=1

rem Quartz
set e[12]=1
set namespace[12]=MIQuartz
set name[12]=Silicate
set tooltip[12]=SiO4. Condensed quartz. Added by MoreIngots mod
set from[12]=Quartz
set fromcount[12]=10
set x[12]=1
set y[12]=1



echo using SMLHelper; > QPatch.cs
echo using SMLHelper.Patchers; >> QPatch.cs
echo using System; >> QPatch.cs
echo using System.Collections.Generic; >> QPatch.cs
echo using System.Reflection; >> QPatch.cs
echo using UnityEngine; >> QPatch.cs
echo using Utilites.Config; >> QPatch.cs
echo namespace MoreIngots >> QPatch.cs
echo { >> QPatch.cs
echo public class QPatch >> QPatch.cs
echo { >> QPatch.cs
echo private static readonly ConfigFile Config = new ConfigFile("config"); >> QPatch.cs
set i=1



echo private static int _xTitaniumIngot = !x[0]!; >> QPatch.cs
echo private static int _yTitaniumIngot = !y[0]!; >> QPatch.cs
:loop1
echo private static int _x!namespace[%i%]! = !x[%i%]!; >> QPatch.cs
echo private static int _y!namespace[%i%]! = !y[%i%]!; >> QPatch.cs
set /a i+=1
if !e[%i%]! == 1 goto loop1
if !e[%i%]! == 2 goto loop1add
goto continue1
:loop1add
set /a i+=1
goto loop1
:continue1
echo public static void Patch() >> QPatch.cs
echo { >> QPatch.cs
echo var assetBundle = AssetBundle.LoadFromFile(@"./QMods/MoreIngots/moreingots.assets"); >> QPatch.cs
echo Config.Load(); >> QPatch.cs
echo var configChanged =  >> QPatch.cs
echo Config.TryGet(ref _xTitaniumIngot, "Titanium Ingot - Titanium", "Size", "x") >> QPatch.cs
echo ^|Config.TryGet(ref _yTitaniumIngot, "Titanium Ingot - Titanium", "Size", "y") >> QPatch.cs
set i=1



:loop2
echo ^|Config.TryGet(ref _x!namespace[%i%]!, "!name[%i%]! - !from[%i%]!", "Size", "x") >> QPatch.cs
echo ^|Config.TryGet(ref _y!namespace[%i%]!, "!name[%i%]! - !from[%i%]!", "Size", "y") >> QPatch.cs
set /a i+=1
if !e[%i%]! == 1 goto loop2
if !e[%i%]! == 2 goto loop2add
goto continue2
:loop2add
set /a i+=1
goto loop2
:continue2
echo ; >> QPatch.cs
echo if (_xTitaniumIngot ^<= 0) >> QPatch.cs
echo { >> QPatch.cs
echo   _xTitaniumIngot = 1; >> QPatch.cs
echo  Config["Titanium Ingot - Titanium", "Size", "x"] = _xTitaniumIngot; >> QPatch.cs
echo  Utilites.Logger.Logger.Error("Size of Titanium Ingot can't be less or equal to 0! X was set to 1", Utilites.Logger.LogType.Custom ^| Utilites.Logger.LogType.Console); >> QPatch.cs
echo  configChanged = true; >> QPatch.cs
echo } >> QPatch.cs
echo if (_yTitaniumIngot ^<= 0) >> QPatch.cs
echo { >> QPatch.cs
echo   _yTitaniumIngot = 1; >> QPatch.cs
echo  Config["Titanium Ingot - Titanium", "Size", "y"] = _yTitaniumIngot; >> QPatch.cs
echo  Utilites.Logger.Logger.Error("Size of Titanium Ingot can't be less or equal to 0! Y was set to 1", Utilites.Logger.LogType.Custom ^| Utilites.Logger.LogType.Console); >> QPatch.cs
echo  configChanged = true; >> QPatch.cs
echo } >> QPatch.cs
set i=1



:loop3
echo if (_x!namespace[%i%]! ^<= 0) >> QPatch.cs
echo { >> QPatch.cs
echo   _x!namespace[%i%]! = 1; >> QPatch.cs
echo   Config["!name[%i%]! - !from[%i%]!", "Size", "x"] = _x!namespace[%i%]!; >> QPatch.cs
echo   Utilites.Logger.Logger.Error("Size of !name[%i%]! can't be less or equal to 0! X was set to 1", Utilites.Logger.LogType.Custom ^| Utilites.Logger.LogType.Console); >> QPatch.cs
echo   configChanged = true; >> QPatch.cs
echo } >> QPatch.cs
echo if (_y!namespace[%i%]! ^<= 0) >> QPatch.cs
echo { >> QPatch.cs
echo   _y!namespace[%i%]! = 1; >> QPatch.cs
echo   Config["!name[%i%]! - !from[%i%]!", "Size", "y"] = _y!namespace[%i%]!; >> QPatch.cs
echo   Utilites.Logger.Logger.Error("Size of !name[%i%]! can't be less or equal to 0! Y was set to 1", Utilites.Logger.LogType.Custom ^| Utilites.Logger.LogType.Console); >> QPatch.cs
echo   configChanged = true; >> QPatch.cs
echo } >> QPatch.cs
set /a i+=1
if !e[%i%]! == 1 goto loop3
if !e[%i%]! == 2 goto loop3add
goto continue3
:loop3add
set /a i+=1
goto loop3
:continue3
echo if (configChanged) >> QPatch.cs
echo { >> QPatch.cs
echo Config.Save(); >> QPatch.cs
echo } >> QPatch.cs
set i=1



:loop4
echo var techType!namespace[%i%]! = TechTypePatcher.AddTechType("!namespace[%i%]!", "!name[%i%]!", "!tooltip[%i%]!"); >> QPatch.cs
set /a i+=1
if !e[%i%]! == 1 goto loop4
if !e[%i%]! == 2 goto loop4add
goto continue4
:loop4add
set /a i+=1
goto loop4
:continue4
set i=1



:loop5
echo var techData!namespace[%i%]! = new TechDataHelper >> QPatch.cs
echo { >> QPatch.cs
echo _craftAmount = 1, >> QPatch.cs
echo _ingredients = new List^<IngredientHelper^>() >> QPatch.cs
echo { >> QPatch.cs
echo new IngredientHelper(TechType.!from[%i%]!, !fromcount[%i%]!) >> QPatch.cs
echo }, >> QPatch.cs
echo _techType = techType!namespace[%i%]! >> QPatch.cs
echo }; >> QPatch.cs
echo var techData!namespace[%i%]!B = new TechDataHelper >> QPatch.cs
echo { >> QPatch.cs
echo _craftAmount = !fromcount[%i%]!, >> QPatch.cs
echo _ingredients = new List^<IngredientHelper^>() >> QPatch.cs
echo { >> QPatch.cs
echo new IngredientHelper(techType!namespace[%i%]!, 1) >> QPatch.cs
echo }, >> QPatch.cs
echo _techType = TechType.!from[%i%]! >> QPatch.cs
echo }; >> QPatch.cs
echo KnownTechPatcher.unlockedAtStart.Add(TechType.!from[%i%]!); >> QPatch.cs
set /a i+=1
if !e[%i%]! == 1 goto loop5
if !e[%i%]! == 2 goto loop5add
goto continue5
:loop5add
set /a i+=1
goto loop5
:continue5
set i=1



:loop6
echo var sprite!namespace[%i%]! = assetBundle.LoadAsset^<Sprite^>("!namespace[%i%]!"); >> QPatch.cs
echo CustomSpriteHandler.customSprites.Add(new CustomSprite(techType!namespace[%i%]!, sprite!namespace[%i%]!)); >> QPatch.cs
echo CraftDataPatcher.customTechData.Add(techType!namespace[%i%]!, techData!namespace[%i%]!); >> QPatch.cs
echo CraftDataPatcher.customTechData.Add(TechType.!from[%i%]!, techData!namespace[%i%]!B); >> QPatch.cs
echo CraftTreePatcher.customCraftNodes.Add("Resources/AdvancedMaterials/!namespace[%i%]!", techType!namespace[%i%]!); >> QPatch.cs
echo CraftTreePatcher.customCraftNodes.Add("Resources/BasicMaterials/!from[%i%]!", TechType.!from[%i%]!); >> QPatch.cs
echo CraftDataPatcher.customItemSizes[key: techType!namespace[%i%]!] = new Vector2int(x: _x!namespace[%i%]!, y: _y!namespace[%i%]!); >> QPatch.cs
set /a i+=1
if !e[%i%]! == 1 goto loop6
if !e[%i%]! == 2 goto loop6add
goto continue6
:loop6add
set /a i+=1
goto loop6
:continue6
set i=1


echo CraftDataPatcher.customItemSizes[key: TechType.TitaniumIngot] = new Vector2int(x: _xTitaniumIngot, y: _yTitaniumIngot); >> QPatch.cs
echo }}} >> QPatch.cs
move /y QPatch.cs "Subnautica Mods\MoreIngots\"