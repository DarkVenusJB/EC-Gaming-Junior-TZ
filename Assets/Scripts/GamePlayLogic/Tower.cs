using System.Collections;
using UnityEngine;

namespace Scripts.GamePlayLogic
{
    public abstract class Tower : MonoBehaviour
    {
        [SerializeField] private float m_shootInterval = 0.5f;
        [SerializeField] private float m_range = 4f;
        [SerializeField] private Transform m_shootPoint;
        [SerializeField] private LayerMask m_enemyLayer;
        [SerializeField] private Projectile m_projectilePrefab;

        private Transform m_target;
        private bool m_canShoot = true;

        protected abstract void Shot(Projectile projectile, Transform shootPoint, Transform shootTarget);
		
        private void Update()
        {
            CheckEnemy();

            if (m_target!=null && m_canShoot)
            {
                Shot(m_projectilePrefab, m_shootPoint, m_target);
                StartCoroutine(shootReload());
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

        private IEnumerator shootReload()
        {
            m_canShoot = false;

            yield return new WaitForSeconds(m_shootInterval);

            m_canShoot = true;
        }
    }
}