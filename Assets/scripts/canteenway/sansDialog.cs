using System.Collections;
using UnityEngine;

public class sansDialog : MonoBehaviour
{
    private Transform dialogTransform;
    private int currentChildIndex = 0;
    private bool sys = true;
    private void Start()
    {
        // Получаем компонент Transform объекта Dialog

        // Ищем объект "Dialog" относительно объекта "cat"
        dialogTransform = this.transform.Find("Dialog");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Проверяем, что столкнулись с объектом игрока
        if (collision.gameObject.CompareTag("Player") && sys)
        {
            // Включаем следующий дочерний элемент объекта Dialog
            if (currentChildIndex < dialogTransform.childCount)
            {            
                if (currentChildIndex == 1) this.gameObject.SetActive(false);
                else
                {
                    StartCoroutine(ShowDialogForSeconds(dialogTransform.GetChild(currentChildIndex).gameObject, 2f));
                    if (currentChildIndex != dialogTransform.childCount - 1)
                        currentChildIndex++;
                }
            }
        }
    }

    IEnumerator ShowDialogForSeconds(GameObject dialogObject, float seconds)
    {
            dialogTransform.gameObject.SetActive(true);
            dialogObject.SetActive(true);
            sys = false;
            yield return new WaitForSeconds(seconds);
            dialogObject.SetActive(false);
            dialogTransform.gameObject.SetActive(false);
            if (currentChildIndex > 0)
            {
                dialogTransform.GetChild(currentChildIndex - 1).gameObject.SetActive(false);
            }
            sys = true;      
    }
}
