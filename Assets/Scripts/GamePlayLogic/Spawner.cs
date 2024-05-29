using UnityEngine;

namespace Scripts.GamePlayLogic
{
	public class Spawner : MonoBehaviour 
	{
		[SerializeField] float m_interval = 3;
		[SerializeField] private Transform m_moveTarget;
		[SerializeField] private Monster monster;
		
		private float m_lastSpawn = -1;

		private void Update () 
		{
			if (Time.time > m_lastSpawn + m_interval)
			{
				Monster enemy = Instantiate(monster, transform.position, Quaternion.identity);
				enemy.MoveTarget = m_moveTarget;

				m_lastSpawn = Time.time;
			}
		}
	}
}


