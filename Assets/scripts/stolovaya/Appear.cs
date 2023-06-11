using UnityEngine;
using System.Collections;

public class Appear : MonoBehaviour
{

    public float fadeInTime = 1.0f;

    private Renderer renderer;
    private Color color;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        color = renderer.material.color;
        color.a = 0f;
        renderer.material.color = color;
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
            renderer.material.color = color;

            yield return null;
        }

        color.a = 1f;
        renderer.material.color = color;
    }
}
