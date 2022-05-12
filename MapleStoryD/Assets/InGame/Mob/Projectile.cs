using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Movement movement;
    private Transform target;
    [SerializeField] private GameObject hitEff;
    [SerializeField] private GameObject dmgHud;


    public void Setup(Transform target)
    {
        movement = GetComponent<Movement>();
        this.target = target;
    }
    void Start()
    {
        
    }


    void Update()
    {
        if(target != null)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            movement.MoveTo(dir);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (!collision.CompareTag("Mob"))
            return;
        if (collision.transform != target)
            return;
        //collision.GetComponent<Monster>().OnDie();
        GameObject clone = Instantiate(hitEff, collision.transform.position, Quaternion.identity);

        int testDmg = Random.Range(1, 100);
        Vector3 DmgskinPos = collision.GetComponent<Monster>().dmgPos.transform.position;
        collision.GetComponent<MonsterHP>().TakeDamage(testDmg, dmgHud, DmgskinPos);
        //GameObject dmgSkinclone = Instantiate(dmgHud, collision.GetComponent<Monster>().dmgPos.transform.position, Quaternion.identity);

        //dmgSkinclone.GetComponent<Hud>().DmgNoCri(1000);
        //dmgSkinclone.GetComponent<Hud>().DmgCri(1000);
        Destroy(gameObject);
    }
}
