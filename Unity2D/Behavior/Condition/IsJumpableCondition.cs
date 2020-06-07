using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsJumpableCondition : BTNode
{
	IBasicAI myAI;
	public IsJumpableCondition(IBasicAI AI)
	{
		myAI = AI;
	}

	public override BTState Evaluate()
	{
		//if (!myAI.IsJumpable)
		//{ 
		//	return BTState.FAILURE;
		//}

		return BTState.SUCCESS;

	}
}
