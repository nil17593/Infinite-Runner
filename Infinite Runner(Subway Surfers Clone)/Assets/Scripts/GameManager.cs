using System.Collections;
using UnityEngine;
using TMPro;

namespace IMPLIEDSOULS.InfiniteRunner
{
    /// <summary>
    /// Game manager class
    /// this class handles all UI part
    /// and score,player win lose,player die
    /// </summary>
    public class GameManager : MonoSingletonGeneric<GameManager>
    {
        #region Serialized fields
        [SerializeField] private TextMeshProUGUI coinsCountText;
        [SerializeField] private TextMeshProUGUI distanceText;
        [SerializeField] private GameObject playerDiePanel;
        [SerializeField] private GameObject achievementPanel;
        #endregion

        #region Private integers
        private int currentScore;
        private int coinsCount;
        private float score;
        #endregion

        #region Referance of other scripts
        private PlayerView playerView;
        #endregion


        protected override void Awake()
        {
            base.Awake();
        }

        void Start()
        {
            currentScore = 0;
            coinsCountText.text = "Score:" + currentScore.ToString();
            UpdateCoinsText();
            DisplayDistanceText();
        }


        //showing panel after player dies
        public void PlayerDiePanel()
        {
            playerDiePanel.SetActive(true);
        }

        //keep count of collected coins
        public void UpdateCoinsText()
        {
            int finalScore = (currentScore + 1) ;
            currentScore = finalScore;
            coinsCountText.text = "Coins: " + finalScore.ToString();
        }

        //showing achievement panel for given time
        public IEnumerator PopUpAchievements(string achievement)
        {
            achievementPanel.SetActive(true);
            yield return new WaitForSeconds(5f);
            achievementPanel.SetActive(false);
        }

        //displays how many distance covered by player in meters
        public void DisplayDistanceText()
        {
            score += Time.deltaTime;
            distanceText.text = "Distance: " + ((int)score).ToString();
        }

    }
}