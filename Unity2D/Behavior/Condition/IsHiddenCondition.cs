using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHiddenCondition : BTNode
{
	INPCAI myAI;

	public IsHiddenCondition(INPCAI AI)
	{
		myAI = AI;
	}

	public override BTState Evaluate()
	{
		if (myAI.GetIsHidden())
		{
			return BTState.SUCCESS;
		}
			
		return BTState.FAILURE;
	}
}
