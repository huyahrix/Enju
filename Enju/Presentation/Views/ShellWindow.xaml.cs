using System.ComponentModel.Composition;
using System.Windows;
using Enju.Applications.Views;

namespace Enju.Presentation.Views
{
    [Export(typeof(IShellView))]
    public partial class ShellWindow : Window, IShellView
    {
        public ShellWindow()
        {
            InitializeComponent();
        }
    }
}


//<Window x:Class="Enju.Presentation.Views.ShellWindow"
//        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
//        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
//        xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
//        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"  
//        xmlns:vm="clr-namespace:Enju.Applications.ViewModels"
//        mc:Ignorable="d" Title="{Binding Title}" Icon="{StaticResource ApplicationIcon}" Width="525" Height="350"
//        d:DataContext="{d:DesignInstance vm:ShellViewModel}">

//    <DockPanel>
//        <Menu DockPanel.Dock="Top">
//            <MenuItem Header = "_File" >
//                < MenuItem Header= "E_xit" Command= "{Binding ExitCommand}" />
//            </ MenuItem >
//        </ Menu >

//        < Grid >


//        </ Grid >
//    </ DockPanel >
//</ Window >
