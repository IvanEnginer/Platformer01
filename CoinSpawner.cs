using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private Transform _spawnPoints;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.0f);

    private Transform[] _points;

    private void Start()
    {
        FillSpawnPointsArray();

        StartCoroutine(Spawn());
    }

    private void FillSpawnPointsArray()
    {
        _points = new Transform[_spawnPoints.childCount];

        _points[0] = _spawnPoints.GetChild(0);

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            yield return _waitForSeconds;

            Transform target = _points[i];

            var creatCoin = Instantiate(_template, target.position, Quaternion.identity);
        }
    }
}