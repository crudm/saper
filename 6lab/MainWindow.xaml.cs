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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _6lab
{
    // <summary>
    // Логика взаимодействия для MainWindow.xaml
    // </summary>
    public partial class MainWindow : Window
    {
        int a;
            int q = 0;
        play pl = new play();

        BitmapImage mine = new BitmapImage(new Uri(@"pack://application:,,,/image/star.png",UriKind.Absolute));

        public MainWindow()
        {
            InitializeComponent();

            cmb.Items.Add("простая");
            cmb.Items.Add("средняя");
            cmb.Items.Add("сложная");

        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            ugr.Children.Clear();

            a = int.Parse(t1.Text);

            pl.set(a);
            pl.mines(a);
            pl.calc();

            if (a>2 && a<11)
            { 
                ugr.Rows = a;
                ugr.Columns = a;
                //указываются размеры сетки (число ячеек * (размер кнопки в ячейки + толщина её границ))
                ugr.Width = a * (50 + 4);
                ugr.Height = a * (50 + 4);
                //толщина границ сетки
                ugr.Margin = new Thickness(5, 5, 5, 5);

                for (int i = 0; i < a * a; i++)
                {
                        //создание кнопки
                        Button btn = new Button();
                        //запись номера кнопки
                        btn.Tag = i;
                        //установка размеров кнопки
                        btn.Width = 50;
                        btn.Height = 50;
                        //текст на кнопке
                        btn.Content = " ";
                        //толщина границ кнопки
                        btn.Margin = new Thickness(2);
                        //при нажатии кнопки, будет вызываться метод Btn_Click
                        btn.PreviewMouseDown += Btn_MouseDown;
                      //добавление кнопки в сетку
                      ugr.Children.Add(btn);
                }
            }
        }

        private void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int p = (int)((Button)sender).Tag;

            
            if (e.LeftButton == MouseButtonState.Pressed)
            {
          
                if (pl.get(p % a, p / a) == 9)
                {
                    Image img = new Image();
                    img.Source = mine;
                    StackPanel stackpnl = new StackPanel();
                    stackpnl.Margin = new Thickness(1);
                    stackpnl.Children.Add(img);
                    ((Button)sender).Content = stackpnl;

                    {
                        MessageBox.Show("Ты проиграл!");
                        q = 0;
                        ugr.Children.Clear();

                        a = int.Parse(t1.Text);

                        pl.set(a);
                        pl.mines(a);
                        pl.calc();
                        if (a > 2 && a < 11)
                        {
                            ugr.Rows = a;
                            ugr.Columns = a;
                            //указываются размеры сетки (число ячеек * (размер кнопки в ячейки + толщина её границ))
                            ugr.Width = a * (50 + 4);
                            ugr.Height = a * (50 + 4);
                            //толщина границ сетки
                            ugr.Margin = new Thickness(5, 5, 5, 5);

                            for (int i = 0; i < a * a; i++)
                            {
                                //создание кнопки
                                Button btn = new Button();
                                //запись номера кнопки
                                btn.Tag = i;
                                //установка размеров кнопки
                                btn.Width = 50;
                                btn.Height = 50;
                                //текст на кнопке
                                btn.Content = " ";
                                //толщина границ кнопки
                                btn.Margin = new Thickness(2);
                                //при нажатии кнопки, будет вызываться метод Btn_Click
                                btn.PreviewMouseDown += Btn_MouseDown;
                                //добавление кнопки в сетку
                                ugr.Children.Add(btn);
                            }
                        }
                    }
                }

                if (pl.get(p % a, p / a) < 9)
                {
                    //установка фона нажатой кнопки, цвета и размера шрифта
                    ((Button)sender).Background = Brushes.White;
                    ((Button)sender).Foreground = Brushes.Red;
                    ((Button)sender).FontSize = 23;
                    //запись в нажатую кнопку её номера
                    ((Button)sender).Content = pl.get(p%a, p/a);
              
                    q++;                   
                }
                if (q == a*a - a)
                {
                    MessageBox.Show("Ты выиграл!");
                    q = 0;
                    ugr.Children.Clear();

                    a = int.Parse(t1.Text);

                    pl.set(a);
                    pl.mines(a);
                    pl.calc();
                    if (a > 2 && a < 11)
                    {
                        ugr.Rows = a;
                        ugr.Columns = a;
                        //указываются размеры сетки (число ячеек * (размер кнопки в ячейки + толщина её границ))
                        ugr.Width = a * (50 + 4);
                        ugr.Height = a * (50 + 4);
                        //толщина границ сетки
                        ugr.Margin = new Thickness(5, 5, 5, 5);

                        for (int i = 0; i < a * a; i++)
                        {
                            //создание кнопки
                            Button btn = new Button();
                            //запись номера кнопки
                            btn.Tag = i;
                            //установка размеров кнопки
                            btn.Width = 50;
                            btn.Height = 50;
                            //текст на кнопке
                            btn.Content = " ";
                            //толщина границ кнопки
                            btn.Margin = new Thickness(2);
                            //при нажатии кнопки, будет вызываться метод Btn_Click
                            btn.PreviewMouseDown += Btn_MouseDown;
                            //добавление кнопки в сетку
                            ugr.Children.Add(btn);
                        }
                    }
                }

            }

            if (e.RightButton == MouseButtonState.Pressed)
            {
                ((Button)sender).Content ="*";
            }
        }
    }
}
