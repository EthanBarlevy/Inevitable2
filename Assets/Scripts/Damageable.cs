using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] public float newtons;
    [Header ("Player Reductions")]
    [SerializeField] public float speed;
    [SerializeField] public float size;

	[Header("Value")]
	protected int value;
	[SerializeField] protected int min_value;
	[SerializeField] protected int max_value;
}
