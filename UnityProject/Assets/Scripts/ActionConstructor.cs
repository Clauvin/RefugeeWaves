using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public static class ActionConstructor
    {
        public static string housesTitle = "Build/Sell Houses";


        #region Build Unnecessary Landmarks Functions
        public static double BuildUnnecessaryLandmarksResult()
        {
            return -1 * 0.1 * StatsManager.instance.unemploymentRate;
        }

        public static PlayerAction BuildUnnecessaryLandmarks()
        {
            return new PlayerAction(ActionsManager.instance.buttons[0],
                "Build unnecessary landmarks",
            "No, we don't need new bridges. But people like looking at them and" +
            "need work, so we'll have one anyway",
            300.0,
            4 * ActionsManager.instance.weekLength,
            MiscInfo.variableTypes.unemployementRate,
            BuildUnnecessaryLandmarksResult);
        }
        #endregion

        #region Encourage Young Professionals Functions
        public static double EncourageYoungProfessionalsFirstResult()
        {
            return -1 * 0.07 * StatsManager.instance.unemploymentRate;
        }

        public static double EncourageYoungProfessionalsSecondResult()
        {
            return 0.05 * ResourceManager.instance.baseTaxPerCitizen;
        }

        public static PlayerAction EncourageYoungProfessionals()
        {
            return new PlayerAction(ActionsManager.instance.buttons[1],
                "Encourage young professionals",
            "Make those teenagers get off their phones and work a little",
            400, 3 * ActionsManager.instance.weekLength,
            MiscInfo.variableTypes.unemployementRate,
            EncourageYoungProfessionalsFirstResult,
            MiscInfo.variableTypes.baseTaxPerCitizen,
            EncourageYoungProfessionalsSecondResult);
        }
        #endregion

        #region Call The Police Functions
        public static double CallThePoliceResult()
        {
            return -0.2 * StatsManager.instance.criminalityRate;
        }

        public static PlayerAction CallThePolice()
        {
            return new PlayerAction(ActionsManager.instance.buttons[2],
                "Call the police!",
            "New police officers should be just what these recent crime waves need!",
            600,
            4 * ActionsManager.instance.weekLength,
            MiscInfo.variableTypes.criminalityRate,
            CallThePoliceResult);
        }
        #endregion

        #region Can I Haz Some Help Functions
        public static double CanIHazSomeHelpResult()
        {
            return ResourceManager.instance.UNHelpBaseValue
                * ResourceManager.instance.UNHelpVariation;
        }

        public static PlayerAction CanIHazSomeHelp()
        {
            return new PlayerAction(ActionsManager.instance.buttons[3],
                "Can I haz some help?",
            "Since the UN wants you to help, nothing is more fair than" +
            " if they help with the bills."
            + "(Obs: This likely won't work if you've been a bad boy internationally)",
            0, 24 * ActionsManager.instance.weekLength,
            MiscInfo.variableTypes.playerCurrentMoney,
            CanIHazSomeHelpResult);
        }
        #endregion

        #region Hola Gringo Functions
        public static double HolaGringoFirstResult()
        {
            return 1000.0f;
        }

        public static double HolaGringoSecondResult()
        {
            return -0.15 * StatsManager.instance.publicOpinionOnImmigrants;
        }

        public static PlayerAction HolaGringo()
        {
            return new PlayerAction(ActionsManager.instance.buttons[4],
                "Hola gringo!",
            "Show people Wavestan is a nice place to live" +
            " (and lure some professionals while you're at it",
            1000, 6 * ActionsManager.instance.weekLength,
            MiscInfo.variableTypes.legalPopulation, HolaGringoFirstResult,
            MiscInfo.variableTypes.publicOpinion,
            HolaGringoSecondResult);
        }
        #endregion

        #region They Don't Look So Bad Functions
        public static double TheyDontLookSoBadResult()
        {
            return StatsManager.instance.publicOpinionOnImmigrants * 0.8;
        }

        public static PlayerAction TheyDontLookSoBad()
        {
            return new PlayerAction(ActionsManager.instance.buttons[5],
                "They don't look so bad, right?",
            "Help your people see just how nice those foreigners may be",
            600,
            8 * ActionsManager.instance.weekLength,
            MiscInfo.variableTypes.publicOpinion,
            TheyDontLookSoBadResult);
        }
        #endregion

        #region MikasaSuCasa Functions
        public static double MikasaSuCasaResult()
        {
            return StatsManager.instance.internationalOpinion * 0.7;
        }

        public static PlayerAction MikasaSuCasa()
        {
            return new PlayerAction(ActionsManager.instance.buttons[6],
                "Mikasa, su casa s2",
            "Show the world you accept other peoples with open arms!" +
            " Come on in, don't mind the mess.",
            1000,
            5 * ActionsManager.instance.weekLength,
            MiscInfo.variableTypes.internationalOpinion, MikasaSuCasaResult);
        }
        #endregion

        #region Houses
        public static double AHouseBuyValue()
        {
            return CommerceManager.instance.houses_buy_price * CommerceManager.instance.houses_buy_multiplier;
        }

        public static double AHouseSellValue()
        {
            return CommerceManager.instance.houses_sell_price * CommerceManager.instance.houses_sell_multiplier;
        }

        public static double buyHouses(int quantity)
        {
            if (quantity <= 0) throw new Exception("Quantidade menor que zero");
            else
            {
                return quantity * AHouseBuyValue();
            }
        }

        public static double sellHouses(int quantity)
        {
            if (quantity <= 0) throw new Exception("Quantidade menor que zero");
            else
            {
                return -1 * quantity * AHouseSellValue();
            }
        }

        public static CommerceAction CommerceHouses()
        {
            return new CommerceAction(housesTitle, "", ActionsManager.instance.buttons[7],
                buyHouses, sellHouses, ActionsManager.instance.possibleActions[6], 0.0f);
        }

        public static double HousesResult()
        {
            ActionsManager.instance.createVisualCommerceEvent(housesTitle, "teste", null);
            return 1;
        }

        public static PlayerAction Houses()
        {
            return new PlayerAction(ActionsManager.instance.buttons[7],
                housesTitle,
            "Get those houses up so people can rest a little",
            300,
            1.5f * ActionsManager.instance.weekLength,
            MiscInfo.variableTypes.availableHouses, HousesResult);
        }
        #endregion

        #region Social Resources
        public static double SocialResourcesResult()
        {
            return 1;
        }

        public static PlayerAction SocialResources()
        {
            return new PlayerAction(ActionsManager.instance.buttons[8],
                "Purchase social resources",
                "Everyone needs some soup and some soap",
            100,
            1 * ActionsManager.instance.weekLength,
            MiscInfo.variableTypes.socialResources, SocialResourcesResult);
        }
        #endregion

        #region Border Officers
        public static double BorderOfficersResult()
        {
            return 1;
        }

        public static PlayerAction BorderOfficers()
        {
            return new PlayerAction(ActionsManager.instance.buttons[9],
                "Hire Border Officers",
                "Those borders won't defend themselves",
            125,
            2 * ActionsManager.instance.weekLength,
            MiscInfo.variableTypes.availableBO, BorderOfficersResult);
        }
        #endregion

        #region Border Resources
        public static double BorderResourcesResult()
        {
            return 1;
        }

        public static PlayerAction BorderResources()
        {
            return new PlayerAction(ActionsManager.instance.buttons[10],
                "Build Border Resources", 
                "Fuel and ammo aren't free, you know.",
            75,
            1 * ActionsManager.instance.weekLength,
            MiscInfo.variableTypes.availableBO, BorderResourcesResult);
        }
        #endregion

    }
}
