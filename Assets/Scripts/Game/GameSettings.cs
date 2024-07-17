using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
	[SerializeField] private EnemyFactory _enemyFactory;
	public EnemyFactory enemyFactory => _enemyFactory;

	[SerializeField] private EnemySpawnPoints _enemySpawnPoints;
	public EnemySpawnPoints enemySpawnPoints => _enemySpawnPoints;

	[SerializeField] private PlayerCharacter _playerCharacter;
	public PlayerCharacter playerCharacter => _playerCharacter;
}
