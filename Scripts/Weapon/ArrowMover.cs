using UnityEngine;

namespace Defender
{
    public class ArrowMover : MonoBehaviour
    {
        [SerializeField] private float _speed = 1.0f;
        [SerializeField] private float _destroyTime = 1.5f;

        private void Start()
        {
            Destroy(gameObject, _destroyTime);
        }

        private void Update()
        {
            transform.position += transform.up * _speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(10);
            }
        }
    }
}