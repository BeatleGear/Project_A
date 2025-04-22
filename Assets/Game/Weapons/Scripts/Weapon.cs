using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class Weapon : ScriptableObject
{
    public string WeaponName = "New Weapon";
    public Sprite WeaponIcon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        Debug.Log("Using " + WeaponName);
    }
}
