using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [Header("Object for following")]
    [SerializeField] GameObject _mainCharacter;

    [Header("Camera propertys")]
    [SerializeField] float _returnSpeed;
    [SerializeField] float _height;
    [SerializeField] float _rearDistance;

    Vector3 currentVector;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(_mainCharacter.transform.position.x, _mainCharacter.transform.position.y + _height, _mainCharacter.transform.position.z - _rearDistance);
        this.transform.rotation = Quaternion.LookRotation(_mainCharacter.transform.position - this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }

    void CameraMove()
    {
        currentVector = new Vector3(_mainCharacter.transform.position.x, _mainCharacter.transform.position.y + _height, _mainCharacter.transform.position.z - _rearDistance);
        this.transform.position = Vector3.Lerp(this.transform.position, currentVector, _returnSpeed * Time.deltaTime);
    }
}
