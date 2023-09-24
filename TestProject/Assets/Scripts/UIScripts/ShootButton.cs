using System.Collections.Generic;
using UnityEngine;

public class ShootButton : MonoBehaviour
{

    public void Shoot()
    {
        if (CanShoot())
            InventoryManager.Instance.CurrentAmmo--;
    }

    public bool CanShoot()
    {
        List<Item> weapons = InventoryManager.Instance.Items.FindAll(item => item.IsWeapon);
        return (InventoryManager.Instance.CurrentAmmo > 0 && weapons.Count > 0);
    }
}
