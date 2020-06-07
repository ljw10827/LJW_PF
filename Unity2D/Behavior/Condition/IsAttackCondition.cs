﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAttackCondition : BTNode
{
	IBasicAI myAI;

	public IsAttackCondition(IBasicAI AI)
	{
		myAI = AI;
	}

	public override BTState Evaluate()
	{
		if (myAI.GetIsAttack())
		{
			//myAI.GetAnimator().SetInteger("AttackState", 0);
			return BTState.FAILURE;
		}

		return BTState.SUCCESS;
	}
}
