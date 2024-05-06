using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.GetComponent<BaseEnemyController>() != null)
        {
            //if bullet touches an enemy
            //deal damage
            BaseEnemyController enemy = collision.transform.GetComponent<BaseEnemyController>();
            Debug.Log("Threat type: " + enemy.threatType);
            //shoow vfx

            Debug.Log("Bullet hit enemy here");
            SpawnManager.Instance.ReturnKillAttackBulletToPool(this);
        }
    }
}
