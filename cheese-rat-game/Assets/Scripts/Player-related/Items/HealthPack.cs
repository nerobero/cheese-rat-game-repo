using UnityEngine;

public class HealthPack : ManualPickupItem
{
    [SerializeField] private float _healAmount;
    public override void UseItem()
    {
        if (IsUsable())
        {
            _playerHealth.Heal(_healAmount);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Oneshots/Powerups/Healing");
            Debug.Log("Player health healed");
            ShowItem();
        } else
        {
            Debug.Log("Cannot use this item for this character: " + _playerObject.name);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        _healAmount = 40f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
