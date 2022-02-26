using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pool
{
    public abstract class ObjectPool<T>: MonoBehaviour,  IObjectPool<T> where T : MonoBehaviour
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

        private void Awake()
        {
            _pool = new List<PoolElement>();
        }

        private void OnValidate()
        {
            if (_baseCapacity <= 16)
            {
                _baseCapacity = 16;
            }

            if (_additionCapacity <= 16)
            {
                _additionCapacity = 16;
            }
        }

        public T GetElement(T template)
        {
            PoolElement poolElement = _pool.FirstOrDefault(e => e.IsActive == false && e.Instance.GetType() == template.GetType());
            
            if (poolElement != null)
            {
                poolElement.IsActive = true;
                poolElement.Instance.gameObject.SetActive(true);
                poolElement.Instance.transform.parent = null;
                return poolElement.Instance;
            }
            else
            {
                SpawnElements(_additionCapacity, template);
                return GetElement(template);
            }
        }

        public void ReturnPool(T element)
        {
            PoolElement poolElement = _pool.FirstOrDefault(e => e.Instance = element);
            
            if (poolElement != null)
            {
                poolElement.IsActive = false;
                poolElement.Instance.gameObject.transform.SetParent(transform);
                poolElement.Instance.gameObject.SetActive(false);
            }
        }

        protected abstract T CreateElement(T template);
        
        private void SpawnElements(int count, T template)
        {
            for (int i = 0; i < count; i++)
            {
                T instance = CreateElement(template);
                instance.gameObject.SetActive(false);
                PoolElement poolElement = new PoolElement(instance);
                poolElement.IsActive = false;
                instance.transform.SetParent(transform);
                _pool.Add(poolElement);
            }
        }
    }
    
}