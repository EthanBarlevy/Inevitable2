using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour, IDataPersistance
{
	protected GameData data;
	public void LoadData(GameData data)
	{
		this.data = data;
	}

	public void SaveData(ref GameData data)
	{
		
	}
}
