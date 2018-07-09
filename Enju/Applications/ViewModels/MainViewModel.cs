using System.ComponentModel.Composition;
using System.Waf.Applications;
using System.Windows.Input;
using Enju.Applications.Views;


namespace Enju.Applications.ViewModels
{
    [Export]
    internal class MainViewModel : ViewModel<IMainView>
    {
        private readonly DelegateCommand exitCommand;

        [ImportingConstructor]
        public MainViewModel(IMainView view) : base(view)
        {
            exitCommand = new DelegateCommand(Close);
        }

        public ICommand ExitCommnad { get { return exitCommand; }  }

        public void Close()
        {
            ViewCore.Close();
        }

        public void Show()
        {
            ViewCore.Show();
        }
    }
}
