using UnityEngine;
using System.Collections;

public class HeroSprite : MonoBehaviour
{

    public Sprite leftImage;
    public Sprite rightImage;
    public Sprite upImage;
    public Sprite downImage;

    public KeyCode key; // �������, ������� ����� �������� ������ ��������
    private int currentTextureIndex = 0; // ������ ������� ��������

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().sprite = leftImage;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().sprite = rightImage;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<SpriteRenderer>().sprite = upImage;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetComponent<SpriteRenderer>().sprite = downImage;
        }
    }
}