using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] private GameSettings _gameSettings;

	private EnemyCollection _enemyCollection = new EnemyCollection();
	[SerializeField, IntRangeSlider(1, 45)] 
	private IntRange _enemyCount = new IntRange(10,15);

	[SerializeField, FloatRangeSlider(0.5f, 3f)] 
	private FloatRange _spawnSpeed = new FloatRange(1f,2f);
	private float _spawnProgress;
	private float _nextSpawnTime;

	

	[SerializeField] private float _playerAttackRange = 8f;
	[SerializeField] private float _playerAttackSpeed = 1f;
	[SerializeField] private int _playerAttackDamage = 1;
	[SerializeField] private float _playerBulletSpeed = 10f;

	private void Awake()
	{
		TakeNextSpawnTime();
		SetupPlayerSettings();
		SpawnEnemy(_gameSettings.enemyFactory, _gameSettings.TakeRndEnemy()) ;
	}

	private void Update()
	{
		CheckEnemySpawn();

		_enemyCollection.GameUpdate();
		_gameSettings.playerCharacter.GameUpdate();
	}

	private void SetupPlayerSettings()
	{
		_gameSettings.playerCharacter.InitPlayer(_playerAttackRange, _playerAttackSpeed);
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
		Enemy enemy = _gameSettings.enemyFactory.Get(enemyType);
		enemy.SpawnOn(_gameSettings.enemySpawnPoints);
		_enemyCollection.Add(enemy);
	}

	private void TakeNextSpawnTime()
	{
		_nextSpawnTime = _spawnSpeed.RandomValueInRange;
	}
}
