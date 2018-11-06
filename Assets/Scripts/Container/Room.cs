using System;
using System.Collections.Generic;

public class Room {
	static int g_RoomID = 0;
	public const int TABLE_MAX = 6;

	public int id{ get; private set; }

	protected List<Table> m_Tables;

	public Room()
	{
		this.id = g_RoomID++;
		m_Tables = new List<Table> ();
	}

	public Table AddTable(){
		if (m_Tables.Count < TABLE_MAX) {
			Table table = new Table ();
			m_Tables.Add (table);
			return table;
		} else {
			throw new ArgumentException ("每个房间最多6张桌子！");
		}
	}
}
