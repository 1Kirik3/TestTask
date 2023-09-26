using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject m_player;

    private void Update()
    {
        gameObject.transform.position = new Vector3(m_player.transform.position.x, m_player.transform.position.y, m_player.transform.position.z - 10);
    }
}
