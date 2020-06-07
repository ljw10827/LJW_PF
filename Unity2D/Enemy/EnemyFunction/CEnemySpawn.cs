using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CEnemySpawn : MonoBehaviour
{
    public List<CBaseEnemyController> enemyList;
    public bool isAllSpawn = false;
    public bool spawnable = true;
    private string oString;
    
    void Awake()
    {
        enemyList = GetComponentsInChildren<CBaseEnemyController>(true).ToList();
        oString = "Fire";
        StartCoroutine(EnemyAllDead());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(KDefine.TAG_PLAYER) && spawnable)
        {
            AllEnemySpawn(enemyList);
            spawnable = false;
        }
    }

    public void AllEnemySpawn(List<CBaseEnemyController> enemylist)
    {
        for (int i = 0; i < enemylist.Count; ++i)
        {
            this.EnemySpawn(enemylist[i]);
        }

        isAllSpawn = true;
    }

    private void EnemySpawn(CBaseEnemyController enemy)
    {
        //StartCoroutine(Spawn(enemy, CEffectManager.Instance.GetEffectEndTime(oString)));
        enemy.gameObject.SetActive(true);
    }
    
    private IEnumerator Spawn(CBaseEnemyController enemy, float delaytime)
    { 
        //CEffectManager.Instance.PlayEffect(enemy.transform.position, oString);
        yield return new WaitForSeconds(0.5f);
        enemy.gameObject.SetActive(true);
    }

    private IEnumerator EnemyAllDead()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (!enemyList[i].IsDead) i -= 1;
            yield return new WaitForEndOfFrame();
        }

        this.gameObject.SetActive(false);
        yield break;
    }
}
