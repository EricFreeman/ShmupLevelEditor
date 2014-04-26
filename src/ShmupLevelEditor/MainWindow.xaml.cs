using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ShmupLevelEditor.Models;

namespace ShmupLevelEditor
{
    public partial class MainWindow
    {
        public List<Wave> WaveList = new List<Wave>();
        private int _selectedIndex;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WavesEdit_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var s = (TreeViewItem)((TreeView) sender).SelectedItem;
            _selectedIndex = int.Parse(s.Name.Substring(1, s.Name.Length - 1));
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var index = WavesEdit.Items.Count;
            var wave = new TreeViewItem {Header = "Wave", Name = "N" + index};
            WavesEdit.Items.Add(wave);
            WaveList.Add(new Wave(index));
        }

        private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_selectedIndex > 0)
            {
                WaveList.Remove(WaveList.First(x => x.Index == _selectedIndex));
                WavesEdit.Items.RemoveAt(_selectedIndex);
                _selectedIndex = -1;
            }
        }
    }
}
