using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Castscene : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform dialogTransform;
    private int currentChildIndex = 0;
    [SerializeField] private int _buildSceneIndex;

    private IEnumerator Start()
    {
        dialogTransform = this.transform;
        while (currentChildIndex < dialogTransform.childCount)
        {
            yield return StartCoroutine(ShowDialogForSeconds(dialogTransform.GetChild(currentChildIndex).gameObject, 3.5f));
            currentChildIndex++;
        }
        SceneManager.LoadScene(_buildSceneIndex, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ShowDialogForSeconds(GameObject dialogObject, float seconds)
    {
        dialogObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        dialogObject.SetActive(false);
        if (currentChildIndex > 0)
        {
            dialogTransform.GetChild(currentChildIndex - 1).gameObject.SetActive(false);
        }
    }
}
