using UnityEngine;


[CreateAssetMenu(fileName = "NewGameSettings", menuName = "Game/Settings")]
public class GameSettings : ScriptableObject
{
    [Header("Oyun Akış Ayarları")]
    [Tooltip("Oyunun genel ilerleme hızı.")]
    public float gameSpeed = 5f;

    [Tooltip("Hızın zamanla ne kadar artacağı (Zorluk artışı).")]
    public float speedMultiplier = 0.1f;

    [Header("Spawn (Üretim) Ayarları")]
    [Tooltip("Engellerin kaç saniyede bir üretileceği.")]
    public float obstacleSpawnRate = 2f;

    [Tooltip("Toplanabilir objelerin (Kürelerin) kaç saniyede bir üretileceği.")]
    public float collectibleSpawnRate = 5f;

    [Header("Skor Ayarları")]
    [Tooltip("Bir toplanabilir obje alındığında kazanılacak puan.")]
    public int collectibleScoreValue = 10;
}