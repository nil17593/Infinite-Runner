using System.Collections;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    public class PlayerController
    {
        #region Components
        private Rigidbody rigidbody;
        Vector3 forwardMove;
        Vector3 verticalMove;
        Vector3 horizontalMove;
        private float horizontalInput;
        private float verticalInput;
        #endregion

        #region Properties
        public PlayerModel PlayerModel { get; }
        public PlayerView PlayerView { get; }
        #endregion

        public PlayerController(PlayerModel playerModel, PlayerView playerPrefab)
        {
            PlayerModel = playerModel;
            PlayerView = GameObject.Instantiate<PlayerView>(playerPrefab);
            PlayerModel.SetPlayerController(this);
            PlayerView.SetPlayerController(this);
            rigidbody = PlayerView.GetComponent<Rigidbody>();
            //CameraController.Instance.SetTarget(PlayerView.transform); 
        }

        public void ForwardMovement(float speed)
        {
            forwardMove = PlayerModel.Speed * Time.fixedDeltaTime * PlayerView.transform.forward;
            rigidbody.MovePosition(rigidbody.position + forwardMove);

            //Vector3 mov = PlayerView.transform.position;
            //mov += forwardMove * speed * Time.deltaTime * PlayerView.transform.forward;
            //rigidbody.MovePosition(mov);
            //TankView.tankMovementVFX.Play();
            //PlayerService.Instance.GetPlayerPos(PlayerView.transform);
        }

        public void PlayerMovement()
        {
            horizontalMove = horizontalInput * PlayerModel.Speed * Time.fixedDeltaTime * PlayerView.transform.right;
            rigidbody.MovePosition(rigidbody.position + horizontalMove);
        }

        public void Jump()
        {
            verticalMove = verticalInput * PlayerModel.JumpForce * Time.fixedDeltaTime * PlayerView.transform.up;
            rigidbody.MovePosition(rigidbody.position + verticalMove);
        }
    }
}