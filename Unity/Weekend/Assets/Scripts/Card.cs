using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    [SerializeField] private float m_cooldownRemaining;
    [SerializeField] private float m_cooldownTime = 5;
    [SerializeField] private Text m_cooldownText;

    [SerializeField] private CardType m_cardType;

    public enum CardType
    {
        Blank,
        Red,
        Yellow,
        Green,
        Blue,
        Purple
    };

    private void Update()
    {
        if (m_cooldownRemaining > 0)
        {
            m_cooldownRemaining -= Time.deltaTime;
            if (m_cooldownText != null)
            {
                m_cooldownText.text = ((int)m_cooldownRemaining).ToString();
            }
        }
    }

    public void UseCard()
    {
        if(m_cooldownRemaining <= 0)
        {
            m_cooldownRemaining = m_cooldownTime;
            CardManager.ms_instance.AddCardToActiveQueue(m_cardType);
        }
    }
}
