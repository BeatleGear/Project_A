using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public delegate void InventorySlotDelegate(InventorySlot slot);
    public static event InventorySlotDelegate slotChanged;

    public delegate void PanelTasksDelegate(ItemPickUp itemPickUp);
    public static event PanelTasksDelegate tasksEvent;

    public delegate void PanelTasksGeneratorDelegate();
    public static event PanelTasksGeneratorDelegate tasksGeneratorEvent;

    public static void OnSlotChanged(InventorySlot slot)
    {
        slotChanged?.Invoke(slot);
    }
    public static void OnTasksEvent(ItemPickUp itemPickUp)
    {
        tasksEvent?.Invoke(itemPickUp);
    }
    public static void OnTasksGeneratorEvent()
    {
        tasksGeneratorEvent?.Invoke();
    }
}
