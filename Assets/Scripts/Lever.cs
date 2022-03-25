using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject txtToDisplay;             //display the UI text

    private bool PlayerInZone;                  //check if the player is in trigger

    private void Start()
    {

        PlayerInZone = false;                   //player not in zone       
        txtToDisplay.SetActive(false);
    }

    private void Update()
    {
        if (PlayerInZone && Input.GetKeyDown(KeyCode.E))           //if in zone and press F key
        {
            //Play lever sound
            gameObject.GetComponent<AudioSource>().Play();
            //Play lever animation
            gameObject.GetComponent<Animator>().Play("lever");

            StartCoroutine(QuitGame());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")     //if player in zone
        {
            txtToDisplay.SetActive(true);
            PlayerInZone = true;
        }
    }


    private void OnTriggerExit(Collider other)     //if player exit zone
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInZone = false;
            txtToDisplay.SetActive(false);
        }
    }

    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(0.8f);

        //Quit game when lever is pressed
        Application.Quit();

    }
}
