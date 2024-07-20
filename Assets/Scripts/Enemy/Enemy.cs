using UnityEngine;

public class Enemy : Unit
{
	public EnemyFactory OriginFactory { get; set; }
	private Sprite _sprite;
	private float _speed;
	private int _health;

	public bool GameUpdate()
	{
		if (_health <= 0)
		{
			OriginFactory.Reclaim(this);
			return (false);
		}
		transform.localPosition += Vector3.down * _speed * Time.deltaTime;
		return true;
	}

	public void SpawnOn(EnemySpawnPoints spawnPoints)
	{
		transform.localPosition = spawnPoints.TakeRandomSpawnPoint().localPosition;
	}

	public void Init(float speed, int health)
	{
		_speed = speed;
		_health = health;
	}

	public void TakeDamage()
	{
		_health--;
	}

	private void ShowDamage()
	{
	}
}
