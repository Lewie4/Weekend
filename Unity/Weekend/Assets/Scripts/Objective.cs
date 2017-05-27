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
        }
    }
}
