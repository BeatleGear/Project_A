using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public delegate void InventorySlotDelegate(InventorySlot slot);
    public static event InventorySlotDelegate slotChanged;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void OnSlotChanged(InventorySlot slot)
    {
        slotChanged?.Invoke(slot);
    }
}
