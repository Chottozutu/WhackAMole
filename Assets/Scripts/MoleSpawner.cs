using System.Collections;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField] private Hole[] holes;

    [SerializeField] private float appearTime = 1.5f;
    [SerializeField] private float hideTime = 1.5f;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            int index = Random.Range(0, holes.Length);

            holes[index].Show();

            yield return new WaitForSeconds(appearTime);

            holes[index].Hide();

            yield return new WaitForSeconds(hideTime);
        }
    }
}