using System.Collections.ObjectModel;
using ShmupLevelEditor.Util;

namespace ShmupLevelEditor.Models
{
    public class Wave : NotifyPropertyChangedBase
    {
        private ObservableCollection<Enemy> _enemyList;
        private float _beforeWaveDelay;

        public ObservableCollection<Enemy> EnemyList
        {
            get { return _enemyList; }
            set
            {
                _enemyList = value;
                OnPropertyChanged();
            }
        }

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
