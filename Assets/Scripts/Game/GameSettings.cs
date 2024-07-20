using UnityEngine;

public class GameSettings : MonoBehaviour
{
	[SerializeField] private EnemyFactory _enemyFactory;
	public EnemyFactory enemyFactory => _enemyFactory;
	[SerializeField] private EnemyType[] _enemyType;
	public EnemyType[] enemyType => _enemyType;

	[SerializeField] private EnemySpawnPoints _enemySpawnPoints;
	public EnemySpawnPoints enemySpawnPoints => _enemySpawnPoints;

	[SerializeField] private PlayerCharacter _playerCharacter;
	public PlayerCharacter playerCharacter => _playerCharacter;

	public GameObject enemiesHolder;

	public EnemyType TakeRndEnemy()
	{
		if (enemyType.Length != 0)
		{
			var rnd = Random.Range(0, enemyType.Length);
			return enemyType[rnd];
		}
		return EnemyType._baseEnemy;
	}
}
