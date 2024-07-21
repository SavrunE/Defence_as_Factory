using System;
using System.Collections.Generic;

[Serializable]
public class EnemyCollection
{
	public List<Enemy> _enemies = new List<Enemy>();

	public Action onEnemiesZero;

	public void Add(Enemy enemy)
	{
		_enemies.Add(enemy);
	}

	public void GameUpdate()
	{
		if (_enemies.Count == 0)
		{
			onEnemiesZero?.Invoke();
		}
		for (int i = 0; i < _enemies.Count; i++)
		{
			if (_enemies[i].GameUpdate() == false)
			{
				int lastIndex = _enemies.Count - 1;
				_enemies[i] = _enemies[lastIndex];
				_enemies.RemoveAt(lastIndex);
				i -= 1;
			}
		}
	}

	public void DestructionAll()
	{
		foreach (var enemy in _enemies)
		{
			enemy.Destruction();
		}
		_enemies.Clear();
	}
}