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
using static MoreIngots.MI.LoadingStartStop;

namespace MoreIngots
{
    /// <summary>
    /// Main class
    /// </summary>
    public class QPatch
    {
        /// <summary>
        /// Entry point
        /// </summary>
        public static void Patch()
        {
            try
            {
                LoadingStarted();
                Load.Config();
                Load.AssetBundles();
                Load.FabricatorTabs();
                Load.Item.TitaniumIngot();
                Load.Item.Custom("MIGold", "Gold Ingot", "Au. Compressed gold. Added by the MoreIngots mod", TechType.Gold, "IPGold");
                Load.Item.Custom("MIDiamond", "Compressed Diamond", "C. Compressed diamond. Added by the MoreIngots mod", TechType.Diamond, "IPDiamond");
                Load.Item.Custom("MILithium", "Lithium Ingot", "Li. Compressed lithium. Added by the MoreIngots mod", TechType.Lithium, "IPLithium");
                Load.Item.Custom("MICopper", "Copper Ingot", "Cu. Compressed copper. Added by the MoreIngots mod", TechType.Copper, "IPCopper");
                Load.Item.Custom("MILead", "Lead Ingot", "Pb. Compressed lead. Added by the MoreIngots mod", TechType.Lead, "IPLead");
                Load.Item.Custom("MISilver", "Silver Ingot", "Ag. Compressed silver. Added by the MoreIngots mod", TechType.Silver, "IPSilver");
                Load.Item.Custom("MIMagnetite", "Compressed Magnetite", "Fe3O4. Compressed magnetite. Added by the MoreIngots mod", TechType.Magnetite, "IPMagnetite");
                Load.Item.Custom("MINickel", "Nickel Ingot", "Ni. Compressed nickel. Added by the MoreIngots mod", TechType.Nickel, "IPNickel");
                Load.Item.Custom("MIKyanite", "Compressed Kyanite", "Al2SiO5. Compressed kyanite. Added by the MoreIngots mod", TechType.Kyanite, "IPKyanite");
                Load.Item.Custom("MIRuby", "Compressed Ruby", "Al2O3. Compressed ruby. Added by the MoreIngots mod", TechType.AluminumOxide, "IPRuby");
                Load.Item.Custom("MIUraninite", "Compressed Uraninite", "U3O8. Compressed uraninite. Added by the MoreIngots mod", TechType.UraniniteCrystal, "IPUraninite");
                Load.Item.Custom("MIQuartz", "Compressed Quartz", "SiO4. Compressed quartz. Added by the MoreIngots mod", TechType.Quartz, "IPQuartz");
                Load.Item.Custom("MISalt", "Salt Lick", "NaCl. Salt. Added by the MoreIngots mod. (Suggested by Oddwood)", TechType.Salt, "Salt", InAssetBundles.Salt);
                Load.Item.Custom("MISulphur", "Compressed Sulphur", "S. Compressed Sulphur. Added by the MoreIngots mod. (Suggested by gnivler)", TechType.Sulphur, "Crystalline Sulphur", InAssetBundles.Sulphur);
                Load.Item.Custom("MIIonCrystal", "Ion Crystal Matrix", "Compressed Ion Cube. Added by the MoreIngots mod.", TechType.PrecursorIonCrystal, "IPUraninite", InAssetBundles.All);
                Load.Item.PlasteelIngot();
                LoadingFinished();
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }
    }
} 
