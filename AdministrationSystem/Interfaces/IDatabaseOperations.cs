namespace AdministrationSystem.Interfaces
{
    public interface IDatabaseOperations<T>
    {
        public T Get(string id);
        public List<T> GetAll();
        public string Add(T entity);
        public void Modify(string id,  T entity);
        public void Delete(string id);
    }
}
