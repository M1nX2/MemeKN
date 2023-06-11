using UnityEngine;
using System.Collections;

public class Dialogs : MonoBehaviour
{
    [SerializeField]    
    private GameObject imageObject;

    void Start()
    {
        imageObject.SetActive(false);
    }
}
