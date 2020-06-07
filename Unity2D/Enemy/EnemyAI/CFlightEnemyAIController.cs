using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFlightEnemyAIController : CEnemyAIController
{
	public override void Start()
	{
		base.Start();
		this.IsFlight = true;
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
	}
}