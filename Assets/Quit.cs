using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("QuitApplication", 3f);
    }
    void QuitApplication()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
