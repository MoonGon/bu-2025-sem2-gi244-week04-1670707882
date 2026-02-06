using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float xRange = 10;

    private InputAction moveAction;
    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        var hInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(hInput * speed * Time.deltaTime * Vector3.right);
        if (transform.position.x < -xRange)
        {
           transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
           transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 left = new Vector3(-xRange, transform.position.y, transform.position.z);
        Vector3 right = new Vector3(-xRange, transform.position.y, transform.position.z);

        Gizmos.DrawLine(left, right);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(left, 0.5f);
        Gizmos.DrawSphere(right, 0.5f);
    }
}
