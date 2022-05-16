namespace BLL.Interfaces.Generic
{
    public interface IObjectLoader<T>
    {
        public IList<T> Load();
    }
}
