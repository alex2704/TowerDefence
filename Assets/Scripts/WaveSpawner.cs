using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public GameObject[] enemies;

    public float timeBetweenWaves = 5.5f;

    private float countdown = 2f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpanWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpanWave()
    {
        PlayerStats.Money += PlayerStats.Rounds * 30;
        PlayerStats.Rounds++;
        if (waveIndex >= waves.Length)
        {
            for (int i = 0; i < waveIndex; i++)
            {
                int index = Random.Range(0, enemies.Length);
                SpawnEnemy(enemies[index]);
                yield return new WaitForSeconds(1f / 2);
            }
        }
        else
        {
            Wave wave = waves[waveIndex];

            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }
        waveIndex++;

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
