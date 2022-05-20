using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterSpawner : MonoBehaviour
{
    private static MonsterSpawner instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    [SerializeField] private GameObject GameOverUI = null;
    [SerializeField] private GameObject[] MobPrefab=null;
    [SerializeField] private float spawnTime = 1f;
    [SerializeField] private float reSpawnTime = 60f;
    [SerializeField] private int MobCnt = 0;
    [SerializeField] private int cnt;
    public float GameTime = 600f;
    public int ClearTime = 0;
    public int mobcntMax = 60;
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
    public int minute = 0;
    public float second = 0;

    public int MonsterExp = 0;
    public int dieMonstercnt = 0;

    private bool isboss = false;
    public static MonsterSpawner Instance { get { if (null == instance) { return null; } return instance; } }

    private IEnumerator Systemcoroutine;
    private IEnumerator Spwancoroutine;
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

        //StartCoroutine(WaveSystem());
        Systemcoroutine = WaveSystem();
        Spwancoroutine = SpawnMonster();
        StartCoroutine(Systemcoroutine);
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.F4))
        {
            currMonsterCount = 100;
            InGameOver();
        }
        if (Input.GetKey(KeyCode.F5))
        {
            InGameOver();
        }
        if (Input.GetKeyUp(KeyCode.F6))
        {
            StopCoroutine(Systemcoroutine);
            StartWave(currWave);
        }
    }
    private IEnumerator WaveSystem()
    {
        //웨이브 시스템 리뉴얼
        StartTime(GameTime);
        while (currWave < WaveMax)
        {
            StartWave(currWave);
            yield return new WaitForSeconds(holdTime+(spawnTime*mobcntMax));
        }
    }
    public void InGameOver()
    {
        GameOver = true;
        Debug.Log("GameOver");
        StopAllCoroutines();
        GameOverUI.SetActive(true);
        if (currMonsterCount >= currMonsterCountMax)
        {
            GameOverUI.GetComponent<GameOver>().GameFail();
        }
        else
        {
            GameOverUI.GetComponent<GameOver>().GameClear();
        }
        
    }
    public void StartTime(float _time)
    {
        StartCoroutine(LimitTime(_time));
    }
    private IEnumerator LimitTime(float _time)
    {
        second = _time;
        minute = 0;
        if(second >60)
        {
            minute = (int)second/60;
            second -= (60 * minute);
        }
        while (!GameOver)
        {
            if (dieMonstercnt >= mobcntMax * WaveMax)
            {
                InGameOver();
                break;
            }
            if (second <= 0 && minute <= 0 )
            {
                InGameOver();
                break;
            }
            if (second <= 0 && minute > 0)
            {
                minute--;
                second = 60f;
            }

            second -= 1;
            ClearTime += 1;
            yield return new WaitForSeconds(1f);
            secondText.text = string.Format("{0:D2}", (int)second);
            minuteText.text = string.Format("{0:D2}", minute);
        }
        secondText.text = "00";
        minuteText.text = "00";
        yield return null;
    }
    public void StartWave(int wave)
    {
        StopCoroutine(Spwancoroutine);
        currWave = wave;
        currWave++;
        InGameManager.Instance._WaveText.text = currWave.ToString();
        //텍스트 currWave
        StartCoroutine(Spwancoroutine);
    }
    private IEnumerator SpawnMonster()
    {
        Debug.Log("소환 시작");
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
                InGameOver();
                break;
            }
            CreateMonster(MobID);
            if (isboss)
                break;
            yield return new WaitForSeconds(spawnTime);
        }
        MobCnt = 0;
    }
    public void CreateMonster(int MobID)
    {
        GameObject clone = Instantiate(MobPrefab[MobID - 1], gameObject.transform);
        MonsterHP boss = clone.GetComponent<MonsterHP>();
        if(boss.isBoss)
            isboss = true;
        else
            isboss = false;
        Monster mob = clone.GetComponent<Monster>();
        mob.nextMove = 1;
        mob.Setup(this);
        mob.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
        sortingOrder++;
        mobList.Add(mob);
        MobCnt++;
        currMonsterCount++;
        MonsterLifeText();
    }
    public void DestroyMonster(Monster mob)
    {
        mobList.Remove(mob);
        int MobId = mob.gameObject.GetComponent<MonsterHP>().MonsterID;
        InGameManager.Instance.GetSkillPoint();
        if(mob.gameObject.GetComponent<MonsterHP>().isBoss)
            dieMonstercnt += 60;

        currMonsterCount--;
        MonsterLifeText();
        MonsterExp += int.Parse(MobInfoManager.Instance.MobList[MobId].MobExp);

        dieMonstercnt++;
        Destroy(mob.gameObject);
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
