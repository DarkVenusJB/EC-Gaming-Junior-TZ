namespace Scripts.GamePlayLogic
{
	public class GuidedProjectile : Projectile
	{
		protected override void Move(float speed)
		{
			if (Target == null) 
			{
				Destroy (gameObject);
				return;
			}

			var translation = Target.transform.position - transform.position;
			
			if (translation.magnitude > speed) 
			{
				translation = translation.normalized * speed;
			}
			
			transform.Translate (translation);
		}
	}
}

