using UnityEditor;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    /// <summary>
    /// scriptable object for player
    /// </summary>
    [CreateAssetMenu(fileName ="PlayerScriptableObject",menuName ="ScriptableObjects/NewPlayerScriptableObject")]
    public class PlayerScriptableObject : ScriptableObject
    {
        public PlayerView PlayerView;
        //public PlayerType PlayerType;
        public float Speed;
        public float HorizontalMovSpeed;
        public float JumpForce;
    }
}