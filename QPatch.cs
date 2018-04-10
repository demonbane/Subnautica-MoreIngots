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
                Log.Info("Started loading");
                Logger.ClearCustomLog();
                Cfg.Load();
                LoadAssetBundles.Load();
                LoadFabricatorTabs.Load();
                LoadItem.TitaniumIngot();
                LoadItem.Load("MIGold", "Gold Ingot", "Au. Compressed gold. Added by the MoreIngots mod", TechType.Gold, "Gold", "MIGold", "IPGold");
                LoadItem.Load("MIDiamond", "Compressed Diamond", "C. Compressed diamond. Added by the MoreIngots mod", TechType.Diamond, "Diamond", "MIDiamond", "IPDiamond");
                LoadItem.Load("MILithium", "Lithium Ingot", "Li. Compressed lithium. Added by the MoreIngots mod", TechType.Lithium, "Lithium", "MILithium", "IPLithium");
                LoadItem.Load("MICopper", "Copper Ingot", "Cu. Compressed copper. Added by the MoreIngots mod", TechType.Copper, "Copper", "MICopper", "IPCopper");
                LoadItem.Load("MILead", "Lead Ingot", "Pb. Compressed lead. Added by the MoreIngots mod", TechType.Lead, "Lead", "MILead", "IPLead");
                LoadItem.Load("MISilver", "Silver Ingot", "Ag. Compressed silver. Added by the MoreIngots mod", TechType.Silver, "Silver", "MISilver", "IPSilver");
                LoadItem.Load("MIMagnetite", "Compressed Magnetite", "Fe3O4. Compressed magnetite. Added by the MoreIngots mod", TechType.Magnetite, "Silver", "MISilver", "IPSilver");
                LoadItem.Load("MINickel", "Nickel Ingot", "Ni. Compressed nickel. Added by the MoreIngots mod", TechType.Nickel, "Nickel", "MINickel", "IPNickel");
                LoadItem.Load("MIKyanite", "Compressed Kyanite", "Al2SiO5. Compressed kyanite. Added by the MoreIngots mod", TechType.Kyanite, "Kyanite", "MIKyanite", "IPKyanite");
                LoadItem.Load("MIRuby", "Compressed Ruby", "Al2O3. Compressed ruby. Added by the MoreIngots mod", TechType.AluminumOxide, "AluminiumOxide", "MIRuby", "IPRuby");
                LoadItem.Load("MIUraninite", "Compressed Uraninite", "U3O8. Compressed uraninite. Added by the MoreIngots mod", TechType.UraniniteCrystal, "UraniniteCrystal", "MIUraninite", "IPUraninite");
                LoadItem.Load("MIQuartz", "Compressed Quartz", "SiO4. Compressed quartz. Added by the MoreIngots mod", TechType.Quartz, "Quartz", "MIQuartz", "IPQuartz");
                LoadItem.Load("MISalt", "Salt Lick", "NaCl. Salt. Added by the MoreIngots mod. (Suggested by Oddwood)", TechType.Salt, "Salt", "Salt", "Salt", InAssetBundles.Salt);
                Log.Info("Finished loading");
            }
            catch (Exception e)
            {
                e.Log(LogType.Console);
            }

        }
    }
} 
