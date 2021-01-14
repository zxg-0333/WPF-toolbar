using GBCourtApp.Controller;
using GBCourtApp.Helpers;
using GBCourtApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GBCourtApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 静态属性
        private Rect desktopWorkingArea;
        private System.Windows.Point anchorPoint;
        private bool inDrag;
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            //
            desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Width - this.Width;
            this.Top = desktopWorkingArea.Height / 2 - (this.Height / 2);
        }
        #region Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = VMController.CreateVM(); 
            //if (Common.IsWin10)
            //{
            //    WindowBlur.SetIsEnabled(this, true);
            //    DataContext = new WindowBlureffect(this, AccentState.ACCENT_ENABLE_ACRYLICBLURBEHIND) { BlurOpacity = 100 };
            //}
            //if (Environment.OSVersion.Version.Major >= 6)
            //    Win32Api.SetProcessDPIAware();

            #region 注释
            //WindowInteropHelper wndHelper = new WindowInteropHelper(this);
            //int exStyle = (int)Win32Api.GetWindowLong(wndHelper.Handle, (int)Win32Api.GetWindowLongFields.GWL_EXSTYLE);
            //exStyle |= (int)Win32Api.ExtendedWindowStyles.WS_EX_TOOLWINDOW;
            //Win32Api.SetWindowLong(wndHelper.Handle, (int)Win32Api.GetWindowLongFields.GWL_EXSTYLE, (IntPtr)exStyle); 
            #endregion


            //SetLightDark(SetConfig());
            //Win32Api.HwndSourceAdd(this);
        }
        #endregion
        #region 移动窗体
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            anchorPoint = e.GetPosition(this);
            inDrag = true;
            CaptureMouse();
            e.Handled = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            try
            {
                ItemsControl ctrl = new ItemsControl();
                ListBox lb = new ListBox();
                if (inDrag)
                {
                    System.Windows.Point currentPoint = e.GetPosition(this);
                    var y = this.Top + currentPoint.Y - anchorPoint.Y;
                    var x = this.Left + currentPoint.X - anchorPoint.X;
                    Win32Api.RECT rect;
                    Win32Api.GetWindowRect(new WindowInteropHelper(this).Handle, out rect);
                    var w = rect.right - rect.left;
                    var h = rect.bottom - rect.top;
                    //int x = Convert.ToInt32(PrimaryScreen.DESKTOP.Width - w);

                    Win32Api.MoveWindow(new WindowInteropHelper(this).Handle, (int)x, (int)y, w, h, 1);
                }
            }
            catch (Exception ex)
            {
                //Log.Error($"MainView.OnMouseMove{ex.Message}");
            }
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if (inDrag)
            {
                ReleaseMouseCapture();
                inDrag = false;
                e.Handled = true;
            }
        }
        #endregion


    }
}
