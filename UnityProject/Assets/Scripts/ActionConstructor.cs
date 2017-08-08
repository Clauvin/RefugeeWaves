using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public static class ActionConstructor
    {
        public static string houses_title = "Houses";
        public static string houses_buy_text_title = "Build";
        public static string houses_sell_text_title = "Sell";
        public static string social_resources_title = "Social Resources";
        public static string social_resources_buy_text_title = "Buy";
        public static string social_resources_sell_text_title = "Sell";
        public static string border_officers_title = "Border Officers";
        public static string border_officers_buy_text_title = "Contract";
        public static string border_officers_sell_text_title = "Dismiss";
        public static string border_resources_title = "Border Resources";
        public static string border_resources_buy_text_title = "Buy";
        public static string border_resources_sell_text_title = "Sell";

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
            600.0,
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
            800,
            3 * ActionsManager.instance.weekLength,
            MiscInfo.variableTypes.unemployementRate,
            EncourageYoungProfessionalsFirstResult,
            MiscInfo.variableTypes.baseTaxPerCitizen,
            EncourageYoungProfessionalsSecondResult);
        }
        #endregion

        #region Call The Police Functions
        public static double CallThePoliceResult()
        {
            return -1 * 0.2 * StatsManager.instance.criminalityRate;
        }

        public static PlayerAction CallThePolice()
        {
            return new PlayerAction(ActionsManager.instance.buttons[2],
                "Call the police!",
            "New police officers should be just what these recent crime waves need!",
            1200,
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
            0,
            24 * ActionsManager.instance.weekLength,
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
            return -1 * 0.15 * StatsManager.instance.publicOpinionOnImmigrants;
        }

        public static PlayerAction HolaGringo()
        {
            return new PlayerAction(ActionsManager.instance.buttons[4],
                "Hola gringo!",
            "Show people Wavestan is a nice place to live" +
            " (and lure some professionals while you're at it",
            2000, 6 * ActionsManager.instance.weekLength,
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
            1200,
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
            2000,
            5 * ActionsManager.instance.weekLength,
            MiscInfo.variableTypes.internationalOpinion,
            MikasaSuCasaResult);
        }
        #endregion

        #region Houses
        public static double AHouseBuyValue()
        {
            return CommerceManager.instance.house_buy_price * CommerceManager.instance.house_buy_multiplier;
        }

        public static double AHouseSellValue()
        {
            return CommerceManager.instance.house_sell_price * CommerceManager.instance.house_sell_multiplier;
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
            return new CommerceAction(houses_title, "Get those houses up so people can rest a little",
                ActionsManager.instance.buttons[7], houses_title, houses_buy_text_title, houses_sell_text_title,
                buyHouses, sellHouses, AHouseBuyValue, AHouseSellValue,
                MiscInfo.variableTypes.availableHouses, 1.5f * ActionsManager.instance.weekLength);
        }

        public static double HousesResult()
        {
            ActionsManager.instance.createVisualCommerceEvent(houses_title, "teste", AHouseBuyValue, AHouseSellValue);
            return 1;
        }

        public static PlayerAction Houses()
        {
            return new PlayerAction(ActionsManager.instance.buttons[7],
                houses_title,
            "Get those houses up so people can rest a little",
            300,
            1.5f * ActionsManager.instance.weekLength,
            MiscInfo.variableTypes.availableHouses, HousesResult);
        }
        #endregion

        #region Social Resources
        public static double SocialResourceBuyValue()
        {
            return CommerceManager.instance.social_resource_buy_price *
                CommerceManager.instance.social_resource_buy_multiplier;
        }

        public static double SocialResourceSellValue()
        {
            return CommerceManager.instance.social_resource_sell_price *
                CommerceManager.instance.social_resource_sell_multiplier;
        }

        public static double buySocialResources(int quantity)
        {
            if (quantity <= 0) throw new Exception("Quantidade menor que zero");
            else
            {
                return quantity * SocialResourceBuyValue();
            }
        }

        public static double sellSocialResources(int quantity)
        {
            if (quantity <= 0) throw new Exception("Quantidade menor que zero");
            else
            {
                return -1 * quantity * SocialResourceSellValue();
            }
        }

        public static CommerceAction CommerceSocialResource()
        {
            return new CommerceAction(social_resources_title, "What's needed to give support for refugees",
                ActionsManager.instance.buttons[8], 
                social_resources_title, social_resources_buy_text_title, social_resources_sell_text_title,
                buySocialResources, sellSocialResources,
                SocialResourceBuyValue, SocialResourceSellValue,
                MiscInfo.variableTypes.socialResources, 1.5f * ActionsManager.instance.weekLength);
        }
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
        public static double BorderOfficerBuyValue()
        {
            return CommerceManager.instance.border_officer_buy_price *
                CommerceManager.instance.border_officer_buy_multiplier;
        }

        public static double BorderOfficerSellValue()
        {
            return CommerceManager.instance.border_officer_sell_price *
                CommerceManager.instance.border_officer_sell_multiplier;
        }

        public static double buyBorderOfficers(int quantity)
        {
            if (quantity <= 0) throw new Exception("Quantidade menor que zero");
            else
            {
                return quantity * BorderOfficerBuyValue();
            }
        }

        public static double sellBorderOfficers(int quantity)
        {
            if (quantity <= 0) throw new Exception("Quantidade menor que zero");
            else
            {
                return -1 * quantity * BorderOfficerSellValue();
            }
        }

        public static CommerceAction CommerceBorderOfficer()
        {
            return new CommerceAction(border_officers_title, "People to stop refugees",
                ActionsManager.instance.buttons[9],
                border_officers_title, border_officers_buy_text_title, border_officers_sell_text_title,
                buyBorderOfficers, sellBorderOfficers,
                BorderOfficerBuyValue, BorderOfficerSellValue,
                MiscInfo.variableTypes.availableBO, 1.5f * ActionsManager.instance.weekLength);
        }

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
        public static double BorderResourceBuyValue()
        {
            return CommerceManager.instance.border_resource_buy_price *
                CommerceManager.instance.border_resource_buy_multiplier;
        }

        public static double BorderResourceSellValue()
        {
            return CommerceManager.instance.border_resource_sell_price *
                CommerceManager.instance.border_resource_sell_multiplier;
        }

        public static double buyBorderResources(int quantity)
        {
            if (quantity <= 0) throw new Exception("Quantidade menor que zero");
            else
            {
                return quantity * BorderResourceBuyValue();
            }
        }

        public static double sellBorderResources(int quantity)
        {
            if (quantity <= 0) throw new Exception("Quantidade menor que zero");
            else
            {
                return -1 * quantity * BorderResourceSellValue();
            }
        }

        public static CommerceAction CommerceBorderResource()
        {
            return new CommerceAction(border_resources_title, "Basically... salary?",
                ActionsManager.instance.buttons[10],
                border_resources_title, border_resources_buy_text_title, border_resources_sell_text_title,
                buyBorderResources, sellBorderResources,
                BorderResourceBuyValue, BorderResourceSellValue,
                MiscInfo.variableTypes.borderResources, 1.5f * ActionsManager.instance.weekLength);
        }

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
