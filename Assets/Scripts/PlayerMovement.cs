using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody player;
    public GameManager gameManager;

    public float forwardforce;
    public float sensitivity;
    public float jumpForce;
    private float sidewaysforce;
    private bool isGrounded;

    private void Update()
    {
        sidewaysforce = Input.acceleration.x; //gets horizontal orientation
        if (Input.touchCount > 0 && isGrounded) //jumps if screen touched and if player on ground
        {
            player.velocity = new Vector3(player.velocity.x, jumpForce, player.velocity.z);
            isGrounded = false; //not touching ground
        }
    }

    void FixedUpdate()
    {
        Move();
        GameOver();
    }

    private void Move()
    {
        player.velocity = new Vector3(sidewaysforce * sensitivity, player.velocity.y, forwardforce * Time.fixedDeltaTime);
    }
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true; //touching ground
    }
    private void GameOver()
    {
        if (player.position.y < -1f) gameManager.GameOver(); //losing condition
    }
}
