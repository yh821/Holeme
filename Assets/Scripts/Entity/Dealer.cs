using System;
using System.Collections.Generic;

public class Dealer : Actor
{
	/// <summary>
	/// 洗牌
	/// </summary>
	public void Shuffle(){
		for (int i = 0; i < Table.CARD_MAX; i++) {
			var rnd = UnityEngine.Random.Range (i, Table.CARD_MAX);
			var temp = m_OwnCards[rnd];
			m_OwnCards[rnd] = m_OwnCards[i];
			m_OwnCards[i] = temp;
		}
	}

	/// <summary>
	/// 发牌
	/// </summary>
	/// <param name="owner">Owner.</param>
	public void Deal(Entity owner){
		var card = DelCard (m_OwnCards.Count - 1);
		owner.AddCard (card);
	}
}
