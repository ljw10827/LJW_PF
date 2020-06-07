using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTestFixedAI : CFixedEnemyAIController, IController
{
	public event ControllEventInt AtkEvent;
	public event ControllEvent MoveEvent;
	public event ControllEventFloat TurnEvent;
	public event ControllEventVector3 RandomMoveEvent;

	public override void Start()
	{
		base.Start();
		attackChkSequence = new Sequence(new List<BTNode>
		{
			new IsAttackRangeCondition(this, 300.0f),
			new IsDamagedCondition(this),
			new IsAttackCondition(this)
		});

		attackSequence = new Sequence(new List<BTNode>
		{
			attackChkSequence,
			new DecideAttackTask(this),
			new AttackTargetTask(this, this.AtkEvent, 1, 300.0f)
		});

		rootAI = new Selector(new List<BTNode>
		{
			attackSequence
		});

	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
	}
}
