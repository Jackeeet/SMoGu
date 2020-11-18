using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMoGu.App
{
    public class Queue<T> : IEnumerable<T>
    {
		public IEnumerator<T> GetEnumerator()
		{
			var current = Head;
			while (current != null)
			{
				yield return current.Value;
				current = current.Next;
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public QueueItem<T> Head { get; private set; }
		QueueItem<T> tail;

		public bool IsEmpty { get { return Head == null; } }

		public void Enqueue(T value)
		{
			if (IsEmpty)
				tail = Head = new QueueItem<T> { Value = value, Next = null };
			else
			{
				var item = new QueueItem<T> { Value = value, Next = null };
				tail.Next = item;
				tail = item;
			}
		}

		public T Dequeue()
		{
			if (Head == null) throw new InvalidOperationException();
			var result = Head.Value;
			Head = Head.Next;
			if (Head == null)
				tail = null;
			return result;
		}
    }

    public class QueueItem<T>
    {
        public T Value { get; set; }
        public QueueItem<T> Next { get; set; }
    }
}
