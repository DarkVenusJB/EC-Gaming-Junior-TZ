using UnityEngine;

namespace GamePlayLogic
{
	public class Spawner : MonoBehaviour 
	{
		[Header("Spawn Parametres")]
		[SerializeField] float m_interval = 3;
		[SerializeField] private Transform m_moveTarget;
		[Header("Pool Parametres")]
		[SerializeField] private int m_poolCount = 10;
		[SerializeField] private bool m_autoExpand = false;
		[SerializeField] private Monster m_monsterPrefab;

		private ObjectPool<Monster> m_pool;
		private float m_lastSpawn = -1;
		
		private void Start()
		{
			m_pool = new ObjectPool<Monster>(m_monsterPrefab, m_poolCount, transform);
			m_pool.AutoExpand = m_autoExpand;
		}
		
		

		private void Update () 
		{
			if (Time.time > m_lastSpawn + m_interval)
			{
				var enemy = CreateMonster();
				enemy.MoveTarget = m_moveTarget;

				m_lastSpawn = Time.time;
			}
		}

		private Monster CreateMonster()
		{
			var monster = m_pool.GetFreeElement();
			monster.transform.position = transform.position;
			

			return monster;
		}
	}
}


