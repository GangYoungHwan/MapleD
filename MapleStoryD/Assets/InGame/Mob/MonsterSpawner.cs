using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] MobPrefab=null;
    [SerializeField] private float spawnTime = 1f;
    [SerializeField] private float reSpawnTime = 70f;
    [SerializeField] private int MobCnt;
    [SerializeField] private int cnt;
    [SerializeField] private int mobcntMax = 60;
    private int sortingOrder = 200;
    private List<Monster> mobList;
    public List<Monster> MobList => mobList;

    public int currWave = 0;
    public int currMonsterCount = 0;
    public int currMonsterCountMax = 100;
    public float holdTime = 5f;

    public Text minuteText = null;
    public Text secondText = null;
    void Start()
    {
        mobList = new List<Monster>();
        StartCoroutine("WaveSystem");
    }
    private IEnumerator WaveSystem()
    {
        while(currMonsterCount< currMonsterCountMax)
        {
            if (currWave > 7)
            {
                break;
            }
            else
            {
                StartTime(holdTime);
                yield return new WaitForSeconds(holdTime);
                StartWave(currWave);
                StartTime(mobcntMax);
                yield return new WaitForSeconds(reSpawnTime);
            }
        }
        //게임오버 UI
    }
    public void StartTime(float _time)
    {
        StartCoroutine(LimitTime(_time));
    }
    private IEnumerator LimitTime(float _time)
    {
        float second = _time;
        int _min = 0;
        Debug.Log(second);
        if(second >60)
        {
            _min = (int)second/60;
            second -= (60 * _min);
        }
        while (true)
        {
            if (currMonsterCount >= currMonsterCountMax)
                break;

            if (second <= 0 && _min > 0)
            {
                _min--;
                second = 60f;
            }
            else if (second <= 0 && _min <= 0)
                break;

            second -= 1;
            yield return new WaitForSeconds(1f);
            secondText.text = string.Format("{0:D2}", (int)second);
            minuteText.text = string.Format("{0:D2}", _min);
        }
        secondText.text = "00";
        minuteText.text = "00";
        yield return null;
    }
    public void StartWave(int wave)
    {
        currWave = wave;
        currWave++;
        MobCnt = 0;
        //텍스트 currWave
        StartCoroutine(SpawnMonster());
    }
    private IEnumerator SpawnMonster()
    {
        while (MobCnt < mobcntMax)
        {
            if (currWave > 7|| currMonsterCount >= currMonsterCountMax)
                break;

            int MobID = 0;
            switch (currWave)
            {
                case 1:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_1);
                    break;
                case 2:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_2);
                    break;
                case 3:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_3);
                    break;
                case 4:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_4);
                    break;
                case 5:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_5);
                    break;
                case 6:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Mob_6);
                    break;
                case 7:
                    MobID = int.Parse(MapInfoManager.Instance.MapList[DataManager.Instance.SpotNumber].Boss);
                    break;
            }
            if (MobID == 0)
            {
                currWave++;
            }
            else
            {
                GameObject clone = Instantiate(MobPrefab[MobID - 1], gameObject.transform);
                Monster mob = clone.GetComponent<Monster>();
                mob.nextMove = 1;
                mob.Setup(this);
                mob.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
                sortingOrder++;
                mobList.Add(mob);
                MobCnt++;
                currMonsterCount++;
                //몹카운터 텍스트
                yield return new WaitForSeconds(spawnTime);
            }
        }
    }

    public void DestroyMonster(Monster mob)
    {
        mobList.Remove(mob);
        InGameManager.Instance.GetSkillPoint();
        currMonsterCount--;
        //몹카운터 텍스트
        Destroy(mob.gameObject);
    }
}
