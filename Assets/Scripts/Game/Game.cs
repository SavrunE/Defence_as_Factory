using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] private GameSettings _gameSettings;

	private EnemyCollection _enemyCollection = new EnemyCollection();
	[SerializeField, IntRangeSlider(1, 45)]
	private IntRange _enemyCount = new IntRange(10, 15);
	private int _calcEnemyCount;
	private int _currentEnemyCount;

	[SerializeField, FloatRangeSlider(0.5f, 3f)]
	private FloatRange _spawnSpeed = new FloatRange(1f, 2f);
	private float _spawnProgress;
	private float _nextSpawnTime;

	[SerializeField] private int _playerHealth = 5;
	[SerializeField] private float _playerSpeed = 1f;
	[SerializeField] private float _playerAttackRange = 8f;
	[SerializeField] private float _playerAttackSpeed = 1f;
	[SerializeField] private int _playerAttackDamage = 1;
	[SerializeField] private float _playerBulletSpeed = 10f;

	private void Awake()
	{
		_calcEnemyCount = _enemyCount.randomValueInRange;
		_gameSettings.SetHp(_playerHealth);
		TakeNextSpawnTime();
		SetupPlayerSettings();
		SpawnEnemy(_gameSettings.enemyFactory, _gameSettings.TakeRndEnemy());
		_enemyCollection.onEnemiesZero += WinGame;
	}

	private void WinGame()
	{
		if (_currentEnemyCount == _calcEnemyCount)
			Debug.Log("end");
	}

	private void Update()
	{
		CheckEnemySpawn();

		_enemyCollection.GameUpdate();
		_gameSettings.playerCharacter.GameUpdate();
	}

	private void SetupPlayerSettings()
	{
		_gameSettings.playerCharacter.InitPlayer(_playerSpeed, _playerAttackRange, _playerAttackSpeed, _playerAttackDamage);
	}

	private void CheckEnemySpawn()
	{
		_spawnProgress += Time.deltaTime;
		if (_spawnProgress >= _nextSpawnTime)
		{
			_spawnProgress -= _nextSpawnTime;
			SpawnEnemy(_gameSettings.enemyFactory, _gameSettings.TakeRndEnemy());
		}
	}

	private void SpawnEnemy(EnemyFactory factory, EnemyType enemyType)
	{
		if (_currentEnemyCount < _calcEnemyCount)
		{
			_currentEnemyCount++;
			Enemy enemy = _gameSettings.enemyFactory.Get(enemyType);
			enemy.transform.parent = _gameSettings.enemiesParent.transform;
			enemy.SpawnOn(_gameSettings.enemySpawnPoints);
			_enemyCollection.Add(enemy);
		}
	}

	private void TakeNextSpawnTime()
	{
		_nextSpawnTime = _spawnSpeed.randomValueInRange;
	}
}
