using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBoss : MonoBehaviour
{
    //enum State Type 
    //Move, Idle, Death, Attack(SpellAttack, NormalAttack, DashAttack, SpeicalAttack), Groggy
    //Hit ==> OnTriggerEnter() -> playerHit 참조.
    //추상클래스로 구현? (Hit함수는 추상메서드로)
    //보스스테이지에 입장하게되면 바로 타겟을 잡음 (GameObject Target == Player)
    //타겟이 없다면 Idle, 일정 거리가 될 때까지 Move (플레이어 방향에 따라 Flip)
    //공격사거리가 되었다면 AttackState로변경
    //Attack 함수에서 랜덤한 숫자를 뽑아 노멀 스펠 대쉬 중 하나를 고름.
    //그 숫자에 따라 맞는 공격 취함.
    //그로기는 많이 처맞거나 SpeicalAttack을 실행 후 그로기 상태로 변경
    //그로기 상태일 때는 일정시간동안 그로기 유지.
    //일정시간이 지나면 거리에 따라 Move , Attack 을 실행
    //HP가 0이 되면 Death
    //가지고 있어야 할 변수 ATK, DEF, SPEED, HP, Critical Percent, Critical Multiple, Name
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
