using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePowerup : Powerup
{
	public void OnTriggerEnter2D(Collider2D collision)
	{
		FindObjectOfType<Player>().AddInvincibility(data.fire_time);
	}
}
