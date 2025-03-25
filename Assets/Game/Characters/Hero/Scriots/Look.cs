using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Look : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;

    [SerializeField]
    Camera cam;
    [SerializeField]
    Animator _animator;

    Vector3 _movementVector;

    float _minimumDistance = 0.01f;

    void Start()
    {
        
    }

    void Update()
    {
        _movementVector = CalculateMovementVector();

        UpdateAnimatorVariables();

        TurnToMousePosition();
    }

    void TurnToMousePosition()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Ground")))
        {
            Vector3 toPoint = hit.point - this.transform.position;
            if (toPoint.magnitude > _minimumDistance)
            {
                float rotZ = Mathf.Atan2(toPoint.x, toPoint.z) * Mathf.Rad2Deg;
                this.transform.rotation = Quaternion.Euler(0f, rotZ, 0f);
                //Debug.Log(toPoint.magnitude);
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        //Debug.Log(hit.point);
    }
    private Vector3 CalculateMovementVector()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 cameraR = cam.transform.right;
        Vector3 cameraF = cam.transform.forward;

        cameraR.y = 0;
        cameraF.y = 0;

        Vector3 movementVector = cameraF.normalized * v + cameraR.normalized * h;
        movementVector = Vector3.ClampMagnitude(movementVector, 1);

        Vector3 relativeVector = this.transform.InverseTransformDirection(movementVector);
        _animator.SetFloat("Horizontal", relativeVector.x);
        _animator.SetFloat("Vertical", relativeVector.z);

        Debug.DrawRay(this.transform.position,relativeVector * 2,Color.red);
        Debug.DrawRay(this.transform.position,movementVector * 2,Color.green);
        return movementVector;
    }
    private void UpdateAnimatorVariables()
    {
        _animator.SetFloat("MovementSpeed", _movementVector.magnitude);

        //_playerAnimator.SetBool(IsAttacking, Input.GetKey(KeyCode.Mouse1));
    }
}
