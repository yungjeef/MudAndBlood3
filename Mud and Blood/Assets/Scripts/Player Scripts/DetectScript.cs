using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScript : MonoBehaviour
{
    bool detected;
    GameObject target;
    GameObject closestEnemy;
    public Transform allied;
    public CircleCollider2D gunRange;

    private Vector3 enemyPosition;
    private Vector3 alliedPosition;
    private float rotated_angle;

    private ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        gunRange.radius = 20;
        explosion = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
        explosion.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        target = FindClosestEnemy();

        if(detected) {
            enemyPosition = target.transform.position;
            alliedPosition = allied.position;
            enemyPosition.x = enemyPosition.x - alliedPosition.x;
            enemyPosition.y = enemyPosition.y - alliedPosition.y;
            rotated_angle = Mathf.Atan2(enemyPosition.y, enemyPosition.x) * Mathf.Rad2Deg;

            allied.rotation = Quaternion.Euler(new Vector3(0, 0, rotated_angle));

            explosion.transform.position = target.transform.position;
            explosion.Play();
        } else {
            allied.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            //explosion.Stop();
        }
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    } 

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Enemy") {
            detected = false;
        }
    }
}
