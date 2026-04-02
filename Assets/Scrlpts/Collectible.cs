using UnityEngine;

public class Collectible : MonoBehaviour, IInteractable
{
    public void Interact()
    {
       
        GameManager.Instance.AddScore(GameManager.Instance.settings.collectibleScoreValue); 
        
      
        gameObject.SetActive(false); 
    }
}
