/** Author's Name:          Laura Amangeldiyeva
 *  Last Modified By:       Laura Amangeldiyeva
 *  Date Last Modified:     October 10, 2023
 *  Program Description:    A script that moves the player.
 *  Revision History:       October 10, 2023 (Laura Amangeldiyeva): Initial PlayerMove script.
 */

using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;


    void Start()
    {
        
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
     
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();


        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);

        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }


}




/*[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    Vector3 movementVector;

    [SerializeField] float speed = 3f;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
    }


    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        movementVector *= speed;

        rgbd2d.velocity = movementVector;
    }
}*/
