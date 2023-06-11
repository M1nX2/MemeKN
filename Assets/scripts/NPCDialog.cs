using System.Collections;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    private Transform dialogTransform;
    private int currentChildIndex = 0;
    private bool sys = true;
    private void Start()
    {
        // �������� ��������� Transform ������� Dialog

        // ���� ������ "Dialog" ������������ ������� "cat"
        dialogTransform = this.transform.Find("Dialog");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        // ���������, ��� ����������� � �������� ������
        if (collision.gameObject.CompareTag("Player")&&sys)
        {
            // �������� ��������� �������� ������� ������� Dialog
            if (currentChildIndex < dialogTransform.childCount)
            {
                StartCoroutine(ShowDialogForSeconds(dialogTransform.GetChild(currentChildIndex).gameObject, 2f));
                if (currentChildIndex != dialogTransform.childCount-1)
                currentChildIndex++;
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
