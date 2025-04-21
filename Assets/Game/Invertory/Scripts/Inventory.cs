using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance !=null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 11;

    public List<Item> items = new List<Item>();
    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.LogWarning("Not enough room");
                return false;
            }
            items.Add(item);
            onItemChangedCallback?.Invoke();

            return true;
        }
        return false;
    }

    public void Remove(Item item)
    { 
        items.Remove(item);
        onItemChangedCallback?.Invoke();
    }

}
