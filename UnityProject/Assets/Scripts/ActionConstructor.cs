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




    }
}
