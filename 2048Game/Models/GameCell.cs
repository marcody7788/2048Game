using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048Game.Models
{
    public class GameCell : INotifyPropertyChanged
    {
        private int number = 0;
        private int row;
        private int column;
        private Color color;

        public event PropertyChangedEventHandler PropertyChanged = (o, e) => { };

        public int Number
        {
            get { return number; }
            set
            {
                this.number = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Number)));
            }
        }

        public Color Color
        {
            get { return color; }
            set
            {
                this.color = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Color)));
            }
        }

        public int Row
        {
            get { return row; }
            set
            {
                this.row = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Row)));
            }
        }

        public int Column
        {
            get { return column; }
            set
            {
                this.column = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Column)));
            }
        }

        public bool IsEmpty => number == 0;
    }
}
