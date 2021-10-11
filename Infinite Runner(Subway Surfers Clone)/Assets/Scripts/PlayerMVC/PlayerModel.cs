using System.Collections;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    /// <summary>
    /// player model class
    /// holds all the player model properties
    /// </summary>
    public class PlayerModel
    {
        #region Properties
        public float Speed { get; } 
        public float HorizontalMoveSpeed { get; }
        public float JumpForce { get; }
        public PlayerType PlayerType { get; }
        public int CoinsCollected { get; set; }
        public float PlayerRunCount { get; set; }
        #endregion

        #region referances of other classes
        private PlayerController playerController;
        #endregion

        public PlayerModel(PlayerScriptableObject playerScriptableObject)
        {
            //PlayerType = playerScriptableObject.PlayerType;
            Speed = playerScriptableObject.Speed;
            JumpForce = playerScriptableObject.JumpForce;
            HorizontalMoveSpeed = playerScriptableObject.HorizontalMovSpeed;
            CoinsCollected = 0;
            PlayerRunCount = 0f;
        }

        public void SetPlayerController(PlayerController _playerController)
        {
            playerController = _playerController;
        }
    }
}