namespace DAL.Interfaces.Generic
{
    public interface IObjectLoader<T>
    {
        public IList<T> Load();
    }
}
