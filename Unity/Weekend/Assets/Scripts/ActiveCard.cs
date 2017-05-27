using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveCard : MonoBehaviour
{
    [SerializeField] private Card.CardType m_cardType;

    public Card.CardType GetCardType()
    {
        return m_cardType;
    }

    public void SetCardType(Card.CardType cardType)
    {
        m_cardType = cardType;
        if (m_cardType == Card.CardType.Blank)
        {
            GetComponent<Image>().color = Color.grey;
        }
        else if (m_cardType == Card.CardType.Red)
        {
            GetComponent<Image>().color = Color.red;
        }
        else if (m_cardType == Card.CardType.Yellow)
        {
            GetComponent<Image>().color = Color.yellow;
        }
        else if (m_cardType == Card.CardType.Green)
        {
            GetComponent<Image>().color = Color.green;
        }
        else if (m_cardType == Card.CardType.Blue)
        {
            GetComponent<Image>().color = Color.blue;
        }
        else if (m_cardType == Card.CardType.Purple)
        {
            GetComponent<Image>().color = Color.magenta;
        }
    }
}
