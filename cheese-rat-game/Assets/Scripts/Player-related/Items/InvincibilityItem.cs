using System.Collections;
using UnityEngine;

public class InvincibilityItem : ManualPickupItem
{
    public override void UseItem()
    {
        if (IsUsable())
        {
            _playerHealth.SetToInvincible();
            FMODUnity.RuntimeManager.PlayOneShot("event:/Oneshots/Powerups/Invincible");
            Debug.Log("Player is invincible");
            StartCoroutine(Resetitem(10f));
        }
        else
        {
            Debug.Log("Cannot use this item for this character: " + _playerObject.name);
        }
    }

    private IEnumerator Resetitem(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        Debug.Log("Player can take damage now");
        _playerHealth.ResetInvincibility();
        _playerHealth = null;
        _playerMovement = null;
        _playerObject = null;
        ShowItem();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
