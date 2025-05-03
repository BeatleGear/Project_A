using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollPlayerHandler : MonoBehaviour
{
    List<Rigidbody> _rigidbodies;
    public void Initialize()
    {
        _rigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());
        Disable();
    }
    public void Enable()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }
    public void Disable()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
        _rigidbodies[0].isKinematic = false;
        Debug.Log("Наоотлючали RB");
    }
}
