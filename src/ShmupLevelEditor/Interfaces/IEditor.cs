using System.Collections.Generic;
using ShmupLevelEditor.Models;

namespace ShmupLevelEditor.Interfaces
{
    public interface IEditor
    {
        List<Wave> WaveList { get; set; }

        void Clear();
    }
}
