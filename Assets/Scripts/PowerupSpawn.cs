using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawn : MonoBehaviour
{
	[SerializeField] GameObject[] powerups;

	// Start is called before the first frame update
	void Start()
    {
		//pick random from array and spawn at gameObject trasform
		Instantiate(powerups[Random.Range(0, powerups.Length)], transform.position, Quaternion.identity);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
