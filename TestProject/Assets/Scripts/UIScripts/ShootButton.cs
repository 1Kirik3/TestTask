using System.Collections.Generic;
using UnityEngine;

public class ShootButton : MonoBehaviour
{
    [SerializeField] private GameObject m_player;

    public void CanShoot()
    {
        List<Item> weapons = InventoryManager.Instance.Items.FindAll(item => item.IsWeapon);
        if (weapons.Count > 0 && InventoryManager.Instance.CurrentAmmo > 0)
            InventoryManager.Instance.CanShoot = true;
    }
}
