using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private CircleCollider2D player_collider;
    private Rigidbody2D player_body;

	[SerializeField] private PlayerData player_data;
    [SerializeField] private float current_speed = -1;
    [SerializeField] private float current_size = -1;

    public PlayerInput player_actions;
    private InputAction ascend;
    private bool ascending = false;
    void Start()
    {
        player_collider = GetComponent<CircleCollider2D>();
        player_body = GetComponent<Rigidbody2D>();

        // take from the data
        current_speed = player_data.initial_speed;
        current_size = player_data.initial_size;

        // set the initial velocity
        player_body.velocity = Vector2.right * current_speed;
    }

	private void Awake()
	{
		player_actions = new PlayerInput();
	}

	private void OnEnable()
    {
        ascend = player_actions.Player.Ascend;
        ascend.Enable();
        ascend.performed += Ascend;
        ascend.canceled += Descend;
    }

	private void OnDisable()
	{
		ascend.Disable();
	}

	void Update()
    {
        current_speed = player_body.velocity.x;
		player_body.AddForce(Vector2.right * current_speed);

        if (ascending) 
        {
			player_body.velocity = new Vector2(player_body.velocity.x, 5.0f);
            
		}
        else 
        {
			player_body.velocity = new Vector2(player_body.velocity.x, -5.0f);
		}
	}

    private void Ascend(InputAction.CallbackContext context)
    {
        ascending = true;
	}
	private void Descend(InputAction.CallbackContext context)
	{
		ascending = false;
	}
}
