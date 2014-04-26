using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using ShmupLevelEditor.Models;

namespace ShmupLevelEditor
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        private ObservableCollection<Wave> _waveList;

        private Wave SelectedWave;
        private Enemy SelectedEnemy;

        public ObservableCollection<Wave> WaveList
        {
            get { return _waveList; }
            set
            {
                _waveList = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            WaveList = new ObservableCollection<Wave>();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var w = new Wave
            {
                EnemyList =
                    new ObservableCollection<Enemy>
                    {
                        new Enemy {Type = "Popcorn"},
                        new Enemy {Type = "ZigZag"},
                        new Enemy {Type = "Bomber"}
                    }
            };
            WaveList.Add(w);
            WavesEdit.ItemsSource = WaveList;
        }

        private void WavesEdit_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var wave = e.NewValue as Wave;
            if (wave != null)
            {
                SelectedWave = wave;
                SelectedEnemy = null;
            }
            else
            {
                SelectedWave = null;
                SelectedEnemy = (Enemy)e.NewValue;
            }
        }

        private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedWave != null)
            {
                _waveList.Remove(SelectedWave);
            }
            else if(SelectedEnemy != null)
            {
                _waveList.First(x => x.EnemyList.Contains(SelectedEnemy)).EnemyList.Remove(SelectedEnemy);
            }
        }

        #region ProeprtyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
