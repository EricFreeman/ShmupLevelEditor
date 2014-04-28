using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml;
using ShmupLevelEditor.Interfaces;
using ShmupLevelEditor.Models;
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
                    "\t\t<Enemy Type='{0}' Spawn='{1}' X='{2}' Speed='{3}' Money='{4}' />\r\n".ToFormat(enemy.Type, enemy.Spawn, enemy.X, enemy.Speed, enemy.Money));

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
            var waves = doc.SelectSingleNode("Waves");

            editor.WaveList = new List<Wave>();

            foreach (XmlNode wave in waves.SelectNodes("Wave"))
            {
                var w = new Wave();
                w.EnemyList = new List<Enemy>();

                foreach (XmlNode enemy in wave.SelectNodes("Enemy"))
                {
                    w.EnemyList.Add(new Enemy
                    {
                        Type = enemy.GetAttribute("Type"),
                        Spawn = float.Parse(enemy.GetAttribute("Spawn").Default("0")),
                        X = float.Parse(enemy.GetAttribute("X").Default("0")),
                        Speed = float.Parse(enemy.GetAttribute("Speed").Default("0")),
                        Money = float.Parse(enemy.GetAttribute("Money").Default("0"))
                    });
                }

                editor.WaveList.Add(w);
            }
        }
    }
}
