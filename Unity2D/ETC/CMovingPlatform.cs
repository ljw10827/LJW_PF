using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMovingPlatform : MonoBehaviour
{
    public float fMovingUpDistance = 0f;
    public float fMovingDownDistance = 0f;
    public float fMovingLeftDistance = 0f;
    public float fMovingRightDistance = 0f;
    public float fMovingSpeed = 1.0f;
    public bool bDirectionRight = true;
    public bool bDirectionUp = true;

    private Vector2 myStartPosition;
    private Rigidbody2D rigidbody;
    private Rigidbody2D playerRigidbody;

    void Start()
    {
        myStartPosition = GetComponent<Transform>().position;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DirectionCheck();
        if (bDirectionRight && (transform.position.x < myStartPosition.x + fMovingRightDistance) && bDirectionUp)
        {
            rigidbody.MovePosition(transform.position + transform.right * fMovingSpeed / 60);
        }
        else if (bDirectionUp && (transform.position.y < myStartPosition.y + fMovingUpDistance))
        {
            rigidbody.MovePosition(transform.position + transform.up * fMovingSpeed / 60);
        }
        else if (!bDirectionRight && (transform.position.x > myStartPosition.x - fMovingLeftDistance))
        {
            rigidbody.MovePosition(transform.position - transform.right * fMovingSpeed / 60);
        }
        else if(!bDirectionUp && (transform.position.y > myStartPosition.y - fMovingDownDistance))
        {
            rigidbody.MovePosition(transform.position - transform.up * fMovingSpeed / 60);
        }
    }

    void DirectionCheck()
    {
        if (transform.position.x <= myStartPosition.x - fMovingLeftDistance)
        {
            bDirectionRight = true;
        }
        else if (transform.position.x >= myStartPosition.x + fMovingRightDistance)
        {
            bDirectionRight = false;
        }
        if (transform.position.y <= myStartPosition.y - fMovingDownDistance)
        {
            bDirectionUp = true;
        }
        else if (transform.position.y >= myStartPosition.y + fMovingUpDistance)
        {
            bDirectionUp = false;
        }
    }

}
