using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{    
    public GameManager gameManager;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Obstacle") gameManager.GameOver();
    }
}