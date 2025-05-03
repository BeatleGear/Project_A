using UnityEngine;

public class RagdollPlayerView : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public void Initialize() => _animator = GetComponent<Animator>();

    public void DisableAnimator() => _animator.enabled = false;

    public void EnableAnimator() => _animator.enabled = true;
}
