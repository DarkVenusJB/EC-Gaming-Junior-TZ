using UnityEngine;

namespace GamePlayLogic
{
	public class CannonTower : Tower
	{
		private Monster m_monster =null;
		
		private void Update()
        {
	        CheckEnemy();
            
            if(Target ==null)
	            return;
            
            transform.LookAt((CalculateTargetCorrection() -ShootPoint.position));
            
            if (CanShoot)
            {
	            Shot();
                StartCoroutine(ShootReload());
            }
        }

		protected override void Shot()
		{
			Projectile projectile =CreateProjectile();
			projectile.Direction = ShootPoint.transform.forward;
		}
		
		private Vector3 CalculateTargetCorrection()
		{
			Vector3 direction = Target.position - ShootPoint.position;
			float distance = Vector3.Distance(ShootPoint.position,Target.position);
			float correction =Mathf.Atan2(Target.GetComponent<Rigidbody>().velocity.x,Target.GetComponent<Rigidbody>().velocity.y);

			Vector3 shootPosition = Target.position + (direction + new Vector3(correction,0 , 0))*distance;

			return (shootPosition)*ProjectileSpeed;
		}
	}
}

