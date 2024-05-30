using System.Collections;
using UnityEngine;

namespace GamePlayLogic
{
	public class CannonProjectile : Projectile
	{
		[SerializeField] private float m_lifeTime=5f;

		private Rigidbody m_rigidbody;

		private void Start() => m_rigidbody = GetComponent<Rigidbody>();
		
		private void OnEnable() => StartCoroutine(LifeRoutine());
		
		private void OnDisable() => StopCoroutine(LifeRoutine());
		
		protected override void Move(float speed)
		{
			m_rigidbody.velocity = Direction * speed;
		}

		private IEnumerator LifeRoutine()
		{
			yield return new WaitForSeconds(m_lifeTime);
			
			Deactivate();
		}
	}
}



