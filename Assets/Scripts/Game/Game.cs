using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] private EnemyFactory _enemyFactory;
	[SerializeField] private EnemySpawnPoints _enemySpawnPoints;

	private EnemyCollection _enemyCollection = new EnemyCollection();
	[SerializeField, IntRangeSlider(1, 45)] 
	private IntRange _enemyCount = new IntRange(10,15);

	[SerializeField, FloatRangeSlider(0.5f, 3f)] 
	private FloatRange _spawnSpeed = new FloatRange(1f,2f);
	private float _spawnProgress;
	private float _nextSpawnTime;

	[SerializeField, FloatRangeSlider(0.5f, 3f)] 
	private FloatRange _enemySpeed = new FloatRange(1f, 2f);
	[SerializeField] private int _enemyHealth = 3;

	[SerializeField] private float _playerAttackRange = 8f;
	[SerializeField] private float _playerAttackSpeed = 0.5f;
	[SerializeField] private int _playerAttackDamage = 1;
	[SerializeField] private float _playerBulletSpeed = 10f;

	private void Awake()
	{
		TakeNextSpawnTime();
	}

	private void Update()
	{
		CheckEnemySpawn();
		_enemyCollection.GameUpdate();
	}

	private void CheckEnemySpawn()
	{
		_spawnProgress += Time.deltaTime;
		if (_spawnProgress >= _nextSpawnTime)
		{
			_spawnProgress -= _nextSpawnTime;
			Enemy enemy = _enemyFactory.Get();
			enemy.SpawnOn(_enemySpawnPoints);
			enemy.SetSpeed(_enemySpeed.RandomValueInRange);
			_enemyCollection.Add(enemy);
		}
	}

	private void TakeNextSpawnTime()
	{
		_nextSpawnTime = _spawnSpeed.RandomValueInRange;
	}
}
