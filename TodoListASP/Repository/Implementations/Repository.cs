using System.Text.Json;
using TodoListASP.Models;

namespace TodoListASP.Repository.Implementations
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly List<T> _entities;
        private int _nextId;

        protected Repository() //protected 'cause it's abstract
        {
            try
            {
                string json = File.ReadAllText(GetFilePath());
                //null, cause fight might not exist 
                List<T>? entities = JsonSerializer.Deserialize<List<T>>(json);

                if (entities == null)
                    throw new InvalidDataException("Failed to deserialize entities from json"); // we go to catch part then
                _entities = entities;
            }
            catch (Exception)
            {
                _entities = new List<T>();
            }

            int maxId = 0;
            foreach (var entity in _entities)
            {
                if(entity.Id > maxId) maxId = entity.Id;
            }

            _nextId = maxId+1;
        }
        public void Create(T entity)
        {
          entity.Id = _nextId++;
            _entities.Add(entity);
            SaveChanges();
        }

        public void Delete(int id)
        {
            T entity;
            for(int i =0; i < _entities.Count; ++i)
            {
                entity = _entities[i];
                if (entity.Id == id)
                {
                    _entities.RemoveAt(i);
                    break;
                }
            }

            SaveChanges();
        }

        public List<T> GetAll() => _entities;

        public T? GetById(int id)
        {
            foreach (var entity in _entities)
            {
                if (entity.Id == id) return entity;
            }
            return null;
        }

        public void SaveChanges()
        {
            string json = JsonSerializer.Serialize(_entities);
            File.WriteAllText(GetFilePath(), json);
        }

        protected abstract string GetFilePath();
    }
}
