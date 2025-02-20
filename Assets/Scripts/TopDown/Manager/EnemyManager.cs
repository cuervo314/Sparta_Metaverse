using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Coroutine waveRoutine;

    [SerializeField] private List<GameObject> enemyPrefabs;

    [SerializeField] List<Rect> spawnAreas;
    [SerializeField] private Color gizmoColor = new Color(1, 0, 0, .3f);
    private List<EnemyController4> activeEnemies = new List<EnemyController4>();

    private bool enemySpawnComplite;

    [SerializeField] private float timeBetweenSpawns = 0.2f;
    [SerializeField] private float timeBetweenWaves = 1f;

    MiniManager4 miniManager4;

    public void Init(MiniManager4 miniManager4 )
    {
        this.miniManager4 = miniManager4;
    }

    public void StartWave(int waveCount)
    {

        if(waveCount <= 0)
        {
            miniManager4.EndofWave();
            return;
        }
        if(waveRoutine != null)
        {
            StopCoroutine(waveRoutine);
        }
        waveRoutine = StartCoroutine(SpawnWave(waveCount));
    }

    public void SpawnWave()
    {
        StopAllCoroutines();
    }

    public void StopWave()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnWave(int waveCount)
    {
        enemySpawnComplite = false;
        yield return new WaitForSeconds(timeBetweenWaves);

        for(int i = 0; i < waveCount; i++)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);
            SpawnRandomEnemy();
        }

        enemySpawnComplite = true;
    }

    private void SpawnRandomEnemy()
    {
        if(enemyPrefabs.Count == 0 || spawnAreas.Count == 0)
        {
            Debug.Log("Enemy Prefabs �Ǵ� Spawn Area�� �������� �ʾҽ��ϴ�.");
            return;
        }

        GameObject randomPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

        Rect randomArea = spawnAreas[Random.Range(0, spawnAreas.Count)];

        Vector2 randomPosition = new Vector2(
            Random.Range(randomArea.xMin, randomArea.xMax),
            Random.Range(randomArea.yMin, randomArea.yMax));

        GameObject spawnEnemy = Instantiate(randomPrefab, new Vector3(randomPosition.x, randomPosition.y), Quaternion.identity);
        EnemyController4 enemyController4 = spawnEnemy.GetComponent<EnemyController4>();
        enemyController4.Init(this, miniManager4.player.transform);

        activeEnemies.Add(enemyController4);
    }

    private void OnDrawGizmosSelected()
    {
        if (spawnAreas == null) return;

        Gizmos.color = gizmoColor;
        foreach(var area in spawnAreas)
        {
            Vector3 center = new Vector3(area.x + area.width / 2, area.y + area.height / 2);
            Vector3 size = new Vector3(area.width, area.height);

            Gizmos.DrawCube(center, size);
        }
    }

    public void RemoveEnemyOnDeath(EnemyController4 enemy)
    {
        activeEnemies.Remove(enemy);
        if(enemySpawnComplite && activeEnemies.Count == 0 )
            miniManager4.EndofWave();
    }
}
