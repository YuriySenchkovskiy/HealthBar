using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Scriptes.Utils.ObjectPool
{
    public class PoolItem : MonoBehaviour
    {
        [SerializeField] private UnityEvent _restart;

        private int _id;
        private Pool _pool;
        
        public void Restart()
        {
            _restart?.Invoke();
        }
        
        public void Release()
        {
            _pool.Release(_id, this);
        }
        
        public void Retain(int id, Pool pool)
        {
            _id = id;
            _pool = pool;
        }
    }
}