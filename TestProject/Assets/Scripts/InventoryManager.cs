using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public InventoryItemController[] InventoryItems;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(Item item)
        => Items.Add(item);

    public void DeleteItem(Item item)
        => Items.Remove(item);

    public void ListItems()
    {
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemCount = obj.transform.Find("ItemCount").GetComponent<TMP_Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButotn = obj.transform.Find("RemoveButton").gameObject.GetComponent<Button>();

            itemCount.text = item.ItemAmount.ToString();
            if (item.ItemAmount == 1)
                itemCount.gameObject.SetActive(false);
            itemIcon.sprite = item.ItemIcon;
            bool isItemStackable = item.IsStackable;

        }

        SetInventoryItems();
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }

}
