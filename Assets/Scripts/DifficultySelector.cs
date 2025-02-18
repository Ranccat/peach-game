using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelector : MonoBehaviour
{
    public TMP_Text DifficultyText;
    public Button IncreaseButton;
    public Button DecreaseButton;

    private readonly int _maxDifficulty = 5;
    private readonly int _minDifficulty = 1;
	private readonly int _baseDifficulty = 3;

    private int _difficulty;

	private void Start()
	{
		_difficulty = _baseDifficulty;

		IncreaseButton.onClick.AddListener(IncreaseDifficulty);
		DecreaseButton.onClick.AddListener(DecreaseDifficulty);
	}

	private void IncreaseDifficulty()
	{
		if (_difficulty < _maxDifficulty)
		{
			_difficulty++;
			UpdateDisplay();
		}
	}

	private void DecreaseDifficulty()
	{
		if (_difficulty > _minDifficulty)
		{
			_difficulty--;
			UpdateDisplay();
		}
	}

	private void UpdateDisplay()
	{
		DifficultyText.text = _difficulty.ToString();
		GameData.Difficulty = _difficulty;
	}

	private void OnDestroy()
	{
		IncreaseButton.onClick.RemoveAllListeners();
		DecreaseButton.onClick.RemoveAllListeners();
	}
}
