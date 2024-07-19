using UnityEngine;

[CreateAssetMenu(menuName = "Factory/NextLvlPlayEnemyFactory")]
public class NextLvlPlayEnemyFactory : EnemyFactory
{
	[SerializeField] private EnemyConfig _nlpBaseEnemy, _nlpMediumEnemy, _nlpHardEnemy, _nlpFatEnemy, _nlpFastEnemy;

	protected override EnemyConfig GetConfig(EnemyType type)
	{
		switch (type)
		{
			case EnemyType._baseEnemy:
				return _nlpBaseEnemy;
			case EnemyType._mediumEnemy:
				return _nlpMediumEnemy;
			case EnemyType._hardEnemy:
				return _nlpHardEnemy;
			case EnemyType._fatEnemy:
				return _nlpFatEnemy;
			case EnemyType._fastEnemy:
				return _nlpFastEnemy;
		}
		Debug.LogError($"No config for: {type}");
		return _nlpBaseEnemy;
	}
}
