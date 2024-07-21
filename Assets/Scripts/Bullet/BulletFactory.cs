using UnityEngine;

[CreateAssetMenu(menuName = "Factory/BulletFactory")]
public class BulletFactory : GameObjectFactory
{
	[SerializeField] private Bullet _bulletPrefab;

	public Bullet bullet => Get(_bulletPrefab);

	private T Get<T>(T prefab) where T : BulletEntity
	{
		T instance = CreateGameObjectInstance(prefab);
		instance.OriginFactory = this;
		return instance;
	}

	public void Reclaim(BulletEntity entity)
	{
		Destroy(entity.gameObject);
	}
}
