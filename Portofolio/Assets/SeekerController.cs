using UnityEngine;

public class SeekerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5.0f;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");   
        float vertical = Input.GetAxisRaw("Vertical");   

        Vector3 movementDirection = new Vector3(horizontal, 0.0f, vertical);
        movementDirection.Normalize();

        transform.position += movementSpeed * Time.deltaTime * movementDirection;
    }
}
