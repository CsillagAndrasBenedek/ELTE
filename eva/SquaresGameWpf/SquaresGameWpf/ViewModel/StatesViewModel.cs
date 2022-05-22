using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresGameWpf.ViewModel
{
    public class StatesViewModel:ViewModelBase
    {
        private string _color;

        public string Color { get => _color; set { _color = value; OnPropertyChanged(); } }

        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }

        public event EventHandler<EventArgs> FieldPressed;
        public DelegateCommand ClickCommand { get; set; }
        public StatesViewModel(string color, int rowIndex, int columnIndex)
        {
            Color = color;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            ClickCommand = new DelegateCommand(_ => FieldPressed?.Invoke(this, EventArgs.Empty));
        }
    }
}
