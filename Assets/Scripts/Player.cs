using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private CircleCollider2D player_collider;
    private Rigidbody2D player_body;

	[SerializeField] private float speed;
    [SerializeField] private float size;

    void Start()
    {
        player_collider = GetComponent<CircleCollider2D>();
        player_body = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }
}
