using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevelScript : MonoBehaviour
{
    public int index;
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(waitingbeforelevelchange());
        }
    }
 
    IEnumerator waitingbeforelevelchange()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(index);

    }
}
