using System.Collections.Generic;
using System.Linq;
using ToDoApi.Models;

namespace ToDoApi.Repositories
{
    public class ToDoRepository
    {
        private static readonly List<ToDoItem> _items = new();
        private static int _idCounter = 0;

        public IEnumerable<ToDoItem> GetAll() => _items;

        public ToDoItem GetById(int id) => _items.FirstOrDefault(x => x.Id == id);

        public ToDoItem Add(string title)
        {
            var item = new ToDoItem { Id = _idCounter++, Title = title, Status = false };
            _items.Add(item);
            return item;
        }

        public bool Update(int id, bool status)
        {
            var item = GetById(id);
            if (item == null) return false;
            item.Status = status;
            return true;
        }

        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item == null) return false;
            _items.Remove(item);
            return true;
        }
    }
}
