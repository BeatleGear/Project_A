using DG.Tweening;
using System.Collections;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    private bool _wasIn, _wasOut;
    // Start is called before the first frame update
    void Start()
    {
        _wasIn = false;
        _wasOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_wasIn)
        {
            OpenTheGate();
            _wasIn = false;
        }
        if (_wasOut)
        {
            LockTheGate();
            _wasOut = false;
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pistol Idle")
            _wasIn = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Pistol Idle")
            _wasOut = true;
    }
    void OpenTheGate()
    {
        transform.DOMoveY(-0.6f, 1.5f);
    }
    void LockTheGate()
    {
        transform.DOMoveY(0.5f, 1.5f);
    }

}
