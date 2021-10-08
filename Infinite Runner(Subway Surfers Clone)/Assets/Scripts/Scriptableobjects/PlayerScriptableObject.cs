using UnityEditor;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    [CreateAssetMenu(fileName ="PlayerScriptableObject",menuName ="ScriptableObjects/NewPlayerScriptableObject")]
    public class PlayerScriptableObject : ScriptableObject
    {
        public PlayerView PlayerView;
        //public PlayerType PlayerType;
        public float Speed;
        public float JumpForce;
    }
}