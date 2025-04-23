using System.Collections.Generic;
using UnityEngine;

public class InventoryWeapon : MonoBehaviour
{
    #region Singleton
    public static InventoryWeapon instanceWeapon;

    private void Awake()
    {
        if (instanceWeapon != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }
        instanceWeapon = this;
    }
    #endregion

    public delegate void OnWeaponChanged();
    public OnWeaponChanged onWeaponChangedCallback;

    public int space = 2;

    public List<Weapon> weapons = new();

    public bool Add(Weapon weapon)
    {
        if (!weapon.isDefaultItem)
        {
            if (weapons.Count >= space)
            {
                Debug.LogWarning("Not enough room");
                return false;
            }
            weapons.Add(weapon);
            onWeaponChangedCallback?.Invoke();
            Debug.Log("Вызвали делегат");

            return true;
        }
        return false;
    }
    public void Remove(Weapon weapon)
    {
        weapons.Remove(weapon);
        onWeaponChangedCallback?.Invoke();
    }
}
