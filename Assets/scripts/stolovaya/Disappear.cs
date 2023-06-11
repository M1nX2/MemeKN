using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Disappear : MonoBehaviour
{
    public Text Text; // ссылка на компонент Text

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Text = GetComponent<Text>();
            Text.enabled = false; // скрыть текст
            SceneManager.LoadScene("CardGame");
        }
    }
}