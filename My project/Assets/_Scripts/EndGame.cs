
using UnityEngine;
using UnityEngine.SceneManagement; // For reloading the scene or managing game states

public class EndGame : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with has a specific tag, layer, or any condition you define
        // Remove the if statement if you want any collision to end the game
        if (collision.gameObject.CompareTag("GameOverTrigger"))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // Log to console for debugging
        Debug.Log("Game Over!");

        // Example of reloading the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Alternatively, you can stop the game time
        // Time.timeScale = 0;

        // Or trigger other game-over behaviors (e.g., displaying UI)
    }
}