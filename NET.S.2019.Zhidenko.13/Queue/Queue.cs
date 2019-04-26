using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] _array;

        public Queue()
        {
            Count = 0;
        }

        public Queue(IEnumerable<T> collection)
        {
            foreach (T element in collection)
            {
                Enqueue(element);
            }
        }

        public int Count { get; private set; }

        /// <summary> Put element to the queue.</summary>
        /// <param name="element"> Element to enqueue. </param>
        public void Enqueue(T element)
        {
            T[] newArray = new T[Count + 1];
            newArray[Count] = element;

            for (int i = 0; i < Count; i++)
            {
                newArray[i] = _array[i];
            }

            _array = newArray;
            Count++;
        }

        /// <summary> Get and remove the first element from the queue.</summary>
        /// <returns> First element in the queue.</returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new ArgumentException();
            }

            T[] newArray = new T[Count - 1];
            T elementToReturn = _array[0];

            for (int i = 0; i < Count - 1; i++)
            {
                newArray[i] = _array[i + 1];
            }

            Count--;
            _array = newArray;
            return elementToReturn;
        }

        /// <summary> Remove all elements from the queue.</summary>
        public void Clear()
        {
            _array = new T[0];
            Count = 0;
        }

        /// <summary> Get enumerator for queue.</summary>
        /// <returns> Enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        /// <summary> Get enumerator for queue.</summary>
        /// <returns> Enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class QueueEnumerator : IEnumerator<T>
        {
            private T[] _array;
            private int _currentIndex;

            public QueueEnumerator(Queue<T> queue)
            {
                _array = queue._array;
                _currentIndex = -1;
            }

            public T Current
            {
                get
                {
                    if (_currentIndex == -1)
                    {
                        throw new InvalidOperationException();
                    }

                    return _array[_currentIndex];
                }
            }

            object IEnumerator.Current => Current;

            /// <summary> Dispose enumerator.</summary>
            public void Dispose()
            {
                _array = null;
            }

            /// <summary> Move pointer to next element in queue.</summary>
            /// <returns> Ability to get next element.</returns>
            public bool MoveNext()
            {
                if (_currentIndex < _array.Length - 1)
                {
                    _currentIndex++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary> Set pointer at the beginning of queue.</summary>
            public void Reset()
            {
                _currentIndex = -1;
            }
        }
    }
}
