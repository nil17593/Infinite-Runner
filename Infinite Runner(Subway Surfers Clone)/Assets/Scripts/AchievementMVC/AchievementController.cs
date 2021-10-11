using System.Collections;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    public class AchievementController
    {
        /// <summary>
        /// this class controls the achievement system
        /// checking continuosly for achievement unlock
        /// </summary>

        #region Properties
        public AchievementModel AchievementModel { get; set; }
        public PlayerModel PlayerModel { get; }
        #endregion

        #region private integers
        private int currentStageOfRunAchievement;
        private int currentStageOfCoinsAchievement;
        #endregion

        #region reference of other scripts
        private PlayerView playerView;
        #endregion

        public AchievementController(AchievementModel achievementModel)
        {
            currentStageOfRunAchievement = 0;
            currentStageOfCoinsAchievement = 0;
            this.AchievementModel = achievementModel;
        }

        //creating enemy kileed achievement
        public void CheckForRunAchievement()
        {
            for (int i = 0; i < AchievementModel.RunMasterAchievementSO.runMasterArray.Length; i++)
            {
                if ( PlayerService.Instance.GetPlayerModel().PlayerRunCount== AchievementModel.RunMasterAchievementSO.runMasterArray[i].distancerequirement)
                {
                    string achievement = AchievementModel.RunMasterAchievementSO.runMasterArray[i].runAchievementType.ToString();
                    UnlockedAchievement(achievement);
                    currentStageOfRunAchievement = i + 1;
                }
            }
        }

        //creating bullets fired achievement
        public void CheckForCoinAchievement()
        {
            for (int i = 0; i < AchievementModel.CoinsCollectAchievementSO.coinscollectedArray.Length; i++)
            {
                if (PlayerService.Instance.GetPlayerModel().CoinsCollected == AchievementModel.CoinsCollectAchievementSO.coinscollectedArray[i].requirement)
                {
                    string achievement = AchievementModel.CoinsCollectAchievementSO.coinscollectedArray[i].coinsAchiementType.ToString();
                    UnlockedAchievement(achievement);
                    currentStageOfCoinsAchievement = i + 1;
                }
            }
        }

        //popup will show which achievement is unlocked
        public void UnlockedAchievement(string achievement)
        {
            Debug.Log("Got :" + achievement);
            GameManager.Instance.PopUpAchievements(achievement);
        }
    }
}