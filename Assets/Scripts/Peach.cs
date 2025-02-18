using TMPro;
using UnityEngine;

public class Peach : MonoBehaviour
{
	private TextMeshPro _text;
	private int _number;
	
	private void Start()
	{
		GameObject textObject = new GameObject("NumberText");
		textObject.transform.SetParent(transform);
		textObject.transform.localPosition = Vector3.zero;

		_text = textObject.AddComponent<TextMeshPro>();
		_text.text = _number.ToString();
		_text.fontSize = 3;
		_text.alignment = TextAlignmentOptions.Center;
		_text.color = Color.blue;
		_text.transform.localPosition -= new Vector3(0, 0.5f, 0);
	}

	public void SetNumber(int number)
	{
		_number = number;
	}

	public int GetNumber()
	{
		return _number;
	}
}
