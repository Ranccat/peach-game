using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
	public Button EasyModeButton;
	public Button NormalModeButton;
	public Button HardModeButton;

	private void Start()
	{
		EasyModeButton.onClick.AddListener(StartGameEasy);
		NormalModeButton.onClick.AddListener(StartGameNormal);
		HardModeButton.onClick.AddListener(StartGameHard);
	}

	private void StartGameEasy()
	{
		GameData.Difficulty = 4;
		GameStart();
	}

	private void StartGameNormal()
	{
		GameData.Difficulty = 3;
		GameStart();
	}

	private void StartGameHard()
	{
		GameData.Difficulty = 2;
		GameStart();
	}

	private void GameStart()
	{
		SceneManager.LoadScene("GameScene");
	}
}
