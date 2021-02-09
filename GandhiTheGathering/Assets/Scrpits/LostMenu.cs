using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class LostMenu : MonoBehaviour
{
    public TextMeshProUGUI maxtext;

    // Start is called before the first frame update
    void Start()
    {
        maxtext.text += "\n" + PlayerPrefs.GetInt("MaxFollowers").ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PAgain() 
    {
        SceneManager.LoadScene(1);
    }

    public void BTM()
    {
        SceneManager.LoadScene(0);
    }
}
