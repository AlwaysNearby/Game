using Enemies;

namespace Pool {
    public class GoblinPool : ObjectPool<Goblin>
    {
		protected override Goblin CreateElement(Goblin template)
		{
			return Instantiate(template);
		}
    }
}
