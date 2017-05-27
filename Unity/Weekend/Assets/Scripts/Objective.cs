using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour {

    [SerializeField] private int m_objectiveCount;
    [SerializeField] private float m_objectiveTimeRemaining;
    [SerializeField] private float m_objectiveTime;

    [SerializeField] private Text m_objectiveCountText;
    [SerializeField] private Slider m_objectiveTimeSlider;

    [SerializeField] private List<Card.CardType> m_currentObjective;

    private void Start()
    {
        m_objectiveTimeRemaining = m_objectiveTime;
        SetRemainingObjectivesText();
    }

    private void Update()
    {
        if (m_objectiveCount >= 0)
        {
            if (m_objectiveTimeRemaining > 0)
            {
                m_objectiveTimeRemaining -= Time.deltaTime;
            }
            else
            {
                RemoveAllCards();
            }
        }

        m_objectiveTimeSlider.value = 1 - (m_objectiveTimeRemaining / m_objectiveTime);
    }

    public int RemainingCurrentObjectives()
    {
        return m_currentObjective.Count;
    }

    public void SetObjective(Objectives.CardObjectives objective)
    {
        for(int i = 0; i < objective.m_objectives.Count; i++)
        {
            m_currentObjective.Add(objective.m_objectives[i]);
        }
        for (int i = 0; i < m_currentObjective.Count; i++)
        {
            GameObject card = Instantiate(ObjectiveManger.ms_instance.GetObjectiveCard((int)m_currentObjective[i]));
            card.transform.SetParent(this.transform.GetChild(0));
        }
    }

    public Card.CardType GetFirstCard()
    {
        return m_currentObjective.Count >= 1 ? m_currentObjective[0] : Card.CardType.Blank;
    }

    public void RemoveFirstCard()
    {
        m_currentObjective.RemoveAt(0);
        Destroy(transform.GetChild(0).GetChild(0).gameObject);

        if (m_currentObjective.Count == 0)
        {
            GetNextObjective();
        }
    }

    public void RemoveAllCards()
    {
        m_currentObjective.Clear();
        
        for(int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            Destroy(transform.GetChild(0).GetChild(i).gameObject);
        }

        GetNextObjective();
        
    }

    private void GetNextObjective()
    {
        if (m_objectiveCount > 0)
        {
            EventManager.TriggerEvent("RefilObjectives");
            m_objectiveCount--;
            m_objectiveTimeRemaining = m_objectiveTime;
            SetRemainingObjectivesText();
        }
        else
        {
            m_objectiveTimeRemaining = 0;
        }
    }

    private void SetRemainingObjectivesText()
    {
        m_objectiveCountText.text = m_objectiveCount.ToString();
    }
}
