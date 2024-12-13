
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    //internel 내부의
    // 해당 클래스 안에서는 public, 다른 클래스,어셈블리에서는 접근불가
    internal class MyMain : Application
    {

        [STAThread]
        public static void Main(string[] args)
        {
            //이게 화면에 보이지는 않음
            MyMain app = new MyMain();
            app.Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //메인 윈도우
            Window mainWindow = new Window();
            mainWindow.Title = "WPF Sample(Main)";
            mainWindow.MouseDown += WinMouseDown;

            mainWindow.Show();//화면에 보여준다


            //서브 윈도우
            for (int i = 0; i < 2; i++)
            {
                Window subWindow = new Window();
                subWindow.Title = $"Extra Window No. {i+1}";
                subWindow.Show();

            }

        }

        //모달창 마우스다운 이벤트
        private void WinMouseDown(object sender, MouseEventArgs args)
        {

            Window modal = new Window();
            modal.Title = "Modal DialogBox";
            modal.Width = 400;
            modal.Height = 200;

            Button btn = new Button();
            btn.Content = "Click Me!";
            btn.Click += Btn_ClickHandler;

            modal.Content = btn;  //모달창에 윈도우에 버튼 추가
            modal.ShowDialog();     //모달 형태로 띄움 ,뒤쪽에 손 못대게 하는 형식

        }

        //버튼 클릭시 핸들러
        private void Btn_ClickHandler(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Clicked!", sender.ToString());
        }
    }
}
