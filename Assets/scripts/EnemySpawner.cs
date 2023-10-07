using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject RedEnemy;
    public GameObject GreenEnemy;
    public GameObject BlueEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    public int Color;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    

    IEnumerator EnemyDrop() 
    {
        Color = Random.Range(1,4);
        
        switch (Color) 
        {
                case 1:
                while (enemyCount < 1)
                {
                    xPos = Random.Range(90, 60);
                    zPos = Random.Range(90, 60);
                    Instantiate(RedEnemy, new Vector3(xPos, 0.3f, zPos), Quaternion.identity);
                    yield return new WaitForSeconds(0.5f);
                    enemyCount += 1;
                }
                break;
                case 2:
                while (enemyCount < 1)
                {
                    xPos = Random.Range(90, 60);
                    zPos = Random.Range(90, 60);
                    Instantiate(GreenEnemy, new Vector3(xPos, 0.3f, zPos), Quaternion.identity);
                    yield return new WaitForSeconds(0.5f);
                    enemyCount += 1;
                }
                break;
                case 3:
                while (enemyCount < 1)
                {
                    xPos = Random.Range(90, 60);
                    zPos = Random.Range(90, 60);
                    Instantiate(BlueEnemy, new Vector3(xPos, 0.3f, zPos), Quaternion.identity);
                    yield return new WaitForSeconds(0.5f);
                    enemyCount += 1;
                }
                break;
        }
        
       
    }
}
