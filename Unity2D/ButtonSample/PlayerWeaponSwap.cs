using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSwap : MonoBehaviour
{
    public Sprite weapon01;
    public Sprite Weapon02;

    private CInput playerInput;
    private int weaponCnt;
    private SpriteRenderer weaponSprite;

    // Start is called before the first frame update
    void Start()
    {
        //Player Fix playerInput = GetComponentInParent<PlayerInput>();
        weaponSprite = GetComponent<SpriteRenderer>();
        weaponCnt = 1;
        weaponSprite.sprite = weapon01;
        Debug.Log(weaponSprite.sprite);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(weaponCnt == 1)
            {
                weaponCnt = 2;
                weaponSprite.sprite = Weapon02;
            }
            else
            {
                weaponCnt = 1;
                weaponSprite.sprite = weapon01;
            }
        }
        
    }
}
