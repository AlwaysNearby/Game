using UnityEngine;

namespace Pool
{
    public interface IPoolElementGetter<T> where T : MonoBehaviour
    {
        public T GetElement();
    }
}