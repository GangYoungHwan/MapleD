using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    GameObject contactSkill = null;
    public Vector3 LoadedPos;
    bool isSelect = false;

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
        //마우스 좌표를 스크린 투 월드로 바꾸고 이 객체의 위치로 설정해 준다.
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
    private void OnMouseUp()
    {
        isSelect = false;
        
        if(contactSkill != null)
        {
            Destroy(gameObject);
            Destroy(contactSkill);
            //contactSkill.GetComponent<Skill>().skillLV+=1;
        }
        else
        {
            this.transform.position = LoadedPos;
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

            //if (other.tag == "Skill")
            //{
            //    LoadedPos = other.transform.position;
            //}
            if (isSelect && currSkillID == colSkillID && currSkillLv == colSkillILv)
            {
                if (contactSkill != null)
                {
                    contactSkill.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                    contactSkill = null;
                }
                //LoadedPos = collision.transform.position;
                contactSkill = collision.gameObject;
                contactSkill.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f);
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
                    contactSkill.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                    contactSkill = null;
                }
            }
        }

    }
}
