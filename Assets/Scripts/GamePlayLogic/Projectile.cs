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
            
            set {m_target = value;}
        }
        
        public Vector3 Direction { get; set; }
        
        public float Speed => m_speed;

        protected abstract void Move(float speed);
        
        private void Update() => Move(m_speed);
        
        private void OnTriggerEnter(Collider other)
        {
            bool isMonster = other.gameObject.TryGetComponent(out IDamageble monster);

            if (isMonster)
                monster.Hit(m_damage);
			
            Deactivate();
        }

        private void OnCollisionEnter(Collision other)
        {
            bool isMonster = other.gameObject.TryGetComponent(out IDamageble monster);

            if (isMonster)
                monster.Hit(m_damage);
			
            Deactivate();
        }

        protected void Deactivate()
        {
            gameObject.transform.position = transform.parent.position;
            if (gameObject.GetComponent<Rigidbody>() != null)
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            gameObject.SetActive(false);
        }
    }
}