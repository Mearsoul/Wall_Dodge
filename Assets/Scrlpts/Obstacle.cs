using UnityEngine;

public class Obstacle : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameManager.Instance.GameOver();
    }
}