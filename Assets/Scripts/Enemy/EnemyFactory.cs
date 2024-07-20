using System;
using UnityEngine;

public abstract class EnemyFactory : GameObjectFactory
{
	[Serializable]
	public class EnemyConfig
	{
		[SerializeField] private Enemy _prefab;
		[SerializeField, FloatRangeSlider(0.5f, 3f)]
		private FloatRange _speed = new FloatRange(1f, 2f);
		[SerializeField] private int _health = 3;

		public Enemy prefab => _prefab;
		public FloatRange speed => _speed;
		public int health => _health;
	}

	public Enemy Get(EnemyType type)
	{
		var config = GetConfig(type);
		Enemy instance = CreateGameObjectInstance(config.prefab);
		instance.OriginFactory = this;
		instance.Init(config.speed.randomValueInRange, config.health);
		return instance;
	}

	protected abstract EnemyConfig GetConfig(EnemyType type);

	public void Reclaim(Enemy enemy)
	{
		Destroy(enemy.gameObject);
	}
}