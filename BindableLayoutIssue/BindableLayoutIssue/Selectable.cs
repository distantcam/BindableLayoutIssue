using System;

namespace BindableLayoutIssue
{
    public class Selectable<T>
    {
        public Selectable(T item)
        {
            Item = item;
        }

        public T Item { get; }

        bool selected;
        public bool Selected
        {
            get => selected;
            set
            {
                if (selected != value)
                {
                    selected = value;
                    SelectionChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler SelectionChanged;
    }
}
