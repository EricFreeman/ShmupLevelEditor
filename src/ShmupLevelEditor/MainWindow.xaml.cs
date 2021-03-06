﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using ShmupLevelEditor.Interfaces;
using ShmupLevelEditor.Models;
using ShmupLevelEditor.Util;

namespace ShmupLevelEditor
{
    public partial class MainWindow : INotifyPropertyChanged, IEditor
    {
        #region Properties

        private ObservableCollection<Wave> _waveList;
        private Wave _selectedWave;
        private Enemy _selectedEnemy;

        public ObservableCollection<Wave> WaveList
        {
            get { return _waveList; }
            set
            {
                _waveList = value;
                OnPropertyChanged();
            }
        }

        public Wave SelectedWave
        {
            get { return _selectedWave; }
            set
            {
                _selectedWave = value;
                OnPropertyChanged();
            }
        }

        public Enemy SelectedEnemy
        {
            get { return _selectedEnemy; }
            set
            {
                _selectedEnemy = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();

            WaveList = new ObservableCollection<Wave>();
        }

        #endregion

        #region Button Events

        private void AddEnemy_OnClick(object sender, RoutedEventArgs e)
        {
            if(SelectedWave != null)
                SelectedWave.EnemyList.Add(CreateEnemy());
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var w = new Wave
            {
                EnemyList = new ObservableCollection<Enemy>()
            };
            WaveList.Add(w);
            WavesEdit.ItemsSource = WaveList;
        }

        private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedWave != null)
            {
                _waveList.Remove(SelectedWave);
            }
            else if (SelectedEnemy != null)
            {
                _waveList.First(x => x.EnemyList.Contains(SelectedEnemy)).EnemyList.Remove(SelectedEnemy);
            }
        }

        private void DuplicateButton_OnClick(object sender, RoutedEventArgs e)
        {
            var toDupe = ((Enemy) WavesEdit.SelectedItem);
            var wave = WaveList.First(x => x.EnemyList.Contains(toDupe));
            wave.EnemyList.Add(toDupe.Clone());
            ReorderWaves();
        }

        private void UpWaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedWave != null)
                WaveList = WaveList.MoveUp(SelectedWave);
        }

        private void DownWaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedWave != null)
                WaveList = WaveList.MoveDown(SelectedWave);
        }

        #endregion

        #region Treeview Events

        private void WavesEdit_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var wave = e.NewValue as Wave;
            var enemy = e.NewValue as Enemy;

            SelectedWave = wave;
            SelectedEnemy = enemy;

            WavePanel.DataContext = SelectedWave;
            EnemyPanel.DataContext = SelectedEnemy;

            ReorderWaves();
        }

        private void ReorderWaves()
        {
            foreach (var w in WaveList)
            {
                if (w.EnemyList.Select(x => x.Spawn).ToList().IsNotInOrder())
                    w.EnemyList = new ObservableCollection<Enemy>(w.EnemyList.OrderBy(x => x.Spawn).ThenBy(x => x.Type));
            }
        }

        // remove selected when clicking whitespace
        private void WavesEdit_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Released && (sender as TreeViewItem) == null)
            {
                // Deselect from TreeView
                var treeItem = (TreeViewItem)WavesEdit.ItemContainerGenerator.ContainerFromItem(WavesEdit.SelectedItem);
                if(treeItem != null)
                    treeItem.IsSelected = false;

                // Deselect from here to update panels
                SelectedEnemy = null;
                SelectedWave = null;

                WavePanel.DataContext = SelectedWave;
                EnemyPanel.DataContext = SelectedEnemy;
            }
        }

        #endregion

        #region Helpers

        public void Clear()
        {
            SelectedWave = null;
            SelectedEnemy = null;

            WavePanel.DataContext = SelectedWave;
            EnemyPanel.DataContext = SelectedEnemy;
            WaveList.Clear();
        }

        private Enemy CreateEnemy()
        {
            return new Enemy
            {
                Type = "Popcorn",
                Spawn = 0,
                Speed = 5,
                X = 0
            };
        }

        #endregion

        #region Menu

        private void NewMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void ExitMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SaveMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var sfd = new SaveFileDialog();
            if(sfd.ShowDialog().IsTrue())
                IO.Save(this, sfd.FileName);
        }

        private void OpenMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog().IsTrue())
            {
                IO.Load(this, ofd.FileName);
                WavesEdit.ItemsSource = WaveList;
            }
        }

        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
