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

    void Update()
    {
        // Up down movements
        transform.position = new Vector3(StartingPosition.x,
            Mathf.Sin(Time.time * movementSpeed) * movementDistance + StartingPosition.y, StartingPosition.z);
    }
}
