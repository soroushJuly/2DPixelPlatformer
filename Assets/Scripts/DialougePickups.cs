using UnityEngine;

public class DialougePickups : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float movementSpeed;
    Vector3 StartingPosition;

    private void Awake()
    {
        StartingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Up down movements
        transform.position = new Vector3(StartingPosition.x,
            Mathf.Sin(Time.time * movementSpeed) * movementDistance + StartingPosition.y, StartingPosition.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Show dialouge
            // disable the pickup
        }
    }
}
