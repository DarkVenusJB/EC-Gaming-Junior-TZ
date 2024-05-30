using UnityEngine;

namespace GamePlayLogic
{
	public class Monster : MonoBehaviour, IDamageble
	{
		private const float m_reachDistance = 0.3f;
		
		[SerializeField] private float m_speed = 5f;
		[SerializeField] private int m_maxHP = 30;
		[SerializeField] private int m_currentHP ;

		private Transform m_moveTarget;
		private Rigidbody m_rigidbody;

		public Transform MoveTarget
		{
			get {return m_moveTarget;}
			
			set {m_moveTarget = value;}
		}

		private void Start()
		{
			m_rigidbody = GetComponent<Rigidbody>();
			
			m_currentHP = m_maxHP;
		}

		private void Update () 
		{
			if (m_moveTarget == null)
				return;
		
			if (Vector3.Distance (transform.position, MoveTarget.position) <= m_reachDistance) 
			{
				Deactivate();
				return;
			}

			MoveToTheTarget();
		}
		
		public void Hit(int damage)
		{
			m_currentHP -= damage;
			
			if(m_currentHP<= 0)
				Die();
		}

		public void Die() => Deactivate();
		

		private void MoveToTheTarget()
		{
			Vector3 direction = MoveTarget.position - transform.position;
			m_rigidbody.velocity = direction.normalized * m_speed;
		}

		private void Deactivate()
		{
			m_currentHP = m_maxHP;
			gameObject.SetActive(false);
		}
	}
}


