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
		public QueueItem<T> Tail;
		public int Count { get; private set; }

		public bool IsEmpty { get { return Head == null; } }

		public void Enqueue(T value)
		{
			if (IsEmpty)
				Tail = Head = new QueueItem<T> { Value = value, Next = null, Previous = null };
			else
			{
				var item = new QueueItem<T> { Value = value, Next = null, Previous = Tail };
				Tail.Next = item;
				Tail = item;
			}
			Count++;
		}

		public T Dequeue()
		{
			if (Head == null) throw new InvalidOperationException();
			var result = Head.Value;
			Head = Head.Next;
			if (Head == null)
				Tail = null;
			Count--;
			return result;
		}
	}

	public class QueueItem<T>
	{
		public T Value { get; set; }
		public QueueItem<T> Next { get; set; }

		public QueueItem<T> Previous { get; set; }
	}
}
