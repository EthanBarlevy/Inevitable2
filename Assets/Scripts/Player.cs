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
    private SpriteRenderer player_sprite;

	[SerializeField] private PlayerData player_data;
    [SerializeField] private Camera main_camera;
    [SerializeField] private float current_speed = -1;
    [SerializeField] private float current_size = -1;
    [SerializeField] private int camera_distance = 0;

    public PlayerInput player_actions;
    private InputAction ascend;
    private bool ascending = false;

    void Start()
    {
        player_collider = GetComponent<CircleCollider2D>();
        player_body = GetComponent<Rigidbody2D>();
        player_sprite = GetComponent<SpriteRenderer>();

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
		// woosh effect if speed is above some threshold
        current_speed = player_body.velocity.x;

        // up and down movement
        if (ascending) 
        {
			player_body.velocity = new Vector2(player_body.velocity.x, 5.0f);

			// keep player from going off the screen
			if (transform.position.y + player_sprite.size.y / 2 > 5)
			{
				player_body.velocity = new Vector2(player_body.velocity.x, 0.0f);
			}
		}
        else 
        {
			player_body.velocity = new Vector2(player_body.velocity.x, -5.0f);

			// keep player from going off the screen
			if (transform.position.y - player_sprite.size.y / 2 < -5)
            {
				player_body.velocity = new Vector2(player_body.velocity.x, 0.0f);
			}
		}

        // move the camera with the player
        main_camera.transform.position = new Vector3(transform.position.x + camera_distance, main_camera.transform.position.y, main_camera.transform.position.z);
	    
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
