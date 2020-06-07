using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFixedEnemyAIController : CEnemyAIController
{
	public override void Start()
	{
		base.Start();
		this.IsFlight = false;
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
	}
}