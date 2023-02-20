using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ScoreSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _scorePrefab;
    private Vector3 _randomSpawnPosition;
    private void Start()
    {
        StartCoroutine(DelaySpawn());
        //ScoreSpawn();
    }
    public void ScoreSpawn()
    {
        _randomSpawnPosition = new Vector3(Random.Range(-8, 2), transform.position.y, Random.Range(11, 1));
        Instantiate(_scorePrefab, _randomSpawnPosition, Quaternion.identity);
    }
    public IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(10f);
        ScoreSpawn();
    }
}
