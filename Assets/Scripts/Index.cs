using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Index : MonoBehaviour
{
	Room m_Room;
	Table m_Table = null;

	// Use this for initialization
	void Start () {
		m_Room = new Room ();

		m_Table.Deal ();
		m_Table.Flop ();
		m_Table.Turn ();
		m_Table.River ();
	}

	public void AddTable () {
		m_Table = m_Room.AddTable ();
	}

	public void AddPlayer () {
		if (m_Table != null)
			m_Table.AddPlayer (new Player ());
	}

	public void Deal () {
		if (m_Table != null)
			m_Table.ShowPlayerPoker ();
	}

	public void Flop () {
		if (m_Table != null)
			m_Table.ShowPublicPoker ();
	}

	public void Turn () {
		if (m_Table != null)
			m_Table.ShowPublicPoker ();
	}

	public void River () {
		if (m_Table != null)
			m_Table.ShowPublicPoker ();
	}
}
