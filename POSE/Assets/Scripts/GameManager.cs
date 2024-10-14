using UnityEngine;

public class GameManager : MonoBehaviour
{
    // [SerializeField]
    // private static GameManager Instance { get; private set; }

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] levels;

    // [SerializeField] private AudioSource music;

    private int currentLevel = 0;
    void Start()
    {
        // Initialize game state
        InitializeGame();
    }

    void Update() {
        LevelManager levelManager = levels[currentLevel].GetComponent<LevelManager>();
        if (levelManager == null) {
            Debug.LogError("LevelManager not found");
            return;
        }

        Debug.Log("Current level " + currentLevel + " hasFinished " + levelManager.hasFinished());

        // Funciona. No tocar.
        GameObject wall = GameObject.FindWithTag("Level");
        if (wall == null) {
            currentLevel++;
            StartNextLevel();
        }
    }

    private void InitializeGame()
    {
        // Add initialization logic here
        Debug.Log("Game Initialized");
        // music.Play();

        StartGame();
        StartNextLevel();

    }

    private void StartNextLevel()
    {
        // Add logic to start the next level
        Debug.Log("Current lvl: " + currentLevel);
        if (currentLevel < levels.Length)
        {

            Instantiate(levels[currentLevel], Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.Log("No more levels");
        }
    }

    public void StartGame()
    {
        Debug.Log("Game Started");
    }

    public void EndGame()
    {
        // Add logic to end the game
        Debug.Log("Game Ended");
    }

    public void RestartGame()
    {
        // Add logic to restart the game
        Debug.Log("Game Restarted");
    }

}