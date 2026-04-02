using UnityEngine;

public class Mover : MonoBehaviour, IPoolable
{
    private bool isMoving = false;

    public void OnSpawned()
    {
        isMoving = true;
    }

    public void OnDespawned()
    {
        isMoving = false;
        gameObject.SetActive(false); 
    }

    private void Update()
    {
        if (isMoving && !GameManager.Instance.isGameOver)
        {
           
            transform.Translate(Vector3.left * GameManager.Instance.currentSpeed * Time.deltaTime);

            if (transform.position.x < -15f)
            {
                OnDespawned();
            }
        }
    }
}