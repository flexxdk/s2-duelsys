namespace DAL.Interfaces.Generic
{
    public interface IObjectManipulator<T> : IObjectLoader<T>
    {
        public int Create(T obj);
        public int Update(T obj);
    }
}
