
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp5
{
    internal class MyMain : Application
    {
        //싱글스레드
        [STAThread]
        public static void Main(string[] args)
        {
            MyMain app = new MyMain();

            //메인이 다 닫을 때 죽게되어있음
            //app.ShutdownMode = ShutdownMode.OnMainWindowClose; 
            app.Run(); //화면에 보이진 않아서 윈도우에 띄우는 작업 해야함


        }

        //Run 매소드 -> 콜백 onStartup

        //시작했을 때 메인 윈도우 띄움
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Window mainWindow = new Window();
            mainWindow.Title = "오 타이틀암";
            mainWindow.MouseDown += WinMouseDown;

            mainWindow.Show(); //화면에 보이게 하기


            //서브 윈도우 두개 띄우기
            for (int i = 0; i < 2; i++)
            {

                Window subWindow = new Window();
                subWindow.Title = "서브다잉" + (i + 1);
                subWindow.ShowInTaskbar = false; //창작업표시줄에 안뜨게

                //메인을 오너로 하게되면
                //항상 메인 창이 젤 뒤에 위치하게 됨,
                // 최소화 같이 됨, 그리고 닫으면 같이 닫힘
                subWindow.Owner = mainWindow; 
                subWindow.Show();

            }
        }

        private void WinMouseDown(object sender, MouseEventArgs args)
        {
            //모달창
            Window modal = new Window();
            modal.Title = "모달임";
            modal.Width = 400;
            modal.Height = 900;

            Button b = new Button();
            b.Content = "Click Me";
            b.Click += btn_Click;

            //모달창에 버튼
            modal.Content = b;



            modal.ShowDialog();//Modal형태로, 뒤에 못만지게
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("나왔다잉", sender.ToString());
        }
    }
}
