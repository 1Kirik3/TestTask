using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_enemy;
    [SerializeField] private int m_spawnTimes;

    private BoxCollider2D _spawnArea;

    private void Awake()
    {
        _spawnArea = gameObject.GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        float xRange = _spawnArea.bounds.size.x/2;
        float yRange = _spawnArea.bounds.size.y/2;
        Vector2 spawnPoint;
        for (int i = 0; i < m_spawnTimes; i++)
        {
            spawnPoint = new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange));
            Instantiate(m_enemy, spawnPoint, Quaternion.identity);
        }
    }
}
