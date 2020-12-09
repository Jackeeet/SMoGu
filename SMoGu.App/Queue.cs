using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMoGu.App
{
	/// <summary>
	/// класс реализующий очередь
	/// </summary>
	/// <typeparam name="T"> тип данных, которые хранит очередь </typeparam>
	public class Queue<T> : IEnumerable<T>
	{
		/// <summary>
		/// Метод возвращающий перечислитель
		/// </summary>
		/// <returns> лениво возвращает все значения очереди </returns>
		public IEnumerator<T> GetEnumerator()
		{
			var current = Head;
			while (current != null)
			{
				yield return current.Value;
				current = current.Next;
			}
		}
		/// <summary>
		/// обертка над GetEnumerator()
		/// </summary>
		/// <returns> возвращает перечисление значений очереди </returns>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		/// <summary>
		/// указатель на первый элемент очереди
		/// </summary>
		public QueueItem<T> Head { get; private set; }
		/// <summary>
		/// указатель на последний элемент очереди
		/// </summary>
		public QueueItem<T> Tail;
		/// <summary>
		/// количество элементов в очереди
		/// </summary>
		public int Count { get; private set; }
		/// <summary>
		/// проверка на содержание очередью элементов
		/// </summary>
		public bool IsEmpty { get { return Head == null; } }
		/// <summary>
		/// метод "кладущий" в очередь значение
		/// </summary>
		/// <param name="value"> знаачение, которое нужно положить в очередь </param>
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
		/// <summary>
		/// метод извлекающий первый элемент из очереди
		/// </summary>
		/// <returns> возвращает извлекаеый элемент </returns>
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
	/// <summary>
	/// вспомогательный класс, хранящий данные об элементе очереди
	/// </summary>
	/// <typeparam name="T"> тип данных, хранящихся в очереди </typeparam>
	public class QueueItem<T>
	{
		/// <summary>
		/// значение элемента очереди
		/// </summary>
		public T Value { get; set; }
		/// <summary>
		/// следующее за текущим элементом значение
		/// </summary>
		public QueueItem<T> Next { get; set; }
		/// <summary>
		/// предыдущее текущему элементу значение
		/// </summary>
		public QueueItem<T> Previous { get; set; }
	}
}
