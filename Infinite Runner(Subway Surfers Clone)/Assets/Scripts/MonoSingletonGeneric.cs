using System.Collections;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    public class MonoSingletonGeneric<T> : MonoBehaviour where T:MonoSingletonGeneric<T>
    {
        private static T instance;
        public static T Instance { get{ return instance; } }

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = (T)this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this);
            }
        }
    }
}