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
        private PlayerModel currentplayerModel;
        #endregion

        #region Components
        private Transform pos;
        private Vector3 lastPosition;
        #endregion

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            CreatePlayer();
            //CalculateDistance();
        }

        private void Update()
        {
            //CalculateDistance();
        }

        public PlayerController CreatePlayer()
        {
            PlayerScriptableObject player = playerScriptableObject;
            PlayerView = playerScriptableObject.PlayerView;
            PlayerModel playerModel = new PlayerModel(playerScriptableObject);
            currentplayerModel = playerModel;
            playerController = new PlayerController(playerModel, PlayerView);
            return playerController;
        }

        //returns player model to caller
        public PlayerModel GetPlayerModel()
        {
            return currentplayerModel;
        }

        //return player position to the caller
        public Transform PlayerPos()
        {
            pos = this.transform;
            return pos;
        }

        //player controller reference
        public void SetPlayerController(PlayerController _playerController)
        {
            playerController = _playerController;
        }

        //calculates distance in meters
        public void CalculateDistance()
        {
            float distance = Vector3.Distance(lastPosition, transform.position);
            lastPosition = transform.position;
            GameManager.Instance.DisplayDistanceText();
        }
    }
}