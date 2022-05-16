namespace DAL.Interfaces.Generics
{
    public interface IObjectLoader<T>
    {
        public IList<T> Load();
    }
}
