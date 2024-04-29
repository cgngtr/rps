using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ObjectCounter _objectCounter;
    public SliderReader _sr;
    public BidManager _bidManager;
    public UIController _UIController;
    public SpawnManager _spawnManager;
    public GameManager _gameManager;
    public int currentSceneIndex;
    private string currentBid;
    private int bidAmount;
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject startMenu;
    public bool isPressed = false;
    public int objectAmount;

    private void Awake()
    {
        _sr = GetComponent<SliderReader>();
        _gameManager = GetComponent<GameManager>();
        _bidManager = GetComponent<BidManager>();
        _spawnManager = GetComponent<SpawnManager>();
        gameMenu = GameObject.Find("Game");
        startMenu = GameObject.Find("StartMenuUI");
        gameMenu.SetActive(true);
    }

    private void Start()
    {
        gameMenu.SetActive(false);
        _objectCounter = GameObject.Find("Manager").GetComponent<ObjectCounter>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.sceneLoaded += OnSceneLoaded;
        currentBid = _gameManager.currentBid;
        bidAmount = _gameManager.bidAmount;
    }

    private void Update()
    {
        
    }



    public void RestartScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void StartGame()
    {
        objectAmount = (int)_sr.spawnSlider.value;
        Debug.Log(objectAmount);
        isPressed = true;
        gameMenu.SetActive(true);
        startMenu.SetActive(false);
        _spawnManager.Spawn();
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
            Debug.LogWarning("There is no next scene in the build order!");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "StartMenu")
        {
            gameObject.SetActive(true);

        }

        if (scene.name == "MainScene")
        {
            gameObject.SetActive(true);
            _objectCounter = FindObjectOfType<ObjectCounter>();
            _UIController = FindObjectOfType<UIController>();
        }
    }
}
