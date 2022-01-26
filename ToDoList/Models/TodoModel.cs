using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    class TodoModel : INotifyPropertyChanged
    {
        public DateTime dateTime { get; set; } = DateTime.Now;
        private bool _isDone;
        private string _text;
        public bool Isdone {
            get
            {
                return _isDone;
            }
            set
            {
                if (_isDone == value)
                {
                    return;
                }
                _isDone = value;
                OnProportyChanged("Isdone");
            } 
        }
        public string Text { 
            get
            { 
                return _text; 
            } 
            set
            {
                if (_text == value)
                {
                    return;
                }
                _text = value;
                OnProportyChanged("Text");
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnProportyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
