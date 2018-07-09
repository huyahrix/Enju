using System.Windows;
using System.ComponentModel.Composition;
using System.Waf.Applications;
using System.Windows.Input;
using Enju.Applications.Views;

namespace Enju.Applications.ViewModels
{
    [Export]
    internal class ShellViewModel : ViewModel<IShellView>
    {
        private readonly DelegateCommand exitCommand;
        private readonly DelegateCommand sayCommand;

        [ImportingConstructor]
        public ShellViewModel(IShellView view)
            : base(view)
        {
            exitCommand = new DelegateCommand(Close);
            sayCommand = new DelegateCommand(SayHello);
        }
       



        public string Title { get { return ApplicationInfo.ProductName; } }

        public ICommand ExitCommand { get { return exitCommand; } }
        public ICommand SayCommnad { get { return sayCommand;  } }

        public void SayHello()
        {
            MessageBox.Show("asas");
        }

        public void Show()
        {
            ViewCore.Show();
        }
        
        private void Close()
        {
            ViewCore.Close();
        }
    }
}
