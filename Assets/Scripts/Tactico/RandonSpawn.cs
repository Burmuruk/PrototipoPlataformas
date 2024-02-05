using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandonSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject roca;
    [SerializeField]
    private GameObject diamante;

    [SerializeField]
    private float spawnTimeRoca = 3.5f;
    [SerializeField]
    private float spawnTimeDiamante = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnTimeRoca, roca));
        StartCoroutine(spawnEnemy(spawnTimeDiamante, diamante));
    }

    private IEnumerator spawnEnemy(float interval, GameObject roca)
    {
        yield return new WaitForSeconds(interval);
        GameObject newRoca = Instantiate(roca, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, roca));
    }
}
