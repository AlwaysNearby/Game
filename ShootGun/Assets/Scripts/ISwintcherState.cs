using DefaultNamespace;
public interface ISwitcherState
{
   public void Switch<T>() where T : PlayerBaseState;
}
