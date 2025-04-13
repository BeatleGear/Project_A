using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RagdollHandler : MonoBehaviour
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
    }

    public void Hit(Vector3 force, Vector3 hitPosition)
    {
        Rigidbody inJuredRigidbody = _rigidbodies.OrderBy(rigidbody  => Vector3.Distance(rigidbody.position, hitPosition)).First();

        inJuredRigidbody.AddForceAtPosition(force, hitPosition, ForceMode.Impulse);
    }
}
