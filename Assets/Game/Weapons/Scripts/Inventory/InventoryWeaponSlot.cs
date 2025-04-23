using UnityEngine;
using UnityEngine.UI;

public class InventoryWeaponSlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Weapon weapon;

    public void AddItem(Weapon newWeapon)
    {
        weapon = newWeapon;

        icon.sprite = weapon.WeaponIcon;
        icon.enabled = true;
        removeButton.interactable = false;
        Debug.Log("—читываем картинку");
    }
    public void ClearSlot()
    {
        weapon = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        Debug.Log("ќчищаем картинку");
    }
    public void OnRemoveButton()
    {
        InventoryWeapon.instanceWeapon.Remove(weapon);
    }
    public void UseItem()
    {
        if (weapon != null)
        {
            weapon.Use();
        }
    }
}
