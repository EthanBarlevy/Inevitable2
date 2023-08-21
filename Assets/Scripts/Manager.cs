using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Manager : MonoBehaviour
{
	[SerializeField] GameObject[] screens;
	[SerializeField] GameObject[] planet_screens;
	[SerializeField] Player player;
	[SerializeField] Shop shop;
	[SerializeField] GameObject world;
	public GameState game_state { get; private set; }

	[Header("UI Prefabs")]
	[SerializeField] GameObject start_screen_ui;
	[SerializeField] GameObject shop_screen_ui;
	[SerializeField] GameObject in_game_screen_ui;
	[SerializeField] GameObject end_of_run_ui;

	public PlayerInput player_actions;
	private InputAction start_game;
	private int current_screen_number;
	private int temp_rokxs;

	[Header("Planet Distances")]
	[SerializeField] int[] number_of_screens;

	public enum GameState
	{ 
		START_GAME,
		SHOP,
		GAMEPLAY,
		END_OF_RUN,
		CUTSCENE
	}

	private void Start()
	{
		game_state = GameState.START_GAME;
		current_screen_number = 1;
		temp_rokxs = 0;
		HideUI();
	}

	private void Update()
	{
		player.SetGameState(game_state);
		switch (game_state)
		{ 
			case GameState.START_GAME:
				start_screen_ui.SetActive(true);
				break;
			case GameState.SHOP:
				shop_screen_ui.SetActive(true);
				break;
			case GameState.GAMEPLAY:
				in_game_screen_ui.SetActive(true);
				break;
			case GameState.END_OF_RUN:
				end_of_run_ui.SetActive(true);
				break;
			case GameState.CUTSCENE:
				
				break;
		}
	}

	private void Awake()
	{
		player_actions = new PlayerInput();
	}

	private void OnEnable()
	{
		start_game = player_actions.UI.StartGame;
		start_game.Enable();
		start_game.performed += StartGame;
	}

	private void OnDisable()
	{
		start_game.Disable();
	}

	private void StartGame(InputAction.CallbackContext context)
	{
		if (game_state == GameState.START_GAME)
		{
			SetStateGameplay();
			player.StartGame();
		}
		if (game_state == GameState.END_OF_RUN)
		{ 
			SetStateStartGame();
			HideUI();
			player.transform.position = new Vector3(-5, 0, 0);
			current_screen_number = -1;
			temp_rokxs = 0;
			SpawnNextScreen();
			SpawnNextScreen();
			SpawnNextScreen();
			//Destroy(player);
			//player = Instantiate(player);
		}
	}

	public void SetStateStartGame()
	{
		game_state = GameState.START_GAME;
		HideUI();
	}

	public void SetStateGameplay()
	{
		game_state = GameState.GAMEPLAY;
		HideUI();
	}

	public void SetStateShop()
	{
		game_state = GameState.SHOP;
		HideUI();
	}

	public void SetStateCutscene()
	{
		game_state = GameState.CUTSCENE;
		HideUI();
	}

	public void QuitGame()
	{ 
		Application.Quit();
	}

	private void HideUI()
	{ 
		start_screen_ui.SetActive(false);
		shop_screen_ui.SetActive(false);
		in_game_screen_ui.SetActive(false);
		end_of_run_ui.SetActive(false);
	}

	public void AddRokxs(int amount)
	{
		temp_rokxs += amount;
		shop.rokxz += amount;
	}

	public void SpawnNextScreen()
	{
		GameObject next_screen;
		bool planet = false;
		foreach (int number in number_of_screens)
		{
			if (number == current_screen_number)
			{
				planet = true;
			}
		}
		if (planet)
		{
			next_screen = planet_screens[Random.Range(0, planet_screens.Length - 1)];
		}
		else
		{
			next_screen = screens[Random.Range(0, screens.Length - 1)];
		}
		Instantiate(next_screen, new Vector3(9.6f + 19.2f * current_screen_number, 0, 0), world.transform.rotation, world.transform);
		List<Screen> children = new List<Screen>();
		foreach (Screen child in world.GetComponentsInChildren<Screen>())
		{
			children.Add(child);
		}
		Destroy(children[0].gameObject);
		current_screen_number++;
	}

	public void AffectPlayer(float speed, float size)
	{ 
		player.ChangeSpeedAndSize(-speed, -size);
		if (player.current_size < 0.2)
		{
			player.ChangeSpeedAndSize(0, -player.current_size);
			game_state = GameState.END_OF_RUN;
		}
		if (player.current_speed <= 2)
		{
			player.ChangeSpeedAndSize(-player.current_speed, 0);
			game_state = GameState.END_OF_RUN;
		}
	}

	public void MakeInvincible(float time)
	{
		player.AddInvincibility(time);
	}

	public float GetPlayerNewtons()
	{
		return player.current_speed * player.current_size;

	}

	public float GetPlayerDistance()
	{
		return player.transform.position.x + 5;
	}

	public void StopPlayer()
	{
		player.ChangeSpeedAndSize(-player.current_speed, -player.current_size);
		HideUI();
		game_state = GameState.END_OF_RUN;
	}

	public float GetStartSpeed()
	{
		return shop.speed;
	}

	public float GetStartSize()
	{
		return shop.size;
	}

	public int getCurrentRokxz()
	{
		return temp_rokxs;
	}

	public GameData GetData()
	{ 
		return new GameData(shop.rokxz, shop.speed, shop.size, shop.boost_speed, shop.boost_frequency, shop.fire_time, shop.boost_frequency, shop.ice_amount, shop.ice_frequency, new System.Numerics.BigInteger());
	}
}
