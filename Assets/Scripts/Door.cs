using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] CameraController controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Player coming from left
            if (collision.transform.position.x < transform.position.x)
                controller.MoveToNewRoom(nextRoom);
            // Player from right
            else if (collision.transform.position.x > transform.position.x)
                controller.MoveToNewRoom(previousRoom);
        }
    }

    private void Awake()
    {

        //controller = GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
