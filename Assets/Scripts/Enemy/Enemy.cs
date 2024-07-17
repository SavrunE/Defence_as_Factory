using UnityEngine;

public class Enemy : Unit
{
	public EnemyFactory OriginFactory { get; set; }
	private float _speed;

	public bool GameUpdate()
	{
		transform.localPosition += Vector3.down * _speed * Time.deltaTime;
		return true;
	}

	public void SpawnOn(EnemySpawnPoints spawnPoints)
	{
		transform.localPosition = spawnPoints.TakeRandomSpawnPoint().localPosition;
	}

	public void SetSpeed(float speed)
	{
		_speed = speed;
	}
}
