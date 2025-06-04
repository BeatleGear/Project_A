using UnityEngine.UI;
using UnityEngine;

public class TaskCheckScript : MonoBehaviour
{
    [SerializeField]
    private Image _imageCheckBattery, _imageCheckOnGenerator, _imageCheckGate;
    // Start is called before the first frame update
    void Start()
    {
        _imageCheckBattery.enabled = false;

        _imageCheckOnGenerator.enabled = false;

        _imageCheckGate.enabled = false;

        InventoryManager.tasksEvent += OnTasksEvent;
        InventoryManager.tasksGeneratorEvent += OnTasksGeneratorEvent;
    }
    void OnTasksEvent(ItemPickUp itemPickUp)
    {
        if (itemPickUp.item.name == "Battery")
        {
            _imageCheckBattery.enabled = true;
        }
    }
    void OnTasksGeneratorEvent()
    {
        _imageCheckOnGenerator.enabled = true;
    }

    private void OnDestroy()
    {
        InventoryManager.tasksEvent -= OnTasksEvent;
        InventoryManager.tasksGeneratorEvent -= OnTasksGeneratorEvent;
    }
}
