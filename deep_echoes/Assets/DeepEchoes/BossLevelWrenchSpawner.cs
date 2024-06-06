using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossLevelWrenchSpawner : MonoBehaviour
{
   [SerializeField] private GameObject wrenchPrefab;
   [SerializeField] private int totalWrenchSpawnCount;
   [SerializeField] private int howManyWrenchWillSpawnEachTime;
   [SerializeField] private float wrenchSpawnInterval;

   private int _spawnedWrenchCount;

   private void Start()
   {
      StartCoroutine(WrenchSpawnCoroutine());
   }

   private IEnumerator WrenchSpawnCoroutine()
   {
      while (_spawnedWrenchCount < totalWrenchSpawnCount)
      {
         for (var i = 0; i < howManyWrenchWillSpawnEachTime; i++)
         {
            var spawnPoint = new Vector3(RandomSign() * Random.Range(6f, 14f), 0, RandomSign() * Random.Range(6f, 14f));
            Instantiate(wrenchPrefab, spawnPoint, Quaternion.identity);
            _spawnedWrenchCount++;
         }
         yield return new WaitForSeconds(wrenchSpawnInterval);
      }
   }

   private static int RandomSign()
   {
      return Random.Range(0, 2) == 1 ? -1 : 1;
   }
}
