using System.Collections;
using System.Collections.Generic;

public class Entity : object
{
	static int g_EntityID = 0;

	public int id { get; private set; }

	protected List<Card> m_OwnCards;

	public Entity() {
		this.id = g_EntityID++;
		m_OwnCards = new List<Card> ();
	}
		
	/// <summary>
	/// 拿牌
	/// </summary>
	/// <param name="card">Card.</param>
	public virtual void AddCard(Card card)
	{
		card.Hold (this);
		m_OwnCards.Add (card);
	}

	/// <summary>
	/// 出牌
	/// </summary>
	/// <param name="cardId">Card identifier.</param>
	public virtual Card DelCard(int index){
		Card card = null;
		if (index >= 0 && index < m_OwnCards.Count) {
			card = m_OwnCards[index];
			m_OwnCards.RemoveAt (index);
		}
		return card;
	}

	public virtual void ShowPoker () {
		foreach (var card in m_OwnCards) {
			UnityEngine.Debug.LogFormat ("Entity{0}:{1}",this.id,card.name);
		}
	}
}
