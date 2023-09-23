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
        InventoryManager.Instance.AddItem(ScriptableItem);
        Destroy(gameObject);
    }
}
