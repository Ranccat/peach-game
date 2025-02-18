using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject PeachPrefab;
	public Transform PeachHolder;

	private readonly int _mapHeight = 10;
	private readonly int _mapWidth = 17;

	private readonly float _interval = 0.6f;

	public void Init()
	{
		int[] randomArray = NumberGenerator.GenerateRandomNumbers(170, 7);
		Shuffler.Shuffle(randomArray);

		float currentWidth = 0f;
		float currentHeight = 0f;
		int idx = 0;
		for (int h = 0; h < _mapHeight; h++)
		{
			for (int w = 0; w < _mapWidth; w++)
			{
				GameObject peach = Instantiate(PeachPrefab, new Vector2(currentWidth, currentHeight), Quaternion.identity, PeachHolder);
				int num = randomArray[idx++];
				peach.GetComponent<Peach>().SetNumber(num);
				currentWidth += _interval;
			}
			currentHeight += _interval;
			currentWidth = 0;
		}
	}
}
