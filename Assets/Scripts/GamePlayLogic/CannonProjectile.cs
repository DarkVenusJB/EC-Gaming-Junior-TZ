namespace Scripts.GamePlayLogic
{
	public class CannonProjectile : Projectile 
	{
		protected override void Move(float speed)
		{
			var translation = transform.forward * speed;
			transform.Translate (translation);
		}
	}
}



