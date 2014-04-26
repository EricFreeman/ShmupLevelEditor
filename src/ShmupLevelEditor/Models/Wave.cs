using System.Collections.ObjectModel;

namespace ShmupLevelEditor.Models
{
    public class Wave
    {
        public ObservableCollection<Enemy> EnemyList { get; set; }
        public float BeforeWaveDelay { get; set; }

        public bool IsSelected { get; set; }
        public bool IsExpanded { get; set; }
    }
}
