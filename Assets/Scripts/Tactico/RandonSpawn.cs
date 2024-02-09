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
    private GameObject obsidiana;
    [SerializeField]
    private GameObject lava;

    [SerializeField]
    private float spawnTimeRoca = 3.5f;
    [SerializeField]
    private float spawnTimeDiamante = 10f;
    [SerializeField]
    private float spawnTimeObsidiana = 3.5f;
    [SerializeField]
    private float spawnTimeLava = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnTimeRoca, roca));
        StartCoroutine(spawnEnemy(spawnTimeDiamante, diamante));
        StartCoroutine(spawnEnemy(spawnTimeRoca, obsidiana));
        StartCoroutine(spawnEnemy(spawnTimeDiamante, lava));
    }

    private IEnumerator spawnEnemy(float interval, GameObject minerales)
    {
        yield return new WaitForSeconds(interval);
        GameObject newMineral = Instantiate(minerales, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, minerales));
    }
}
