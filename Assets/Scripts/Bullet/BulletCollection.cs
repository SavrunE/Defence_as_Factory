using System;
using System.Collections.Generic;

[Serializable]
public class BulletCollection
{
	public List<Bullet> bullets = new List<Bullet>();

	public Action onEnemiesZero;

	public void Add(Bullet bullet)
	{
		bullets.Add(bullet);
	}

	public void GameUpdate()
	{
		for (int i = 0; i < bullets.Count; i++)
		{
			if (bullets[i].GameUpdate() == false)
			{
				int lastIndex = bullets.Count - 1;
				bullets[i] = bullets[lastIndex];
				bullets.RemoveAt(lastIndex);
				i -= 1;
			}
		}
	}

	public void DestructionAll()
	{
		foreach (var bullet in bullets)
		{
			bullet.Recycle();
		}
		bullets.Clear();
	}
}