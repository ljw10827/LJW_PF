using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToTargetTask : BTNode
{
	IBasicAI myAI;
	float fJumpPower;

	public JumpToTargetTask(IBasicAI AI, float fPower)
	{
		myAI = AI;
		fJumpPower = fPower;
	}

	public override BTState Evaluate()
	{
		myAI.GetTransform().GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fJumpPower));
		//myAI.IsJump = true;
		Debug.Log("점프");
		return BTState.SUCCESS;
	}
}
