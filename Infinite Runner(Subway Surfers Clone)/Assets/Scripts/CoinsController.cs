using System.Collections;
using TMPro;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    /// <summary>
    /// this class handles coins 
    /// player will get points for every coin collected
    /// </summary>
    public class CoinsController : MonoBehaviour
    {
        public PlayerModel PlayerModel { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<PlayerView>() != null)
            {
                UpdateCoinsCounter();
                AchievementService.Instance.InvokeOnCoinAchievemt();
                GameManager.Instance.UpdateCoinsText();
                Debug.Log(GameManager.Instance);
                gameObject.SetActive(false);
            }
        }

        public void UpdateCoinsCounter()
        {
            Debug.Log("ala");
            PlayerModel.CoinsCollected += 1;
            AchievementService.Instance.GetAchievementController().CheckForCoinAchievement();
        }
    }
}