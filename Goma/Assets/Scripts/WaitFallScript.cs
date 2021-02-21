using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitFallScript : MonoBehaviour
{
    BoxCollider bc;
    private void Start() => bc = GetComponent<BoxCollider>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(FallingBlock());
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        bc.enabled = true;
    }

    IEnumerator FallingBlock()
    {
        yield return new WaitForSeconds(2f);
       
        bc.enabled = false;        
    }
}
