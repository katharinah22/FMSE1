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
using MySql.Data.MySqlClient;

namespace FMSE1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //SqlConnection myConnection = new SqlConnection("Server=qrtest-aprophis.c9users.io;Database=qrtestdatabase;Uid=aprophis");
        MySqlConnection myConnection = new MySqlConnection("server=sql11.freemysqlhosting.net;database=sql11163169;uid=sql11163169;password=VL5BNCw87M");
        public MainWindow()
        {
            InitializeComponent();
            
            myButton.Click += MyButton_Click;
            myButton2.Click += MyButton2_Click;
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            Console.Write("Clicked!");

            try
            {
                myConnection.Open();
                //textBox.Text = "Server Version: " + myConnection.ServerVersion;
                Console.WriteLine("Server Version: " + myConnection.ServerVersion);
                MySqlCommand command = myConnection.CreateCommand();
                command.CommandText = "SELECT * FROM test";
                MySqlDataReader reader = command.ExecuteReader();
                int fields = reader.FieldCount;
                String[] cols = new string[fields];
                for (int i = 0; i < fields; i++)
                {
                    cols[i] = reader.GetName(i);
                }
                textBox1Titel.AppendText(cols[0]);
                textBox2Titel.AppendText(cols[1]);
                textBox3Titel.AppendText(cols[2]);
                textBox4Titel.AppendText(cols[3]);

                while (reader.Read())
                {
                    textBox1.AppendText(reader.GetValue(0).ToString());
                    textBox2.AppendText(reader.GetValue(1).ToString());
                    textBox3.AppendText(reader.GetValue(2).ToString());
                    textBox4.AppendText(reader.GetValue(3).ToString());
                    textBox1.AppendText("\n");
                    textBox2.AppendText("\n");
                    textBox3.AppendText("\n");
                    textBox4.AppendText("\n");
                }
                myButton.IsEnabled = false;
            }
            catch (Exception f)
            {
                Console.WriteLine(f.ToString());
            }
            finally
            {
                myConnection.Close();
            }
        }

        private void MyButton2_Click(object sender, RoutedEventArgs e)
        {
            MapWindow map = new MapWindow();
            this.Close();
            map.Show();
        }
    }
}
