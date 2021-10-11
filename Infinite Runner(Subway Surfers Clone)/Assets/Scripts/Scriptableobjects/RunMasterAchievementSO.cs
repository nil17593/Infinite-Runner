using System;
using System.Collections;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner 
{
    [CreateAssetMenu(menuName = "RunMasterAchievementSO", fileName = "ScriptableObject/NewRunMasterAchievementSO")]
    public class RunMasterAchievementSO : ScriptableObject
    {
        public RunMasterAchievements[] runMasterArray;

        [Serializable]
        public class RunMasterAchievements
        {
            public RunAchievementType runAchievementType;
            public int requirement;
        }
    }

    public enum RunAchievementType
    {
        None,
        Runner,
        GoodRunner,
        Boom,
    }
}
