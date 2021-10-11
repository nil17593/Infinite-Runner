using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    public class GroundSpawner : MonoSingletonGeneric<GroundSpawner>
    {
        #region Serialized fields
        [SerializeField] private GameObject[] groundTiles;
        [SerializeField] private float posOnZ=0f;
        [SerializeField] private float tileLength=60f;
        [SerializeField] private int amtOftilesOnScreen=3;
        #endregion

        #region Transforms
        private Transform playerTransform;
        #endregion

        #region private fields
        private GameObject temp;
        #endregion

        #region Lists
        private List<GameObject> tilesList;
        #endregion


        protected override void Awake()
        {
            base.Awake();
        }

        void Start()
        {
            tilesList = new List<GameObject>();
            //playerTransform = gameObject.GetComponent<PlayerView>().transform;
            //playerTransform = PlayerService.Instance.PlayerPos();
            playerTransform = GameObject.FindObjectOfType<PlayerView>().transform;
            for(int i = 0; i < amtOftilesOnScreen; i++)
            {
                SpawnTile();
            }
        }

        private void Update()
        {
            if (playerTransform.transform.position.z-70 > (posOnZ - amtOftilesOnScreen * tileLength))
            {
                SpawnTile();
                DeleteTile();
            }
        }

        public void SpawnTile(int prefabIndex = -1)
        {
            temp = Instantiate(groundTiles[0]) as GameObject;
            temp.transform.SetParent(transform);
            temp.transform.position = Vector3.forward * posOnZ;
            posOnZ += tileLength;
            tilesList.Add(temp);
            //nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        }

        private void DeleteTile()
        {
            Destroy(tilesList[0]);
            tilesList.RemoveAt(0); 
        }

        public void TileLastPos()
        {

        }
        //public void ChangeTilePos()
        //{
        //    temp.transform.position = nextSpawnPoint;
        //    nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        //    for (int i = 0; i < temp.transform.GetChild(2).transform.childCount; i++)
        //    {
        //        temp.transform.GetChild(2).transform.GetChild(i).gameObject.SetActive(true);
        //    }
        //}
    }
}
