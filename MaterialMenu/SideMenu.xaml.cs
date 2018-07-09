using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;



namespace MaterialMenu
{
    public partial class SideMenu
    {
        //object with the event.
        //declare event handler.
        public delegate void EventHandler(Object sender, EventArgs e);
        // declare event
        public event EventHandler Event;
        // raise event, result: "hello"
        public void RaiseEvent()
        {
            // Event = menthod loadcombo()
            var handler = Event;
            if (handler != null)
            {
                EventArgs args = new EventArgs();
                //args. = "hello";
                handler(this, args);
            }
          
        }

        private bool _isShown;


        private string _connectionString;
        public string ConnectionString
        {
            get
            { return _connectionString; }
          
        }
        private string _server;
        public string Server
        {
            get { return this._server; }
        }
        private string _user;
        public string User
        {
            get { return this._user; }
         
        }
        private string _pasword;
        public string PassWord
        {
            get { return this._pasword; }
        }
        private String _dataBase;
        public string DataBase
        {
            get { return _dataBase; }
        }

        public SideMenu()
        {
            InitializeComponent();
            Theme = SideMenuTheme.Default;
            ClosingType = ClosingType.Auto;
        }

        public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
        "State",
        typeof(MenuState),
        typeof(SideMenu));

        public static readonly DependencyProperty ThemeProperty = DependencyProperty.Register(
        "Theme",
        typeof(SideMenuTheme),
        typeof(SideMenu));

        public static readonly DependencyProperty MenuWidthProperty = DependencyProperty.Register(
        "MenuWidth",
        typeof(double),
        typeof(SideMenu));

        public static readonly DependencyProperty MenuProperty = DependencyProperty.Register(
        "Menu",
        typeof(ScrollViewer),
        typeof(SideMenu));

        public static readonly DependencyProperty ShadowBackgroundProperty = DependencyProperty.Register(
        "ShadowBackground",
        typeof(Brush),
        typeof(SideMenu));

        public static readonly DependencyProperty SolidBlueBackgroundProperty = DependencyProperty.Register(
    "SolidBlue",
    typeof(Brush),
    typeof(SideMenu));
        public static readonly DependencyProperty ButtonBackgroundProperty = DependencyProperty.Register(
        "ButtonBackground",
        typeof(Brush),
        typeof(SideMenu));

        public static readonly DependencyProperty ButtonHoverProperty = DependencyProperty.Register(
        "ButtonHover",
        typeof(Brush),
        typeof(SideMenu));

        public ClosingType ClosingType { get; set; }

        public Brush ButtonBackground
        {
            get { return (Brush)GetValue(ButtonBackgroundProperty); }
            set
            {
                SetValue(ButtonBackgroundProperty, value);
                Resources["ButtonBackground"] = value;
            }
        }

        public Brush ButtonHover
        {
            get { return (Brush)GetValue(ButtonHoverProperty); }
            set
            {
                SetValue(ButtonHoverProperty, value);
                Resources["ButtonHover"] = value;
            }
        }

        public Brush ShadowBackground
        {
            get { return (Brush)GetValue(ShadowBackgroundProperty); }
            set
            {
                SetValue(ShadowBackgroundProperty, value);
                Resources["Shadow"] = value ?? new SolidColorBrush { Color = (Color)ColorConverter.ConvertFromString("#FF7995C9"), Opacity = .8 };
            }
        }

        public Brush SolidBlueBackground
        {
            get { return (Brush)GetValue(SolidBlueBackgroundProperty); }
            set
            {
                SetValue(SolidBlueBackgroundProperty, value);
                Resources["SolidBlue"] = value ?? new SolidColorBrush { Color = Colors.Azure, Opacity = .8 };
            }
        }

        public ScrollViewer Menu
        {
            get { return (ScrollViewer)GetValue(MenuProperty); }
            set { SetValue(MenuProperty, value); }
        }

        public double MenuWidth
        {
            get { return (double)GetValue(MenuWidthProperty); }
            set
            {
                SetValue(MenuWidthProperty, value);
            }
        }

        public MenuState State
        {
            get { return (MenuState)GetValue(StateProperty); }
            set
            {
                SetValue(StateProperty, value);
                if (value == MenuState.Visible)
                {
                    Show();
                }
                else
                {
                    Hide();
                }
            }
        }

        public SideMenuTheme Theme
        {
            get { return (SideMenuTheme)GetValue(ThemeProperty); }
            set
            {
                if (value == SideMenuTheme.None) return;
                SetValue(ThemeProperty, value);
                SolidColorBrush buttonBackground;
                SolidColorBrush buttonHoverBackground;
                SolidColorBrush background;
                switch (value)
                {
                    case SideMenuTheme.Default:
                        background = new SolidColorBrush { Color = Color.FromArgb(205, 20, 20, 20) };
                        buttonBackground = new SolidColorBrush { Color = Color.FromArgb(50, 30, 30, 30) };
                        buttonHoverBackground = new SolidColorBrush { Color = Color.FromArgb(50, 70, 70, 70) };
                        break;
                    case SideMenuTheme.Primary:
                        background = new SolidColorBrush { Color = Color.FromArgb(205, 24, 57, 85) };
                        buttonBackground = new SolidColorBrush { Color = Color.FromArgb(50, 35, 85, 126) };
                        buttonHoverBackground = new SolidColorBrush { Color = Color.FromArgb(50, 45, 110, 163) };
                        break;
                    case SideMenuTheme.Success:
                        background = new SolidColorBrush { Color = Color.FromArgb(205, 55, 109, 55) };
                        buttonBackground = new SolidColorBrush { Color = Color.FromArgb(50, 65, 129, 65) };
                        buttonHoverBackground = new SolidColorBrush { Color = Color.FromArgb(50, 87, 172, 87) };
                        break;
                    case SideMenuTheme.Warning:
                        background = new SolidColorBrush { Color = Color.FromArgb(205, 150, 108, 49) };
                        buttonBackground = new SolidColorBrush { Color = Color.FromArgb(50, 179, 129, 58) };
                        buttonHoverBackground = new SolidColorBrush { Color = Color.FromArgb(50, 216, 155, 70) };
                        break;
                    case SideMenuTheme.Danger:
                        background = new SolidColorBrush { Color = Color.FromArgb(205, 135, 52, 49) };
                        buttonBackground = new SolidColorBrush { Color = Color.FromArgb(50, 179, 69, 65) };
                        buttonHoverBackground = new SolidColorBrush { Color = Color.FromArgb(50, 238, 92, 86) };
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
                ButtonBackground = buttonBackground;
                ButtonHover = buttonHoverBackground;
                if (Menu != null) Menu.Background = background;
            }
        }

        public void Toggle()
        {
            if (_isShown)
            {
                Hide();
            }
            else
            {
                Show();
                txtServerName.Focus();
            }
        }

        public void Show()
        {
            var animation = new DoubleAnimation
            {
                From = -MenuWidth * .85,
                To = 0,
                Duration = TimeSpan.FromMilliseconds(100)
            };
            
            RenderTransform.BeginAnimation(TranslateTransform.XProperty, animation);
            _isShown = true;
            var p = Parent as Panel;
            (FindName("ShadowColumn") as ColumnDefinition).Width = new GridLength(10000);
        }

        public void Hide()
        {
            var animation = new DoubleAnimation
            {
                To = -MenuWidth,
                Duration = TimeSpan.FromMilliseconds(100)
            };
            RenderTransform.BeginAnimation(TranslateTransform.XProperty, animation);
            _isShown = false;
            (FindName("ShadowColumn") as ColumnDefinition).Width = new GridLength(0);
        }

        public override void OnApplyTemplate()
        {
            Panel.SetZIndex(this, int.MaxValue);
            RenderTransform = new TranslateTransform(-MenuWidth, 0);
            (FindName("MenuColumn") as ColumnDefinition).Width = new GridLength(MenuWidth);

            //this is a little hack to fire propertu changes.
            //wpf so complex, it could be much simple...
            State = State;
            Theme = Theme;
            ShadowBackground = ShadowBackground;
            ButtonBackground = ButtonBackground;
            ButtonHover = ButtonHover;
        }

        private void ShadowMouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseEvent(); 
            if (ClosingType == ClosingType.Auto) Hide();

        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            string connetionString = "";
            SqlConnection cnn;
            //connetionString = "Data Source=10.0.0.12;Initial Catalog=DRD02V41;User ID=sa;Password=@abc123@";(simple)
            connetionString = "Data Source=" + txtServerName.Text + ";Initial Catalog=" + txtDataBase.Text + "; User ID =" + txtLoginName.Text + ";Password=" + txtPassWord.Password.ToString();
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                cnn.Close();
                FlowDocument ObjFdoc = new FlowDocument();
                //Add paragraphs to flowdocument Blocks property
                Paragraph ObjPara1 = new Paragraph();
                ObjPara1.Inlines.Add(new Run("Connect to an SQL server successfully."));
                ObjFdoc.Blocks.Add(ObjPara1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
            _connectionString  = connetionString;
            _server  = txtServerName.Text;
            _user   = txtLoginName.Text;
            _pasword  = txtPassWord.Password.ToString();
            _dataBase = txtDataBase.Text;
            ShadowMouseDown(null, null);
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    {
                        if (!string.IsNullOrEmpty(txtServerName.Text))
                            BtnConnect_Click(sender, e);
                        break;
                    }
                default:
                    break;
            }
        }
    }
}