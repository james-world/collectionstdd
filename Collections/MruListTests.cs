using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Collections
{
    public class MruListTests
    {
        private MruList mruList;

        [SetUp]
        public void Setup()
        {
            mruList = new MruList();
        }

        [Test]
        public void NewListIsEmpty()
        {
            Assert.IsEmpty(mruList);
            Assert.AreEqual(0, mruList.Count);
        }

        [Test]
        public void AddSingleItemToList()
        {
            mruList.Add("Item");
            CollectionAssert.AreEqual(new [] { "Item" }, mruList);
        }

        [Test]
        public void AddSecondDifferentItemToList()
        {
            mruList.Add("Item1");
            mruList.Add("Item2");
            CollectionAssert.AreEqual(new [] {"Item2", "Item1"}, mruList);
        }

        [Test]
        public void AddExistingItemMovesItToMostRecent()
        {
            mruList.Add("Item1");
            mruList.Add("Item2");
            mruList.Add("Item1");
            CollectionAssert.AreEqual(new[] { "Item1", "Item2" }, mruList);
        }

        [Test]
        public void NullInsertFails()
        {
            var ex = Assert.Throws<ArgumentException>(() => mruList.Add(null));
            Assert.AreEqual("item", ex.ParamName);
            Assert.AreEqual("Null or empty string\r\nParameter name: item", ex.Message);
        }

        [Test]
        public void EmptyInsertFails()
        {
            var ex = Assert.Throws<ArgumentException>(() => mruList.Add(""));
            Assert.AreEqual("item", ex.ParamName);
            Assert.AreEqual("Null or empty string\r\nParameter name: item", ex.Message);
        }

        [Test]
        public void MruListWithCapacityZeroHoldsNoItems()
        {
            mruList = new MruList(0) {"Item1", "Item2", "Item3", "Item4"};
            CollectionAssert.IsEmpty(mruList);
        }

        [Test]
        public void AccessNthItem()
        {
            mruList = new MruList { "Item1", "Item2", "Item3", "Item4" };
            Assert.AreEqual("Item2", mruList[2]);
        }

        [Test]
        public void MruListWithCapacityOneHoldsMostRecentItem()
        {
            mruList = new MruList(1) {"Item1", "Item2"};
            CollectionAssert.AreEqual(new[] { "Item2" }, mruList);
        }

        [Test]
        public void MruListAtCapacityDropsLeastRecentlyUsedItems()
        {
            mruList = new MruList(3) {"Item1", "Item2", "Item3", "Item4"};
            CollectionAssert.AreEqual(new[] { "Item4", "Item3", "Item2" }, mruList);
        }

        [Test]
        public void InvalidIndexShouldThrowOutOfRangeException()
        {
            // ReSharper disable once UnusedVariable
            Assert.Throws<ArgumentOutOfRangeException>(() => { var _ = mruList[1]; });
        }
    }

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
