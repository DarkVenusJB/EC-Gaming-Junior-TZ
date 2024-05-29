
using UnityEngine;

namespace Scripts.GamePlayLogic
{
	public class CannonTower : Tower
	{
		protected override void Shot(Projectile projectilePrefab, Transform shootPoint ,Transform target)
		{
			if(shootPoint != null)
				 Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
		}
	}
}

