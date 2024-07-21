using UnityEngine;

public class Bullet : BulletEntity
{
	private Vector3 _launchPoint;
	private TargetPoint _targetPoint;
	private float _speed;
	private int _damage;

	public void Init(Vector3 launchPoint, TargetPoint targetPoint, float speed, int damage)
	{
		_launchPoint = launchPoint;
		_targetPoint = targetPoint;
		_speed = speed;
		_damage = damage;

		transform.position = _launchPoint;

	}

	public override bool GameUpdate()
	{
		if (_targetPoint != null)
		{
			var direction = (_targetPoint.position - transform.position).normalized;
			float step = _speed * Time.deltaTime;
			transform.position += direction * step;
			SetRotation(direction);
			if (Vector3.Distance(transform.position, _targetPoint.position) < step)
			{
				OriginFactory.Reclaim(this);
				_targetPoint.enemy.TakeDamage(_damage);
				return false;
			}
			return true;
		}
		OriginFactory.Reclaim(this);
		return false;
	}

	public override void Recycle()
	{
		OriginFactory.Reclaim(this);
	}

	private void SetRotation(Vector3 direction)
	{
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
}
