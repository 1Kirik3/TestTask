using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour, IRemovable
{
    public Item ScriptableItem;
    public Button RemoveButton; 

    public void RemoveItem()
    {
        InventoryManager.Instance.DeleteItem(ScriptableItem);
        InventoryManager.Instance.CurrentAmmo = 0;
        Destroy(gameObject);
    }

    public void AddItem(Item newitem)
        => ScriptableItem = newitem;
}
