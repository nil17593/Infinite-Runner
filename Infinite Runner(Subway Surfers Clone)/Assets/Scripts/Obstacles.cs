using System.Collections;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    /// <summary>
    /// this class handles the logic for
    /// if player collides with any obstacle 
    /// player will die
    /// </summary>
    public class Obstacles : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<PlayerView>() != null)
            {
                collision.gameObject.SetActive(false);
                GameManager.Instance.PlayerDiePanel();
            }
        }
    }
}