using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public static class ActionConstructor
    {
        #region Build Unnecessary Landmarks
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

        #region Encourage Young Professionals
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

        #region Call The Police
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

        #region Can I Haz Some Help
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

        #region Hola Gringo

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


    }
}
