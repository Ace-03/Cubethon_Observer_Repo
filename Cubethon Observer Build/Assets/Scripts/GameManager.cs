using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    GameObject player;

    private void Start()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        player = playerMovement.gameObject;
    }

    public void OnEnable()
    {
        PlayerCollision.OnHitObstacle += EndGame;
    }

    public void OnDisable()
    {
        PlayerCollision.OnHitObstacle -= EndGame; ;
    }
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void EndGame(Collision collisionInfo)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        PlayerCollision.OnHitObstacle -= EndGame;

        if(collisionInfo != null)
            Debug.Log("Hit: " + collisionInfo.collider.name);

        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
