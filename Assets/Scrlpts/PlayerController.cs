using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    
        rb.constraints = RigidbodyConstraints.FreezePositionX | 
                         RigidbodyConstraints.FreezePositionZ | 
                         RigidbodyConstraints.FreezeRotation;
    }

private void Update()
    {
        if (GameManager.Instance == null) return;

       
        if ((transform.position.y > 5f || transform.position.y < -5f) && !GameManager.Instance.isGameOver)
        {
            GameManager.Instance.GameOver();
        }

        
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !GameManager.Instance.isGameOver)
        {
            Jump();
        }
    }
    private void Jump()
    {
        rb.linearVelocity = Vector3.zero; 
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }
    private void OnTriggerEnter(Collider other)
    {
    
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.Interact(); 
        }
    }
}