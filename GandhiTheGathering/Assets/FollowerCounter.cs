using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FollowerCounter : MonoBehaviour
{

    public TextMeshProUGUI followers;

    // Start is called before the first frame update
    void Start()
    {
        followers.text = "Followers: " + transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        followers.text = "Followers: " + transform.childCount;
    }
}
