using System.Collections;
using System.Collections.Generic;

namespace MyLibrary
{
    public interface IMyDictionary<TKey, TValue> : IEnumerable
    {
        void Add(TKey key, TValue value);
        List<TValue> Get(TKey key);
        bool Remove(TKey key, TValue value);
        bool RemoveAll(TKey key);
    }
}
