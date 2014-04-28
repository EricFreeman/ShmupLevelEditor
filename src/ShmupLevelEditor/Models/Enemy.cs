using ShmupLevelEditor.Util;

namespace ShmupLevelEditor.Models
{
    public class Enemy : NotifyPropertyChangedBase
    {
        private string _type;
        private float _spawn;
        private float _x;
        private float _speed;
        private float _money;

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged();
                OnPropertyChanged("EditorName");
            }
        }

        public float Spawn
        {
            get { return _spawn; }
            set
            {
                _spawn = value;
                OnPropertyChanged();
                OnPropertyChanged("EditorName");
            }
        }

        public float X
        {
            get { return _x; }
            set
            {
                _x = value;
                OnPropertyChanged();
            }
        }

        public float Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                OnPropertyChanged();
            }
        }

        public float Money
        {
            get { return _money; }
            set
            {
                _money = value;
                OnPropertyChanged();
            }
        }

        public string EditorName
        {
            get { return "{0} - {1}".ToFormat(Type, Spawn); }
        }
    }
}
