using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                if (_instance == null)
                {
                    Debug.LogError("game instance missing");
                }
            }

            return _instance;
        }
    }

    private MapManager _map;
    public static MapManager Map { get { return Instance._map; } }

    private UIManager _ui;
    public static UIManager UI { get { return Instance._ui; } }

    [Header("Game Configs")]
    private readonly float _initialTime = 120.0f;

    private float _timeRemaining;
    private int _score;

	private void Awake()
	{
		_map = FindObjectOfType<MapManager>();
        if (_map == null)
        {
            GameObject go = new GameObject("@MapManager");
            _map = go.AddComponent<MapManager>();
        }

        _ui = FindObjectOfType<UIManager>();
        if (_ui == null)
        {
            GameObject go = new GameObject("@UIManager");
            _ui = go.AddComponent<UIManager>();
        }
	}

	private void Start()
	{
        _timeRemaining = _initialTime;
        _score = 0;

        UI.UpdateScore(_score);
        UI.UpdateTimer(_timeRemaining);

        Map.Init();
	}

	private void Update()
	{
        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
            UI.UpdateTimer(_timeRemaining);
        }
	}

    public void AddScore(int score)
    {
        _score += score;
        UI.UpdateScore(_score);
    }
}
