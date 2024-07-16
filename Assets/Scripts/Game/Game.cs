using System.Runtime.CompilerServices;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] private EnemyFactory _enemyFactory;
	[SerializeField] private EnemySpawnPoints _enemySpawnPoints;
	private EnemyCollection _enemyCollection = new EnemyCollection();

	[SerializeField, FloatRangeSlider(0.5f, 2f)] private FloatRange _sd = new FloatRange(1f);
	[SerializeField, IntRangeSlider(1, 10)] private FloatRange _enemyCount = new FloatRange(1);

	[Header("Задержка перед появлением врага, X - Mинимум, Y - Mаксимум")]
	[SerializeField] private Vector2 _spawnSpeed = new Vector2(1f, 2f);
	private float _spawnProgress;
	private float _nextSpawnTime;

	[Header("Скорость врага, X - Mинимум, Y - Mаксимум")]
	[SerializeField] private Vector2 _enemySpeed = new Vector2(1f, 2f);
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
			float enemySpeed = Random.Range(_enemySpeed.x, _enemySpeed.y);
			enemy.SetSpeed(enemySpeed);
			_enemyCollection.Add(enemy);
		}
	}

	private void TakeNextSpawnTime()
	{
		_nextSpawnTime = Random.Range(_spawnSpeed.x, _spawnSpeed.y);
	}
}
