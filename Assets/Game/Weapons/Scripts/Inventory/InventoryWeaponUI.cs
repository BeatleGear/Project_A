using UnityEngine;

public class InventoryWeaponUI : MonoBehaviour
{
    public Transform itemParents;
    public GameObject inventoryUI;

    InventoryWeapon inventoryWeapon;

    public InventoryWeaponSlot[] WeaponSlots;
    void Start()
    {
        inventoryWeapon = InventoryWeapon.instanceWeapon;
        inventoryWeapon.onWeaponChangedCallback += UpdateWeaponUI;
        WeaponSlots = itemParents.GetComponentsInChildren<InventoryWeaponSlot>();
    }
    void UpdateWeaponUI()
    {
        for (int i = 0; i < WeaponSlots.Length; i++)
        {
            if (i < inventoryWeapon.weapons.Count)
            {
                WeaponSlots[i].AddItem(inventoryWeapon.weapons[i]);
            }
            else
            {
                WeaponSlots[i].ClearSlot();
            }
        }
    }
}
