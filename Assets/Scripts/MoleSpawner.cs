using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField] private Hole[] holes;

    [Header("出現間隔")]
    [SerializeField] private float minSpawnInterval = 0.3f;
    [SerializeField] private float maxSpawnInterval = 1.5f;

    [Header("出現時間")]
    [SerializeField] private float appearTime = 1.5f;

    [Header("同時出現数")]
    [SerializeField] private int minSpawnCount = 1;
    [SerializeField] private int maxSpawnCount = 3;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            // 次の出現までランダム待機
            float wait = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(wait);

            // 今回出すモグラの数
            int spawnCount = Random.Range(minSpawnCount, maxSpawnCount + 1);

            // 重複しないように穴をコピー
            List<Hole> candidates = new List<Hole>(holes);
            List<Hole> appeared = new List<Hole>();

            for (int i = 0; i < spawnCount; i++)
            {
                if (candidates.Count == 0)
                    break;

                int index = Random.Range(0, candidates.Count);

                Hole hole = candidates[index];

                hole.Show();

                appeared.Add(hole);
                candidates.RemoveAt(index);
            }

            // 出現時間
            yield return new WaitForSeconds(appearTime);

            // 全員引っ込める
            foreach (Hole hole in appeared)
            {
                hole.Hide();
            }
        }
    }
}