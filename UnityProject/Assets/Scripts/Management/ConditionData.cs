﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConditionData
{
    public int[] conditions;
    public int participant;

    public ConditionData(ExperimentManager expManager)
    {
        // TODO: replace 4 by const
        participant = expManager.participant;
        conditions = new int[4];

        for (int i = 0; i < 4; i++)
        {
            conditions[i] = expManager.conditionCounter[i];
        }
    }
}
