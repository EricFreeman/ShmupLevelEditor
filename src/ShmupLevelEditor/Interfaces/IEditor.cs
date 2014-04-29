using System.Collections.ObjectModel;
using ShmupLevelEditor.Models;

namespace ShmupLevelEditor.Interfaces
{
    public interface IEditor
    {
        ObservableCollection<Wave> WaveList { get; set; }

        void Clear();
    }
}
