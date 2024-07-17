using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class PlayerCharacter : Unit
{
	private float _targetingRange;
	private TargetPoint _target = null;

	private const int ENEMY_LAYER_MASK = 1 << 9;

	public void GameUpdate()
	{
		IsAcquireTarget();

		if (_target != null)
		{
			_target.GetComponent<SpriteRenderer>().color = new Color(1,0,0);
		}
	}

	public void SetTargetingRange(float range)
	{
		_targetingRange = range;
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

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Vector3 pos = transform.localPosition;
		Gizmos.DrawWireSphere(pos, _targetingRange);
	}
}
