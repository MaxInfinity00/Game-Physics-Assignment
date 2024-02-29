using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    
    public string nextLevel;
    public bool lastLevel = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.GetComponent<Player>())
        {
            if(lastLevel)
            {
                SceneManager.LoadScene("Menu");
                return;
            }
            else
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
}
