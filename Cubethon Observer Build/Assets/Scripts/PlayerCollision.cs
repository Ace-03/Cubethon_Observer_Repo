using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    public delegate void HitObstiacle(Collision collisionInfo);
    public static event HitObstiacle OnHitObstacle;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "obstacle") 
        {
            //movement.enabled = false;
            //FindObjectOfType<GameManager>().EndGame();
        
            if(OnHitObstacle != null)
                OnHitObstacle(collisionInfo);
        }
    }
}
