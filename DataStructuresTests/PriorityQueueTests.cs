using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace DataStructuresTests
{
    public class PriorityQueueTests
    {
        [Fact]
        public void TestQueueingOnSamePriorityValueType()
        {
            var priorityQueue = new PriorityQueue<string, int>();

            for (char i = 'a'; i <= 'z'; i++)
            {
                priorityQueue.Insert(i.ToString(), 1);
            }

            for (char i = 'a'; i <= 'z'; i++)
            {
                Assert.Equal(i.ToString(), priorityQueue.Pop());
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => priorityQueue.Pop());
        }

        [Fact]
        public void TestDifferentPrioritiesValueType()
        {
            var priorityQueue = new PriorityQueue<string, int>();

            int priority = 30;
            for (char i = 'a'; i <= 'z'; i++)
            {
                priorityQueue.Insert(i.ToString(), priority--);
            }

            for (char i = 'z'; i >= 'a'; i--)
            {
                Assert.Equal(i.ToString(), priorityQueue.Pop());
            }
        }

        [Fact]
        public void TestPeek()
        {
            var priorityQueue = new PriorityQueue<string, int>();

            priorityQueue.Insert("key", 0);

            Assert.Equal("key", priorityQueue.Peek());
        }

        [Fact]
        public void TestCount()
        {
            var priorityQueue = new PriorityQueue<string, int>();

            priorityQueue.Insert("key", 0);
            priorityQueue.Insert("key", 0);
            priorityQueue.Insert("key", 0);
            priorityQueue.Insert("key", 1);
            priorityQueue.Insert("key", 1);
            priorityQueue.Insert("key", 2);
            priorityQueue.Insert("key", 3);
            priorityQueue.Insert("key", 4);
            priorityQueue.Insert("key", 4);
            priorityQueue.Insert("key", 4);

            Assert.Equal(10, priorityQueue.Count());
        }

        [Fact]
        public void TestCountPriority()
        {
            var priorityQueue = new PriorityQueue<string, int>();

            priorityQueue.Insert("key", 0);
            priorityQueue.Insert("key", 0);
            priorityQueue.Insert("key", 0);
            priorityQueue.Insert("key", 1);
            priorityQueue.Insert("key", 1);

            Assert.Equal(3, priorityQueue.Count(0));
            Assert.Equal(2, priorityQueue.Count(1));
        }

        [Fact]
        public void TestQueueingOnSamePriorityReferenceType()
        {            
            var priorityQueue = new PriorityQueue<string, Distance>();

            for (char i = 'a'; i <= 'z'; i++)
            {
                priorityQueue.Insert(i.ToString(), new Distance(1));
            }

            for (char i = 'a'; i <= 'z'; i++)
            {
                Assert.Equal(i.ToString(), priorityQueue.Pop());
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => priorityQueue.Pop());
        }

        [Fact]
        public void TestDifferentPrioritiesReferenceType()
        {
            var priorityQueue = new PriorityQueue<string, Distance>();

            float distance = 30;
            for (char i = 'a'; i <= 'z'; i++)
            {
                priorityQueue.Insert(i.ToString(), new Distance(distance--));
            }

            for (char i = 'z'; i >= 'a'; i--)
            {
                Assert.Equal(i.ToString(), priorityQueue.Pop());
            }
        }

        private class Distance : IComparable<Distance>
        {
            private float _distance;

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
