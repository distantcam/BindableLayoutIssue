using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BindableLayoutIssue
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Items = Enumerable.Range(1, 5).Select(i => new Selectable<string>("Item " + i)).ToArray();

            foreach (var item in Items)
            {
                item.SelectionChanged += Item_SelectionChanged;
            }
        }

        private void Item_SelectionChanged(object sender, System.EventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItems)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedVisible)));
        }

        public IEnumerable<Selectable<string>> Items { get; }

        public IEnumerable<Selectable<string>> SelectedItems => Items.Where(i => i.Selected).ToArray();

        public bool SelectedVisible => Items.Any(i => i.Selected);

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
