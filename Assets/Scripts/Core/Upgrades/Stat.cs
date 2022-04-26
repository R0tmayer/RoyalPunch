using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Upgrades
{
    [Serializable]
    public class Stat 
    {
        [HorizontalGroup("BrushSizeMember", 0.5f, LabelWidth = 35)]
        public int Value;

        [HorizontalGroup("BrushSizeMember", 0.5f, LabelWidth = 35)]
        public int Cost;
    }
}