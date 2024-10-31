using UnityEngine;

public class ProjectileBase : MonoBehaviour
{

    [SerializeField] protected float _maxProjDistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        if (isOutOfMaxDist())
        {
            Destroy(gameObject);
        }
    }

    private bool isOutOfMaxDist()
    {
        return transform.position.x > _maxProjDistance 
            || transform.position.x < -_maxProjDistance
            || transform.position.y > _maxProjDistance
            || transform.position.y <-_maxProjDistance;
    }
}
