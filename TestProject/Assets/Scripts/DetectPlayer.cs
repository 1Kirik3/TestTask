using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private EnemyMovement _currentEnemy;
    private void Awake()
    {
        _currentEnemy = gameObject.GetComponentInParent<EnemyMovement>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _currentEnemy.Player = collision.transform;
        }
    }
}
