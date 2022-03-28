using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    
    //public AudioSource Ghost;
    public GameObject player;
    public GameObject jump;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {

        if(collider.CompareTag("Player"))
        {
            StartCoroutine (EndJump());
        }
    }

    void OnTriggerExit(Collider collision)
    {

        if(collision.CompareTag("Player"))
        {
            Destroy(jump.gameObject);
            Destroy(gameObject);
        }
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds (1f);
        //Ghost.Play();
        jump.SetActive(true);
        player.GetComponent<Movement>().enabled = false;

        yield return new WaitForSeconds (2f);
        jump.SetActive(false);
    }
}
