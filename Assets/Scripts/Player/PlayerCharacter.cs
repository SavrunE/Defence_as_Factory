using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter: Unit
{
    private float _targetingRange;
    private TargetPoint _target;
    public void SetTargetingRange(float range)
    {
        _targetingRange = range;
	}

    private bool IsAcquireTarget()
    {
        Collider[] targets = Physics.OverlapSphere(transform.localPosition, _targetingRange);
        if (targets.Length > 0)
        {

        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Vector3 pos = transform.localPosition;
        Gizmos.DrawWireSphere(pos, _targetingRange);
    }
}
