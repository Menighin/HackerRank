using System;

namespace DataStructures 
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private int _capacity = 32;
        public int Size { get; private set; }
        private T[] _heap = new T[32];

        private int GetLeftChildIndex(int index) { return 2 * index + 1; }
        private int GetRightChildIndex(int index) { return 2 * index + 2; }
        private int GetParentIndex(int index) { return (index - 1) / 2; }

        private bool HasLeftChild(int index) { return GetLeftChildIndex(index) < Size; }
        private bool HasRightChild(int index) { return GetRightChildIndex(index) < Size; }
        private bool HasParent(int index) { return GetParentIndex(index) >= 0; }

        private T LeftChild(int index) { return _heap[GetLeftChildIndex(index)]; }
        private T RightChild(int index) { return _heap[GetRightChildIndex(index)]; }
        private T Parent(int index) { return _heap[GetParentIndex(index)]; }
        private T GetItem(int index) { return _heap[index]; }

        private void Swap(int i, int j) 
        {
            T temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;
        }

		/// <summary>
		/// Ensures the heap has capacity by resizing it if it needs
		/// </summary>
        private void EnsureCapacity() 
        {
            if (Size == _capacity) 
            {
                _capacity *= 2;
                Array.Resize(ref _heap, _capacity);
            }
        }

        private void HeapifyUp() 
        {
            var currIndex = Size - 1;
            while (HasParent(currIndex) && Parent(currIndex).CompareTo(_heap[currIndex]) > 0) 
            {
                this.Swap(currIndex, this.GetParentIndex(currIndex));
                currIndex = this.GetParentIndex(currIndex);
            }
        }

        private void HeapifyDown()
        {
            var currIndex = 0;
            while (this.HasLeftChild(currIndex))
            {
                var smallerChildIndex = this.GetLeftChildIndex(currIndex);
                if (this.HasRightChild(currIndex) && this.RightChild(currIndex).CompareTo(this.LeftChild(currIndex)) < 0)
                    smallerChildIndex = this.GetRightChildIndex(currIndex);
                
                if (GetItem(currIndex).CompareTo(GetItem(smallerChildIndex)) < 0)
                    break;

                this.Swap(currIndex, smallerChildIndex);
                currIndex = smallerChildIndex;
            }
        }

        public MinHeap()
        {
            this.Size = 0;
        }

        public T Peek() 
        {
            if (Size == 0) throw new ArgumentOutOfRangeException("Heap is empty");
            return this.GetItem(0);
        }

        public T Pop() 
        {
            if (Size == 0) throw new ArgumentOutOfRangeException("Heap is empty");
            var item = this.GetItem(0);

            _heap[0] = this.GetItem(Size - 1);
            Size--;
            this.HeapifyDown();

            return item;
        }

        public void Add(T item) 
        {
            this.EnsureCapacity();
            _heap[Size] = item;
            Size++;
            this.HeapifyUp();
        }

    }
}