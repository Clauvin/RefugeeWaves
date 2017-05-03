using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public static class ActionConstructor
    {
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
            BuildUnnecessaryLandmarksResult());
        }





    }
}
