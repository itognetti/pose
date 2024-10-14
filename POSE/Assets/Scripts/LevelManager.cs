using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] walls;

    [SerializeField] [Range(2.0f, 10.0f)]
    private float wallSpeed = 2.0f;
    private int currentWall = 0;

    private bool levelFinished = false;

    private int finishedWalls = 0;
    private int wallsCount = 0;
    void Start() {
        SwapRandomOrderWalls();
        StartLevel();
    }

    void Update() {
        Wall currentWallScript = GetCurrentWall().GetComponent<Wall>();

        if (currentWallScript == null) {
            Debug.LogError("Wall does not have Wall script attached");
            return;
        }

        // if (currentWallScript.GetIsOutOfBounds()) {
        //         Debug.Log("Finished Walls: " + finishedWalls + " Walls Length: " + walls.Length);
        //         finishedWalls++;
        //         SpawnWall();
        // }

        // Get this level and check if there's no children inside it then spawn a new wall
        if (finishedWalls >= wallsCount) {
            Debug.Log("Level Finished");
            Destroy(gameObject);
            levelFinished = true;
        }

        if (transform.childCount == 0 && finishedWalls < wallsCount) {
            Debug.Log("finished Walls: " + finishedWalls);
            finishedWalls++;
            SpawnWall();
        }


    }

    private void StartLevel() {
        // We start with a current wall
        wallsCount = walls.Length;
        levelFinished = false; 
        SpawnWall();
    }

    private GameObject SpawnWall() {
        GameObject toReturn = Instantiate(walls[currentWall++ % walls.Length], transform);
        try {
            toReturn.GetComponent<Wall>().SetSpeed(wallSpeed);
        } catch (System.Exception e) {
            Debug.LogError("Wall does not have Wall script attached" + e);
        }
        return toReturn;

    }

    private void SwapRandomOrderWalls() {
        for (int i = 0; i < walls.Length; i++) {
            int randomIndex = Random.Range(0, walls.Length);
            GameObject temp = walls[randomIndex];
            walls[randomIndex] = walls[i];
            walls[i] = temp;
        }
    }

    private GameObject GetCurrentWall() {
        return walls[currentWall % walls.Length];
    }

    public bool hasFinished() {
        return levelFinished;
    }
}