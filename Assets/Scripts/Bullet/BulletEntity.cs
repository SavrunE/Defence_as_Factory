using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletEntity : GameBehavior
{
	public BulletFactory OriginFactory { get; set; }

	public override void Recycle()
	{
		OriginFactory.Reclaim(this);
	}
}
