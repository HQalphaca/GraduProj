using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnManager : MonoBehaviour // 적 유닛 생성을 관장하는 스크립트
{
    public static SpawnManager Inst { get; private set; }
    public GameObject EnemyPrefab;  // 적 유닛을 만들 때 필요한 게임오브젝트
    public Enemy enemy;
    public Text EnemyText;
    public Text WaveText;
    public Wave[] waves;
    public Text timerTxt;
    public static SpawnManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<SpawnManager>();
            return _instance;
        }
    }

    //변수 설정
    private static SpawnManager _instance;

    public Transform[] wayPoints;
    public GameObject currentSpawnTarget;
    public float spawnRate = 1f;

    // 어떤 오브젝트를 스폰할지 설정 및 유닛생성 시작
    public void Awake()
    {
        currentSpawnTarget = EnemyPrefab;
        //StartCoroutine(SpawnRoutine());
    }
    private void Start()
    {
        NextWave();
        
    }

    public void CountdownWaveTime()
    {
        currentWave.wave_time -= Time.deltaTime;
        timerTxt.text ="" + Mathf.Round(currentWave.wave_time);
    }

    public Wave currentWave;
    int currentWaveNum;

    public int enemyRemainingToSpawn;
    public int enemyAlive;
    public int enemyAliveNW;
    public float nextSpawnTime;

    public void Update()
    {
        if (enemyRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            enemyRemainingToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawn;
            Enemy spawnedEnemy = Instantiate(enemy);
            spawnedEnemy.OnDeath += EnemyDeath;
        }

        enemyAlive = waves[currentWaveNum - 1].enemyCount;
        enemyAliveNW = waves[currentWaveNum].enemyCount;
        enemy._hp = currentWave.Enemy_hp;
        UIUpdate(currentWaveNum, enemyAlive);
        CountdownWaveTime();
        if (currentWave.wave_time <= 0.0f)
        {
            NextWave();
        }
    }
    private void UIUpdate(int waves, int count)
    {
        WaveText.text = "WAVE: " + waves;
        EnemyText.text = "REMAIN ENEMY: " + count;
    }

    void EnemyDeath()
    {
        enemyAlive--;
        if (enemyAlive == 0)
        {
            Invoke("NextWave", 1.0f);
        }
        EnemyText.text = "REMAIN ENEMY: " + enemyAlive;
    }

    void NextWave()
    {
        currentWaveNum++;
        if (currentWaveNum - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNum - 1];
            enemyRemainingToSpawn = currentWave.enemyCount;
            enemyAlive = enemyRemainingToSpawn;
        }
        
    }

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawn;
        public int Enemy_hp;
        public float wave_time;
    }


    

}
