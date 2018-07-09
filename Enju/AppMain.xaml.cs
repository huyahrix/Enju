using System;
using System.Collections.Generic;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;
using System.Runtime.InteropServices;
//using Microsoft

namespace Enju
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class AppMain : Window
    {
        public AppMain()
        {
            try
            {
                MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
                InitializeComponent();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Menu.Event += LoadComboxDataBase;
            LoadDynamicTabControl();
            //Menu.Toggle();
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void Power_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }
        private void Normal_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //Slider Menu
        //
        //
        private void BtnShowConnect_Click(object sender, RoutedEventArgs e)
        {
            Menu.Toggle();
        }

        private void KeyPress(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                if (e.Key == Key.P)
                    BtnExportExcel_Click(null, null);
            }

            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                if (e.Key == Key.N)
                    tabDynamic.SelectedItem = _tabItem.Last();
            }

            //if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            //{
            //    if (e.Key == Key.F4)
            //    {
            //        BtnDelete_Click(null,null);
            //    }
            //}

            switch (e.Key)
            {
                case Key.Escape:
                    {
                        BtnShowConnect_Click(sender, e);
                        break;
                    }
                case Key.F5:
                    {
                        BtnExecute_Click(sender, e);
                        break;
                    }
            }
        }
        private List<TabItem> _tabItem;

        private void LoadDynamicTabControl()
        {
            _tabItem = new List<TabItem>();
            TabItem _tabAdd = new TabItem
            {
                Name = "Tab0",
                Header = "+"
            };

            _tabItem.Add(_tabAdd);
            this.AddTabItem();
            tabDynamic.DataContext = _tabItem;
            tabDynamic.SelectedIndex = 0;
        }
        private void TabDynamic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            TabItem tab = tabDynamic.SelectedItem as TabItem;
            //MessageBox.Show(tab.Name);
            if (tab == null) return;
            if (tab.Header.ToString() == "+")
            {

                tabDynamic.DataContext = null;
                TabItem newTab = this.AddTabItem();
                tabDynamic.DataContext = _tabItem;
                tabDynamic.SelectedItem = newTab;
                //GetFocusQuery();
            }
            else
            {
                //GetFocusQuery();
            }

        }
        private void GetFocusQuery()
        {
            var rtbquery = FindVisualChildren<RichTextBox>(tabDynamic).Where((p) => (p).Name == string.Format("rtbQuery{0}", tabDynamic.SelectedIndex + 1)).FirstOrDefault();
            if (rtbquery == null) return;
            rtbquery.Focus();
        }

        int _tabID = 1;
        private TabItem AddTabItem()
        {
            //=> tabItem header

            int count = _tabItem.Count;
            TabItem tab = new TabItem
            {
                Header = string.Format("Query{0}", _tabID),
                Name = string.Format("Tab{0}", _tabID),
                HeaderTemplate = tabDynamic.FindResource("TabHeader") as DataTemplate
            };
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(4, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });

            //=> rtbQuery
            RichTextBox rtbQuery = new RichTextBox();
            rtbQuery.SetValue(Grid.RowProperty, 0);
            rtbQuery.Name = string.Format("rtbQuery{0}", _tabID);
            rtbQuery.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            Block.SetLineHeight(rtbQuery, 2);
            rtbQuery.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA0B2D4"));
            grid.Children.Add(rtbQuery);

            //=> rtbResuft
            RichTextBox rtbResuft = new RichTextBox();
            Block.SetLineHeight(rtbResuft, 2);
            rtbResuft.SetValue(Grid.RowProperty, 1);
            rtbResuft.Name = string.Format("rtbResuft{0}", _tabID);
            rtbResuft.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            rtbResuft.IsReadOnly = true;
            rtbResuft.Visibility = Visibility.Visible;
            grid.Children.Add(rtbResuft);

            //=>dtGridResuft
            DataGrid dtGrid = new DataGrid();
            dtGrid.SetValue(Grid.RowProperty, 1);
            dtGrid.Name = string.Format("dtGrid{0}", _tabID);
            dtGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            dtGrid.VerticalAlignment = VerticalAlignment.Stretch;
            dtGrid.IsReadOnly = true;
            dtGrid.Visibility = Visibility.Hidden;

            grid.Children.Add(dtGrid);
            tab.Content = grid; //Itemcontrol of single tabItem
            _tabItem.Insert(count - 1, tab); //=> list all tabItem  (add to last -1 index)
            _tabID += 1;
            return tab;
        }

        //=>event
        //
        //
        string gsConnectionString = "";
        private void LoadComboxDataBase(Object sender, EventArgs e)
        {
            gsConnectionString = Menu.ConnectionString;
            //DESKTOP - 74K1D89\MYSQLSERVER
            if (string.IsNullOrEmpty(gsConnectionString)) return;

            DataTable dt = new DataTable();
            string SQL = "EXEC sp_databases";
            dt = ReturnDataTable(SQL, gsConnectionString);
            if (dt == null)
                return;
            cbxDataBase.ItemsSource = dt.DefaultView;
            //cbxDataBase.SelectedItem = Menu.DataBase;
            cbxDataBase.Text = Menu.DataBase;
        }
        private void CbxDataBase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((cbxDataBase.SelectedValue == null) || string.IsNullOrEmpty(cbxDataBase.SelectedValue.ToString()))
                return;
            gsConnectionString = "";
            gsConnectionString = "Data Source=" + Menu.Server + ";Initial Catalog=" + cbxDataBase.SelectedValue.ToString() + "; User ID =" + Menu.User + ";Password=" + Menu.PassWord;

        }
        //=>executed
        private void BtnExecute_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(gsConnectionString)) return;

            TabItem tab = (TabItem)tabDynamic.SelectedItem;
            int index = int.Parse(tab.Name.Remove(0, 3));
            //int index = tabDynamic.SelectedIndex + 1;
            DataTable dt = new DataTable();
            var Query = FindVisualChildren<RichTextBox>(tabDynamic).Where((p) => p.Name == (string.Format("rtbQuery{0}", index))).FirstOrDefault();
            var dtGrid = FindVisualChildren<DataGrid>(tabDynamic).Where((p) => p.Name == string.Format("dtGrid{0}", index)).FirstOrDefault();
            var rtbResuft = FindVisualChildren<RichTextBox>(tabDynamic).Where((p) => p.Name == (string.Format("rtbResuft{0}", index))).FirstOrDefault();
            if (Query == null || dtGrid == null || rtbResuft == null) return;
            string SQL = new TextRange(Query.Document.ContentStart, Query.Document.ContentEnd).Text;
            if (string.IsNullOrEmpty(SQL)) return;

            dt = ReturnDataTable(SQL, gsConnectionString);
            if (dt == null)
            {
                dtGrid.Visibility = Visibility.Hidden;
                rtbResuft.Visibility = Visibility.Visible;
            }
            else
            {
                dtGrid.ItemsSource = dt.DefaultView;
                dtGrid.Visibility = Visibility.Visible;
                rtbResuft.Visibility = Visibility.Hidden;
            }
        }
        //=>
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject rootObject) where T : DependencyObject
        {
            if (rootObject != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(rootObject); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(rootObject, i);

                    if (child != null && child is T)
                        yield return (T)child;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }
        // ADO.net /System.Data.SqlClient 
        private DataSet ReturnDataSet(string SQL, string sConnectionStringNew)
        {
            if (string.IsNullOrEmpty(sConnectionStringNew)) return null;
            int iCountError = 0;
            TabItem tab = (TabItem)tabDynamic.SelectedItem;
            int index = int.Parse(tab.Name.Remove(0, 3));
            var rtbResuft = FindVisualChildren<RichTextBox>(tabDynamic).Where((p) => p.Name == (string.Format("rtbResuft{0}", index))).FirstOrDefault();
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection();
            if (sConnectionStringNew != "")
            {
                conn = new SqlConnection(sConnectionStringNew);
            }
            else
                conn = new SqlConnection(gsConnectionString);
            SqlCommand cmd = new SqlCommand(SQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                conn.Open();
                //cmd.CommandTimeout = 0;
                if (iCountError > 0)
                {
                    cmd.CommandTimeout = 30;
                }
                else
                    cmd.CommandTimeout = 30;
                da.Fill(ds);
                conn.Close();
                FlowDocument ObjFdoc = new FlowDocument();
                Paragraph ObjPara1 = new Paragraph();
                ObjPara1.Inlines.Add(new Run("Commands completed successfully."));
                ObjFdoc.Blocks.Add(ObjPara1);

                rtbResuft.Document = ObjFdoc;
                rtbResuft.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3BB600"));
                return ds;
            }
            catch (SqlException ex)
            {
                FlowDocument ObjFdoc = new FlowDocument();
                Paragraph ObjPara1 = new Paragraph();
                ObjPara1.Inlines.Add(new Run(ex.Message.ToString()));
                ObjFdoc.Blocks.Add(ObjPara1);
                rtbResuft.Document = ObjFdoc;
                //WriteLogFile(SQL & vbCrLf & ex.Message)
                rtbResuft.Foreground = Brushes.Red;
            }
            return null;
        }
        public DataTable ReturnDataTable(string SQL, string sConnectionStringNew = "")
        {
            DataSet ds = ReturnDataSet(SQL, sConnectionStringNew);
            if (ds == null || ds.Tables.Count == 0)
            { return null; }
            return ds.Tables[0];
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            string tabname = (sender as Button).CommandParameter.ToString();
            //MessageBox.Show(tabname);
            //var item = tabDynamic.Items.Cast<TabItem>().Where(i => i.Equals(tabname)).SingleOrDefault();
            var item1 = FindVisualChildren<TabItem>(tabDynamic).Where((p) => p.Name == tabname).FirstOrDefault();
            TabItem tab = (TabItem)item1;
            if (tab != null)
            {
                if (_tabItem.Count <= 2)
                {
                    MessageBox.Show("Cannot remove last tab.");
                }
                else
                //if (MessageBox.Show(string.Format("Are you sure you want to remove the tab '{0}'?", tab.Header.ToString()),
                //    "Remove Tab", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    tabDynamic.DataContext = null;
                    _tabItem.Remove(tab);
                    tabDynamic.DataContext = _tabItem;
                    int _sIndex = _tabItem.IndexOf(_tabItem.Last());
                    tabDynamic.SelectedItem = _tabItem[_sIndex - 1];
                }
            }
        }

        private void BtnExportExcel_Click(object sender, RoutedEventArgs e)
        {
            ////EXPORT 
            //  if (string.IsNullOrEmpty(gsConnectionString)) return;
            TabItem tab = (TabItem)tabDynamic.SelectedItem;
            int index = int.Parse(tab.Name.Remove(0, 3));
            DataTable dt = new DataTable();
            var dtGrid = FindVisualChildren<DataGrid>(tabDynamic).Where((p) => p.Name == string.Format("dtGrid{0}", index)).FirstOrDefault();
            if (dtGrid == null || dtGrid.Items.Count <= 0)
                return;
            dt = ((DataView)dtGrid.ItemsSource).ToTable();
            string xlname = Menu.Server + DateTime.Now.ToString(@"dd\/MM\/yyyy_h\:mm_tt")  + @".xls";
            string path = Directory.GetCurrentDirectory() + xlname;
            // MessageBox.Show(path.ToString());
            var existingFile = new FileInfo(Directory.GetCurrentDirectory ());

            //check process runing by Microsoft.Office.Interop.Excel;
            //if (IsOpened("Enju.xlsx"))
            //{
            //    MessageBox.Show("excel is opened");
            //    return;
            //}
            //check process runing by System.Diagnostics.Process

            Process[] pname = Process.GetProcessesByName(xlname);
            if (pname.Length > 0)
            {
                MessageBox.Show("running");
                return;
            }
            if (existingFile.Exists)
                existingFile.Delete();

            //using Microsoft.Office.Interop.Excel;

            Excel.Application xlApp = new Excel.Application();
            //xlsFile .
            //check whether Excel is installed in  system.
            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            int xlrow = 0;
            int xlcol = 0;

            foreach (DataColumn col in dt.Columns)
            {
                xlcol++;
                xlWorkSheet.Cells[1, xlcol] = col.ColumnName;
            }

            foreach (DataRow row in dt.Rows)
            {
                xlrow++;
                xlcol = 0;
                foreach (DataColumn col in dt.Columns)
                {
                    xlcol++;
                    xlWorkSheet.Cells[xlrow, xlcol] = row[col.ColumnName];
                }
            }

            xlWorkSheet.Columns.AutoFit();
            xlWorkBook.SaveAs(path , Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            GC.Collect();

            ReleaseObject(xlWorkSheet);
            ReleaseObject(xlWorkBook);
            ReleaseObject(xlApp);

            System.Diagnostics.Process.Start(path);

        }

        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        static bool IsOpened(string wbook)
        {
            bool isOpened = true;
            Excel.Application exApp;
            exApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            try
            {
                exApp.Workbooks.get_Item(wbook);
            }
            catch (Exception)
            {
                isOpened = false;
            }
            return isOpened;
        }

        private void Menu_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
