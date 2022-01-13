using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class WaveManager : MonoBehaviour
{
    [Header("Enemies")]
    public BasicEnemy basicEnemy;

    [Header("Components")]
    public TextMeshProUGUI WaveNumberText;
    public TextMeshProUGUI EnemyNumberText;
    public TextMeshProUGUI WaveTimerText;
    public TextMeshProUGUI NextWaveText;
    public WaveInfo[] waveInfos;

    public WinMenu winMenu;
    [SerializeField] private List<Wave> waves = new List<Wave>();

    private bool ready = false;
    private Transform ENEMIES;
    private int currentWave = 0;
    private int untilNextWave = 30;

    private void Awake()
    {
        ENEMIES = GameObject.Find("ENEMIES").transform;
        NextWaveText.gameObject.SetActive(true);
        waveInfos[0].gameObject.SetActive(true);

    }

    void FixedUpdate()
    {
        if (currentWave == waves.Count && currentWave != 0)
        {
            UpdateFields(waves[currentWave - 1]);
            GameWon();
            return;
        }
        if (waves.Count != 0)
        {
            if (currentWave < waves.Count)
            {
                UpdateFields(waves[currentWave]);
            }
        }
        if (ready == true)
        {
            SpawnWave(waves[currentWave]);
            ready = false;
            currentWave++;
        }
    }

    private void GameWon()
    {
        NextWaveText.gameObject.SetActive(false);
        waveInfos[0].gameObject.SetActive(false);
        waveInfos[1].gameObject.SetActive(false);
        Time.timeScale = 0f;
        winMenu.GameWin();

    }

    private void FillTestWaves()
    {
        for (int i = 0; i < 10; i++)
        {
            Wave w = ScriptableObject.CreateInstance("Wave") as Wave;
            w.SpawnTile1 = Global.Instance.spawnTile;
            w.EnemyType1 = basicEnemy;
            w.Count1 = 10 + i;
            w.Countdown = 30;
            waves.Add(w);
        }
    }

    private void UpdateFields(Wave wave)
    {
        WaveNumberText.text = $"Wave: {currentWave}/{waves.Count}";
        EnemyNumberText.text = $"Enemies: {Global.Instance.enemies.Count}";
        WaveTimerText.text = $"Until next wave: {untilNextWave}";
        waveInfos[0].enemyNameText.text = $"{wave.EnemyType1.GetType()}";
        waveInfos[0].enemyCountText.text = $"{wave.Count1}";
        if (wave.EnemyType2 != null)
        {
            waveInfos[1].gameObject.SetActive(true);
            waveInfos[1].enemyNameText.text = $"{wave.EnemyType2.GetType()}";
            waveInfos[1].enemyCountText.text = $"{wave.Count2}";
        }
        else
        {
            waveInfos[1].gameObject.SetActive(false);
        }

    }

    private void SpawnWave(Wave wave)
    {
        if (wave.EnemyType1 != null)
        {
            StartCoroutine("SpawnWavePart1", wave);
        }
        if (wave.EnemyType2 != null)
        {
            StartCoroutine("SpawnWavePart1", wave);
        }
    }

    IEnumerator SpawnWavePart1(Wave wave)
    {
        for (int i = 0; i < wave.Count1; i++)
        {
            Enemy enemy = Instantiate(wave.EnemyType1, new Vector3(wave.SpawnTile1.transform.position.x, 1, wave.SpawnTile1.transform.position.z), Quaternion.identity);
            enemy.name = $"Enemy{i}";
            float delay = enemy.Speed / 1000f;
            Global.Instance.enemies.Add(enemy);
            enemy.transform.SetParent(ENEMIES);
            yield return new WaitForSeconds(0.2f);
        }
        yield break;
    }

    IEnumerator SpawnWavePart2(Wave wave)
    {
        for (int i = 0; i < wave.Count2; i++)
        {
            Enemy enemy = Instantiate(wave.EnemyType2, new Vector3(wave.SpawnTile1.transform.position.x, 1, wave.SpawnTile1.transform.position.z), Quaternion.identity);
            enemy.name = $"Enemy{i}";
            float delay = enemy.Speed / 1000f;
            Global.Instance.enemies.Add(enemy);
            enemy.transform.SetParent(ENEMIES);
            yield return new WaitForSeconds(0.2f);
        }
        yield break;
    }

    public void PlayerReady()
    {
        FillTestWaves();
        ready = true;
        InvokeRepeating("DecreaseTime", 1f, 1f);
    }

    private void DecreaseTime()
    {
        if (untilNextWave > 0)
        {
            untilNextWave -= 1;
        }
        if (untilNextWave == 0)
        {
            ready = true;
            untilNextWave = waves[currentWave].Countdown;
        }
    }
}
