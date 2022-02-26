namespace Pool
{
    public interface IObjectPool<T>
    {
        public T GetElement(T template);

        public void ReturnPool(T element);
    }
}