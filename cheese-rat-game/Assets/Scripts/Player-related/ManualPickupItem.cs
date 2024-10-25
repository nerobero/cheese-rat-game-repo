using System;
using UnityEngine;

public abstract class ManualPickupItem : MonoBehaviour
{
    //protected GameObject _gameObjectRef = null;

    //gameobject reference to the player that owns this pick-up item
    protected GameObject _playerObject = null;

    protected bool collidingWithPlayer = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collidingWithPlayer = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collidingWithPlayer = false;
        }
    }

    public void SetPlayerObject(GameObject playerObject)
    {
        if (playerObject)
        {
            _playerObject = playerObject;
        }
    }

    public abstract bool UseItem();

}
