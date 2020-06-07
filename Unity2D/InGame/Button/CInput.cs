using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class CInput : MonoBehaviour
{
    public CAttackButton AttackButton;
    public CJumpButton JumpButton;
    public float fMove;
    public float fMobileMove;
    public float fSpeed = 30f;
    private Dictionary<int, string> oDict;
    private List<KeyValuePair<int,string>> pTouchList;
    private const string oRightTag = "RightDirection";
    private const string oLeftTag = "LeftDirection";
    
    public void Awake()
    {
        AttackButton = GameObject.Find("AttackButton").GetComponent<CAttackButton>();
        JumpButton = GameObject.Find("JumpButton").GetComponent<CJumpButton>();

        pTouchList = new List<KeyValuePair<int, string>>();
        oDict = new Dictionary<int, string>();
        Mathf.Clamp(fMobileMove, -1, 1);
    }

    public void Update()
    {
        fMove = Input.GetAxis("Horizontal");

        if (EventSystem.current.IsPointerOverGameObject())
        {
            var camera = Function.FindComponent<Camera>("UI Camera");
            var pos = camera.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(pos, transform.forward, 15.0f);

            if (hit)
            {
                if (hit.transform.CompareTag(KDefine.TAG_RIGHTDIRECTION))
                {
                    var image = hit.transform.GetComponent<Image>();
                    image.color = Color.gray;
                }

                else if (hit.transform.CompareTag(KDefine.TAG_LEFTDIRECTION))
                {
                    var image = hit.transform.GetComponent<Image>();
                    image.color = Color.gray;
                }
            }

        }

        for (int i = 0; i < Input.touchCount; i++)
        {
            var touch = Input.GetTouch(i);
            
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    var camera = Function.FindComponent<Camera>("UI Camera");
                    var pos = camera.ScreenToWorldPoint(touch.position);
                    var hit = Physics2D.Raycast(pos, transform.forward, 15.0f);

                    if (hit)
                    {
                        if (hit.transform.CompareTag(KDefine.TAG_RIGHTDIRECTION))
                        {
                            var keyPair = new KeyValuePair<int, string>(i, oRightTag);
                            var image = hit.transform.GetComponent<Image>();
                            image.color = Color.gray;

                            if (!oDict.ContainsKey(i))
                            {
                                oDict.Add(i, oRightTag);
                            }
                            fMobileMove = Mathf.MoveTowards(fMobileMove, this.CalMoveDirection(oRightTag), fSpeed * Time.deltaTime);
                        }

                        else if (hit.transform.CompareTag(KDefine.TAG_LEFTDIRECTION))
                        {
                            var keyPair = new KeyValuePair<int, string>(i, oLeftTag);
                            var image = hit.transform.GetComponent<Image>();
                            image.color = Color.gray;
                            
                            if (!oDict.ContainsKey(i))
                            {
                                oDict.Add(i, oLeftTag);
                            }
                            fMobileMove = Mathf.MoveTowards(fMobileMove, this.CalMoveDirection(oLeftTag), fSpeed * Time.deltaTime);
                        }

                    }

                    else
                    {
                        if (oDict.ContainsKey(i))
                        {
                            oDict.Remove(i);
                        }
                    }
                }

                else
                {
                    if (oDict.ContainsKey(i))
                    {
                        oDict.Remove(i);
                    }
                }

                
            }

            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                if (oDict.ContainsKey(i))
                {
                    oDict.Remove(i);
                }
            }
        }

        if (Input.touchCount <= 0)
        {
            oDict.Clear();
        }
        if (oDict.Count <= 0)
        {
            fMobileMove = Mathf.MoveTowards(fMobileMove, 0, fSpeed * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Jump();
        }
    }

    public void Jump()
    {
        JumpButton.IsJump = true;
        StartCoroutine(JumpEnd());
    }

    IEnumerator JumpEnd()
    {
        yield return new WaitForEndOfFrame();
        JumpButton.IsJump = false;
    }

    private float CalMoveDirection(string dirTag)
    {
        var result = dirTag == oRightTag ? 1 : -1;
        return result;
    }
}
