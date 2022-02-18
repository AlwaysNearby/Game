using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pool
{
    public abstract class ObjectPool<T, U>: MonoBehaviour,  IObjectPool<T, U> where T : MonoBehaviour where U : Enum
    {
        public class PoolElement
        {
            public bool IsActive;
            public T Instance;
            public U Type;

            public PoolElement(T instance, U type)
            {
                Instance = instance;
                Type = type;
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
            Array allTypes = Enum.GetValues(typeof(U));

            foreach (var typeTemplate in allTypes) 
            {
                SpawnElements(_baseCapacity, (U)typeTemplate);
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

        public T GetTemplate(U typeTemplate)
        {
            PoolElement poolElement = _pool.FirstOrDefault(e => e.IsActive == false && typeTemplate.Equals(e.Type));
            
            if (poolElement != null)
            {
                poolElement.IsActive = true;
                poolElement.Instance.gameObject.SetActive(true);
                poolElement.Instance.transform.parent = null;
                return poolElement.Instance;
            }
            else
            {
                SpawnElements(_additionCapacity, typeTemplate);
                return GetTemplate(typeTemplate);
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

        protected abstract T CreateElement(U typeTemplate);
        
        private void SpawnElements(int count, U typeTemplate)
        {
            for (int i = 0; i < count; i++)
            {
                T instance = CreateElement(typeTemplate);
                instance.gameObject.SetActive(false);
                PoolElement poolElement = new PoolElement(instance, typeTemplate);
                poolElement.IsActive = false;
                instance.transform.SetParent(transform);
                _pool.Add(poolElement);
            }
        }
    }
    
}