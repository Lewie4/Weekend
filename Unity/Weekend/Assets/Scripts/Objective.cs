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
    }
}
