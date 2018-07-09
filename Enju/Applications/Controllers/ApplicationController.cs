using System.ComponentModel.Composition;
using System.Windows;
using Enju.Applications.ViewModels;

namespace Enju.Applications.Controllers
{
    [Export]
    internal class ApplicationController
    {
        private readonly ShellViewModel shellViewModel;
        //private readonly MainViewModel mainViewModel;

        [ImportingConstructor]
        public ApplicationController(ShellViewModel shellViewModel)
        {
            //this.mainViewModel = mainViewModel;
            this.shellViewModel = shellViewModel;
        }



        public void Initialize()
        {
        }

        public void Run()
        {
            shellViewModel.Show();
            MessageBox.Show("wtf");

            //shellViewModel.Show();
        }

        public void Shutdown()
        {

        }
    }
}
