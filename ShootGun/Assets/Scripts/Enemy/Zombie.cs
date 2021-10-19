namespace Enemy
{
    public class Zombie : BaseEnemy
    {
        private void Update()
        {
            MoveAt(transform.forward);
        }
    }
}
