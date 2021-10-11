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
        private Vector3 forwardMove;
        private Vector3 verticalMove;
        private Vector3 horizontalMove;
        #endregion

        #region integers and floats
        private int laneNumber = 1;
        private float distance;
        public float xPos;
        private float boostSpeed = 100f;
        #endregion

        #region Properties
        public PlayerModel PlayerModel { get; }
        public PlayerView PlayerView { get; }
        #endregion

        #region Bools
        private bool isBoost=false;
        #endregion

        public PlayerController(PlayerModel playerModel, PlayerView playerPrefab)
        {
            PlayerModel = playerModel;
            PlayerView = GameObject.Instantiate<PlayerView>(playerPrefab);
            PlayerModel.SetPlayerController(this);
            PlayerView.SetPlayerController(this);
            rigidbody = PlayerView.GetComponent<Rigidbody>();
            CameraController.Instance.SetTarget(PlayerView.transform);
            SubscribeEvent();//subscribe event
        }

        //player will continuously move forward 
        public void ForwardMovement(float speed)
        {
            if(!isBoost)
            forwardMove = PlayerModel.Speed * Time.fixedDeltaTime * PlayerView.transform.forward;
            rigidbody.MovePosition(rigidbody.position + forwardMove);
            AchievementService.Instance.InvokeOnRunAchievemt();
        }

        //player will change lanes
        public void LaneChanger()
        {
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

        public IEnumerator SpeedBooster()
        {
            if (PlayerService.Instance.GetPlayerModel().CoinsCollected == 20)
            {
                isBoost = true;
                forwardMove = PlayerModel.Speed*boostSpeed * Time.fixedDeltaTime * PlayerView.transform.up;
                rigidbody.MovePosition(rigidbody.position + forwardMove);
                yield return new WaitForSeconds(10f);
                isBoost = false;
                ForwardMovement(PlayerModel.Speed);
            }
        }

        //update coins counter
        private void UpdateCoinsCollected()
        {
            //PlayerModel.CoinsCollected += 1;
            AchievementService.Instance.GetAchievementController().CheckForCoinAchievement();
        }

        private void SubscribeEvent()
        {
            AchievementService.Instance.OnRunAchievement += UpdateCoinsCollected;
        }

        public void DeSubscribeEvent()
        {
            AchievementService.Instance.OnRunAchievement -= UpdateCoinsCollected;
        }
    }
}