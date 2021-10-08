using System.Collections;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    public class PlayerModel
    {
        #region Properties
        public float Speed { get; } 
        public float JumpForce { get; }
        public PlayerType PlayerType { get; }
        #endregion

        #region referances of other classes
        private PlayerController playerController;
        #endregion
        public PlayerModel(PlayerScriptableObject playerScriptableObject)
        {
            //PlayerType = playerScriptableObject.PlayerType;
            Speed = playerScriptableObject.Speed;
            JumpForce = playerScriptableObject.JumpForce;
        }

        public void SetPlayerController(PlayerController _playerController)
        {
            playerController = _playerController;
        }
    }
}