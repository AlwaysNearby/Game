using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pool
{
    public abstract class ObjectPool<T>: MonoBehaviour, IObjectPool<T> where T : MonoBehaviour
    {
        private class PoolElement
        {
            public bool IsActive;
            public T Instance;

            public PoolElement(T instance)
            {
                Instance = instance;
            }

        }
        
        [SerializeField] private int _baseCapacity;
        [SerializeField] private int _additionCapacity;

        private List<PoolElement> _pool;

        public void Init()
        {
            _pool = new List<PoolElement>();
            SpawnElements(_baseCapacity);
        }

        public T GetElement()
        {
            PoolElement poolElement = _pool.FirstOrDefault(e => e.IsActive == false);
            
            if (poolElement != null)
            {
                poolElement.IsActive = true;
                poolElement.Instance.gameObject.SetActive(true);
                poolElement.Instance.transform.parent = null;
                return poolElement.Instance;
            }
            else
            {
                SpawnElements(_additionCapacity);
                return GetElement();
            }
        }

        public void ReturnToPool(T element)
        {
            PoolElement poolElement = _pool.FirstOrDefault(e => e.Instance = element);
            
            if (poolElement != null)
            {
                poolElement.IsActive = false;
                poolElement.Instance.gameObject.transform.SetParent(transform);
                poolElement.Instance.gameObject.SetActive(false);
            }
        }

        protected abstract T CreateElement();
        
        private void SpawnElements(int count)
        {
            for (int i = 0; i < count; i++)
            {
                T instance = CreateElement();
                instance.gameObject.SetActive(false);
                PoolElement poolElement = new PoolElement(instance);
                poolElement.IsActive = false;
                instance.transform.SetParent(transform);
                _pool.Add(poolElement);
            }
        }
    }
    

 
}