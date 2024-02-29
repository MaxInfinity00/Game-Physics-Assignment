using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class LayerOfDeath : MonoBehaviour
{
    // BoxCollider2D boxCollider;
    // void Start()
    // {
    //     boxCollider = GetComponent<BoxCollider2D>();
    //     boxCollider.isTrigger = true;
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            Debug.Log("Player died");
            StartCoroutine(RespawnPlayer());
        }
    }
    
    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
