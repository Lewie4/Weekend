using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private GameObject m_activeCardsContainer;
    [SerializeField] private List<ActiveCard> m_activeCards;

    [SerializeField] private float m_waitRemaining;
    [SerializeField] private float m_waitTime;

    public static CardManager ms_instance;

    private void Awake()
    {
        if(ms_instance == null)
        {
            ms_instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        for (int i = 0; i < m_activeCardsContainer.transform.childCount; i++)
        {
            ActiveCard currentCard = m_activeCardsContainer.transform.GetChild(i).GetComponent<ActiveCard>();
            if (currentCard != null)
            {
                m_activeCards.Add(currentCard);
            }
        }

        m_waitRemaining = m_waitTime;
    }

    public void Update()
    {
        if(m_activeCards[0].GetCardType() != Card.CardType.Blank)
        {
            if(m_waitRemaining <= 0)
            {
                for(int i = 0; i < m_activeCards.Count; i++)
                {
                    Card.CardType nextCardType = i + 1 >= m_activeCards.Count ? Card.CardType.Blank : m_activeCards[i + 1].GetCardType();
                    m_activeCards[i].SetCardType(nextCardType);
                }
                m_waitRemaining = m_waitTime;
            }
            else
            {
                m_waitRemaining -= Time.deltaTime;
            }
        }
    }

    public void AddCardToActiveQueue(Card.CardType cardType)
    {
        for(int i = 0; i < m_activeCards.Count; i++)
        {
            if(m_activeCards[i].GetCardType() == Card.CardType.Blank)
            {
                m_activeCards[i].SetCardType(cardType);
                break;
            }
        }
    }
}
