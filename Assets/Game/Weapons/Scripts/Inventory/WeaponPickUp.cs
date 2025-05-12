using DG.Tweening;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public Weapon weapon;

    [SerializeField]
    ItemMover _itemMover;

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
            _itemMover.Animation.Kill();
            Destroy(gameObject);
        }
    }
}
