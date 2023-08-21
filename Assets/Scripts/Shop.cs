using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Shop : MonoBehaviour, IDataPersistance
{
	[Header("ShopMaximums")]
	[SerializeField] private float speed_max;
	[SerializeField] private float size_max;
	[SerializeField] private float boost_speed_max;
	[SerializeField] private float frequency_max;
	[SerializeField] private float ice_amount_max;

	[SerializeField] private AudioSource audio_click;

	[Header("CurrentPurchases")]
	public int rokxz;
	public float speed;
	public float size;
	public float boost_speed;
	public float boost_frequency;
	public float fire_time;
	public float fire_frequency;
	public float ice_amount;
	public float ice_frequency;

	[Header("Prices")]
	public int speed_price;
	public int size_price;
	public int boost_speed_price;
	public int boost_frequency_price;
	public int fire_time_price;
	public int fire_frequency_price;
	public int ice_amount_price;
	public int ice_frequency_price;
	public void BuySpeed()
	{
		if(speed < speed_max && rokxz >= (int)Mathf.Pow(300, (speed / 2)))
		{
			rokxz -= (int)Mathf.Pow(30, (speed / 2));
			speed++;
		}
    }

	public void BuySize()
	{
		if (size < size_max && rokxz >= (int)Mathf.Pow(500, (size / 2)))
		{
			rokxz -= (int)Mathf.Pow(50, (size / 2));
			size += 0.3f;
		}
	}

	public void BuyBoostSpeed()
	{
		if (boost_speed < boost_speed_max && rokxz >= (int)Mathf.Pow(450, (boost_speed / 2)))
		{
			rokxz -= (int)Mathf.Pow(450, (boost_speed / 2));
			boost_speed += 0.5f;
		}
	}

	public void BuyBoostFrequency()
	{
		if (boost_frequency < frequency_max && rokxz >= (int)Mathf.Pow(1000, (boost_frequency / 2)))
		{
			rokxz -= (int)Mathf.Pow(100, ((boost_frequency + 2) / 2));
			boost_frequency += 0.01f;
		}
	}

	public void BuyFireTime()
	{
		if (rokxz >= (int)Mathf.Pow(30, (fire_time / 2)))
		{
			rokxz -= (int)Mathf.Pow(30, (fire_time / 2));
			fire_time += 0.5f;
		}
	}

	public void BuyFireFrequency()
	{
		if (fire_frequency < frequency_max && rokxz >= (int)Mathf.Pow(1000, (fire_frequency / 2)))
		{
			rokxz -= (int)Mathf.Pow(100, ((fire_frequency + 2) / 2));
			fire_frequency += 0.01f;
		}
	}

	public void BuyIceAmount()
	{
		if (ice_amount < ice_amount_max && rokxz >= (int)Mathf.Pow(800, (ice_amount / 2)))
		{
			rokxz -= (int)Mathf.Pow(80, (ice_amount / 2));
			ice_amount += 0.1f;
		}
	}

	public void BuyIceFrequency()
	{
		if (ice_frequency < frequency_max && rokxz >= (int)Mathf.Pow(1000, (ice_frequency / 2)))
		{
			rokxz -= (int)Mathf.Pow(100, ((ice_frequency + 2) / 2));
			ice_frequency += 0.01f;
		}
	}

	public void LoadData(GameData data)
	{
		this.rokxz = data.rokxz;
		this.speed = data.speed;
		this.size = data.size;
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
		data.size = this.size;
		data.boost_speed = this.boost_speed;
		data.boost_frequency = this.boost_frequency;
		data.fire_time = this.fire_time;
		data.fire_frequency = this.fire_frequency;
		data.ice_amount = this.ice_amount;
		data.ice_frequency = this.ice_frequency;
	}
}
