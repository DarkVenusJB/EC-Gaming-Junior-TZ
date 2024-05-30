using UnityEngine;
using UnityEngine.Serialization;

namespace GamePlayLogic
{
	public class CannonTower : Tower
	{
		[Header("Cannon Rotation")]
		[SerializeField] private CannonRotator m_rotator;
		[FormerlySerializedAs("m_rotateSpeed")] [SerializeField] private float m_cannonRotateSpeed =5f;
		
		private void Update()
        {
	        CheckEnemy();
            
            if(Target ==null)
	            return;
            
            m_rotator.RotateCannon(CalculateTargetCorrection()-ShootPoint.position,m_cannonRotateSpeed);
            
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
			float correction = Mathf.Atan2(Target.GetComponent<Rigidbody>().velocity.x,Target.GetComponent<Rigidbody>().velocity.y);

			Vector3 shootPosition = Target.position + (direction + new Vector3(correction,0 ,0))*distance;

			return(shootPosition)*ProjectileSpeed;
		}
	}
}

