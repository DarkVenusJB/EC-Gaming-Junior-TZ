using UnityEngine;

namespace GamePlayLogic
{
	public class SimpleTower : Tower
	{
		protected override void Shot()
		{
			Projectile projectile = CreateProjectile();
		}
	}
}


