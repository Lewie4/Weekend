using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectiveManger : MonoBehaviour {

    [SerializeField] private List<Objective> m_objective;

    private Objectives m_possibleObjectives;

    private void Awake()
    {
        EventManager.StartListening("RefilObjectives", RefilObjectives);

        if(m_possibleObjectives == null)
        {
            m_possibleObjectives = GetComponent<Objectives>();
        }

        RefilObjectives();
    }

    private void RefilObjectives()
    {
        for (int i = 0; i < m_objective.Count; i++)
        {
            if(m_objective[i].RemainingObjectives() <= 0)
            {
                m_objective[i].SetObjective(m_possibleObjectives.SelectRandomObjective(Objectives.Difficulty.Easy));
            }
        }
    }
}
