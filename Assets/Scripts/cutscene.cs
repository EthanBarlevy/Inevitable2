using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene : MonoBehaviour
{
	// Start is called before the first frame update

	[SerializeField] private float time_to_wait;
    //private GameObject UI;
	//[SerializeField] private AudioSource sfx;
	[SerializeField] private AudioSource UI_sfx;
	[SerializeField] private GameObject manager;
	void Start()
    {
		//UI = GameObject.Find("EndOfRunUIPlanet");
		
	}

    // Update is called once per frame
    void Update()
    {
		if (time_to_wait > 0)
		{
			time_to_wait -= Time.deltaTime;
		}
		else
		{
			//UI.SetActive(true);
			manager.GetComponent<Manager>().SetToDarkTextEnd();
			UI_sfx.Play();
		}

	}
}
