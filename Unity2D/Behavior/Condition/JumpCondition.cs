using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCondition : BTNode
{
	IBasicAI myAI;
	public JumpCondition(IBasicAI AI)
	{
		myAI = AI;
	}

	public override BTState Evaluate()
	{
		return BTState.SUCCESS;
		//return myAI.IsJump ? BTState.FAILURE : BTState.SUCCESS;
	}
}
