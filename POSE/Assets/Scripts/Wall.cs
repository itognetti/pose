using UnityEngine;

public class Wall : MonoBehaviour
{


    private float speed;
    private GameObject player;
    private bool isPushingPlayer = false;

    private bool isOutOfBounds = false;

    private bool isRotable = false;

    void Start() {
        // Get the player object
        player = GameObject.FindWithTag("Player");

        Vector3 spawnerPosition = GameObject.FindWithTag("Spawner").transform.position;

        transform.position = spawnerPosition;
        if (isRotable) {
            // Rotate the wall
            transform.Rotate(-90, 0, 180 * Random.Range(0, 1));
        }

        // OpenDoor();

        // Calculate the time it takes for the wall to reach a certain point
        // float distanceToCloseDoor = 10.0f; // Example distance
        // float timeToCloseDoor = distanceToCloseDoor / speed;

        // // Invoke the CloseDoor method after the calculated time
        // Invoke("CloseDoor", timeToCloseDoor);
    }

    // TODO: Open/Close door animation in GameManager
    private void OpenDoor() {
        // Animator doorAnim = doorParent.GetComponent<Animator>();
        // doorAnim.ResetTrigger("close");
        // doorAnim.SetTrigger("open");

    }

    private void CloseDoor() {
        // Animator doorAnim = doorParent.GetComponent<Animator>();
        // doorAnim.ResetTrigger("open");
        // doorAnim.SetTrigger("close");
    }
    void Update()
    {
        Move();
        if (isOutOfBounds)
        {
            Destroy(gameObject);
        }
    }

    public void Move()
    {
        // Move the wall forward
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
        transform.position = transform.position + speed * Time.deltaTime * Vector3.right;

        // If the wall is pushing the player we move the player too
        if (isPushingPlayer)
        {
            player.transform.position = player.transform.position + speed * Time.deltaTime * Vector3.right;
            //player.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        // If the wall collides with the player we start pushing the player
        switch (other.gameObject.tag)
        {
            case "Body":
                isPushingPlayer = true;
                break;
            case "DeathBox":
                isOutOfBounds = true;
                break;
        }

    }

    void OnTriggerExit(Collider other)
    {
        // If the wall stops colliding with the player we stop pushing the player
        if (other.gameObject.CompareTag("Body"))
        {
            isPushingPlayer = false;
        }
    }


    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void SetIsRotable(bool rotable)
    {
        isRotable = rotable;
    }


    // @depreacted
    public bool GetIsOutOfBounds()
    {
        return isOutOfBounds;
    }
}