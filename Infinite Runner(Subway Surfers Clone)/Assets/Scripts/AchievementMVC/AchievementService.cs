using System;
using System.Collections;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    public class AchievementService : MonoSingletonGeneric<AchievementService>
    {

        /// <summary>
        /// generic singleton class for achievement services
        /// </summary>

        #region Events
        public event Action OnRunAchievement;
        public event Action OnCoinAchievemt;
        #endregion

        #region serialized fields
        [SerializeField] private RunMasterAchievementSO runMasterAchievementSO;
        [SerializeField] private CoinsCollectAchievementSO coinsCollectAchievementSO;
        #endregion

        #region other scripts referances
        private AchievementController achievementController;
        private AchievementModel achievementModel;
        #endregion          

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            CreateAchievement();
            InvokeOnCoinAchievemt();
            InvokeOnRunAchievemt();
        }

        //creating achivements
        private void CreateAchievement()
        {
            achievementModel = new AchievementModel(coinsCollectAchievementSO, runMasterAchievementSO);
            achievementController = new AchievementController(achievementModel);
        }

        //return achievement controller to the caller
        public AchievementController GetAchievementController()
        {
            return achievementController;
        }

        //invoking fire bullet event
        public void InvokeOnCoinAchievemt()
        {
            OnCoinAchievemt?.Invoke();
        }

        //invoking enemy killed event
        public void InvokeOnRunAchievemt()
        {
            OnRunAchievement?.Invoke(); //Its same as below code

            // if (OnEnemyKilled == null)
            // {
            //     OnEnemyKilled.Invoke();
            // }
        }
    }
}