using System;
using Xunit;
using DataStructures;

namespace DataStructures.Tests
{
    public class MinHeapTest
    {
        private MinHeap<int> _minHeap;

        public MinHeapTest() 
        {
            _minHeap = new MinHeap<int>();
        }

        [Fact]
        public void TestManipulation() 
        {
            _minHeap.Add(5);
            Assert.True(_minHeap.Size == 1, $"Heap should have size 1 but is {_minHeap.Size} instead.");
            Assert.True(_minHeap.Peek() == 5, $"Peek should return 5 but got {_minHeap.Peek()} instead.");

            _minHeap.Add(7);
            Assert.True(_minHeap.Size == 2, $"Heap should have size 2 but is {_minHeap.Size} instead.");
            Assert.True(_minHeap.Peek() == 5, $"Peek should return 5 but got {_minHeap.Peek()} instead.");

            _minHeap.Add(3);
            Assert.True(_minHeap.Size == 3, $"Heap should have size 3 but is {_minHeap.Size} instead.");
            Assert.True(_minHeap.Peek() == 3, $"Peek should return 3 but got {_minHeap.Peek()} instead.");

            var item = _minHeap.Pop();
            Assert.True(_minHeap.Size == 2, $"Heap should have size 2 but is {_minHeap.Size} instead.");
            Assert.True(item == 3, $"Peek should return 3 but got {item} instead.");

            item = _minHeap.Pop();
            Assert.True(_minHeap.Size == 1, $"Heap should have size 1 but is {_minHeap.Size} instead.");
            Assert.True(item == 5, $"Peek should return 5 but got {item} instead.");

            item = _minHeap.Pop();
            Assert.True(_minHeap.Size == 0, $"Heap should have size 0 but is {_minHeap.Size} instead.");
            Assert.True(item == 7, $"Peek should return 7 but got {item} instead.");

        }

    }

}