using TMPro;
using Unity.VisualScripting;
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

	private void OnTriggerEnter2D(Collider2D collision)
	{
		gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
	}

	public void SetNumber(int number)
	{
		_number = number;
	}

	public int GetNumber()
	{
		return _number;
	}

	private void ShootUpward()
	{
		var rb = GetComponent<Rigidbody2D>();
		rb.constraints &= ~(RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY);
		float minAngle = 65f;
		float maxAngle = 115f;

		float randomAngle = Random.Range(minAngle, maxAngle);
		Vector2 forceDir = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

		float forceMag = 10f;
		rb.AddForce(forceDir * forceMag, ForceMode2D.Impulse);
	}

	public void OnCollected()
	{
		ShootUpward();
		Destroy(gameObject, 3.0f);
	}
}
