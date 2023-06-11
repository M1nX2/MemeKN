using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZhendosDialog : MonoBehaviour
{
    private Transform dialogTransform;
    private int currentChildIndex = 0;
    private bool sys = true;
    public int _buildSceneIndex;

    private void Start()
    {
        // �������� ��������� Transform ������� Dialog

        // ���� ������ "Dialog" ������������ ������� "cat"
        dialogTransform = this.transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // ���������, ��� ����������� � �������� ������
        if (collision.gameObject.CompareTag("Player") && sys)
        {
            // �������� ��������� �������� ������� ������� Dialog
            if (currentChildIndex < dialogTransform.childCount)
            {
                if (currentChildIndex == 1) SceneManager.LoadScene(_buildSceneIndex, LoadSceneMode.Single);
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
        dialogObject.SetActive(true);
        sys = false;
        yield return new WaitForSeconds(seconds);
        dialogObject.SetActive(false);
        if (currentChildIndex > 0)
        {
            dialogTransform.GetChild(currentChildIndex - 1).gameObject.SetActive(false);
        }
        sys = true;
    }
}
