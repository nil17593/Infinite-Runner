using System;
using System.Collections;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    [CreateAssetMenu(menuName = "CoinsCollectAchievementSO", fileName = "ScriptableObject/NewCoinsCollectAchievementSO")]
    public class CoinsCollectAchievementSO : ScriptableObject
    {
        public CoinsCollectAchievements[] coinscollectedArray;

        [Serializable]
        public class CoinsCollectAchievements
        {

            public CoinsAchiementType coinsAchiementType;
            public int requirement;

        }
    }

    public enum CoinsAchiementType
    {
        Collecter,
        Gainer,
    }
}
