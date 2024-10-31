using UnityEngine;
using FMODUnity;


public class PickupSound : MonoBehaviour

{
    FMOD.Studio.EventInstance PlayPickup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*
    void Awake()
    {
        PlayPickup = RuntimeManager.CreateInstance("event:/Oneshots/ping");
    }
    */
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            RuntimeManager.PlayOneShot("event:/Oneshots/ping");
        }
    }
}

