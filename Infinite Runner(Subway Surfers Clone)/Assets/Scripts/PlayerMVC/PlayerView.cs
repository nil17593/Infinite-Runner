using System.Collections;
using UnityEngine;
using TMPro;

namespace IMPLIEDSOULS.InfiniteRunner
{
    public class PlayerView : MonoBehaviour
    {
        #region Reference of other Scripts
        private PlayerController playerController;
        #endregion

        #region Properties
        public PlayerModel PlayerModel { get; }
        #endregion

        #region Serialized fields
        [SerializeField] private Transform player;
        #endregion

        private void FixedUpdate()
        {
            playerController.ForwardMovement(playerController.PlayerModel.Speed);
            playerController.Jump();
            playerController.LaneChanger();
            playerController.SpeedBooster();
        }

        private void Update()
        {
            if (transform.position.y < -3)
            {
                Die();
            }

        }

        public void SetPlayerController(PlayerController _playerController)
        {
            playerController = _playerController;
        }

        //player will die after falling from ground
        void Die()
        {
            this.gameObject.SetActive(false);
            GameManager.Instance.PlayerDiePanel();
            playerController.DeSubscribeEvent();
        }
    }
}