using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[System.Serializable]
public class GameData
{
	public int rokxz;
	public float speed;
	public float boost_speed;
	public float boost_frequency;
	public float fire_time;
	public float fire_frequency;
	public float ice_amount;
	public float ice_frequency;
	public BigInteger score;

	public GameData()
	{ 
		this.rokxz = 0;
		this.speed = 0;
		this.boost_speed = 0;
		this.boost_frequency = 0;
		this.fire_time = 0;
		this.fire_frequency = 0;
		this.ice_amount = 0;
		this.ice_frequency = 0;
		this.score = new BigInteger();
	}
}
