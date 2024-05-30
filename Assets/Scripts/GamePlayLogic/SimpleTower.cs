namespace GamePlayLogic
{
	public class SimpleTower : Tower
	{
		private void Update()
		{
			CheckEnemy();

			if (Target!=null && CanShoot)
			{
				Shot();
				StartCoroutine(ShootReload());
			}
		}
		
		protected override void Shot() =>CreateProjectile();
	}
}


