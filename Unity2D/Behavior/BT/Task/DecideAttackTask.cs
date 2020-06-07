using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideAttackTask : BTNode
{
	IBasicAI myAI;
	public DecideAttackTask(IBasicAI AI)
	{
		myAI = AI;
	}

	public override BTState Evaluate()
	{
        if (!myAI.GetIsAttack())
        {
		    myAI.SetIsAttack(true);
		    return BTState.SUCCESS;
        }
        else
        {
            return BTState.FAILURE;
        }
	}
}
