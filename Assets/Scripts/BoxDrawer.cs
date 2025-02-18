using UnityEngine;

public class BoxDrawer : MonoBehaviour
{
	public GameObject boxPrefab;

	private GameObject _currentBox;
	private Vector2 _startMousePos;
	private bool _isDrawing = false;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_isDrawing = true;
			_startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			CreateBox(_startMousePos);
		}
		if (_isDrawing && Input.GetMouseButton(0))
		{
			Vector2 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			UpdateBoxSize(_startMousePos, currentMousePos);
		}
		if (Input.GetMouseButtonUp(0))
		{
			_isDrawing = false;
			BoxCreated();
		}
	}

	private void CreateBox(Vector2 pos)
	{
		_currentBox = Instantiate(boxPrefab, pos, Quaternion.identity);
		_currentBox.transform.localScale = Vector3.zero;
	}

	private void UpdateBoxSize(Vector2 start, Vector2 end)
	{
		if (_currentBox == null)
			return;

		Vector2 center = (start + end) / 2;
		Vector2 size = new Vector2(Mathf.Abs(end.x - start.x), Mathf.Abs(end.y - start.y));

		_currentBox.transform.position = center;
		_currentBox.transform.localScale = size;
	}

	private void BoxCreated()
	{
		if (_currentBox == null)
			return;

		BoxCollider2D boxCollider = _currentBox.GetComponent<BoxCollider2D>();
		if (boxCollider == null)
			return;

		Vector2 boxCenter = _currentBox.transform.position;
		Vector2 boxSize = _currentBox.transform.localScale;

		Collider2D[] objectsInBox = Physics2D.OverlapBoxAll(boxCenter, boxSize, 0);
		Destroy(_currentBox);

		int sum = 0;
		foreach (Collider2D obj in objectsInBox)
		{
			Peach peach = obj.GetComponent<Peach>();

			if (peach == null)
				continue;

			sum += peach.GetNumber();
		}

		if (sum != 10)
			return;

		int score = 0;
		foreach (Collider2D obj in objectsInBox)
		{
			Peach peach = obj.GetComponent<Peach>();

			if (peach == null)
				continue;

			score++;
			Destroy(obj.gameObject);
		}

		GameManager.Instance.AddScore(score);
	}
}
