using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.PostProcessing;

public class HeroHealth : MonoBehaviour
{
    [Header("Health stats")]
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;
    [SerializeField] private Animator _animator;

    [SerializeField] RagdollPlayer _ragdollPlayer;
    [SerializeField] RagdollPlayerHandler _ragdollPlayerHandler;
    [SerializeField] CapsuleCollider _capsuleCollider;
    [SerializeField] CharacterController _characterController;
    [SerializeField] Look _look;


    public event Action<float> HealthChanged;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        _capsuleCollider = GetComponentInParent<CapsuleCollider>();
        _characterController = GetComponent<CharacterController>();
        _look = GetComponent<Look>();
        _currentHealth = _maxHealth;
        _ragdollPlayerHandler.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        //if (_isHit)
        //{
        //    if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Blend Tree"))
        //    {
        //        Debug.Log("Вернули анимацию, как было");
        //        _animator.SetBool("Hit", false);
        //        _isHit = false;
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.G))
            ChangeHeals(-10);
    }

    private void ChangeHeals(int value)
    {
        _currentHealth += value;

        if (_currentHealth <= 0 )
            Death();

        else if (_currentHealth >= 100)
            _currentHealth = 100;
        else
        {
            float _currentHealthAsPercantage = (float)_currentHealth / _maxHealth;
            Debug.Log("Рассчитанный процент " + _currentHealthAsPercantage);
            HealthChanged?.Invoke(_currentHealthAsPercantage);
        }
    }

    private void Death()
    {        
        HealthChanged?.Invoke(0);
        Die();
    }
    void Die()
    {
        _characterController.enabled = false;
        _capsuleCollider.enabled = false;
        _look.enabled = false;
        _ragdollPlayer.Kill();         
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "mixamorig:RightHand")
        {
            Debug.Log("Получаю урон");
            ChangeHeals(-10);
            _animator.SetTrigger("Hit");
        }
    }
}
