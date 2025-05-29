using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public CompletePanel completePanel;
    private void OnTriggerEnter(Collider other)
    {
        completePanel.completeLevelSetActive();
    }
}
