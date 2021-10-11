using System.Collections;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    public class CameraController : MonoSingletonGeneric<CameraController>
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float smoothFactor;
        //private Transform playerLastPos;
        private PlayerView player;

        protected override void Awake()
        {
            base.Awake();
        }
        void FollowPlayer()
        {
            //target = player.GetPlayerTransform();
            if (target != null)
            {
                Vector3 targetPosition = target.position + offset;
                Vector3 smoothedposition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
                transform.position = targetPosition;
            }
        }

        private void LateUpdate()
        {
            FollowPlayer();
        }

        public void SetTarget(Transform target)
        {
            if (target != null)
            {
                this.target = target;
            }
            Debug.Log(target);
        }
    }
}