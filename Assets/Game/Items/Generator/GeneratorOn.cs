using UnityEngine;

public class GeneratorOn : MonoBehaviour
{
    private bool ThePlayerIsNearby;

    void Start()
    {
        ThePlayerIsNearby = false;
        InventoryManager.slotChanged += OnSlotChanged;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Pistol Idle")
        {
            ThePlayerIsNearby = true;
            Debug.Log("Рядом стоит игрок, ожидаю дальнейших действий");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Pistol Idle")
        {
            ThePlayerIsNearby = false;
            Debug.Log("Игрок вышел из зоны генератора");
        }
    }
    void OnSlotChanged(InventorySlot slot)
    {
        if (ThePlayerIsNearby)
        {
            GameObject Child = transform.Find("battery (1)").gameObject;
            if (Child != null)
            {
                Debug.Log("Нашли объект");
                slot.OnRemoveButton();
            }
            else
            {
                Debug.Log("Не нашли объект");
            }
            Child.SetActive(true);
            InventoryManager.OnTasksGeneratorEvent();
        }
        else
        {
            Debug.Log("Игрок не рядом с генератором");
        }
    }
}
