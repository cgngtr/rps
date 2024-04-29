using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float spawnPositionX;
    float spawnPositionY;
    public int objectAmount;
    public GameManager _gameManager;
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private GameObject paperPrefab;
    [SerializeField] private GameObject scissorsPrefab;
    [SerializeField] private SliderReader _sr;

    void Start()
    {
        _gameManager = GetComponent<GameManager>();
        _sr = GetComponent<SliderReader>();
        objectAmount = (int)_sr.spawnSlider.value;
        Debug.Log(objectAmount);
    }

    void Update()
    {

    }

    public Vector3 GetRandomSpawnPos()
    {
        float x = Random.Range(-7, 7);
        float y = Random.Range(-4, 3);
        return new Vector3(x, y, 0f);
    }

    public void Spawn()
    {
        Vector2 spawnPosition = new Vector2(spawnPositionX, spawnPositionY);

            for (int i = 0; i < _gameManager.objectAmount; i++)
            {
                Instantiate(rockPrefab, GetRandomSpawnPos(), Quaternion.identity);
                Instantiate(paperPrefab, GetRandomSpawnPos(), Quaternion.identity);
                Instantiate(scissorsPrefab, GetRandomSpawnPos(), Quaternion.identity);
            }
        // Random x pos range = -1,14.5
        // Random y pos range = -5.57, 2.42
        // include all of them.
    }
}
