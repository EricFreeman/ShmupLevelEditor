using System.IO;
using System.Linq;
using System.Xml;
using ShmupLevelEditor.Interfaces;
using ShmupLevelEditor.Util;

namespace ShmupLevelEditor
{
    public static class IO
    {
        public static void Save(IEditor editor, string fileName)
        {
            var text = "<Waves>\r\n";

            foreach (var wave in editor.WaveList)
            {
                text += "\t<Wave BeforeWaveDelay='{0}'>\r\n".ToFormat(wave.BeforeWaveDelay);

                text = wave.EnemyList.Aggregate(text, (current, enemy) => current + 
                    "\t\t<Enemy Type='{0}' Spawn='{1}' Y='{2}' Speed='{3}' />\r\n".ToFormat(enemy.Type, enemy.Spawn, enemy.Y, enemy.Speed));

                text += "\t</Wave>\r\n";
            }

            text += "</Waves>";

            using (var file = new StreamWriter(fileName))
            {
                file.WriteLine(text);
            }
        }

        public static void Load(IEditor editor, string fileName)
        {
            editor.Clear();

            var doc = new XmlDocument();
            doc.Load(fileName);
        }
    }
}
