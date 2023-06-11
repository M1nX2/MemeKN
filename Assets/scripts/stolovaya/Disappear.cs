using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Disappear : MonoBehaviour
{
    public Text Text; // ������ �� ��������� Text

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Text = GetComponent<Text>();
            Text.enabled = false; // ������ �����
            SceneManager.LoadScene("CardGame");
        }
    }
}