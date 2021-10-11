using System.Collections;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    public class AchievementModel
    {
        /// <summary>
        /// this is model class for achievement system
        /// by using scriptable object model desides which achievements to be create
        /// </summary>
        public CoinsCollectAchievementSO CoinsCollectAchievementSO { get; set; }
        public RunMasterAchievementSO RunMasterAchievementSO { get; set; }

        public AchievementModel(CoinsCollectAchievementSO coinsCollectAchievementSO,RunMasterAchievementSO runMasterAchievementSO)
        {
            RunMasterAchievementSO = runMasterAchievementSO;
            CoinsCollectAchievementSO = coinsCollectAchievementSO;
        }
    }
}