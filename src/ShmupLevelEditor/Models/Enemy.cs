using ShmupLevelEditor.Util;

namespace ShmupLevelEditor.Models
{
    public class Enemy : NotifyPropertyChangedBase
    {
        private string _type;
        private float _spawn;
        private float _y;
        private float _speed;
        private float _money;

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public float Spawn
        {
            get { return _spawn; }
            set
            {
                _spawn = value;
                OnPropertyChanged();
            }
        }

        public float Y
        {
            get { return _y; }
            set
            {
                _y = value;
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
    }
}
