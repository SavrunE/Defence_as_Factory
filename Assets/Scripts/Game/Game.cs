using Unity.VisualScripting;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] private GameSettings _gameSettings;

	private EnemyCollection _enemyCollection = new EnemyCollection();
	private BulletCollection _bulletCollection = new BulletCollection();
	[SerializeField, IntRangeSlider(1, 45)]
	private IntRange _enemyCount = new IntRange(10, 15);
	private int _calcEnemyCount;
	private int _currentEnemyCount;

	[SerializeField, FloatRangeSlider(0.5f, 5f)]
	private FloatRange _spawnSpeed = new FloatRange(2f, 3.5f);
	private float _spawnTimeProgress;
	private float _nextSpawnTime;

	[SerializeField] private int _playerHealth = 5;
	private int _currentPlayerHealth;
	[SerializeField] private float _playerSpeed = 1f;
	[SerializeField] private float _playerAttackRange = 8f;
	[SerializeField] private float _playerAttackSpeed = 1f;
	[SerializeField] private int _playerAttackDamage = 1;
	[SerializeField] private float _playerBulletSpeed= 10f;

	private static Game _instance;

	private void Awake()
	{
		_instance = this;
		_currentPlayerHealth = _playerHealth;
		_calcEnemyCount = _enemyCount.randomValueInRange;
		_gameSettings.UpdatePlayerHealth(_currentPlayerHealth);
		TakeNextSpawnTime();
		SetupPlayerSettings();
		SpawnEnemy(_gameSettings.enemyFactory, _gameSettings.TakeRndEnemy());
		_enemyCollection.onEnemiesZero += WinGame;
		_gameSettings.gameMenuWindow.onRestartClicked += Restart;
	}

	private void Update()
	{
		TrySpawn();

		_enemyCollection.GameUpdate();
		_bulletCollection.GameUpdate();
		_gameSettings.playerCharacter.GameUpdate();
	}

	private void WinGame()
	{
		if (_currentEnemyCount == _calcEnemyCount)
		{
			_gameSettings.ShowGameMenu(GameResultType.Victory);
		}
	}

	private void LoseGame()
	{
		_gameSettings.ShowGameMenu(GameResultType.Defeat);
	}

	public void Restart()
	{
		_spawnTimeProgress = 0f;
		_currentEnemyCount = 0;
		_enemyCollection.DestructionAll();
		Awake();
	}

	public void TakeDamage(int damage = 1)
	{
		_currentPlayerHealth -= damage;
		ShowDamage();
		if (_currentPlayerHealth <= 0)
		{
			LoseGame();
		}
	}

	private void ShowDamage()
	{
		_gameSettings.UpdatePlayerHealth(_currentPlayerHealth);
	}

	private void SetupPlayerSettings()
	{
		_gameSettings.playerCharacter.InitPlayer(_playerSpeed, _playerAttackRange, _playerAttackSpeed, _playerBulletSpeed, _playerAttackDamage);
	}

	private void TrySpawn()
	{
		_spawnTimeProgress += Time.deltaTime;
		if (_spawnTimeProgress >= _nextSpawnTime)
		{
			_spawnTimeProgress -= _nextSpawnTime;
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

	public static Bullet SpawnBullet()
	{
		Bullet bullet = _instance._gameSettings.bulletFactory.bullet;
		_instance._bulletCollection.Add(bullet);
		return bullet;
	}

	private void TakeNextSpawnTime()
	{
		_nextSpawnTime = _spawnSpeed.randomValueInRange;
	}
}
