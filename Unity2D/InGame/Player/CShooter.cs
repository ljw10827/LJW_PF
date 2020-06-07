using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스왑 버튼 있고
//총의 갯수제한 변동 가능해야되고
//버튼을 누르는 순간 바뀌어야됨 
public class CShooter : MonoBehaviour
{
    public CInput playerInput;
    //웨펀 클래스 가지고 웨펀에서 샷
    public CWeapon weapon;
    public float fAtk;
    public float fAtkSpeed;
    public bool bIsAttackTime;
    private CCameraShakeInCinemachine cameraShake;
    private CWeapon spareWeapon;

    private void Awake()
    {
        playerInput = this.GetComponent<CInput>();
        weapon = FindObjectOfType<CWeapon>();
        cameraShake = this.GetComponent<CCameraShakeInCinemachine>();
        SetBonusDamage(1.0f);
    }

    private void Start()
    {
        CWeaponManager.Instance.SetParent(this.transform);
        CWeaponManager.Instance.SetCurrentWeapon(weapon);
    }

    void Update()
    {
        if (this.playerInput.AttackButton.IsAttack)
        {
            weapon.Attack();
            cameraShake.StartingShake();
        }

        else
        {
            if (weapon.GetWeaponCategory() == EWeaponCategory.E_CHARGEGUN)
            {
                weapon.Shot();
            }
        }

        if (spareWeapon != null && playerInput.AttackButton.IsInteract)
        {
            CWeaponManager.Instance.AddWeapon(spareWeapon);
            Destroy(this.spareWeapon.gameObject);
            spareWeapon = null;
        }
    }

    public void SetBonusDamage(float Damage)
    {
        weapon.SetBonusDamage(Damage);
    }

    public void SetCurrentWeapon(CWeapon changeWeapon)
    {
        weapon = changeWeapon;
    }

    void OnEnable()
    {
        this.weapon.gameObject.SetActive(true);
    }

    void OnDisable()
    {
        this.weapon.gameObject.SetActive(false);
    }

    public void SetSpareWeapon(CWeapon weapon)
    {
        spareWeapon = weapon;
    }
}
