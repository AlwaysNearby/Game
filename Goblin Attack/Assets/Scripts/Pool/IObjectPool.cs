using UnityEngine;

namespace Pool
{
    public interface IObjectPool<T> where T : MonoBehaviour
    {
        public T GetElement();
    }
}