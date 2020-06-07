using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBasicAI
{
	Vector3 GetTargetPosition();
	Vector3 MyPrevPosition { get; }
	Animator GetAnimator();
	Transform GetTransform();
	GameObject Target { get; set; }
	float GetTargetDistance();
	bool GetIsAttack();
	CLivingEntity LivingEntity { get; set; }
	bool FacingRight { get; set; }
    bool IsFlight { get; set; }
	void SetIsAttack(bool isAttack);
    void Test();
}