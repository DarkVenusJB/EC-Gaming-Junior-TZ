using System;
using System.Collections;
using UnityEngine;

namespace GamePlayLogic
{
    public abstract class Tower : MonoBehaviour
    {
        [Header("Shoot Parametres")]
        [SerializeField] private float m_shootInterval = 0.5f;
        [SerializeField] private float m_range = 4f;
        [SerializeField] private Transform m_shootPoint;
        [SerializeField] private LayerMask m_enemyLayer;
        [Header("Pool Parametres")]
        [SerializeField] private int m_poolCount = 10;
        [SerializeField] private bool m_autoExpand = false;
        [SerializeField] private Projectile m_projectilePrefab;

        private ObjectPool<Projectile> m_pool;
        private Transform m_target;
        private bool m_canShoot = true;

        protected abstract void Shot();

        private void Start()
        {
            m_pool = new ObjectPool<Projectile>(m_projectilePrefab, m_poolCount, transform);
            m_pool.AutoExpand = m_autoExpand;
        }
        

        private void Update()
        {
            CheckEnemy();

            if (m_target!=null && m_canShoot)
            {
                Shot();
                StartCoroutine(ShootReload());
            }
        }

        private void CheckEnemy()
        {
            if (m_target == null)
            {
                Collider[] checkedEnemyes = Physics.OverlapSphere(transform.position,m_range,m_enemyLayer);

                foreach (var enemy in checkedEnemyes)
                {
                    m_target = enemy.transform;
                    return;
                }
            }
            
            else if (Vector3.Distance(m_shootPoint.position, m_target.position)>m_range)
                m_target = null;
        }

        private IEnumerator ShootReload()
        {
            m_canShoot = false;

            yield return new WaitForSeconds(m_shootInterval);

            m_canShoot = true;
        }

        protected Projectile CreateProjectile()
        {
            if (m_shootPoint != null)
            {
                var projectile = m_pool.GetFreeElement();
                projectile.transform.position = m_shootPoint.position;
                projectile.Target = m_target;
            
                return projectile;
            }
            
            throw new Exception("Shoot point is null!");
        }
        
    }
}