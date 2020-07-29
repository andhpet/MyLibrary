using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLibrary
{
    public class MyDictionary<TKey, TValue> : IMyDictionary<TKey, TValue>
    {
        Dictionary<TKey, List<TValue>> _internal;

        public MyDictionary()
        {
            _internal = new Dictionary<TKey, List<TValue>>();
        }

        public MyDictionary(TKey key, TValue value)
        {
            _internal = new Dictionary<TKey, List<TValue>>();
            List<TValue> simpleList = new List<TValue>() { value };

            _internal.Add(key, simpleList);
        }

        public void Add(TKey key, TValue value)
        {
            if (_internal.ContainsKey(key))
            {
                _internal[key].Add(value);

            }
            else
            {
                List<TValue> simpleList = new List<TValue>() { value };
                _internal.Add(key, simpleList);
            }
        }

        public bool Remove(TKey key, TValue value)
        {
            if (_internal.ContainsKey(key))
            {
                return _internal[key].Remove(value);
            }
            else
            {
                throw new Exception("'value' does not exist");
            }
        }

        public bool RemoveAll(TKey key)
        {
            if (_internal.ContainsKey(key))
            {
                return _internal.Remove(key);
            }
            else
            {
                throw new Exception("'key' does not exist");
            }
        }

        public List<TValue> Get(TKey key)
        {
            //TODO: read about Type checking for null
            if (key == null)
                throw new ArgumentNullException();

            if (_internal.ContainsKey(key))
            {
                _internal[key].Sort();
                return _internal[key];
            }
            else
            {
                //TODO: Read about defoult value of type
                return null;
            }

        }

        public List<TValue> IntersectValues(TKey key1, TKey key2)
        {
            if (_internal.ContainsKey(key1) && _internal.ContainsKey(key2))
            {
                List<TValue> list1 = _internal[key1];
                List<TValue> list2 = _internal[key2];
                List<TValue> result = new List<TValue>();

                for (int i = 0; i < _internal[key1].Count; i++)
                {
                    if (list2.Contains(list1[i]))
                    {
                        result.Add(list1[i]);
                    }
                }
                return result;
            }
            else
            {
                throw new Exception("'key1' or 'key2' does not exist");
            }
        }


        public MyDictionary<TKey, TValue> Intersect(IMyDictionary<TKey, TValue> other)
        {
            var result = new MyDictionary<TKey, TValue>();
            foreach (var key in _internal.Keys)
            {
                var lst = other.Get(key);
                if ( lst != null)
                {
                    foreach (var val in lst) 
                    {
                        result.Add(key, val);
                    }
                }
            }
            return result;
        }

        public MyDictionary<TKey, TValue> Union(MyDictionary<TKey, TValue> multiDict)
        {
            MyDictionary<TKey, TValue> result = new MyDictionary<TKey, TValue>();
            foreach (var keyValuePair in this)
            {
                result.Add(keyValuePair.Key, keyValuePair.Value);
            }
            foreach (var keyValuePair in multiDict)
            {
                result.Add(keyValuePair.Key, keyValuePair.Value);
            }
            return result;
        }

        protected IEnumerable<KeyValuePair<TKey, TValue>> Flatten()
        {
            foreach (var key in _internal.Keys)
            {
                foreach (var value in _internal[key])
                {
                    yield return new KeyValuePair<TKey, TValue>(key, value);
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return this.Flatten().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _internal.GetEnumerator();
        }
    }

    public static class MyExtentions
    {
        public static MyDictionary<TKey, TValue> Union<TKey, TValue>(this MyDictionary<TKey, TValue> first, MyDictionary<TKey, TValue> second)
        {
            MyDictionary<TKey, TValue> result = new MyDictionary<TKey, TValue>();
            foreach (var keyValuePair in first)
            {
                result.Add(keyValuePair.Key, keyValuePair.Value);
            }
            foreach (var keyValuePair in second)
            {
                result.Add(keyValuePair.Key, keyValuePair.Value);
            }
            return result;
        }

        public static MyDictionary<TKey, TValue> Intersect<TKey, TValue>(this MyDictionary<TKey, TValue> first, MyDictionary<TKey, TValue> second)
        {
            throw new NotImplementedException();
        }
    }
}
