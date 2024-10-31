using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; 
using System;

public class Cheese : MonoBehaviour
{
    public GameObject cheeseObject;
    public GameObject playerObject;

    public bool collidingWithPlayer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collidingWithPlayer = true;
            playerObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collidingWithPlayer = false;
            playerObject = null;
        }
    }

    void Update()
    {
        if (playerObject != null && playerObject.GetComponent<PlayerMovement>().carryingCheese)
        {
            cheeseObject.transform.position = playerObject.transform.position;
         /* FMOD.Studio.EventInstance PickupSound;
            PickupSound = RuntimeManager.CreateInstance ("event:/Oneshots/ping");
            PickupSound.start(); */
            RuntimeManager.PlayOneShot ("event:/Oneshots/ping");   /* This my Bookgang ah code ~Shiori */

        }
    }
}