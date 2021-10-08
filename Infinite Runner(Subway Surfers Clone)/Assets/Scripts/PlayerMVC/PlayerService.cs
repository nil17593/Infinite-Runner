using System.Collections;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    public class PlayerService:MonoSingletonGeneric<PlayerService>
    {
        #region Serialized fields
        [SerializeField] private PlayerScriptableObject playerScriptableObject;
        #endregion

        #region properties
        public PlayerScriptableObject PlayerSO { get; }
        public PlayerView PlayerView { get; private set; }
        #endregion

        #region References of other scripts
        private PlayerController playerController;
        private PlayerModel playerModel;
        #endregion

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            CreatePlayer();
        }

        public PlayerController CreatePlayer()
        {
            PlayerScriptableObject player = playerScriptableObject;
            PlayerView = playerScriptableObject.PlayerView;
            PlayerModel playerModel = new PlayerModel(playerScriptableObject);
            playerController = new PlayerController(playerModel, PlayerView);
            return playerController;
        }

        public void SetPlayerController(PlayerController _playerController)
        {
            playerController = _playerController;
        }

    }
}