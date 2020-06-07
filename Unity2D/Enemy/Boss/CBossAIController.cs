using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class CBossAIController : MonoBehaviour ,IBasicAI, IController
{
    public Vector3 myTargetPosition = Vector3.zero;
    private Transform myTransform;
    public GameObject targetObject;

    public event ControllEventInt AtkEvent;
    public event ControllEvent MoveEvent;
    public event ControllEventFloat TurnEvent;

    private Selector rootAI;
    private Sequence moveSequence;
    private Sequence attackSequence;
    private Sequence attackChkSequence;
    private Sequence moveChkSequnce;

    private bool bIsAttack = false;
    private bool bIsDamaged = false;
    private bool bIsFacing = true;
    private bool bIsJump = false;

    private Animator animator;
    private Vector3 myPrevPosition;

    public GameObject Target
    {
        get
        {
            return targetObject;
        }
        set
        {
            targetObject = value;
        }
    }

    public bool FacingRight
    {
        get
        {
            return bIsFacing;
        }
        set
        {
            bIsFacing = value;
        }
    }

    public bool IsDamaged { get; set; }
    public bool IsDead { get; set; }

    public Vector3 MyPrevPosition
    {
        get
        {
            return myPrevPosition == null ? this.transform.position : myPrevPosition;
        }
    }

    public bool IsJump
    {
        get
        {
            return bIsJump;
        }

        set
        {
            bIsJump = value;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.GetComponent<Transform>();

        animator = this.GetComponent<Animator>();

        attackChkSequence = new Sequence(new List<BTNode>
        {
            new IsAttackRangeCondition(this, 3.0f),
            new IsAttackCondition(this)
        });

        moveChkSequnce = new Sequence(new List<BTNode>
        {
            new MoveCondition(this, 3.0f),
            new IsAttackCondition(this)
        });

        moveSequence = new Sequence(new List<BTNode>
        {
            new FindTargetTask(this, TurnEvent),
            moveChkSequnce,
            new MoveToTargetTask(this, MoveEvent, 3.0f)
        });

        attackSequence = new Sequence(new List<BTNode>
        {
            attackChkSequence,
            new DecideAttackTask(this),
            new AttackTargetTask(this, AtkEvent, 3, 3.0f)
        });

        rootAI = new Selector(new List<BTNode>
        {
            moveSequence,
            attackSequence
        });
    }


    public void FixedUpdate()
    {
        rootAI.Evaluate();
    }

    public Vector3 SetTargetPosition(Vector3 targetPosition)
    {
        myTargetPosition = targetPosition;
        return myTargetPosition;
    }

    public Vector3 GetTargetPosition()
    {
        //Player Fix
        return new Vector3(1.0f, 1.0f, 1.0f);
    }

    public Transform GetTransform()
    {
        return myTransform;
    }

    public float GetTargetDistance()
    {
        return Vector3.Distance(this.GetTargetPosition(), myTransform.position);
    }

    public bool GetIsAttack()
    {
        return bIsAttack;
    }

    public void SetIsAttack(bool isAttack)
    {
        bIsAttack = isAttack;
    }

    public Animator GetAnimator()
    {
        return animator;
    }

    public void Test()
    {
        Function.LateCall((oParams) =>
        {
            bIsAttack = false;
        }, 3.5f);

        Function.LateCall((oParams) =>
        {
            animator.SetInteger("AttackState", 0);
        }, 0.0f);
    }
}
*/