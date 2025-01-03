using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Time it takes to reach new value (Smaller faster)
    [SerializeField] private float smoothTime;
    private float currentPositionX;

    private Vector3 velocity;

    private void Update()
    {
        Vector3 _position = transform.position;
        transform.position = Vector3.SmoothDamp(_position, new Vector3(currentPositionX, _position.y, _position.z), ref velocity, smoothTime * Time.deltaTime);

        velocity = Vector3.zero;
    }

    private void Awake()
    {
        currentPositionX = transform.position.x;
    }

    public void MoveToNewRoom(Transform newRoom)
    {
        currentPositionX = newRoom.position.x;
    }
}
