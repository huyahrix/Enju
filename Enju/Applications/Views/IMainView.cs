using System.Waf.Applications;

namespace Enju.Applications.Views
{
    internal interface IMainView: IView
    {
        void Show();

        void Close();
    }
}