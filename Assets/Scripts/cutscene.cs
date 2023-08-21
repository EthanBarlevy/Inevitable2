using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene : MonoBehaviour
{
	// Start is called before the first frame update

	[SerializeField] private float time_to_wait;
    //private GameObject UI;
	[SerializeField] public AudioSource sfx;
	[SerializeField] private AudioSource UI_sfx;
	private GameObject manager;
	bool is_cutscene = true;
	void Start()
    {
		//UI = GameObject.Find("EndOfRunUIPlanet");
		manager = GameObject.Find("GameManager");

	}

    // Update is called once per frame
    void Update()
    {
		if (time_to_wait > 0)
		{
			time_to_wait -= Time.deltaTime;
		}
		if(time_to_wait<0 && is_cutscene)
		{
			//UI.SetActive(true);
			is_cutscene = false;
			manager.GetComponent<Manager>().SetToDarkTextEnd();
			UI_sfx.Play();
		}
		else
				{ }

	}

	private void OnDestroy()
	{
		//sfx.Stop();
	}
}
