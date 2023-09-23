using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour, IRemovable
{
    public Item ScriptableItem;
    public Button RemoveButton; 

    public void RemoveItem()
    {
        InventoryManager.Instance.DeleteItem(ScriptableItem);
        Destroy(gameObject);
    }

    public void AddItem(Item newitem)
        => ScriptableItem = newitem;
}
