using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//똑같이 체크를하고 공격직전에 쿨다운인지 체크를 하고 쿨다운이면 fail보내고 무브.
public class CEnemyAIController : MonoBehaviour, IBasicAI
{
    protected GameObject targetObject;
    protected Transform effectPoint;

    protected Transform myTransform;
    protected bool bIsAttack = false;
    protected Animator animator;
    protected Vector3 myPrevPosition;
    protected CLivingEntity livingEntity;
    protected bool bIsFacing;
    protected bool bIsFlight;
    protected bool bIsJump;
    protected Selector rootAI;
    protected Sequence attackSequence;
    protected Sequence attackChkSequence;
	protected float prevPosSetTimer = 0f;
	private float prevPosMaxTimer = 0.3f;


	public Vector3 MyPrevPosition
	{
		get
		{
			return this.myPrevPosition;
		}
	}

	public GameObject Target
	{
		get
		{
			return this.targetObject;
		}

		set
		{
			this.targetObject = value;
		}
	}
	public bool FacingRight
	{
		get
		{
			return this.bIsFacing;
		}

		set
		{
			this.bIsFacing = value;
		}
	}

	public bool IsFlight
	{
		get
		{
			return this.bIsFlight;
		}

		set
		{
			this.bIsFlight = value;
		}
	}

	public bool IsJump
	{
		get
		{
			return this.bIsJump;
		}

		set
		{
			this.bIsFlight = value;
		}
	}

	public CLivingEntity LivingEntity
	{
		get
		{
			return this.livingEntity;
		}
		set
		{
			this.livingEntity = value;
		}
	}


	// Start is called before the first frame update
	public virtual void Start()
    {
        myTransform = this.GetComponent<Transform>();
        animator = this.GetComponent<Animator>();
        targetObject = FindObjectOfType<CMovement>().attackPivot;
		Mathf.Clamp(this.prevPosSetTimer, 0, this.prevPosMaxTimer);
		//LivingEntity = this.GetComponent<CLivingEntity>();
    }

    public virtual void FixedUpdate()
    {
        if (!livingEntity.IsDead && rootAI != null)
        { 
            rootAI.Evaluate();
        }
    }

	public Animator GetAnimator()
	{
		return this.animator;
	}

	public bool GetIsAttack()
	{
		return this.bIsAttack;
	}

	public float GetTargetDistance()
	{
		return Vector2.Distance(Target.transform.position, this.transform.position);
	}

	public Vector3 GetTargetPosition()
	{
		return this.Target.transform.position;
	}

	public Transform GetTransform()
	{
		return this.myTransform;
	}

	public void SetIsAttack(bool isAttack)
	{
		this.bIsAttack = isAttack;
	}

	public void Test()
	{
		Function.LateCall((oParams =>
		{
			this.bIsAttack = false;
		}), 1.0f);
	}
}
