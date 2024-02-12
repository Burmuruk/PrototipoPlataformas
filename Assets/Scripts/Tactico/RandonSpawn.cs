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
    private float spawnTimeRoca;
    [SerializeField]
    private float spawnTimeDiamante;
    [SerializeField]
    private float spawnTimeObsidiana;
    [SerializeField]
    private float spawnTimeLava;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnTimeRoca, roca));
        StartCoroutine(spawnEnemy(spawnTimeDiamante, diamante));
        StartCoroutine(spawnEnemy(spawnTimeObsidiana, obsidiana));
        StartCoroutine(spawnEnemy(spawnTimeLava, lava));
    }

    private IEnumerator spawnEnemy(float interval, GameObject minerales)
    {
        yield return new WaitForSeconds(interval);
        GameObject newMineral = Instantiate(minerales, new Vector3(Random.Range(-8f, 7), Random.Range(-7f, 7f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, minerales));
    }
}
