using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.DataStructureAlgorithm.HashTable
{


    public static class CSharpHashTableShow
    {
        public static void Show()
        {
            var data = new string[] { "8", "9", "5", "3", "6", "0", "2", "7", "1" };
            var hashTable = new CSharpHashTable(11, new LinearHashCollectionSolver());
            foreach (string s in data)
            {
                hashTable.Insert(s);
            }

            hashTable.PrintAll();
            Console.ReadKey();
        }

    }

    public class CSharpHashTable
    {
        private static int _length;
        private static string[] _data;
        private IHashCollectionSolver _solver;
        private static int count;

        public CSharpHashTable(int length, IHashCollectionSolver solver)
        {
            //if 0 then 3
            _length = length == 0 ? 3 : length;
            _data = new string[_length];
            _solver = solver;
        }

        //Calculate hash by key
        static int SimpleHash(string key)
        {
            int total = key.ToCharArray().Sum(a => a);
            return total % _length;
        }



        #region insert, delete, search

        public void Insert(string key)
        {
            var hashValue = SimpleHash(key);
            if (count == _length)
            {
                Console.WriteLine("hash table is full");
                //TODO: Extend space dynamically
                return;
            }

            if (_data[hashValue] == null)
            {
                _data[hashValue] = key;
                count++;
                return;
            }

            while (true)
            {
                //fixing conflict by getting next offset
                hashValue = _solver.GetNextOffset(_length, hashValue);
                if (_data[hashValue] == null)
                {
                    _data[hashValue] = key;
                    count++;
                    return;
                }
            }
        }

        public void Delete(string key)
        {
            var hashValue = SimpleHash(key);
            _data[hashValue] = null;
            count--;
        }

        public string Find(string key)
        {
            var hashValue = SimpleHash(key);
            if (_data[hashValue] == null)
            {
                Console.WriteLine(key + "is not in table");
            }

            return _data[hashValue];
        }

        #endregion



        public void PrintAll()
        {
            for (int i = 0; i < _length; i++)
            {
                Console.WriteLine(String.Format("bucket {0}，value is {1}", i, _data[i] ?? "none"));
            }

        }



    }
}
