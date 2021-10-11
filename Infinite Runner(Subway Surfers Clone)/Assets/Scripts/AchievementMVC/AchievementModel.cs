using System.Collections;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    public class AchievementModel : MonoBehaviour
    {

        public CoinsCollectAchievementSO CoinsCollectAchievementSO { get; }
        public RunMasterAchievementSO RunMasterAchievementSO { get; }

        public AchievementModel(CoinsCollectAchievementSO coinsCollectAchievementSO,RunMasterAchievementSO runMasterAchievementSO)
        {
            RunMasterAchievementSO = runMasterAchievementSO;
            CoinsCollectAchievementSO = coinsCollectAchievementSO;
        }
    }
}