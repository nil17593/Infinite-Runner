using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        [SerializeField] private TextMeshProUGUI coinsAcheievemetText;
        [SerializeField] private GameObject pausetextPanel;
        [SerializeField] private GameObject playerDiePanel;
        [SerializeField] private GameObject achievementPanel;
        [SerializeField] private Button buttonMenu;
        [SerializeField] private Button buttonRestart;
        [SerializeField] private string gameScene;
        [SerializeField] private string lobby;
        #endregion

        #region Private integers
        private int currentScore;
        private int coinsCount;
        private float score;
        #endregion

        #region Referance of other scripts
        private PlayerView playerView;
        #endregion

        #region Bools
        public static bool gameIsPaused;
        #endregion

        protected override void Awake()
        {
            base.Awake();
        }

        void Start()
        {
            coinsCount = 0;
            coinsCountText.text = "Coins:" + coinsCount.ToString();
            DisplayDistanceText();
            buttonRestart.onClick.AddListener(RestartGame);
            buttonMenu.onClick.AddListener(LoadLobby);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameIsPaused = !gameIsPaused;
                PauseGame();
            }
        }

        //showing panel after player dies
        public void PlayerDiePanel()
        {
            playerDiePanel.SetActive(true);
        }

        //keep count of collected coins
        public void UpdateCoinsText(int increment)
        { 
            coinsCount += increment;
            coinsCountText.text = "Coins: " + coinsCount.ToString();
            //AchievementService.Instance.InvokeOnCoinAchievemt();
        }

        //showing achievement panel for given time
        public IEnumerator PopUpAchievements(string achievement)
        {
            achievementPanel.SetActive(true);
            coinsAcheievemetText.text= "Achievement Unlocked : " + achievement;
            yield return new WaitForSeconds(2f);
            achievementPanel.SetActive(false);
        }

        //displays how many distance covered by player in meters
        public void DisplayDistanceText()
        {
            score += Time.time;
            distanceText.text = "Distance: " + ((int)score).ToString();
        }

        //pause game function
        void PauseGame()
        {
            if (gameIsPaused)
            {
                Time.timeScale = 0f;
                pausetextPanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pausetextPanel.SetActive(false);
            }
        }

        //restart game on buttonclick
        private void RestartGame()
        {
            PlayerService.Instance.PlayerPos().transform.position = new Vector3(0, 1, 0);
            GroundSpawner.Instance.SpawnTile();
            SceneManager.LoadScene(gameScene);
        }

        private void LoadLobby()
        {
            SceneManager.LoadScene(lobby);
        }
    }
}