using System.Collections;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    /// <summary>
    /// player controller class
    /// this class handles all type of player movement
    /// </summary>
    public class PlayerController
    {
        #region Components
        private Rigidbody rigidbody;
        Vector3 forwardMove;
        Vector3 verticalMove;
        Vector3 horizontalMove;
        private int laneNumber = 1;
        Touch touch;
        public float xPos;
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
            CameraController.Instance.SetTarget(PlayerView.transform); 
        }

        //player will continuously move forward 
        public void ForwardMovement(float speed)
        {
            forwardMove = PlayerModel.Speed * Time.fixedDeltaTime * PlayerView.transform.forward;
            rigidbody.MovePosition(rigidbody.position + forwardMove);
        }
        
        //player will change lanes
        public void LaneChanger()
        {
            //Key Code COntrol the lane
            if (Input.GetKeyDown(KeyCode.D))
            {
                horizontalMove = PlayerModel.HorizontalMoveSpeed * Time.fixedDeltaTime * PlayerView.transform.right;
                rigidbody.MovePosition(rigidbody.position + horizontalMove);
                laneNumber++;
                if (laneNumber == 3)
                {
                    laneNumber = 2;
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                horizontalMove = PlayerModel.HorizontalMoveSpeed * Time.fixedDeltaTime * -PlayerView.transform.right;
                rigidbody.MovePosition(rigidbody.position + horizontalMove);
                laneNumber--;
                if (laneNumber == -1)
                {
                    laneNumber = 0;
                }
            }
        }

        //player jump
        public void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalMove = PlayerModel.JumpForce * Time.fixedDeltaTime * PlayerView.transform.up;
                rigidbody.MovePosition(rigidbody.position + verticalMove);
            }           
        }
    }
}