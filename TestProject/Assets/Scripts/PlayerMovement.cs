using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // ChatGPT code with some changes
    [SerializeField] private FixedJoystick m_fixedJoystick;
    [SerializeField] private float m_movementSpeed;
    [SerializeField] private Healthbar m_healthbar;

    private Rigidbody2D _playerRigidbody;
    private bool _isFacingRight;

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _playerRigidbody.velocity = new Vector2(m_fixedJoystick.Horizontal * m_movementSpeed, m_fixedJoystick.Vertical * m_movementSpeed);

        if (m_fixedJoystick.Horizontal < 0 && !_isFacingRight)
            FlipPlayer();
        if (m_fixedJoystick.Horizontal > 0 && _isFacingRight)
            FlipPlayer();
    }

    private void FlipPlayer()
    {
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        m_healthbar.gameObject.transform.localScale *= Mathf.Sign(gameObject.transform.localScale.x);
        if (_isFacingRight)
            m_healthbar.gameObject.transform.localScale *= -1;
        _isFacingRight = !_isFacingRight;
    }
}
