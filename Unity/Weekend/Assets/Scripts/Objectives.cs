using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour {

    [SerializeField] private List<CardObjectives> m_possibleObjectives;

    [System.Serializable]
    public class CardObjectives
    {
        public List<Card.CardType> m_objectives;
        public int m_weight;
    }

    public CardObjectives SelectRandomObjective()
    {
        // Get the total sum of all the weights.
        int totalWeight = 0;
        for (int i = 0; i < m_possibleObjectives.Count; i++)
        {
            totalWeight += m_possibleObjectives[i].m_weight;
        }

        // Step through all the possibilities, one by one, checking to see if each one is selected.
        int index = 0;
        int lastIndex = m_possibleObjectives.Count - 1;
        while (index < lastIndex)
        {
            // Do a probability check with a likelihood of weights[index] / weightSum.
            if (Random.Range(0, totalWeight) < m_possibleObjectives[index].m_weight)
            {
                return m_possibleObjectives[index];
            }

            // Remove the last item from the sum of total untested weights and try again.
            totalWeight -= m_possibleObjectives[index++].m_weight;
        }

        // No other item was selected, so return very last index.
        return m_possibleObjectives[index];
    }
}
