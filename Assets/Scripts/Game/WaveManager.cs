using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class WaveManager : MonoBehaviour
{
    [Header("Components")]
    public TextMeshProUGUI WaveNumberText;
    public TextMeshProUGUI EnemyNumberText;
    public TextMeshProUGUI WaveTimerText;
    public TextMeshProUGUI NextWaveText;
    public WaveInfo[] waveInfos;
    public WinMenu winMenu;
    public GameObject NextWaveInfoHolder;

    public Wave[] waves;
    private bool gameStarted = false;
    private int currentWave = -1;
    private float countdown = 0;

    private void Update()
    {
        UpdateNextWave();

        if (!gameStarted)
        {
            UpdateFields(waves[currentWave + 1]);
            return;
        }

        if (countdown <= 0)
        {
            currentWave++;
            StartCoroutine(SpawnWave(waves[currentWave]));
            countdown = waves[currentWave].countdown;
        }
        else
        {
            countdown -= Time.deltaTime;
        }
        if (currentWave == waves.Length - 1)
        {
            NextWaveInfoHolder.SetActive(false);
            WaveTimerText.gameObject.SetActive(false);
        }
        UpdateFields(waves[currentWave]);

        if (currentWave == waves.Length - 1 && Global.Instance.enemies.Count == 0)
        {
            GameWon();
        }

    }
    private void UpdateFields(Wave wave)
    {
        if (currentWave != waves.Length)
        {
            WaveNumberText.text = $"Wave: {currentWave + 1}/{waves.Length}";
        }
        EnemyNumberText.text = $"Enemies: {Global.Instance.enemies.Count}";
        WaveTimerText.text = $"Until next wave: {Math.Floor(countdown)}";

    }
    private void UpdateNextWave()
    {
        if (currentWave != waves.Length - 1)
        {
            waveInfos[0].enemyNameText.text = $"{waves[currentWave + 1].enemy.GetType()}";
            waveInfos[0].enemyCountText.text = $"Count: {waves[currentWave + 1].count}";
        }
        else
        {
            waveInfos[0].enemyNameText.text = $"";
            waveInfos[0].enemyCountText.text = $"";
        }
    }
    public void StartSpawning()
    {
        gameStarted = true;
        NextWaveText.gameObject.SetActive(true);
    }
    IEnumerator SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(0.5f);
        }
        yield break;
    }

    private void SpawnEnemy(Enemy enemyType)
    {
        Enemy enemy = Instantiate(enemyType, Global.Instance.spawnTile.transform.position, Quaternion.identity);
        Global.Instance.enemies.Add(enemy);
    }

    public void SkipWave()
    {
        if (currentWave == waves.Length - 1) return;
        countdown = 0;
    }
    private void GameWon()
    {
        NextWaveText.gameObject.SetActive(false);
        waveInfos[0].gameObject.SetActive(false);
        Time.timeScale = 0f;
        winMenu.GameWin();
    }
}

