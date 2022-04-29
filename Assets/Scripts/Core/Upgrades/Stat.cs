using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Upgrades
{
    [Serializable]
    public class Stat 
    {
        [HorizontalGroup("Stat", 0.5f, LabelWidth = 35)]
        public int Value;

        [HorizontalGroup("Stat", 0.5f, LabelWidth = 35)]
        public int Cost;
    }
}