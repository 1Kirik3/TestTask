using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public bool IsStackable;
    public bool IsWeapon;
    public bool IsOutfit;
    public int ID;
    public int ItemAmount;
    public string ItemName;
    public Sprite ItemIcon;
 
}
