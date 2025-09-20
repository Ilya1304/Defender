using System.Collections;
using UnityEngine;

namespace Defender
{
    public class Crossbow : MonoBehaviour
    {
        [SerializeField] private GameObject _arrow;
        [SerializeField] private float _delay = 1f;

        private void Start()
        {
            StartCoroutine(ShootCooldown());
        }

        private void Update()
        {
            RotateToMouse();
        }

        private void RotateToMouse()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDerection = mousePosition - (Vector2)transform.position;
            transform.up = lookDerection;
        }

        private void Shoot()
        {
            Instantiate(_arrow, transform.position, transform.rotation);
        }

        private IEnumerator ShootCooldown()
        {
            while (true)
            {
                if (Input.GetMouseButton(0))
                    Shoot();
                yield return new WaitForSeconds(_delay);
            }
        }
    }
}