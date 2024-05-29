using UnityEngine;

namespace Scripts.GamePlayLogic
{
	public class SimpleTower : Tower
	{
		protected override void Shot(Projectile projectilePrefab, Transform shootPoint,Transform target)
		{
			Projectile projectile =  Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
			projectile.Target = target;
		}
	}
}


