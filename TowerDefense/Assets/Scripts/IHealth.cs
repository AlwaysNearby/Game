using System;

public interface IHealth
{
    event Action OnDeath;
    event Action OnHit;
    
    void Decrease(float damage);
    
}
