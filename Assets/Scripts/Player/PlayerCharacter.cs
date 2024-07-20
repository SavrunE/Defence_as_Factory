using UnityEngine;

public class PlayerCharacter : Unit
{
	[SerializeField] private CharacterBorders _characterBorders;
	[SerializeField] private float _characterSize = 0.35f;
	private float _targetingRange;
	private TargetPoint _target = null;

	private float _speed, _attackSpeed, _currentAttackTime;

	private Vector2 _horizontalBorders, _verticalBorders;

	private const int ENEMY_LAYER_MASK = 1 << 9;

	private void OnEnable()
	{
		_characterBorders.onBordersChanged += ChangeMovableBorders;
	}

	private void OnDisable()
	{
		_characterBorders.onBordersChanged -= ChangeMovableBorders;
	}

	public void GameUpdate()
	{
		IsAcquireTarget();
		Attack();
		MoveCharacter();
	}

	private void ChangeMovableBorders(Vector2 x, Vector2 y)
	{
		_horizontalBorders = new Vector2(x.x + _characterSize / 2f, x.y - _characterSize / 2f);
		_verticalBorders = new Vector2(y.x + _characterSize / 2f, y.y - _characterSize / 2f);
	}

	private void MoveCharacter()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 moveDirection = new Vector3(moveHorizontal, moveVertical);
		Vector3 nextPos = transform.localPosition + moveDirection * _speed * Time.deltaTime;
		if (nextPos.x > _horizontalBorders.y)
		{
			nextPos.x = _horizontalBorders.y;
		}
		else if (nextPos.x < _horizontalBorders.x)
		{
			nextPos.x = _horizontalBorders.x;
		}
		if (nextPos.y > _verticalBorders.y)
		{
			nextPos.y = _verticalBorders.y;
		}
		else if (nextPos.y < _verticalBorders.x)
		{
			nextPos.y = _verticalBorders.x;
		}
		transform.localPosition = nextPos;
	}

	public void InitPlayer(float playerSpeed, float attackRange, float attackSpeed)
	{
		_speed = playerSpeed;
		_targetingRange = attackRange;
		_attackSpeed = 1f / attackSpeed;
	}

	private bool IsAcquireTarget()
	{
		Collider2D[] targets = Physics2D.OverlapCircleAll(transform.localPosition, _targetingRange, ENEMY_LAYER_MASK);
		if (targets.Length > 0)
		{
			float distance = Mathf.Infinity;

			foreach (var target in targets)
			{
				Vector2 diff = target.transform.position - transform.position;
				float curDistance = diff.sqrMagnitude;
				if (curDistance < distance)
				{
					_target = target.GetComponent<TargetPoint>();
					distance = curDistance;
				}

			}

			return true;
		}

		_target = null;
		return false;
	}

	private void Attack()
	{
		if (_currentAttackTime >= _attackSpeed)
		{
			if (_target != null)
			{
				_target.enemy.TakeDamage();
				_currentAttackTime = 0f;
			}
		}
		else
		{
			_currentAttackTime += Time.deltaTime;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Vector3 pos = transform.localPosition;
		Gizmos.DrawWireSphere(pos, _targetingRange);
	}
}
