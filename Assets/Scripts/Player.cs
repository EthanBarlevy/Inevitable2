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
	private Transform player_transform;

	[SerializeField] private PlayerData player_data;
    [SerializeField] private Camera main_camera;
    [SerializeField] public float current_speed = -1;
    [SerializeField] public float current_size = -1;
    [SerializeField] private int camera_distance = 0;

    public PlayerInput player_actions;
    private InputAction ascend;
    private bool ascending = false;
    private Manager.GameState game_state;

    private float invincibility_time;

    void Start()
    {
        player_collider = GetComponent<CircleCollider2D>();
        player_body = GetComponent<Rigidbody2D>();
        player_sprite = GetComponent<SpriteRenderer>();
		player_transform = GetComponent<Transform>();
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
        if (game_state == Manager.GameState.GAMEPLAY)
        { 
            current_speed = player_body.velocity.x;
        }

        if (game_state == Manager.GameState.END_OF_RUN)
        {
            player_body.velocity = new Vector3(0, 0);
        }

        // up and down movement
        if (ascending)
        {
            player_body.velocity = new Vector2(player_body.velocity.x, 5.0f);
            // player_transform.localRotation.

            // keep player from going off the screen
            if (transform.position.y + player_sprite.size.y / 2 > 5)
            {
                player_body.velocity = new Vector2(player_body.velocity.x, 0.0f);
            }
        }
        else
        {
            if (game_state == Manager.GameState.GAMEPLAY)
            {
                player_body.velocity = new Vector2(player_body.velocity.x, -5.0f);
            }

			// keep player from going off the screen
			if (transform.position.y - player_sprite.size.y / 2 < -5)
            {
				player_body.velocity = new Vector2(player_body.velocity.x, 0.0f);
			}
		}

        // move the camera with the player
        main_camera.transform.position = new Vector3(transform.position.x + camera_distance, main_camera.transform.position.y, main_camera.transform.position.z);

        // update size
        gameObject.transform.localScale = new Vector3(current_size, current_size, current_size);

        if(invincibility_time > 0) 
        {
            invincibility_time -= Time.deltaTime;
        }
    }

    public void SetGameState(Manager.GameState new_state)
    {
        game_state = new_state;

	}

    public void ChangeSpeedAndSize(float speed, float size)
    {
        if (invincibility_time <= 0)
        { 
            current_speed += speed;
            current_size += size;
        }

        player_body.velocity = new Vector3(current_speed, player_body.velocity.y);
    }

    public void StartGame()
    {
		// take from the data
		player_data.initial_speed = FindObjectOfType<Manager>().GetStartSpeed();
		player_data.initial_size = FindObjectOfType<Manager>().GetStartSize();
		current_speed = player_data.initial_speed;
		current_size = player_data.initial_size;

		player_body.velocity = Vector2.right * current_speed;
	}

    public void AddInvincibility(float time)
    {
        invincibility_time += time;
    }

    private void Ascend(InputAction.CallbackContext context)
    {
        // if we are on the start screen, set the game state to gameplay
        if (game_state == Manager.GameState.GAMEPLAY)
        { 
            ascending = true;
        }

	}

	private void Descend(InputAction.CallbackContext context)
	{
		if (game_state == Manager.GameState.GAMEPLAY)
		{
		    ascending = false;
		}
	}
}
