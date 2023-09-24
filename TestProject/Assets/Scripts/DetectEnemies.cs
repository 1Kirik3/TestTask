using System.Collections.Generic;
using UnityEngine;

public class DetectEnemies : MonoBehaviour
{
    private float _minDistance;

    public GameObject NearestEnemy;
    public List<GameObject> Enemies = new List<GameObject>();

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
                if (Vector2.Distance(enemy.gameObject.transform.position, this.gameObject.transform.position) < _minDistance)
                {
                    NearestEnemy = enemy;
                    _minDistance = Vector2.Distance(enemy.gameObject.transform.position, this.gameObject.transform.position);
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

    public void DealDamage(int damage)
    {
        if (NearestEnemy != null && InventoryManager.Instance.CurrentAmmo != 0)
            NearestEnemy.GetComponent<Combat>().TakeDamage(damage);
    }
}
