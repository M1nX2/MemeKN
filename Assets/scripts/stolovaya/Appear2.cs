using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Appear2 : MonoBehaviour
{
    public float fadeInTime = 1.0f;

    private Text text;
    private Color color;

    void Start()
    {
        text = GetComponent<Text>();
        color = text.color;
        color.a = 0f;
        text.color = color;
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1f);

        float elapsedTime = 0.0f;

        while (elapsedTime < fadeInTime)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeInTime);
            text.color = color;

            yield return null;
        }

        color.a = 1f;
        text.color = color;
    }
}
