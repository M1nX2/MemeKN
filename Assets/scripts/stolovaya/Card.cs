using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Card : MonoBehaviour
{
    [SerializeField] private CardGame game;
    [SerializeField] public Sprite backSprite;
    [SerializeField] public Sprite frontSprite;
    [SerializeField] public int number;
    

    public int Number => number;
    public bool Up => this.GetComponent<SpriteRenderer>().sprite == frontSprite;


    public void OnMouseDown() 
    {
        if (!Up&&game.Sys)
        {
            UpCard();         
            game.OpenCard();
        }   
    }   
    public void NoFindCard()
    {
        this.GetComponent<SpriteRenderer>().sprite = backSprite;
    }
    public void UpCard() 
    {
        this.GetComponent<SpriteRenderer>().sprite = frontSprite;
    } 
}