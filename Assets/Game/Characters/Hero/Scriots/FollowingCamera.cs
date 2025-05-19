using UnityEngine;
using UnityEngine.UIElements;

public class FollowingCamera : MonoBehaviour
{
    [Header("Object for following")]
    [SerializeField] GameObject _mainCharacter;

    [Header("Camera propertys")]
    [SerializeField] private float _returnSpeed;
    [SerializeField] private float _height;
    [SerializeField] private float _rearDistance;

    private float _rotationY;

    public bool isRotate = false;
    public bool is—hange = false;

    public int change—ounter;

    public float RotationSpeed = 5.0f;

    private float lastTimeToLook;

    Vector3 currentVector;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(_mainCharacter.transform.position.x, _mainCharacter.transform.position.y + _height, _mainCharacter.transform.position.z - _rearDistance);
        transform.rotation = Quaternion.LookRotation(_mainCharacter.transform.position - transform.position);
        Vector3 rotate = transform.eulerAngles;
        rotate.x = 40;
        transform.rotation = Quaternion.Euler(rotate);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                change—ounter = (change—ounter + 1) % 4;
                lastTimeToLook = Time.time + 3;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if ((change—ounter--) <= 0)
                    change—ounter = 3;
                lastTimeToLook = Time.time + 3;
            }
        }

    }
    // Update is called once per frame
    void LateUpdate()
    {
        CameraMove();
    }

    void CameraMove()
    {
        switch (change—ounter)
        {
            case 0:
                currentVector = new Vector3(_mainCharacter.transform.position.x, _mainCharacter.transform.position.y + _height, _mainCharacter.transform.position.z - _rearDistance);
                break;
            case 1:
                currentVector = new Vector3(_mainCharacter.transform.position.x - _rearDistance, _mainCharacter.transform.position.y + _height, _mainCharacter.transform.position.z);
                break;
            case 2:
                currentVector = new Vector3(_mainCharacter.transform.position.x, _mainCharacter.transform.position.y + _height, _mainCharacter.transform.position.z + _rearDistance);
                break;
            case 3:
                currentVector = new Vector3(_mainCharacter.transform.position.x + _rearDistance, _mainCharacter.transform.position.y + _height, _mainCharacter.transform.position.z);
                break;
            default:
                break;
        }

        transform.position = Vector3.Lerp(transform.position, currentVector, _returnSpeed * Time.deltaTime);
        if (Time.time <= lastTimeToLook)
        {
            transform.rotation = Quaternion.LookRotation(_mainCharacter.transform.position - transform.position);
        }
        Vector3 rotate = transform.eulerAngles;
        rotate.x = 40;
        transform.rotation = Quaternion.Euler(rotate);
    }
}
