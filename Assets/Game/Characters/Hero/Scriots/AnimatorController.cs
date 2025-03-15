using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        _animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
    }
}
