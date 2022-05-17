using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] MobPrefab=null;
    [SerializeField] private float spawnTime = 1f;
    [SerializeField] private float reSpawnTime = 60f;
    [SerializeField] private int MobCnt;
    [SerializeField] private int cnt;
    [SerializeField] private int mobcntMax = 60;
    private int sortingOrder = 200;
    private List<Monster> mobList;
    public List<Monster> MobList => mobList;

    public bool GameOver = false;
    public int currWave = 0;
    public int currMonsterCount = 0;
    public int currMonsterCountMax = 100;
    public int WaveMax = 0;
    public float holdTime = 5f;

    public Text minuteText = null;
    public Text secondText = null;

    public int dieMonstercnt = 0;
    void Start()
    {
        mobList = new List<Monster>();
        int wavcnt = 0;
        for(int i=0; i<7; i++)
        {
            int MobID = 0;
            switch (i)
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
            if (MobID != 0)
                wavcnt++;
        }
        WaveMax = wavcnt;
        InGameManager.Instance._WaveMaxText.text = WaveMax.ToString();
        InGameManager.Instance._MonsterLifeMaxText.text = currMonsterCountMax.ToString();

        StartCoroutine("WaveSystem");
    }
    private IEnumerator WaveSystem()
    {
        //웨이브 시스템 리뉴얼
        StartTime(WaveMax * (mobcntMax+holdTime));
        while (true)
        {
            if (currWave > WaveMax)
            {
                break;
            }
            else
            {
                StartWave(currWave);
                yield return new WaitForSeconds(mobcntMax + holdTime);
            }
        }
        //타임오버시 남은 몬스터수에따라 스팟 인포 넘김
        //dieMonster가 mobcntMax*WaveMax 같으면 스팟 인포 넘기고 게임오버
        //
        //게임오버 UI
    }
    public void InGameOver()
    {
        GameOver = true;
        Debug.Log("GameOver");
        StopCoroutine("WaveSystem");
        if(dieMonstercnt >= mobcntMax*WaveMax)
        {
            Debug.Log("모두 처치");
        }
        else
        {
            Debug.Log(dieMonstercnt + "마리 처치");
        }

        if(currMonsterCount == currMonsterCountMax)
        {
            Debug.Log("실패");
        }
        
    }
    public void StartTime(float _time)
    {
        StartCoroutine(LimitTime(_time));
    }
    private IEnumerator LimitTime(float _time)
    {
        float second = _time;
        int _min = 0;
        if(second >60)
        {
            _min = (int)second/60;
            second -= (60 * _min);
        }
        while (!GameOver)
        {
            if (second <= 0 && _min <= 0 )
            {
                InGameOver();
                break;
            }
            if (second <= 0 && _min > 0)
            {
                _min--;
                second = 60f;
            }

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
        InGameManager.Instance._WaveText.text = currWave.ToString();
        yield return new WaitForSeconds(holdTime);
        while (MobCnt < mobcntMax)
        {
            int MobID = getMonsterID(currWave);
            if(currMonsterCount >= currMonsterCountMax)
            {
                InGameOver();
                break;
            }
            if (currWave > WaveMax || MobID == 0)
            {
                break;
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
                MonsterLifeText();
                yield return new WaitForSeconds(spawnTime);
            }
        }
    }

    public void DestroyMonster(Monster mob)
    {
        mobList.Remove(mob);
        InGameManager.Instance.GetSkillPoint();
        currMonsterCount--;
        MonsterLifeText();
        Destroy(mob.gameObject);

        dieMonstercnt++;
    }

    public void MonsterLifeText()
    {
        if(currMonsterCount >=80)
            InGameManager.Instance._MonsterLifeText.color = Color.red;
        else
            InGameManager.Instance._MonsterLifeText.color = Color.white;

        InGameManager.Instance._MonsterLifeText.text = currMonsterCount.ToString();
    }

    public int getMonsterID(int wave)
    {
        int Boss = 7;
        int MobID = 0;
        int wavcnt = wave;
        switch (wavcnt)
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
            wavcnt++;
            if(wavcnt <=Boss) MobID = getMonsterID(wavcnt);
        }
        return MobID;
    }
}
