using System.Drawing;
using UnityEngine;

public class BooEnemyController : MonoBehaviour
{
    public Transform player;         // Reference to the player's transform
    public LookAtPlayer look;        // Checking to see if player is looking at them
    public float followSpeed = 5f;   // Speed at which the enemy moves
    public float followRange = 10f;  // Distance within which the enemy starts following
    public float stopDistance = 1.5f; // Distance at which the enemy stops moving closer

   
    void Update()
    {
        // Check if the player is within follow range
        if (player != null)
        {
            
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= followRange && distanceToPlayer > stopDistance && !look.Spotted)
            {
                gameObject.GetComponent<Renderer>().enabled = true;
                // Move the enemy toward the player
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * followSpeed * Time.deltaTime;

                // Optionally rotate to face the player
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * followSpeed);
            }
            else gameObject.GetComponent<Renderer>().enabled = false;
            
        }
    }
}