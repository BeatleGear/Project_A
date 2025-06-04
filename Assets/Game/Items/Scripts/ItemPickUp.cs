using DG.Tweening;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;

    [SerializeField]
    ItemMover _itemMover;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Pistol Idle")
            PickUp();
    }

    public void PickUp()
    {
        if (Inventory.instance.Add(item))
        {
            Debug.Log("Подобрали " + item.name);
            gameObject.SetActive(false);
            //_itemMover.Animation.Kill();
            InventoryManager.OnTasksEvent(this);            
            //Destroy(gameObject);
            
        }
    }
}
