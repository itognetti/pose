using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject WallObject;
    public GameObject[] walls;
    public float removeDistance;
    public GameObject doorParent;

    private GameObject currentWall;
    private float closeDistance = -10f;

    public AudioSource music;
    private int wallNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        music.Play();
        currentWall = nextWall(0);
        for (int t = 0; t < walls.Length; t++ )
        {
            GameObject tmp = walls[t];
            int r = Random.Range(t, walls.Length);

            // Randomize orientation if rotable wall
            if (tmp.CompareTag("Rotable"))
            {
                // We rotate the wall 90 degrees on the Y axis
                tmp.transform.rotation = Quaternion.Euler(-90, 0, 90 * Random.Range(0, 2));
            }
            walls[t] = walls[r];
            walls[r] = tmp;
        }
        openDoor();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWall.transform.position.x > closeDistance){
            closeDoor();
        }
        if(currentWall.transform.position.x > removeDistance){
            Destroy(currentWall);
            currentWall = nextWall(wallNumber++);
            openDoor();
        }
    }

    private GameObject nextWall(int n){
        GameObject wall = Instantiate(WallObject, transform);
        Instantiate(walls[n], wall.transform);
        return wall;
    }

    private void openDoor(){
        Animator doorAnim = doorParent.GetComponent<Animator>();
        doorAnim.ResetTrigger("close");
        doorAnim.SetTrigger("open");
    }

    private void closeDoor(){
        Animator doorAnim = doorParent.GetComponent<Animator>();
        doorAnim.ResetTrigger("open");
        doorAnim.SetTrigger("close");
    }

    // void SetWallsSpeed(float speed) {
    //     foreach (Transform child in transform)
    //     {
    //         child.SetSpeed(speed);
    //     }
    // }
}
