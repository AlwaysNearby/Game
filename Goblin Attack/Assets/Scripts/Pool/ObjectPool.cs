using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pool
{
    public abstract class ObjectPool<T, TU>: MonoBehaviour,  IObjectPool<T, TU> where T : MonoBehaviour where TU : Enum
    {
        private class PoolElement
        {
            public bool IsActive;
            public T Instance;
            public TU InstanceType;

            public PoolElement(T instance, TU instanceType)
            {
                Instance = instance;
                InstanceType = instanceType;
            }

        }
        [SerializeField] private int _baseCapacity;
        [SerializeField] private int _additionCapacity;

        private List<PoolElement> _pool;

        private void Awake()
        {
            _pool = new List<PoolElement>();
        }

        private void Start()
        {
            Array allTypes = Enum.GetValues(typeof(TU));

            foreach (var typeTemplate in allTypes) 
            {
                SpawnElements(_baseCapacity, (TU)typeTemplate);
            }
            
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

        public T GetElement(TU elementType)
        {
            PoolElement poolElement = _pool.FirstOrDefault(e => e.IsActive == false && elementType.Equals(e.InstanceType));
            
            if (poolElement != null)
            {
                poolElement.IsActive = true;
                poolElement.Instance.gameObject.SetActive(true);
                poolElement.Instance.transform.parent = null;
                return poolElement.Instance;
            }
            else
            {
                SpawnElements(_additionCapacity, elementType);
                return GetElement(elementType);
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

        protected abstract T CreateElement(TU elementType);
        
        private void SpawnElements(int count, TU elementType)
        {
            for (int i = 0; i < count; i++)
            {
                T instance = CreateElement(elementType);
                instance.gameObject.SetActive(false);
                PoolElement poolElement = new PoolElement(instance, elementType);
                poolElement.IsActive = false;
                instance.transform.SetParent(transform);
                _pool.Add(poolElement);
            }
        }
    }
    
}