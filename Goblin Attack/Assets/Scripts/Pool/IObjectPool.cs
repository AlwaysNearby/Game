using System;
using UnityEngine;

namespace Pool
{
    public interface IObjectPool<T, U> where T : MonoBehaviour where U : Enum
    {
        public T GetTemplate(U typeTemplate);
    }
}