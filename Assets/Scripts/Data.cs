using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Data : MonoBehaviour
{
	TextMeshProUGUI tmp;
	Manager manager;
	[SerializeField] private types data;

	public enum types
	{ 
		speed, speed_cost,
		size, size_cost,
		boost_speed, boost_speed_cost,
		boost_frequency, boost_frequency_cost,
		fire_time, fire_time_cost,
		fire_frequency, fire_frequency_cost,
		ice_amount, ice_amount_cost,
		ice_frequency, ice_frequency_cost
	}
	void Start()
    {
		tmp = GetComponent<TextMeshProUGUI>();
		manager = FindObjectOfType<Manager>();

	}

    void Update()
    {
		string owo = "";
		switch (data)
		{ 
			case types.speed:
				owo = manager.GetData().speed + "";
				break; 
			case types.speed_cost:
				owo = (int)Mathf.Pow(3, (manager.GetData().speed / 2)) + "";
				break;
			case types.size:
				owo = manager.GetData().size + "";
				break;
			case types.size_cost:
				owo = (int)Mathf.Pow(50, (manager.GetData().size / 2)) + "";
				break;
			case types.boost_speed:
				owo = manager.GetData().boost_speed + "";
				break;
			case types.boost_speed_cost:
				owo = (int)Mathf.Pow(45, (manager.GetData().boost_speed / 2)) + "";
				break;
			case types.boost_frequency:
				owo = manager.GetData().boost_frequency + "";
				break;
			case types.boost_frequency_cost:
				owo = (int)Mathf.Pow(100, ((manager.GetData().boost_frequency + 2) / 2)) + "";
				break;
			case types.fire_time:
				owo = manager.GetData().fire_time + "";
				break;
			case types.fire_time_cost:
				owo = (int)Mathf.Pow(30, (manager.GetData().fire_time / 2)) + "";
				break;
			case types.fire_frequency:
				owo = manager.GetData().fire_frequency + "";
				break;
			case types.fire_frequency_cost:
				owo = (int)Mathf.Pow(100, ((manager.GetData().fire_frequency + 2) / 2)) + "";
				break;
			case types.ice_amount:
				owo = manager.GetData().ice_amount + "";
				break;
			case types.ice_amount_cost:
				owo = (int)Mathf.Pow(80, (manager.GetData().ice_amount / 2)) + "";
				break;
			case types.ice_frequency:
				owo = manager.GetData().ice_frequency + "";
				break;
			case types.ice_frequency_cost:
				owo = (int)Mathf.Pow(100, ((manager.GetData().ice_frequency + 2) / 2)) + "";
				break;
		}
		tmp.SetText(owo);
    }
}
