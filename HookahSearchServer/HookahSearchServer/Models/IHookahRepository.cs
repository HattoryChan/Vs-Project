using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahSearchServer.Models
{
    public interface IHookahRepository
    {
        void Add(HookahItem item);
        IEnumerable<HookahItem> GetAll();
        HookahItem Find(string key);
        HookahItem Remove(string key);
        void Update(HookahItem item);
    }
}
