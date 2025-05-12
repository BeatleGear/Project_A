using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorOn : MonoBehaviour
{
    private bool ThePlayerIsNearby;

    void Start()
    {
        ThePlayerIsNearby = false;
        InventoryManager.slotChanged += OnInventorySlotEvent;
    }

    // Update is called once per frame
    void Update()
    {

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
    void OnInventorySlotEvent(InventorySlot slot)
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
        }
        else
        {
            Debug.Log("Игрок не рядом с генератором");
        }
    }
}
