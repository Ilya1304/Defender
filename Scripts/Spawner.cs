using UnityEngine;

namespace Defender
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Corn _target;
        [SerializeField] private Transform _topBorder;
        [SerializeField] private Transform _bottomBorder;
        [SerializeField] private float _spawnIntervalMin = 1f;
        [SerializeField] private float _spawnIntervalMax = 3.5f;
        [SerializeField] private int _baseSpawnCount = 1;
        [SerializeField] private float _spawnTimer = 0;


        public int SpawnCounter { get; private set; }

        private void Start()
        {
            SpawnCounter = _baseSpawnCount;
        }

        private void Update()
        {
            if (LevelController.IsFinished) return;
            if (SpawnCounter <= 0) return;

            _spawnTimer -= Time.deltaTime;

            if (_spawnTimer <= 0)
            {
                SpawnEnemy();
            }
        }

        public void InitSpawner(int value)
        {
            SpawnCounter = _baseSpawnCount + value;
        }

        private void SpawnEnemy()
        {
            SpawnCounter--;
            _spawnTimer = Random.Range(_spawnIntervalMin, _spawnIntervalMax);

            float randomY = Random.Range(_bottomBorder.position.y, _topBorder.position.y);
            Vector2 spawnPosition = new(transform.position.x, randomY);

            Enemy enemy = Instantiate(_enemy, spawnPosition, Quaternion.identity);
            enemy.SetTarget(_target);
        }
    }
}