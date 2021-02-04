using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowerCounter : MonoBehaviour
{

    public TextMeshProUGUI Followers;
    public int FollowerCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowerCount = transform.childCount;
        Followers.text = "Followers:" + (FollowerCount);
    }
}
