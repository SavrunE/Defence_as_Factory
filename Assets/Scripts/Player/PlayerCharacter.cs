using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using static UnityEngine.GraphicsBuffer;

public class PlayerCharacter : Unit
{
	private float _targetingRange;
	private TargetPoint _target = null;

	private float _attackSpeed;
	private float _currentAttackTime;
	
	private const int ENEMY_LAYER_MASK = 1 << 9;

	public void GameUpdate()
	{

		IsAcquireTarget();
		Attack();
	}

	public void InitPlayer(float attackRange, float attackSpeed)
	{
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
