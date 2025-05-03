using UnityEngine;

public class RagdollPlayer : MonoBehaviour
{
    [SerializeField] RagdollPlayerView _view;
    [SerializeField] RagdollPlayerHandler _ragdollPlayerHandler;
    // Start is called before the first frame update
    void Start()
    {
        _view.Initialize();
        Debug.Log("Получили ссылку на аниматор");
        _ragdollPlayerHandler.Initialize();
        Debug.Log("Отключили RB");
    }

    public void Kill()
    {
        Debug.Log("Вошли в метод");
        _view.DisableAnimator();
        Debug.Log("Отключили аниматор");
        _ragdollPlayerHandler.Enable();
    }
}

