﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

[Serializable]
public class EnemyCollection
{
	public List<Enemy> _enemies = new List<Enemy>();

	public void Add(Enemy enemy)
	{
		_enemies.Add(enemy);
	}

	 public void GameUpdate()
	{
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
}
