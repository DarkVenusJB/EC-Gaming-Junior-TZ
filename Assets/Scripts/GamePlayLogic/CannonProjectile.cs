using System.Collections;
using UnityEngine;

namespace GamePlayLogic
{
	public class CannonProjectile : Projectile
	{
		[SerializeField] private float m_lifeTime=5f;
		
		private void OnEnable() => StartCoroutine(LifeRoutine());
		
		private void OnDisable() => StopCoroutine(LifeRoutine());
		
		protected override void Move(float speed)
		{
			var translation = transform.forward * (speed * Time.deltaTime);
			transform.Translate (translation);
		}

		private IEnumerator LifeRoutine()
		{
			yield return new WaitForSeconds(m_lifeTime);
			
			Deactivate();
		}
	}
}



