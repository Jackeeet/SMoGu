using System;
using System.Collections.Generic;

namespace SMoGu.App
{
	/// <summary>
	/// Класс, реализующий очередь.
	/// </summary>
	/// <typeparam name="T"> Тип данных, которые хранит очередь. </typeparam>
	public class Queue<T> : IEnumerable<T>
	{
		/// <summary>
		/// Метод, возвращающий перечислитель.
		/// </summary>
		/// <returns> Лениво возвращает все значения очереди. </returns>
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
		/// Обертка над GetEnumerator().
		/// </summary>
		/// <returns> Возвращает перечисление значений очереди. </returns>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		/// <summary>
		/// Указатель на первый элемент очереди.
		/// </summary>
		public QueueItem<T> Head { get; private set; }
		/// <summary>
		/// Указатель на последний элемент очереди.
		/// </summary>
		public QueueItem<T> Tail;
		/// <summary>
		/// Количество элементов в очереди.
		/// </summary>
		public int Count { get; private set; }
		/// <summary>
		/// Проверка на содержание очередью элементов.
		/// </summary>
		public bool IsEmpty { get { return Head == null; } }
		/// <summary>
		/// Метод, "кладущий" в очередь значение.
		/// </summary>
		/// <param name="value"> Значение, которое нужно положить в очередь. </param>
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
		/// Метод, извлекающий первый элемент из очереди.
		/// </summary>
		/// <returns> Возвращает извлекаемый элемент. </returns>
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
	/// Вспомогательный класс, хранящий данные об элементе очереди.
	/// </summary>
	/// <typeparam name="T"> Тип данных, хранящихся в очереди. </typeparam>
	public class QueueItem<T>
	{
		/// <summary>
		/// Значение элемента очереди.
		/// </summary>
		public T Value { get; set; }
		/// <summary>
		/// Следующее за текущим элементом значение.
		/// </summary>
		public QueueItem<T> Next { get; set; }
		/// <summary>
		/// Предыдущее текущему элементу значение.
		/// </summary>
		public QueueItem<T> Previous { get; set; }
	}
}
