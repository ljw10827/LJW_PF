using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTargetTask : BTNode
{
	IBasicAI myAI;
	event ControllEventInt attackEvent;
	int nStartDiceValue = 1;
	int nDiceRange;
	float fAttackRange;


	//ADD : float AttackRange
	public AttackTargetTask(IBasicAI AI, ControllEventInt eventAttack, int nRange, float fRange)
	{
		myAI = AI;
		attackEvent = eventAttack;
		nDiceRange = nRange;
		fAttackRange = fRange;
	}

	public override BTState Evaluate()
	{
		if (attackEvent != null)
		{
			myAI.GetAnimator().SetFloat("Speed", 0.0f);
			int nRandomDiceValue = Random.Range(nStartDiceValue, nStartDiceValue + nDiceRange);
            myAI.Test();
			attackEvent(nRandomDiceValue);
		}
		
		return BTState.SUCCESS;
	}
}
