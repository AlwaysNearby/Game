namespace Pool
{
    public interface IObjectPool<T, TU>
    {
        public T GetElement(TU elementType);
    }
}