using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Shop : MonoBehaviour, IDataPersistance
{
	[Header("ShopMaximums")]
	[SerializeField] private float speed_max;
	[SerializeField] private float boost_speed_max;
	[SerializeField] private float frequency_max;
	[SerializeField] private float ice_amount_max;

	[Header("CurrentPurchases")]
	public int rokxz;
	public float speed;
	public float boost_speed;
	public float boost_frequency;
	public float fire_time;
	public float fire_frequency;
	public float ice_amount;
	public float ice_frequency;


	public void BuySpeed()
	{
		if(speed < speed_max) 
		{ 
			speed++;
		}
    }

	public void BuyBoostSpeed()
	{
		if (speed < boost_speed_max)
		{
			boost_speed++;
		}
	}

	public void BuyBoostFrequency()
	{
		if (boost_frequency < frequency_max)
		{ 
			boost_frequency++;
		}
	}

	public void BuyFireTime()
	{
		fire_time++;
	}

	public void BuyFireFrequency()
	{
		if (fire_frequency < frequency_max)
		{ 
			fire_frequency++;
		}
	}

	public void BuyIceAmount()
	{
		if (ice_amount < ice_amount_max)
		{ 
			ice_amount++;
		}
	}

	public void BuyIceFrequency()
	{
		if (ice_frequency < frequency_max)
		{ 
			ice_frequency++;
		}
	}

	public void LoadData(GameData data)
	{
		this.rokxz = data.rokxz;
		this.speed = data.speed;
		this.boost_speed = data.boost_speed;
		this.boost_frequency = data.boost_frequency;
		this.fire_time = data.fire_time;
		this.fire_frequency = data.fire_frequency;
		this.ice_amount = data.ice_amount;
		this.ice_frequency = data.ice_frequency;
	}

	public void SaveData(ref GameData data)
	{
		data.rokxz = this.rokxz;
		data.speed = this.speed;
		data.boost_speed = this.boost_speed;
		data.boost_frequency = this.boost_frequency;
		data.fire_time = this.fire_time;
		data.fire_frequency = this.fire_frequency;
		data.ice_amount = this.ice_amount;
		data.ice_frequency = this.ice_frequency;
	}
}
