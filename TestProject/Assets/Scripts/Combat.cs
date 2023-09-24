using System.Collections;
using UnityEngine;

public class Combat : MonoBehaviour, IDamagable
{
    [SerializeField] private float m_InvincibleTime;
    [SerializeField] private GameObject m_drop;
    [SerializeField] private Healthbar m_healthbar;

    private bool _isInvincible = false;
    
    public int m_healthPoints;
    public int m_damageAmount;

    private void Start()
    {
        if (m_healthbar != null)
            m_healthbar.SetMaxHealth(m_healthPoints);
    }

    public void TakeDamage(int damageAmount)
    {
        if (!_isInvincible)
        {
            StartCoroutine(AttackCooldown());
            m_healthPoints -= damageAmount;
            m_healthbar.SetHealth(m_healthPoints);
            if (m_healthPoints <= 0)
            {
                Instantiate(m_drop);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator AttackCooldown()
    {
        _isInvincible = true;
        yield return new WaitForSeconds(m_InvincibleTime);
        _isInvincible = false;
    }
}
