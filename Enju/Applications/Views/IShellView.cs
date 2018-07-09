using System.Waf.Applications;

namespace Enju.Applications.Views
{
    internal interface IShellView : IView
    {
        void Show();

        void Close();

        void SayHello();
       
    }
}
