using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObjectiveManger : MonoBehaviour
{

    [SerializeField] private List<Objective> m_objective;

    private Objectives m_possibleObjectives;
    [SerializeField] private List<GameObject> m_ObjectiveCards;

    private int m_levelScore;
    [SerializeField] private int m_cardScoreValue;
    [SerializeField] private Text m_levelScoreText;

    public static ObjectiveManger ms_instance;

    private void Awake()
    {
        if (ms_instance == null)
        {
            ms_instance = this;
        }
        else
        {
            Destroy(this);
        }

        EventManager.StartListening("RefilObjectives", RefilObjectives);

        if (m_possibleObjectives == null)
        {
            m_possibleObjectives = GetComponent<Objectives>();
        }

        RefilObjectives();
    }

    private void Start()
    {
        m_levelScore = 0;
    }

    public void AddScore(int completedCards)
    {
        m_levelScore += (completedCards * m_cardScoreValue);
        m_levelScoreText.text = m_levelScore.ToString();
    }

    private void RefilObjectives()
    {
        for (int i = 0; i < m_objective.Count; i++)
        {
            if (m_objective[i].RemainingCurrentObjectives() <= 0)
            {
                m_objective[i].SetObjective(m_possibleObjectives.SelectRandomObjective(Objectives.Difficulty.Easy));
            }
        }
    }

    public GameObject GetObjectiveCard(int card)
    {
        return card < m_ObjectiveCards.Count ? m_ObjectiveCards[card] : null;
    }

    public void RemoveObjective(Card.CardType card)
    {
        for (int i = 0; i < m_objective.Count; i++)
        {
            if(m_objective[i].GetFirstCard() == card)
            {
                m_objective[i].RemoveFirstCard();
            }
        }
    }
}