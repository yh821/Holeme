using System;
using System.Collections;
using System.Collections.Generic;

public class Table : Entity
{
	public const int CARD_MAX = 52;
	public const int PLAYER_MAX = 9;

	private Card[] m_Cards = new Card[CARD_MAX];

	protected Dealer m_Dealer;
	protected List<Player> m_Players;

	public Table(){
		m_Players = new List<Player>();
		m_Dealer = new Dealer();
		m_Dealer.Join (this);
		for (int i = 0; i < CARD_MAX; i++) {
			m_Cards[i] = new Card (i, m_Dealer);
			m_Dealer.AddCard (m_Cards[i]);
		}
	}

	public Player AddPlayer(Player player)
	{
		if (m_Players.Count < PLAYER_MAX) {
			m_Players.Add (player);
			player.Join (this);
			return player;
		} else {
			throw new ArgumentException ("玩家最多只能9位!");
		}
	}

	public Player RemovePlayer(int playerId)
	{
		var player = m_Players.Find (e => e.id == playerId);
		if (player != null)
			m_Players.Remove (player);
		return player;
	}

	public void Deal()
	{
		if (m_Players.Count >= 2) {
			m_Dealer.Shuffle ();
			for (int i = 0; i < 2; i++) {
				for (int j = 0; j < m_Players.Count; j++) {
					m_Dealer.Deal (m_Players[j]);
				}
			}
		}
	}

	public void Flop()
	{
		for (int i = 0; i < 3; i++) {
			m_Dealer.Deal (this);
		}
	}

	public void Turn()
	{
		m_Dealer.Deal (this);
	}

	public void River()
	{
		m_Dealer.Deal (this);
	}

	public void ShowPublicPoker(){
		ShowPoker ();
	}

	public void ShowPlayerPoker(){
		foreach (var player in m_Players) {
			player.ShowPoker ();
		}
	}
}
