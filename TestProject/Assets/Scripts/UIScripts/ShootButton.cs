using System.Collections.Generic;
using UnityEngine;

public class ShootButton : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    private DetectEnemies _playerDetector;
    private Combat _playerCombat;

    private void Awake()
    {
        _playerDetector = m_player.GetComponentInChildren<DetectEnemies>();
        _playerCombat = m_player.GetComponent<Combat>();
    }

    public void CanShoot()
    {
        List<Item> weapons = InventoryManager.Instance.Items.FindAll(item => item.IsWeapon);
        if (weapons.Count > 0 && InventoryManager.Instance.CurrentAmmo > 0)
            InventoryManager.Instance.CanShoot = true;
    }
}
