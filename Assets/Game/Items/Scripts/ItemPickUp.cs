using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.transform.name == "Pistol Idle")
            PickUp();
    }

    public void PickUp()
    {
        if (Inventory.instance.Add(item))
        {
            Debug.Log("Подобрали " + item.name);
            Destroy(gameObject);
        }
    }
}
