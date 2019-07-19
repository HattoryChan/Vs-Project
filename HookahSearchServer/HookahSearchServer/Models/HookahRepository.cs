using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace HookahSearchServer.Models
{
    public class HookahRepository : IHookahRepository
    {
        private static ConcurrentDictionary<string, HookahItem> _todos =
            new ConcurrentDictionary<string, HookahItem>();

        public HookahRepository()
        {
            Add(new HookahItem { Name = "Item1" });

        }

        public IEnumerable<HookahItem> GetAll()
        {
            return _todos.Values;
        }

        public void Add(HookahItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todos[item.Key] = item;
        }

        public HookahItem Find(string key)
        {
            HookahItem item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        public HookahItem Remove(string key)
        {
            HookahItem item;
            _todos.TryRemove(key, out item);
            return item;
        }

        public void Update(HookahItem item)
        {
            _todos[item.Key] = item;
        }
    }
}
