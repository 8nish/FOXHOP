using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Transform currentCheckpoint; 
    private Health playerhealth; 
    private UIManager uiManager; 

    private void Awake()
    {
        playerhealth = GetComponent<Health>(); //get the Health component
        uiManager = Object.FindFirstObjectByType<UIManager>(); //find the UIManager in the scene
    }

    public void Respawn2()
    {
        if (currentCheckpoint == null)
        {
            uiManager.GameOver(); // Show Game Over screen
            return;
        }

        //move player to the checkpoint
        transform.position = currentCheckpoint.position;

        //restore player health
        playerhealth.Respawn1();

        //move the camera to the new room
        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; //update the checkpoint
            collision.GetComponent<Collider2D>().enabled = false; //disable the checkpoint collider
            collision.GetComponent<Animator>().SetTrigger("Appear"); //trigger the appear animation
        }
    }
}
