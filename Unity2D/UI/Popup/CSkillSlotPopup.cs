using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSkillSlotPopup : MonoBehaviour
{
    [System.Serializable]
    public struct stSlot
    {
        public Image image;
    }

    [System.Serializable]
    public struct stDisplaySlot
    {
        public List<stSlot> slotList;
    }

    public GameObject[] slotSkillObjects;
    public Button[] slotButtons;
    public Sprite[] skillSprites;
    public Text[] skillText;
    public List<CSkill> skillList;

    
    public List<stDisplaySlot> displaySlots;

    //public List<List<Image>> slotSprites = new List<List<Image>>();
    public List<int> startList = new List<int>();
    public List<int> resultSkillList = new List<int>();
    
    public Image resultImage; //테스트 확인용 지울거
    public Text resultText;   //테스트 확인용 지울거
    
    public int nSkillCnt = 3; 

    void OnEnable()
    {
        OnEnter();
        for (int i = 0; i < skillList.Count; i++)
        {
            startList.Add(i);
        }

        for (int i = 0; i < slotButtons.Length; i++)
        {
            slotButtons[i].interactable = false;
            for (int j = 0; j < nSkillCnt; j++)
            {
                //int nRandom = Random.Range(0, startList.Count);
                int nRandom = Random.Range(0, skillList.Count);

                if (i == 0 && j == 1 || i == 1 && j == 0 || i == 2 && j == 2)
                {
                    //resultSkillList.Add(startList[nRandom]);
                    resultSkillList.Add(nRandom);

                }

                //displaySlots[i].slotList[j].image.sprite = skillList[startList[nRandom]].spriteImage;
                displaySlots[i].slotList[j].image.sprite = skillList[nRandom].spriteImage;

                if (j == 0)
                {
                    //displaySlots[i].slotList[nSkillCnt].image.sprite = skillList[startList[nRandom]].spriteImage;
                    displaySlots[i].slotList[nSkillCnt].image.sprite = skillList[nRandom].spriteImage;
                }

                //startList.RemoveAt(nRandom);
            }
        }
        for (int i = 0; i < slotButtons.Length; i++)
        {
            StartCoroutine(StartSlot(i));
        }

        Function.StopGame();
    }
    int[] ans = { 2, 3, 1 };
    IEnumerator StartSlot(int nSlotNumber)//39 66 
    {
        for (int i = 0; i < (nSkillCnt * (6 + nSlotNumber * 4 ) + ans[nSlotNumber])* 2; i++)
        {
            slotSkillObjects[nSlotNumber].transform.localPosition -= new Vector3(0f, 50f, 0f);
            if (slotSkillObjects[nSlotNumber].transform.localPosition.y < 50f)
            {
                slotSkillObjects[nSlotNumber].transform.localPosition += new Vector3(0f, 300f, 0f);
            }

            skillText[nSlotNumber].text = displaySlots[nSlotNumber].slotList[(int)slotSkillObjects[nSlotNumber].transform.localPosition.y / 100].image.sprite.name;
            yield return new WaitForSecondsRealtime(0.02f);
        }

        slotButtons[nSlotNumber].interactable = true;
        StopCoroutine(StartSlot(nSlotNumber));
        yield break;
    }

    public void Test(int nIndex)
    {
        resultImage.sprite = skillList[resultSkillList[nIndex]].spriteImage;
        resultText.text = skillList[resultSkillList[nIndex]].oSkillName;
        skillList[resultSkillList[nIndex]].SelectSkill();
        Function.StartGame();
    }

    private void OnEnter()
    {
        startList.Clear();
        resultSkillList.Clear();
        CheckSkill();
        for (int i = 0; i < slotSkillObjects.Length; i++)
        {
            slotSkillObjects[i].transform.localPosition = new Vector3(0.0f, 300.0f, 0.0f);
        }
    }

    private void CheckSkill()
    {
        for (int i = 0; i < skillList.Count; i++)
        {
            if (!skillList[i].bIsSelect || skillList[i].bIsReuse) continue;

            Debug.Log(skillList[i].oSkillName);
            skillList.RemoveAt(i);
            break;
        }
    }
}
