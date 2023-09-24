using UnityEngine;

public class ItemController : MonoBehaviour, IPickable
{
    public Item ScriptableItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            PickupItem();
    }
    public void PickupItem()
    {
        if (ScriptableItem.IsStackable)
        {
            bool isInInventory = false;
            foreach(var item in InventoryManager.Instance.Items)
            {
                if (item.ID == ScriptableItem.ID)
                {
                    InventoryManager.Instance.CurrentAmmo += ScriptableItem.ItemAmount;
                    isInInventory = true;
                    Destroy(gameObject);
                }
            }
            if (!isInInventory)
            {
                InventoryManager.Instance.CurrentAmmo += ScriptableItem.ItemAmount;
                InventoryManager.Instance.Items.Add(ScriptableItem);
                Destroy(gameObject);
            }
        }
        else
        {
            InventoryManager.Instance.AddItem(ScriptableItem);
            Destroy(gameObject);
        }
    }
}
