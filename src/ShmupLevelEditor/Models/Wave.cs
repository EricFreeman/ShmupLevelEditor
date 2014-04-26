using System.Collections.Generic;

namespace ShmupLevelEditor.Models
{
    public class Wave
    {
        public int Index { get; set; } // Just to correlate with index of wave in tree view

        public List<Enemy> EnemyList { get; set; }
        public float BeforeWaveDelay { get; set; }

        public bool IsSelected { get; set; }
        public bool IsExpanded { get; set; }

        public Wave(int index)
        {
            Index = index;
        }
    }
}
