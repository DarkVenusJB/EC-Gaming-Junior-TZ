using UnityEngine;

namespace GamePlayLogic
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private float m_speed = 8f;
        [SerializeField] int m_damage = 10;

        private Transform m_target;

        public Transform Target
        {
            get{return m_target;}
            
            set
            {
                if (m_target == null)
                    m_target = value;
            }
        }
        
        protected abstract void Move(float speed);
        
        private void Update() => Move(m_speed);

        private void OnTriggerEnter(Collider other)
        {
            bool isMonster = other.gameObject.TryGetComponent(out IDamageble monster);

            if (isMonster)
                monster.Hit(m_damage);
			
            Deactivate();
        }

        protected void Deactivate()
        {
            gameObject.transform.position = transform.parent.position;
            gameObject.SetActive(false);
            
        }
           
    }
}