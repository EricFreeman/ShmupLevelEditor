using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ShmupLevelEditor.Models;

namespace ShmupLevelEditor
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        private ObservableCollection<Wave> _waveList;

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

        private void WavesEdit_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

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

        private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
        {
            
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
