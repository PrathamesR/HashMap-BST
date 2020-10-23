using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable_BST
{

    public struct KeyValue<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
    }

    class HashTable<K,V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>> []hashTable;

        public HashTable(int size)
        {
            this.size = size;
            hashTable = new LinkedList<KeyValue<K,V>>[size];
        }

        public int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = hashTable[position];
            if (linkedList != null)
            {
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }
            }

            if(typeof(V)==typeof(int))
            {
                return (V)(object)-1;
            }
            else
                return default(V);
        }

        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);

            int listSize;
            if (hashTable[position] == null)
                listSize = 0;
            else
                listSize = hashTable[position].Count;

            for (int j = 0; j < listSize; j++)
            {
                if (hashTable[position].ElementAt(j).Key.Equals(key))
                {
                    hashTable[position].AddLast(new KeyValue<K, V>() { Key = key, Value = value });
                    hashTable[position].RemoveFirst();
                    return;
                }
            }

            if (hashTable[position] == null)
                hashTable[position] = new LinkedList<KeyValue<K, V>>();

            hashTable[position].AddLast(new KeyValue<K, V>() { Key = key, Value = value });
        }

        public void DisplayHashMap()
        {
            foreach(LinkedList<KeyValue<K,V>> list in hashTable)
            {
                if (list == null)
                    continue;
                foreach(KeyValue<K,V> pair in list)
                {
                    Console.WriteLine(pair.Key + ": " + pair.Value);
                }
            }
        }

        public void Remove(K key, V value)
        {
            int position = GetArrayPosition(key);
            KeyValue<K, V> item=default(KeyValue<K,V>);
            foreach(KeyValue<K,V> pair in hashTable[position])
            {
                if(pair.Value.Equals(value))
                {
                    item = pair;
                    break;
                }
            }
            hashTable[position].Remove(item);
        }

        public bool IsEmpty()
        {
            foreach(var list in hashTable)
            {
                if(list!=null)
                {
                    return false;
                }
            }

            return true;
        }
    }

    class Count
    {
        string message;

        public Count(string msg)
        {
            this.message = msg;
        }

        public void FindOccurances()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(message.Length);

            string[] words = message.Split(' ');
            
            foreach(string word in words)
            {
                if (hashTable.Get(word) == -1)
                    hashTable.Add(word, 1);
                else
                    hashTable.Add(word, hashTable.Get(word) + 1);
            }

            hashTable.DisplayHashMap();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";

            new Count(input).FindOccurances();

            Console.Read();
        }
    }
}
