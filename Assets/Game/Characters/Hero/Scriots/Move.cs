using UnityEngine.EventSystems;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    [SerializeField]
    private CharacterController _charController;
    public FollowingCamera _followingCamera;

    float deltaX;
    float deltaZ;
    void Start()
    {

    }
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        switch(_followingCamera.change—ounter)
        {
            case 0:
                deltaX = Input.GetAxis("Horizontal") * speed;
                deltaZ = Input.GetAxis("Vertical") * speed;
                break;
            case 1:
                deltaZ = Input.GetAxis("Horizontal") * -speed;
                deltaX = Input.GetAxis("Vertical") * speed;
                break;
            case 2:
                deltaX = Input.GetAxis("Horizontal") * -speed;
                deltaZ = Input.GetAxis("Vertical") * -speed;
                break;
            case 3:
                deltaZ = Input.GetAxis("Horizontal") * speed;
                deltaX = Input.GetAxis("Vertical") * -speed;
                break;
            case 4:
                break;
        }

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
