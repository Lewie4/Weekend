using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

    [SerializeField] private List<Card.CardType> m_currentObjective;

    public int RemainingObjectives()
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
            EventManager.TriggerEvent("RefilObjectives");
        }
    }
}
