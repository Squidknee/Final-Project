using System.Collections;
using UnityEngine;

namespace _app.Scripts.Triggers
{
    public class RandomSpawner : MonoBehaviour
    {
        //TODO: implement rarity system locations
        public GameObject[] commonFruitPrefabs; 
        public GameObject[] uncommonFruitPrefabs;
        public float spawnInterval = 30f;
        public float spawnRange = 20f;
        
        private void Start()
        {
            StartCoroutine(SpawnRandomFruit());
        }

        private IEnumerator SpawnRandomFruit()
        {
            while (true) // Loop forever
            {
                // Choose a random prefab from either array (common or uncommon)
                GameObject fruitToSpawn = GetRandomFruitPrefab();

                // Generate a random position within a defined range
                Vector3 randomPosition = new Vector3(
                    Random.Range(-spawnRange, spawnRange),
                    0f, // Set Y position to avoid spawning below the ground
                    Random.Range(-spawnRange, spawnRange)
                );

                // Instantiate the fruit prefab at the random position
                Instantiate(fruitToSpawn, randomPosition, Quaternion.identity);

                // Wait for the specified interval before spawning the next fruit
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        private GameObject GetRandomFruitPrefab()
        {
            // Randomly choose between common and uncommon fruit
            bool isCommon = Random.value < 0.75f; // 75% chance for common

            if (isCommon && commonFruitPrefabs.Length > 0)
            {
                return commonFruitPrefabs[Random.Range(0, commonFruitPrefabs.Length)];
            }
            else if (!isCommon && uncommonFruitPrefabs.Length > 0)
            {
                return uncommonFruitPrefabs[Random.Range(0, uncommonFruitPrefabs.Length)];
            }

            return null; // No fruit prefabs available
        }
    }
}