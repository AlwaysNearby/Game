using System;
using Enemies;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Factories
{
    public enum GoblinType
    {
        Melee = 0,
        Ranged = 0,
    }
    
    public class GoblinFactory : IFactoryGoblin<GoblinType>
    {
        private DiContainer _diContainer;

        private Goblin _meleeTemplate, _rangedTemplate;
        
        public GoblinFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public void Create(GoblinType type, Vector3 at)
        {
            switch (type)
            {
                case GoblinType.Melee:
                    MeleeGoblin meleeGoblin = _diContainer.InstantiatePrefabForComponent<MeleeGoblin>(_meleeTemplate);
                    meleeGoblin.Init(at);
                    break;
                default:
                    throw new Exception();
            }   
        }

        public void Load()
        {
            _meleeTemplate = Resources.Load<Goblin>("Goblins/Melee Goblin");
        }
    }
}