using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometTrail : MonoBehaviour
{
	//particle effect
	TrailRenderer trail;
	Transform parent_transform;

	// Start is called before the first frame update
	void Start()
    {
		trail = GetComponent<TrailRenderer>();
		parent_transform = GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
		trail.startWidth = parent_transform.localScale.x+.4f;
		//trail.widthMultiplier = parent_transform.localScale.x;
		
	}
}
