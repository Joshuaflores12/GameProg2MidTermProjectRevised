//using JetBrains.Annotations;
//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using UnityEngine;

//public class BulletSpawner : MonoBehaviour
//{
//    public Transform BulletDirectionPlayer;
//    public Transform SpawnPointPosition;
//    public float spawnMin;
//    public float spawnMax;
//    public float BulletSpeed;
//    public float rotSpeed;
//    public float shootingRadius;
//    private bool isEnemyInRange = false;
//     public GameManager gameManager;
//    [SerializeField] private float SpawnTimer;
//    public GameObject PlayerBullet;




//    // Start is called before the first frame update
//    void Start()
//    {
//        SpawnTimer = Random.Range(spawnMin, spawnMax);

//    }
//    // Update is called once per frame
//    void Update()
//    {

//        if (BulletDirectionPlayer != null)
//        {
//            float distanceToPlayer = Vector3.Distance(transform.position, BulletDirectionPlayer.position);

//            // Check if the player is within the shooting range
//            if (distanceToPlayer <= shootingRadius)
//            {
//                isEnemyInRange = true;
//                RotatesTowardsEnemy();
//            }
//            else
//            {
//                isEnemyInRange = false;
//            }

//            if (isEnemyInRange)
//            {
//                PlayerAutoShoot();
//            }
//        }

//        // Check if the player is within the shooting range

//    }

//    void PlayerAutoShoot()
//    {
//        SpawnTimer -= Time.deltaTime;

//        if (SpawnTimer <= 0)
//        {
//            Vector3 BulletDirection = (BulletDirectionPlayer.position - SpawnPointPosition.position).normalized;
//            GameObject PlayerBullet1 = Instantiate(PlayerBullet, SpawnPointPosition.position, Quaternion.identity);
//            Rigidbody BulletRB = PlayerBullet1.GetComponent<Rigidbody>();
//            if (BulletRB != null)
//            {
//                BulletRB.velocity = BulletDirection * BulletSpeed;
//            }

//            Destroy(PlayerBullet1, 5f);


//        }


//    }

//    void RotatesTowardsEnemy()
//    {
//        Vector3 relativePos = BulletDirectionPlayer.position - transform.position;
//        Quaternion targetRotation = Quaternion.LookRotation(relativePos, Vector3.up);
//        float step = rotSpeed * Time.deltaTime;
//        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
//    }
//    void OnDrawGizmos()
//    {
//        Gizmos.color = Color.red;
//        Gizmos.DrawWireSphere(transform.position, shootingRadius);
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Enemy"))
//        {
//            // Game over condition: When the turret collides with an enemy.
//            gameManager.GameOver();

//        }

//    }// SA PLAYER ITO
//}

using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public GameManager gameManager;
    [Header("Attributes")]

    public float range = 15f;
    public Transform target;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag,GreenEnemyTag,BlueEnemyTag;


    public Transform partToRotate;
    public float turnSpeed = 10f;

    public float fireRate = 1f;

    public GameObject redbulletPrefab;
    public GameObject greenbulletPrefab;
    public GameObject bluebulletPrefab;
    public Transform firePoint;

    public ColorChanger CC;



    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null; // Reset the target if no enemy is in range.
        }

    }

    private void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;


        // Add your logic for shooting or tracking the target here.
    }


    void Shoot()
    {

        if(CC.playerColor == PlayerColor.RedPlayer)
        {

            GameObject bulletGO = (GameObject)Instantiate(redbulletPrefab, firePoint.position, firePoint.rotation);

            BulletScript bullet = bulletGO.GetComponent<BulletScript>();


            if (bullet != null)
                bullet.Seek(target);
        }  if(CC.playerColor == PlayerColor.GreenPlayer)
        {

            GameObject bulletGO = (GameObject)Instantiate(greenbulletPrefab, firePoint.position, firePoint.rotation);

            BulletScript bullet = bulletGO.GetComponent<BulletScript>();


            if (bullet != null)
                bullet.Seek(target);
        }  if(CC.playerColor == PlayerColor.BluePlayer)
        {

            GameObject bulletGO = (GameObject)Instantiate(bluebulletPrefab, firePoint.position, firePoint.rotation);

            BulletScript bullet = bulletGO.GetComponent<BulletScript>();


            if (bullet != null)
                bullet.Seek(target);
        }
       



    }

    void OnDrawGizmos()
    {
        // Draw a red sphere to represent the shooting radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Game over condition: When the turret collides with an enemy.
            gameManager.GameOver();

        }

    }// SA PLAYER ITO
}


