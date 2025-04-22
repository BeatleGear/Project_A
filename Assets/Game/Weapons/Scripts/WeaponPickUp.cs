using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public Weapon weapon;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.transform.name == "Pistol Idle")
            PickUp();
    }
    public void PickUp()
    {
        if (InventoryWeapon.instanceWeapon.Add(weapon))
        {
            Debug.Log("Подобрали " + weapon.WeaponName);
            Destroy(gameObject);
        }
    }
}
