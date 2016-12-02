using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class MruList: IEnumerable<string>
    {
        private readonly List<string> list = new List<string>();
        private readonly int capacity;

        public int Count => list.Count;

        public MruList()
        {
            capacity = int.MaxValue;
        }

        public MruList(int capacity)
        {
            if(capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.capacity = capacity;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string this[int index] => list[index];

        public void Add(string item)
        {
            if (string.IsNullOrEmpty(item))
                throw new ArgumentException("Null or empty string", nameof(item));

            if (capacity == 0)
                return;

            list.Remove(item);
            EnsureCapacity();
            list.Insert(0, item);
        }

        private void EnsureCapacity()
        {
            if (list.Count == capacity)
                list.RemoveAt(capacity - 1);
        }
    }
}