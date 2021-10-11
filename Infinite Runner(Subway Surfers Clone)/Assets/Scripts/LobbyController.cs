using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace IMPLIEDSOULS.InfiniteRunner
{

    public class LobbyController : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private string gameScene;

        private void Start()
        {
            startButton.onClick.AddListener(StartGame);
        }
        private void StartGame()
        {
            SceneManager.LoadScene(gameScene);
        }
    }
}