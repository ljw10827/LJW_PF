using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMovement : MonoBehaviour
{
    public bool bIsFacingRight;
    public bool isWalk;
    public bool dashLock;
    public float fMoveSpeed;
    public Animator animator;
    //public CDirectionPad directionPad;
    public bool bIsDash = false;
    public float jumpDownPower = 20;
    public float fDashCoolDown = 0.0f;
    public CInput playerInput;
    public int nJumpPower;
    public float fDashPower;
    public Vector3 inputVector;
    public GameObject attackPivot;
    public Rigidbody2D rigidbody;
    public Collider2D myCollider;

    private int nJumpCount = 0;
    private int nJumpCountLimit = 2;
    private float lastDashLockTime = 0f, timer = 0f;
    private bool jumpUp = true;
    private bool isGrounded = true;
    private int dashCounter = 0;
    private Collider2D platformcollider;
    private CShooter shooter;

    void Awake()
    {
        playerInput = this.GetComponent<CInput>();
        rigidbody = this.GetComponent<Rigidbody2D>();
        myCollider = this.GetComponent<CapsuleCollider2D>();
        shooter = this.GetComponent<CShooter>();
    }

    private void Start()
    {
        bIsFacingRight = true;
        inputVector = Vector3.zero;
        fMoveSpeed = 250;
        nJumpPower = 800;
        fDashPower = 0.3f;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerInput.fMove != 0 || playerInput.fMobileMove != 0 || inputVector.x != 0)
        {
            if (!bIsDash)
            {
                this.Move();
            }
        }
        else
        {
            dashLock = false;
            this.Idle();
        }
        if ((playerInput.JumpButton.IsJump) && (nJumpCount < nJumpCountLimit))
        {
            if (!bIsDash)
            {
                this.Jump();
            }
        }
        if (timer < 10000) timer += Time.deltaTime;
        else
        {
            timer = 0;
            lastDashLockTime -= 10000;
        }
        if (timer - lastDashLockTime > 0.2f)
        {
            dashCounter = 0;
        }
    }

    protected void Idle()
    {
        animator.SetBool("isWalk", false);
        rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
    }

    void Move()
    {
        if (playerInput.fMove < 0 || playerInput.fMobileMove < 0)
        {
            bIsFacingRight = false;
        }
        else if (playerInput.fMove > 0 || playerInput.fMobileMove > 0)
        {
            bIsFacingRight = true;
        }

        transform.localScale = new Vector3(bIsFacingRight ? 1f : -1f, 1f, 1f);

        rigidbody.velocity = new Vector2((playerInput.fMove + playerInput.fMobileMove)* fMoveSpeed * Time.deltaTime, rigidbody.velocity.y);


        if (dashLock == false)
        {
            dashLock = true;
            lastDashLockTime = timer;
            if (bIsFacingRight)
            {
                if (dashCounter != 1) dashCounter = 1;
                else
                {
                    dashCounter = 0;
                    Dash();
                }
            }
            else
            {
                if (dashCounter != -1) dashCounter = -1;
                else
                {
                    dashCounter = 0;
                    Dash();
                }
            }
        }
        isWalk = true;
        animator.SetBool("DirectionRight", bIsFacingRight);
        animator.SetBool("isWalk", isWalk);
    }

    protected void Jump()
    {
        //jumpUp = directionPad.bIsDownJump ? false : true;
        jumpUp = true;

        if (jumpUp)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(new Vector2(0, nJumpPower));

        }
        else if (isGrounded && platformcollider.CompareTag(KDefine.TAG_PLATFORM))
        {
            StartCoroutine(JumpDown());
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(new Vector2(0, -jumpDownPower));
        }
        else
        {
            return;
        }

        nJumpCount++;
        isGrounded = false;

        animator.SetBool("JumpUp", jumpUp);
        animator.SetBool("Grounded", isGrounded);
    }

    protected void Dash()
    {
        if (!bIsDash)
        {
            float startPosition = rigidbody.transform.position.x;
            StartCoroutine(DashPlayer(startPosition));
        }
    }

    private IEnumerator DashPlayer(float startPosition)
    {
        bIsDash = true;
        animator.SetBool("isDash", bIsDash);
        shooter.enabled = false;
        for (int i = 1; i <= 7; i++)
        {
            if (bIsDash)
            {
                rigidbody.MovePosition(new Vector2(startPosition + (bIsFacingRight ? i * fDashPower : -i * fDashPower), rigidbody.transform.position.y));
                yield return new WaitForSeconds(0.04f);
            }
        }
    }

    public void EndOfDash()
    {
        bIsDash = false;
        animator.SetBool("isDash", bIsDash);
        shooter.enabled = true;
        this.Idle();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 어떤 콜라이더와 닿았으며, 충돌 표면이 위쪽을 보고 있으면
        if (collision.contacts[0].normal.y >= 0.7f)
        {
            // isGrounded를 true로 변경하고, 누적 점프 횟수를 0으로 리셋
            isGrounded = true;
            nJumpCount = 0;
        }

        if (collision.contacts[0].normal.y == -1f)
        {
            rigidbody.AddForce(new Vector2(0, -10));
        }

        platformcollider = collision.collider;
        animator.SetBool("Grounded", isGrounded);
        if(collision.gameObject.CompareTag(KDefine.TAG_PUSHABLE)) 
        {
            Debug.Log("Detect push");
            if ((collision.contacts[0].normal.y <= 0.7 || collision.contacts[0].normal.x >= -0.7) && collision.contacts[0].normal.y <= 0.7f)
            {
                collision.gameObject.GetComponent<IPushable>().Push(playerInput.fMove + playerInput.fMobileMove);
                Debug.Log("Success");
                shooter.enabled = false;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(KDefine.TAG_PUSHABLE))
        {
            if ((collision.contacts[0].normal.y <= 0.7 || collision.contacts[0].normal.x >= -0.7) && collision.contacts[0].normal.y <= 0.7f)
            {
                collision.gameObject.GetComponent<IPushable>().Push(playerInput.fMove + playerInput.fMobileMove);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(!shooter.enabled) shooter.enabled = true;
        IPushable target = collision.gameObject.GetComponent<IPushable>();
        if(target != null)
        {
            collision.gameObject.GetComponent<IPushable>().IsContact = false;
        }
    }

    private void JumpUpEnd()
    {
        jumpUp = false;
        animator.SetBool("JumpUp", jumpUp);
    }

    private IEnumerator JumpDown()
    {
        Physics2D.IgnoreCollision(myCollider, platformcollider);
        yield return new WaitForSeconds(0.2f);
        Physics2D.IgnoreCollision(myCollider, platformcollider, false);

    }
}
