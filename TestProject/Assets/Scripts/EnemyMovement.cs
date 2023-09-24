using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int m_MovementSpeed;

    private bool _isFacingRight;
    private CircleCollider2D _triggetZone;

    public Transform Player;
    public int damageAmount;

    private void Awake()
    {
        _triggetZone = gameObject.GetComponentInChildren<CircleCollider2D>();
        damageAmount = gameObject.GetComponent<Combat>().m_damageAmount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player = collision.transform;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Combat>().TakeDamage(damageAmount);
            UnsetTarget();
        }
    }

    private void FixedUpdate()
    {
        if (Player != null && Vector2.Distance(gameObject.transform.position, Player.transform.position) > 0.1f)
        {
            Vector2 direction = (Player.position - transform.position).normalized;
            if (direction.x < 0 && !_isFacingRight)
                FlipEnemy();
            if (direction.x > 0 && _isFacingRight)
                FlipEnemy();
            transform.position += (Vector3)(direction * m_MovementSpeed * Time.deltaTime);
        }

        UnsetTarget();
    }

    private void FlipEnemy()
    {
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        _isFacingRight = !_isFacingRight;
    }

    private void UnsetTarget()
    {
        if (Player != null)
        {
            if (Vector2.Distance(gameObject.transform.position, Player.transform.position) > _triggetZone.radius)
                Player = null;
        }
    }
}
