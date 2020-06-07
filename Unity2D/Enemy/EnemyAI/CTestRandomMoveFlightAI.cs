using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTestRandomMoveFlightAI : CFlightEnemyAIController, IController, IRandomMoveAI
{
	public event ControllEventInt AtkEvent;
	public event ControllEvent MoveEvent;
	public event ControllEventFloat TurnEvent;
	public event ControllEventVector3 RandomMoveEvent;


	protected Sequence moveSequence;
	protected Sequence moveChkSequnce;
	public float fAttackRange;
	public int nMoveCount = 3;
	public float fMoveTime;
	private bool bIsMoving = false;

	public bool IsMoving
	{
		get
		{
			return bIsMoving;
		}

		set
		{
			bIsMoving = value;
		}
	}
	public int RandomCount
	{
		get
		{
			return nMoveCount;
		}

		set
		{
			nMoveCount = value;
		}
	}

	public override void Start()
	{
		base.Start();
		Function.LateCall((a_oParams =>
		{
			this.OnEnter();
		}), 0.15f);
		

	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
	}

	public void RandomMoveEnd(WaitForSeconds waitSec)
	{
		StartCoroutine(MoveEnd(waitSec));
	}

	private IEnumerator MoveEnd(WaitForSeconds waitSec)
	{
		this.bIsMoving = true;
		yield return waitSec;
		this.bIsMoving = false;
	}
	
	private void OnEnter()
	{
		attackChkSequence = new Sequence(new List<BTNode>
		{
			new MovingCondition(this),
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
			new IsAttackCondition(this),
			new MovingCondition(this),
			new MoveCountCondition(nMoveCount)
		});

		moveSequence = new Sequence(new List<BTNode>
		{
			new FindTargetTask(this, TurnEvent),
			moveChkSequnce,
			new RandomMoveTask(RandomMoveEvent),
			new MoveEndTask(this, fMoveTime)
		}); ;

		rootAI = new Selector(new List<BTNode>
		{
			moveSequence,
			attackSequence
		});
	}
}
