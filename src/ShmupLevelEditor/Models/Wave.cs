using System.Collections.ObjectModel;
using ShmupLevelEditor.Util;

namespace ShmupLevelEditor.Models
{
    public class Wave : NotifyPropertyChangedBase
    {
        public ObservableCollection<Enemy> EnemyList { get; set; }

        private float _beforeWaveDelay;
        public float BeforeWaveDelay
        {
            get { return _beforeWaveDelay; }
            set
            {
                _beforeWaveDelay = value;
                OnPropertyChanged();
            }
        }
    }
}
