using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTestFlightAI : CFlightEnemyAIController, IController
{
	public event ControllEventInt AtkEvent;
	public event ControllEvent MoveEvent;
	public event ControllEventFloat TurnEvent;
	public event ControllEventVector3 RandomMoveEvent;


	protected Sequence moveSequence;
	protected Sequence moveChkSequnce;
	public float fAttackRange;

	public override void Start()
	{
		base.Start();
		
		attackChkSequence = new Sequence(new List<BTNode>
		{
			new IsAttackRangeCondition(this, fAttackRange),
			new IsDamagedCondition(this),
			new IsAttackCondition(this)
		});

		attackSequence = new Sequence(new List<BTNode>
		{
			attackChkSequence,
			new DecideAttackTask(this),
			new AttackTargetTask(this, this.AtkEvent, 1, fAttackRange)
		});

		moveChkSequnce = new Sequence(new List<BTNode>
		{
			new MoveCondition(this, fAttackRange),
			new IsAttackCondition(this),
			new IsDamagedCondition(this)
		});

		moveSequence = new Sequence(new List<BTNode>
		{
			new FindTargetTask(this, TurnEvent),
			moveChkSequnce,
			new MoveToTargetTask(this, MoveEvent, fAttackRange)
		});

		rootAI = new Selector(new List<BTNode>
		{
			moveSequence,
			attackSequence
		});

	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
	}
}
