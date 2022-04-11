using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject doorSlider;
    [SerializeField] GameObject doorDown;
    [SerializeField] GameObject doorUp;
    [SerializeField] float tInterval = 0.1f;
    [SerializeField] float secondInterval = 0.1f;
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(OpenDoor());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(CloseDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        float t = 0;

        while (t < 1)
        {
            doorSlider.transform.position = Vector3.Lerp(doorDown.transform.position, doorUp.transform.position, t);
            t += tInterval;
        
            yield return new WaitForSeconds(secondInterval);
        }

        yield break;
    }

    IEnumerator CloseDoor()
    {
        float t = 0;

        while (t < 1)
        {
            doorSlider.transform.position = Vector3.Lerp(doorUp.transform.position, doorDown.transform.position, t);
            t += tInterval;
        
            yield return new WaitForSeconds(secondInterval);
        }

        yield break;
    }
}
