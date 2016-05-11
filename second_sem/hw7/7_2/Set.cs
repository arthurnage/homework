using System;
using System.Collections;
using System.Collections.Generic;

namespace MyWorks
{
	public class Set<T>
	{
		private List<T> set;

		// constructor
		public Set()
		{
			set = new List<T>();
		}

		// adds an element to the set
		public void Add(T value) => set.Push(value);

		// removes an element from the set
		public void Remove(T value) => set.Remove(value);

		// checks is an element belongs to the set
		public bool IsBelong(T value) => set.IsBelong(value);

		// returns this set as list
		public List<T> GetList() => set;

		// returns the union of 2 sets
		public Set<T> Union(Set<T> anotherSet)
		{
			List<T> commonList = set;
			Set<T> resultSet = new Set<T>();
			foreach (T value in anotherSet.GetList())
			{
				if (!commonList.IsBelong(value))
				{
					commonList.Push(value);
				}
			}
			while (!commonList.IsEmpty())
			{
				resultSet.Add(commonList.Pop());
			}
			return resultSet;
		}

		// returns the intersection of sets
		public Set<T> Intersection(Set<T> anotherSet)
		{
			Set<T> resultSet = new Set<T>();
			foreach (T value in anotherSet.GetList())
			{
				if (IsBelong(value))
				{
					resultSet.Add(value);
				}
			}
			return resultSet;
		}
	}
}