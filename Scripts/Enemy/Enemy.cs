using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defender
{
    public class Enemy : MonoBehaviour
    {
        [Header("Speed Settings")]
        [SerializeField] private float _baseSpeed = 1.0f;
        [SerializeField] private float _speedPerlInterval = 0.2f;

        [Header("Attack Settings")]
        [SerializeField] private float _attackInterval = 1.0f;
        [SerializeField] private int _killReward = 1;
        [SerializeField] private int _health = 1;
        [SerializeField] private Corn _target;

        [Space(20)]
        [SerializeField] private Animator _animator;

        private bool _isMoving = true;
        private float _borderTargetX;
        private float _currentSpeed;
        private Coroutine _coroutine;

        public static List<Enemy> ActiveEnemies = new List<Enemy>();

        private void Start()
        {
            _currentSpeed = _baseSpeed + _speedPerlInterval + LevelController.Level;
        }

        private void OnEnable()
        {
            ActiveEnemies.Add(this);
        }

        private void OnDisable()
        {
            ActiveEnemies.Remove(this);
        }

        private void Update()
        {
            if (_target == false) return;

            _isMoving = transform.position.x > _borderTargetX;
            _animator.SetBool("IsMoving", _isMoving);

            if (_isMoving)
            {
                Move();
            }
            else if (_coroutine == null)
            {
                _coroutine = StartCoroutine(DelayAttack());
            }
        }

        private void Move()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            transform.position += -transform.right * (_currentSpeed * Time.deltaTime);
        }

        private IEnumerator DelayAttack()
        {
            while (true)
            {
                _target.TakeDamage();
                yield return new WaitForSeconds(_attackInterval);
            }
        }

        public void TakeDamage(int value)
        {
            _health -= value;

            if (_health <= 0)
            {
                _target.AddCrystals(_killReward);
                Destroy(gameObject);
            }
        }

        public void SetTarget(Corn corn)
        {
            _target = corn;
            _borderTargetX = corn.transform.position.x;
        }
    }
}