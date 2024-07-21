using UnityEngine;

public class Enemy : Unit
{
	[SerializeField] private Animator _animator;
	public EnemyFactory OriginFactory { get; set; }
	private float _speed;
	private int _health;
	private bool _isDead = false;

	public override bool GameUpdate()
	{
		if (_health <= 0 || _isDead)
		{
			OriginFactory.Reclaim(this);
			return (false);
		}
		transform.localPosition += Vector3.down * _speed * Time.deltaTime;
		return true;
	}

	public override void Recycle()
	{
		_isDead = true;
	}

	public void Destruction()
	{
		Destroy(this.gameObject);
	}

	public void SpawnOn(EnemySpawnPoints spawnPoints)
	{
		transform.localPosition = spawnPoints.TakeRandomSpawnPoint().position;
	}

	public void Init(float speed, int health)
	{
		_speed = speed;
		_health = health;
	}

	public void TakeDamage(int count)
	{
		_health -= count;
		_animator.SetBool("Attacked", true);
	}
}
