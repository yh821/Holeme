using System.Collections;
using System.Collections.Generic;

public class Card
{
	//S(黑桃,spade),C(草花,club),H(红桃,heart),D(方片,diamond)
	public static readonly string[] CardName = new string[]{
		"SA","S2","S3","S4","S5","S6","S7","S8","S9","S10","SJ","SQ","SK",
		"HA","H2","H3","H4","H5","H6","H7","H8","H9","H10","HJ","HQ","HK",
		"CA","C2","C3","C4","C5","C6","C7","C8","C9","C10","CJ","CQ","CK",
		"DA","D2","D3","D4","D5","D6","D7","D8","D9","D10","DJ","DQ","DK"
	};

	public int id;
	public string name;
	public string image;
	public Entity owner{ get; private set; }

	public Card(int id, Entity owner){
		this.id = id;
		this.owner = owner;
		name = CardName [id];
		image = "card_" + this.name;
	}

	public void Hold(Entity actor){
		this.owner = actor;
	}
}
