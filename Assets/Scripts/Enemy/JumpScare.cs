using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    
    //public AudioSource Ghost;
    public GameObject player;
    public GameObject jump;
    public GameObject lose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.tag == "Player")
        {
            StartCoroutine (EndJump());
        }
    }

    IEnumerator EndJump()
    {
        GetComponent<MeshRenderer>().enabled = false;
        jump.SetActive(true);
        player.GetComponent<Movement>().enabled = false;

        yield return new WaitForSeconds (3f);
        jump.SetActive(false);
        lose.SetActive(true);
        Destroy(gameObject);
    }
}
