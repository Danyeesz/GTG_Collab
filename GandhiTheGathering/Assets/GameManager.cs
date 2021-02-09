using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Transform tutorial;
    public float GameTime;
    public Transform Followers;
    
   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tutorial());
       
    }

    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;
        if (GameTime > 30)
        {
            tutorial.GetChild(3).gameObject.SetActive(true);
        }
        if (GameTime > 60)
        {
            tutorial.GetChild(3).gameObject.SetActive(false);
        }

        if (Followers.childCount == 0)
        {
            Invoke("Lost", 2.0f);
            
        }

    }

    IEnumerator Tutorial()
    {
        tutorial.GetChild(0).gameObject.SetActive(true);
        while (GameTime<=10)
        {
            tutorial.GetChild(1).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            tutorial.GetChild(1).gameObject.SetActive(false);
            tutorial.GetChild(2).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            tutorial.GetChild(2).gameObject.SetActive(false);
        }
        tutorial.GetChild(0).gameObject.SetActive(false);
        tutorial.GetChild(3).gameObject.SetActive(false);
    }

    public void Lost() 
    {
        SceneManager.LoadScene(2);
    }
}
