using UnityEngine;

[CreateAssetMenu(menuName = "Factory/BaseEnemyFactory")]
public class BaseEnemyFactory : EnemyFactory
{
    [SerializeField] private EnemyConfig _baseEnemy, _mediumEnemy, _hardEnemy, _fatEnemy, _fastEnemy;

    protected override EnemyConfig GetConfig(EnemyType type)
    {
        switch (type)
        {
            case EnemyType._baseEnemy:
                return _baseEnemy;
            case EnemyType._mediumEnemy:
				return _mediumEnemy;
            case EnemyType._hardEnemy:
				return _hardEnemy;
            case EnemyType._fatEnemy:
				return _fatEnemy;
            case EnemyType._fastEnemy:
				return _fastEnemy;
        }
        Debug.LogError($"No config for: {type}");
        return _baseEnemy;
    }
}
