using UnityEngine;

public class RagdollPlayer : MonoBehaviour
{
    [SerializeField] RagdollPlayerView _view;
    [SerializeField] RagdollPlayerHandler _ragdollPlayerHandler;
    // Start is called before the first frame update
    void Start()
    {
        _view.Initialize();
        Debug.Log("�������� ������ �� ��������");
        _ragdollPlayerHandler.Initialize();
        Debug.Log("��������� RB");
    }

    public void Kill()
    {
        Debug.Log("����� � �����");
        _view.DisableAnimator();
        Debug.Log("��������� ��������");
        _ragdollPlayerHandler.Enable();
    }
}

