using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour {

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    };

    [SerializeField] private List<CardObjectives> m_possibleObjectives;

    [System.Serializable]
    public class CardObjectives
    {
        public Difficulty m_difficulty;
        public List<Card.CardType> m_objectives;
        public int m_weight;
    }

    public CardObjectives SelectRandomObjective(Difficulty difficulty)
    {
        int totalWeight = 0;
        for (int i = 0; i < m_possibleObjectives.Count; i++)
        {
            if (m_possibleObjectives[i].m_difficulty == difficulty)
            {
                totalWeight += m_possibleObjectives[i].m_weight;
            }
        }

        int index = 0;
        int lastIndex = m_possibleObjectives.Count - 1;
        while (index < lastIndex)
        {
            if (m_possibleObjectives[index].m_difficulty == difficulty)
            {
                if (Random.Range(0, totalWeight) < m_possibleObjectives[index].m_weight)
                {
                    return m_possibleObjectives[index];
                }

                // Remove the last item from the sum of total untested weights and try again.
                totalWeight -= m_possibleObjectives[index].m_weight;
            }
            index++;
        }

        // No other item was selected, so return very last index.
        return m_possibleObjectives[index];
    }
}
