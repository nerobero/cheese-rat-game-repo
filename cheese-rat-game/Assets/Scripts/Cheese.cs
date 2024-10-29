using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    public GameObject cheeseObject; 
    public GameObject playerObject; 

    public bool collidingWithPlayer = false; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<<< HEAD:cheese-rat-game/Assets/Scripts/Player-related/Items/Cheese.cs
        if (collision.gameObject.tag == "Player")
========
        if (collision.CompareTag("Player"))
>>>>>>>> 6cf6f88c82134f89dddee2cbc0f63974e61ed17f:cheese-rat-game/Assets/Scripts/Cheese.cs
        {
            collidingWithPlayer = true;
            playerObject = collision.gameObject; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
<<<<<<<< HEAD:cheese-rat-game/Assets/Scripts/Player-related/Items/Cheese.cs
        if (collision.gameObject.tag == "Player")
========
        if (collision.CompareTag("Player"))
>>>>>>>> 6cf6f88c82134f89dddee2cbc0f63974e61ed17f:cheese-rat-game/Assets/Scripts/Cheese.cs
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
        }
    }
}
