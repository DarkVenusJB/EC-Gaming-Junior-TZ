using UnityEngine;

namespace GamePlayLogic
{
	public class GuidedProjectile : Projectile
	{
		protected override void Move(float speed)
		{
			if (Target == null) 
			{
				Deactivate();
				return;
			}
			
			transform.position	= Vector3.MoveTowards(transform.position, Target.position , speed *Time.deltaTime);
		}
	}
}

