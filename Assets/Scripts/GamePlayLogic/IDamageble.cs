namespace Scripts.GamePlayLogic
{
    public interface IDamageble
    {
        public void Hit(int damage);

        public void Die();
    }
}