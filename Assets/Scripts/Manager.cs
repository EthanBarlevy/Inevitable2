using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
	[SerializeField] GameObject[] screens;
	[SerializeField] Player player;
	[SerializeField] Shop shop;
	public GameState game_state { get; private set; }

	[Header("UI Prefabs")]
	[SerializeField] GameObject start_screen_ui;
	[SerializeField] GameObject shop_screen_ui;
	[SerializeField] GameObject in_game_screen_ui;

	public enum GameState
	{ 
		START_GAME,
		SHOP,
		GAMEPLAY,
		CUTSCENE
	}

	private void Start()
	{
		game_state = GameState.START_GAME;
		HideUI();
	}

	private void Update()
	{
		switch (game_state)
		{ 
			case GameState.START_GAME:
				if (start_screen_ui != null)
				{ 
					start_screen_ui.SetActive(true);
				}
				break;
			case GameState.SHOP:
				if (shop_screen_ui != null)
				{
					shop_screen_ui.SetActive(true);
				}
				break;
			case GameState.GAMEPLAY:
				if (in_game_screen_ui != null)
				{
					in_game_screen_ui.SetActive(true);
				}
				break;
			case GameState.CUTSCENE:
				
				break;
		}
	}

	public void SetState(GameState new_state)
	{
		game_state = new_state;
		HideUI();
	}

	private void HideUI()
	{ 
		start_screen_ui.SetActive(false);
		shop_screen_ui.SetActive(false);
		in_game_screen_ui.SetActive(false);
	}

	public void AddRokxs(int amount)
	{
		shop.rokxz += amount;
	}
}
