using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class CardGame : MonoBehaviour
{
    
    [SerializeField] private Transform panelCard;
    [SerializeField] private List<Card> cards;
    private List<Vector3> pos=new List<Vector3>();
    private int numberCard;
     private int numberCard2;
    public bool sys = true;
    public bool Sys => sys;
    [SerializeField]
    private int _buildSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        int[] arr = { 0, 1, 2, 3, 4, 5 ,6 ,7 ,8 ,9, 10, 11, 12, 13 };

        for (int i = arr.Length - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        foreach (int num in arr)
        {
            Debug.Log(num + " ");
        }

        for (int i = 0; i < panelCard.childCount; i++)
        {
            var card = panelCard.GetChild(i).GetComponent<Card>();
            Debug.Log(card.transform.position);
            pos.Add(card.transform.position);           
            cards.Add(card);
        }
        for (int i = 0; i < panelCard.childCount; i++)
        {
            panelCard.GetChild(i).GetComponent<Card>().transform.position = pos[arr[i]];
        }
     }
    private IEnumerator DownWithTimeOut(Card card)
    {
        yield return new WaitForSeconds(1);
        card.GetComponent<Card>().NoFindCard();
        sys = true;
    }
    public void OpenCard()
    {
        int openCard = 0;
        foreach (Card card in cards)
        {
            if (card.GetComponent<Card>().Up)
            {
                if (openCard == 0)
                {
                    numberCard = card.Number;                
                }
                else if(openCard == 1)
                {
                    numberCard2 = card.Number;
                }
                openCard++;
            }
        }
        if (openCard == 2 )
        {
            if (numberCard == numberCard2)
            {
                //for (int i=0;i< Card card in cards)
                //{
                //    if (card.GetComponent<Card>().Number == numberCard)
                //    { 
                //        cards.Remove(card); 
                //    }
                //}
                foreach(Card card in cards.FindAll((card1) => card1.GetComponent<Card>().Number == numberCard)) cards.Remove(card);
                if (cards.Count == 0)
                {
                    SceneManager.LoadScene(_buildSceneIndex, LoadSceneMode.Single);
                    //Новая сцена
                }
               
            }
            else
            {

                foreach (Card card in cards)
                {
                    if (card.GetComponent<Card>().Up)
                    {

                        // Thread.Sleep(1000);
                        sys = false;
                        this.StartCoroutine(DownWithTimeOut(card));
                        card.GetComponent<Card>().StartCoroutine(DownWithTimeOut(card));
                    }
                    
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
