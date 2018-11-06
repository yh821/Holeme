using System;
using System.Collections.Generic;

public class Pool<T> where T : Entity
{
	public int max { get; private set; }

	protected List<T> m_Pool;

	public Pool (int max) {
		this.max = max;
		m_Pool = new List<T> (max);
	}

	public virtual void AddItem (T t) {
		m_Pool.Add (t);
	}
}
