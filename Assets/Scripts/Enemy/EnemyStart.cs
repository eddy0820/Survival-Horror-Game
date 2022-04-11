using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStart : MonoBehaviour
{

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
            if (other.tag == "Player")
            {
                enemy.SetActive(true);
                Destroy(gameObject);
            }
    }
}
