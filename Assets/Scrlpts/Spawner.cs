using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private void Start()
    {
        // Engeller ve küreler için iki ayrı Coroutine başlatıyoruz
        StartCoroutine(SpawnObstacleRoutine());
        StartCoroutine(SpawnCollectibleRoutine());
    }

    private IEnumerator SpawnObstacleRoutine()
    {
        // Oyun bitmediği sürece çalışır
        while (!GameManager.Instance.isGameOver)
        {
            yield return new WaitForSeconds(GameManager.Instance.settings.obstacleSpawnRate);
            
            // Engel normal Spawner pozisyonunda (X) üretilir
            Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(-2f, 3f), transform.position.z);
            
            // Havuzdan engeli çağır
            ObjectPool.Instance.SpawnFromPool("Obstacle", spawnPos, Quaternion.identity);
        }
    }

    private IEnumerator SpawnCollectibleRoutine()
    {
        // İlk başta engellerle aynı anda çıkmasın diye bir süre bekle
        yield return new WaitForSeconds(GameManager.Instance.settings.collectibleSpawnRate / 2f);

        while (!GameManager.Instance.isGameOver)
        {
            
            float randomDelay = Random.Range(-0.7f, 0.7f); 
            yield return new WaitForSeconds(GameManager.Instance.settings.collectibleSpawnRate + randomDelay);
            
           
            Vector3 spawnPos = new Vector3(transform.position.x + 8f, Random.Range(-2.5f, 2.5f), transform.position.z);
            
           
            ObjectPool.Instance.SpawnFromPool("Collectible", spawnPos, Quaternion.identity);
        }
    }
}