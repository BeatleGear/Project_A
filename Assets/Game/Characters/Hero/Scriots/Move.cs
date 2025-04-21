using UnityEngine.EventSystems;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    [SerializeField]
    private CharacterController _charController;
    void Start()
    {

    }
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
