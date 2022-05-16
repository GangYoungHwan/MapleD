using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    GameObject contactSkill = null;
    public Vector3 LoadedPos;
    bool isSelect = false;
    private GameObject[] skill = null;

    private void Start()
    {
        LoadedPos = this.transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        isSelect = true;
    }
    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        this.GetComponent<SpriteRenderer>().sortingOrder = 101;
        this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.7f);

        skill = GameObject.FindGameObjectsWithTag("Skill");
        for(int i=0; i< skill.Length; i++)
        {
            int currSkillID = GetComponent<Skill>().SkillID;
            int SkillIDs = skill[i].GetComponent<Skill>().SkillID;
            int currSkillLv = GetComponent<Skill>().skillLV;
            int SkillILvs = skill[i].GetComponent<Skill>().skillLV;
            if (currSkillID == SkillIDs && currSkillLv == SkillILvs)
            {
                skill[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
            }
            else
            {
                skill[i].GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f);
            }
        }
    }
    private void OnMouseUp()
    {
        isSelect = false;
        
        if(contactSkill != null)
        {
            int currSlotnum = GetComponent<Skill>().SlotNum;
            int conSlotnum = contactSkill.GetComponent<Skill>().SlotNum;
            int currSkillLv = GetComponent<Skill>().skillLV;
            int currSkillNum = GetComponent<Skill>().SkillNum;
            InGameManager.Instance.skillList[currSlotnum]._slot = false;
            InGameManager.Instance.CereteSkill(currSkillNum, contactSkill.transform.position, currSkillLv, conSlotnum);
            InGameManager.Instance.Skillcnt -= 1;
            Destroy(gameObject);
            Destroy(contactSkill);
            
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 100;
            this.transform.position = LoadedPos;
        }

        for (int i = 0; i < skill.Length; i++)
        {
            skill[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Skill")
        {
            int currSkillID = GetComponent<Skill>().SkillID;
            int colSkillID = collision.GetComponent<Skill>().SkillID;
            int currSkillLv = GetComponent<Skill>().skillLV;
            int colSkillILv = collision.GetComponent<Skill>().skillLV;

            if (isSelect && currSkillID == colSkillID && currSkillLv == colSkillILv)
            {
                if (contactSkill != null)
                {
                    contactSkill = null;
                }
                contactSkill = collision.gameObject;
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Skill")
        {
            int currSkillID = GetComponent<Skill>().SkillID;
            int colSkillID = collision.GetComponent<Skill>().SkillID;
            int currSkillLv = GetComponent<Skill>().skillLV;
            int colSkillILv = collision.GetComponent<Skill>().skillLV;
            if (isSelect && currSkillID == colSkillID && currSkillLv == colSkillILv)
            {
                if (contactSkill != null)
                {
                    contactSkill = null;
                }
            }
        }
    }
}
