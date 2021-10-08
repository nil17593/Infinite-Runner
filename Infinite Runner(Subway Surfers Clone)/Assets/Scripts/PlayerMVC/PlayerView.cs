using System.Collections;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    public class PlayerView : MonoBehaviour
    {
        #region Reference of other Scripts
        private PlayerController playerController;
        #endregion

        private float horizontalInput;
        private float verticalInput;
        private float speed, movement;
        private float input;
        Vector3 horizontalMovement;


        private void Update()
        {
            MovementInputs();
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            playerController.ForwardMovement(playerController.PlayerModel.Speed);
            playerController.PlayerMovement();
            playerController.Jump();

        }

        private void MovementInputs()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }

        public void SetPlayerController(PlayerController _playerController)
        {
            playerController = _playerController;
        }
    }
}