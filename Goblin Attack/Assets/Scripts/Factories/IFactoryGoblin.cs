using System;
using UnityEngine;

namespace Factories
{
    public interface IFactoryGoblin<T> : IFactoryInitialization where T : Enum
    {
        public void Create(T type, Vector3 at);
    }
}