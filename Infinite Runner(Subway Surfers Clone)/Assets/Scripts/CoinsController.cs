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
        public PlayerModel PlayerModel { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<PlayerView>() != null)
            {
                PlayerService.Instance.GetPlayerModel().CoinsCollected += 1;
                AchievementService.Instance.GetAchievementController().CheckForCoinAchievement();
                //AchievementService.Instance.InvokeOnCoinAchievemt();
                GameManager.Instance.UpdateCoinsText(1);
                Debug.Log(GameManager.Instance);
                gameObject.SetActive(false);
            }
        }
    }
}