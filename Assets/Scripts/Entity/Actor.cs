using System.Collections;
using System.Collections.Generic;

public class Actor : Entity
{
	protected Table m_Table;

	/// <summary>
	/// 加入
	/// </summary>
	/// <param name="table">Table.</param>
	public void Join(Table table){
		m_Table = table;
	}
}
