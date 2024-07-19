using UnityEngine;

public class GameSettings : MonoBehaviour
{
	[SerializeField] private BaseEnemyFactory _enemyFactory;
	public BaseEnemyFactory enemyFactory => _enemyFactory;
	[SerializeField] private EnemyType _enemyType;
	public EnemyType enemyType => _enemyType;

	[SerializeField] private EnemySpawnPoints _enemySpawnPoints;
	public EnemySpawnPoints enemySpawnPoints => _enemySpawnPoints;

	[SerializeField] private PlayerCharacter _playerCharacter;
	public PlayerCharacter playerCharacter => _playerCharacter;
}
