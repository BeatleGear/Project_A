using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyView _view;
    [SerializeField] RagdollHandler _ragdollHandler;

    void Start()
    {
        _view.Initialize();
        _ragdollHandler.Initialize();
    }

    public void Kill()
    {
        _view.DisableAnimator();
        _ragdollHandler.Enable();
    }
}
