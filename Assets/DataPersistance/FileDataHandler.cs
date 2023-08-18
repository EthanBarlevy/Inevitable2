using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler 
{
	private string data_dir_path = "";
	private string data_file_name = "";

	public FileDataHandler(string data_dir_path, string data_file_name)
	{
		this.data_dir_path = data_dir_path;
		this.data_file_name = data_file_name;
	}

	public GameData Load()
	{
		string fullPath = Path.Combine(data_dir_path, data_file_name);
		GameData loadedData = null;
		if (File.Exists(fullPath)) 
		{
			try
			{
				string data_to_load = "";
				using (FileStream stream = new FileStream(fullPath, FileMode.Open))
				{
					using (StreamReader reader = new StreamReader(stream))
					{ 
						data_to_load = reader.ReadToEnd();
					}
				}

				loadedData = JsonUtility.FromJson<GameData>(data_to_load);
			}
			catch (Exception e)
			{
				Debug.LogError("Error occured while loading" + fullPath + "\n" + e);
			}
		}
		return loadedData;
	}

	public void Save(GameData data)
	{
		string fullPath = Path.Combine(data_dir_path, data_file_name);
		try 
		{ 
			Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

			string data_to_store = JsonUtility.ToJson(data, true);

			using (FileStream stream = new FileStream(fullPath, FileMode.Create))
			{
				using (StreamWriter writer = new StreamWriter(stream))
				{ 
					writer.Write(data_to_store);
				}
			}
		}
		catch (Exception e)
		{
			Debug.LogError("Error occured while saving" + fullPath + "\n" + e);
		}
	}
}
