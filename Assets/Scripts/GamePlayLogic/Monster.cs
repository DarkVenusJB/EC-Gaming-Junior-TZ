using UnityEngine;

namespace Scripts.GamePlayLogic
{
	public class Monster : MonoBehaviour, IDamageble
	{
		private const float m_reachDistance = 0.3f;
	
		 // TODO исправить публичное поле
		[SerializeField] private float m_speed = 5f;
		[SerializeField] private int m_maxHP = 30;
		[SerializeField] private int m_currentHP ;

		private Transform m_moveTarget;

		public Transform MoveTarget
		{
			get
			{
				return m_moveTarget;
			}

			set
			{
				if (m_moveTarget == null)
				{
					m_moveTarget = value;
				}
			}
		}
		
		private void Start() 
		{
			m_currentHP = m_maxHP;
		}

		private void Update () 
		{
			if (m_moveTarget == null)
				return;
		
			if (Vector3.Distance (transform.position, MoveTarget.position) <= m_reachDistance) 
			{
				Destroy (gameObject);
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

		public void Die()
		{
			Destroy(gameObject);
		}

		private void MoveToTheTarget()
		{
			transform.position	= Vector3.MoveTowards(transform.position, MoveTarget.position , m_speed *Time.deltaTime);
		}
	}
}


