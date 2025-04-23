using Unity.VisualScripting;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public InventoryWeapon inventoryWeapon;
    public InventoryWeaponUI inventoryWeaponUI;

    public int SelectedWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if(inventoryWeapon.weapons.Count > 1)
        {
            int previousSelectedWeapon = SelectedWeapon;

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (SelectedWeapon >= transform.childCount - 1)
                    SelectedWeapon = 0;
                else
                    SelectedWeapon++;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (SelectedWeapon <= 0)
                    SelectedWeapon = transform.childCount - 1;
                else
                    SelectedWeapon--;
            }
            if (previousSelectedWeapon != SelectedWeapon)
            {
                SelectWeapon();
            }
        }

    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == SelectedWeapon)
            {
                weapon.gameObject.SetActive(true);

                inventoryWeaponUI.WeaponSlots[i].icon.gameObject.transform.localScale =
                new Vector3(transform.localScale.x * 1.3f, transform.localScale.y * 1.3f,
                transform.localScale.z * 1.3f);
            }
            else
            {
                weapon.gameObject.SetActive(false);

                inventoryWeaponUI.WeaponSlots[i].icon.gameObject.transform.localScale =
                new Vector3(transform.localScale.x * 1f, transform.localScale.y * 1f,
                transform.localScale.z * 1f);
            }
            i++;
        }
    }
}
