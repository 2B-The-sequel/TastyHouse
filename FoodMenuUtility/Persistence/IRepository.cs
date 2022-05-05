using System.Collections.Generic;

namespace FoodMenuUtility.Persistence
{
    public interface IRepository<T> where T : IPersistable
    {
        public T Create(string text);

        public T Retrieve(int id);

        public List<T> RetrieveAll();

        public T Update(int id);

        public void Delete(int id);
    }
}