using System;
using System.Collections.Generic;
using Xunit;

namespace DataStructuresTests
{
    public class PriorityQueueTests
    {
        private const string _item1 = "item1";
        private const string _item2 = "item2";
        private const string _item3 = "item3";

        [Fact]
        public void Pop_ShouldWork()
        {
            var priorityQueue = new PriorityQueue<string, int>();

            priorityQueue.Insert(_item1, 0);

            Assert.Equal(_item1, priorityQueue.Pop());
        }

        [Fact]
        public void Pop_ShouldFail()
        {
            var priorityQueue = new PriorityQueue<string, int>();

            Assert.Throws<ArgumentOutOfRangeException>(() => priorityQueue.Pop());
        }

        [Fact]
        public void Peek_ShouldWork()
        {
            var priorityQueue = new PriorityQueue<string, int>();

            priorityQueue.Insert(_item1, 0);

            Assert.Equal(_item1, priorityQueue.Peek());
        }

        [Fact]
        public void Peek_ShouldFail()
        {
            var priorityQueue = new PriorityQueue<string, int>();

            Assert.Throws<ArgumentOutOfRangeException>(() => priorityQueue.Peek());
        }

        [Fact]
        public void Count_ShouldWork()
        {
            var priorityQueue = new PriorityQueue<string, int>();

            Assert.Equal(0, priorityQueue.Count());

            priorityQueue.Insert(_item1, 0);
            priorityQueue.Insert(_item2, 1);
            priorityQueue.Insert(_item3, 1);

            Assert.Equal(3, priorityQueue.Count());
        }

        [Fact]
        public void CountByPriority_ShouldWork()
        {
            var priorityQueue = new PriorityQueue<string, int>();

            priorityQueue.Insert(_item1, 0);
            priorityQueue.Insert(_item2, 1);
            priorityQueue.Insert(_item3, 1);

            Assert.Equal(1, priorityQueue.CountByPriority(0));
            Assert.Equal(2, priorityQueue.CountByPriority(1));
        }

        [Fact]
        public void CountByPriority_ShouldFail()
        {
            var priorityQueue = new PriorityQueue<string, int>();

            priorityQueue.Insert(_item1, 0);

            Assert.Throws<KeyNotFoundException>(() => priorityQueue.CountByPriority(1));
        }

        [Fact]
        public void Clear_ShouldWork()
        {
            var priorityQueue = new PriorityQueue<string, int>();

            priorityQueue.Insert(_item1, 0);

            priorityQueue.Clear();

            Assert.Equal(0, priorityQueue.Count());
        }

        [Fact]
        public void Queueing_SamePriority_ValueType()
        {
            var priorityQueue = new PriorityQueue<string, int>();

            priorityQueue.Insert(_item1, 0);
            priorityQueue.Insert(_item2, 0);
            priorityQueue.Insert(_item3, 0);

            Assert.Equal(_item1, priorityQueue.Pop());
            Assert.Equal(_item2, priorityQueue.Pop());
            Assert.Equal(_item3, priorityQueue.Pop());
        }

        [Fact]
        public void Queueing_SamePriority_ReferenceType()
        {
            var priorityQueue = new PriorityQueue<string, Distance>();

            priorityQueue.Insert(_item1, new Distance(0f));
            priorityQueue.Insert(_item2, new Distance(0f));
            priorityQueue.Insert(_item3, new Distance(0f));

            Assert.Equal(_item1, priorityQueue.Pop());
            Assert.Equal(_item2, priorityQueue.Pop());
            Assert.Equal(_item3, priorityQueue.Pop());
        }

        [Fact]
        public void Queueing_DifferentPriority_ValueType()
        {
            var priorityQueue = new PriorityQueue<string, int>();

            priorityQueue.Insert(_item2, 10);
            priorityQueue.Insert(_item3, 20);
            priorityQueue.Insert(_item1, 9);

            Assert.Equal(_item1, priorityQueue.Pop());
            Assert.Equal(_item2, priorityQueue.Pop());
            Assert.Equal(_item3, priorityQueue.Pop());
        }

        [Fact]
        public void Queueing_DifferentPriority_ReferenceType()
        {
            var priorityQueue = new PriorityQueue<string, Distance>();

            priorityQueue.Insert(_item2, new Distance(10f));
            priorityQueue.Insert(_item3, new Distance(20f));
            priorityQueue.Insert(_item1, new Distance(9f));

            Assert.Equal(_item1, priorityQueue.Pop());
            Assert.Equal(_item2, priorityQueue.Pop());
            Assert.Equal(_item3, priorityQueue.Pop());
        }


        private class Distance : IComparable<Distance>
        {
            private readonly float _distance;

            public Distance(float distance)
            {
                _distance = distance;
            }

            public int CompareTo(Distance other)
            {
                if (_distance < other._distance)
                    return -1;

                if (_distance > other._distance)
                    return 1;

                return 0;
            }
        }
    }
}
