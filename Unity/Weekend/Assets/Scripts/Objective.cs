using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

    [SerializeField] private Objectives.CardObjectives m_currentObjective;

    public int RemainingObjectives()
    {
        return m_currentObjective.m_objectives.Count;
    }

    public void SetObjective(Objectives.CardObjectives objective)
    {
        m_currentObjective = objective;
        for (int i = 0; i < m_currentObjective.m_objectives.Count; i++)
        {
            GameObject card = Instantiate(ObjectiveManger.ms_instance.GetObjectiveCard((int)m_currentObjective.m_objectives[i]));
            card.transform.SetParent(this.transform);
        }
    }

    public Card.CardType GetFirstCard()
    {
        return m_currentObjective.m_objectives.Count >= 1 ? m_currentObjective.m_objectives[0] : Card.CardType.Blank;
    }

    public void RemoveFirstCard()
    {
        m_currentObjective.m_objectives.RemoveAt(0);
        Destroy(transform.GetChild(0).gameObject);
    }
}
