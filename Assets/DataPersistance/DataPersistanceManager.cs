using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
	[Header("File Storeage Config")]
	[SerializeField] private string file_name;

	private GameData gameData;
	private List<IDataPersistance> data_persistance_objects;
	private FileDataHandler data_handler;

    public static DataPersistanceManager instance { get; private set; }

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("Multiple Data Persistance Managers found in scene.");
		}
		instance = this; 
	}

	private void Start()
	{
		this.data_handler = new FileDataHandler(Application.persistentDataPath, file_name);
		this.data_persistance_objects = FindAllDataPersistanceObjects();
		LoadGame();
	}

	public void NewGame()
	{ 
		this.gameData = new GameData();
	}
	public void LoadGame()
	{
		this.gameData = data_handler.Load();

		if (this.gameData == null)
		{
			Debug.Log("No save data found. Creating new save data");
			NewGame();
		}

		foreach (IDataPersistance data_persistance in this.data_persistance_objects)
		{
			data_persistance.LoadData(gameData);
		}
	}
	public void SaveGame()
	{
		foreach (IDataPersistance data_persistance in this.data_persistance_objects)
		{
			data_persistance.SaveData(ref gameData);
		}

		data_handler.Save(gameData);
	}

	private void OnApplicationQuit()
	{
		SaveGame();
	}

	private List<IDataPersistance> FindAllDataPersistanceObjects()
	{ 
		IEnumerable<IDataPersistance> data_objects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
		return new List<IDataPersistance>(data_objects);
	}
}
