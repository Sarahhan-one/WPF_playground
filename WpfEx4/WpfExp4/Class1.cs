using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfExp4
{
    public class Model : INotifyPropertyChanging
    {
        private int num;    
        public int Num
        {
            get { return num; }
            set { num = value; onPropertyChanged("Num"); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; onPropertyChanged("Name"); }
        }
        //delegate to reguster event handler 
        public event PropertyChangingEventHandler? PropertyChanging;
        protected void onPropertyChanged(string propertyName)
        {
            PropertyChangingEventHandler handler = PropertyChanging; 
            if (handler != null) handler(this,new PropertyChangingEventArgs(propertyName));
        }
    }

    //bridge between view and model
    public class ViewModel : INotifyPropertyChanging
    {
        private Model model = null; 
        public Model Model
        {
            get { return model; }
            set { model = value; onPropertyChanged("Model"); }
        }

        public Command Cmd { get; set; }

        public ViewModel()
        {
            model = new Model();
            Cmd = new Command(CmdExecute);
        }
        public void CmdExecute(object obj)
        {
            Model.Res = Model.Num + " / " + Model.Name;
        }

        public event PropertyChangingEventHandler? PropertyChanging;
        protected void onPropertyChanged(string propertyName)
        {
            PropertyChangingEventHandler handler = PropertyChanging;
            if (handler != null) handler(this, new PropertyChangingEventArgs(propertyName));
        }
    }

    public class Command : ICommand
    {
        Action<object> action;

        public Command(Action<object> action)
        {
            this.action = action;
        }

        public event EventHandler<EventArgs> CommandChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            action(parameter);
        }

    }
}
 