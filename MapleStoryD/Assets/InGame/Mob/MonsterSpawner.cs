using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] MobPrefab=null;
    [SerializeField] private float spawnTime = 1f;
    private float reSpawnTimer;
    [SerializeField] private float reSpawnTime = 20f;
    [SerializeField] private int MobCnt;
    [SerializeField] private int cnt;
    [SerializeField] private int mobcntMax = 60;
    private int sortingOrder = 200;
    private List<Monster> mobList;
    public List<Monster> MobList => mobList;
    void Start()
    {
        mobList = new List<Monster>();
        reSpawnTimer = reSpawnTime;
        StartCoroutine("SpawnMonster");
    }

    private IEnumerator SpawnMonster()
    {
        while (true)
        {
            if (cnt > 6)
                break;

            int MobID = 0;
            switch (cnt)
            {
                case 0:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_1);
                    break;
                case 1:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_2);
                    break;
                case 2:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_3);
                    break;
                case 3:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_4);
                    break;
                case 4:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_5);
                    break;
                case 5:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_6);
                    break;
                case 6:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Boss);
                    break;
            }

            while (MobCnt <= mobcntMax)
            {
                if (MobID == 0)
                {
                    reSpawnTimer = 0f;
                    break;
                }
                else
                    reSpawnTimer = reSpawnTime;

                GameObject clone = Instantiate(MobPrefab[MobID - 1], gameObject.transform);
                Monster mob = clone.GetComponent<Monster>();
                mob.nextMove = 1;
                mob.Setup(this);
                mob.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
                sortingOrder++;
                mobList.Add(mob);

                yield return new WaitForSeconds(spawnTime);
                MobCnt++;
            }
            MobCnt = 0;
            cnt++;
            yield return new WaitForSeconds(reSpawnTimer);
        }
    }

    public void DestroyMonster(Monster mob)
    {
        mobList.Remove(mob);

        Destroy(mob.gameObject);
    }
}
