namespace DAL.Interfaces.Generics
{
    public interface IObjectManipulator<T> : IObjectLoader<T>
    {
        public void Create(T obj);
        public void Update(T obj);
    }
}
