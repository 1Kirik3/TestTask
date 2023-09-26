using System.Collections.Generic;
using UnityEngine;

public class DetectEnemies : MonoBehaviour
{
    [SerializeField] private ShootButton m_shootButton;
    private float _minDistance;
    private int _damage;

    public GameObject NearestEnemy;
    public List<GameObject> Enemies = new List<GameObject>();

    private void Awake()
    {
        _damage = GetComponentInParent<Combat>().m_damageAmount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _minDistance = 100;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemies.Add(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            foreach (GameObject enemy in Enemies)
            {
                if (Vector2.Distance(enemy.gameObject.transform.position, gameObject.transform.position) < _minDistance)
                {
                    NearestEnemy = enemy;
                    _minDistance = Vector2.Distance(enemy.gameObject.transform.position, gameObject.transform.position);
                }

            }
        }            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemies.Remove(collision.gameObject);
            NearestEnemy = null;
        }
    }

    public void DealDamage()
    {        
        if (NearestEnemy != null && InventoryManager.Instance.CanShoot)
        {
            NearestEnemy.GetComponent<Combat>().TakeDamage(_damage);
            InventoryManager.Instance.CurrentAmmo--;
        }
    }
}
