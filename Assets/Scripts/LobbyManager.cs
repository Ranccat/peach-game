using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    public Button StartButton;

	private void Start()
	{
		StartButton.onClick.AddListener(StartGame);
	}

	private void StartGame()
	{
		SceneManager.LoadScene("GameScene");
	}
}
