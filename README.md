# MyLibrary
To study Interfaces

We need to implement a dictionary which can have many values (type V) associated with a key (type K). And all values of a given key are sorted. Here are some points to consider:
1. The collection should implement IEnumerable interface which returns IEnumerble<KeyValuePair<K,V>>. It means that each key should be paired with each of its values.
2. The collection should have Add(K, V), Get(K), Remove(K, V) and RemoveAll(K) methods.
3. The collection should have Union(), Intersect() methods.