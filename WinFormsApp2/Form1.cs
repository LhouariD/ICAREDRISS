using System;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        //   private Timer blinkTimer;
        public string ConnectionString;

        public Form1()
        {
            InitializeComponent();
            //    blinkTimer = new Timer();
            //    blinkTimer.Interval = 500; // milliseconds
            //   BlinkTimer1_Tick += BlinkTimer1_Tick;
            //    blinkTimer.Start();
        }
        private void BlinkTimer1_Tick(object sender, EventArgs e)
        {
            button1.Visible = !button1.Visible;
        }
        private async void Blink_effect(Control X)
        {
            int counter = 0;
            while (true)
            {
                counter++;
                await Task.Delay(500);
                X.BackColor = X.BackColor == Color.Wheat ? Color.WhiteSmoke : Color.Wheat;

                if (counter == 8)
                {
                    X.BackColor = Color.White;
                    break;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    Blink_effect(button2);
                    MessageBox.Show("Erreur");
                    goto autofhere;
                }
                MessageBox.Show("Bien");
            autofhere:;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        [Obsolete]
        public void Disp_data()
        {
            string query = ""; string Wipadr = "100.79.179.70,1433";
            //           string query = ""; string Wipadr = "100.110.56.123,1433";  //"100.79.179.70,1433";

            string cs = "Data Source =" + Wipadr + "; Initial Catalog = Bicare;user id =driss;password=HADsql1_";
            // "Data Source =  " + GlobClass1.Ipserv + "; Initial Catalog = Bicare;user id =driss;password=HADsql1_"
            try
            {
                using (SqlConnection cnsql = new SqlConnection(cs))
                {
                    //      SqlConnection connexion = new SqlConnection(cs);

                    //                    if (cnsql.State != ConnectionState.Open)
                    {
                        cnsql.Open();
                    }
                    //                   if (textBox1.Text != (""))
                    {
                        //                   query = "select * from client01 where code_cli=" + int.Parse(textBox1.Text);
                    }
                    //                   else
                    {
                        //                  query = "select * from client01";
                    }
                    ////////////////
                    ///

                    // Utilisation de LIKE avec paramètre pour éviter l'injection SQL
                    query = "SELECT * FROM client WHERE Nom_cli >'" + textBox1.Text.Trim() + "'  ORDER BY Nom_cli"; // LIKE @search";
                    using (SqlCommand cmd = new SqlCommand(query, cnsql))
                    {
                        //                       cmd.Parameters.AddWithValue("@search", "%" + textBox1.Text.Trim() + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("Inexistant ");
                                return;
                            }
                            //      while (reader.Read())
                            //      {
                            MessageBox.Show("Adresse " + reader["code_cli"] + "///" + reader["nom_cli"] + "///" + reader["adresse_cli"]);
                            //   Console.WriteLine($"{reader["code_cli"]} - {reader["adresse_cli"]}");
                            DataTable dt = new DataTable();

                            dt.Load(reader);
                            dataGridView1.DataSource = dt;
                            cnsql.Close();

                            //     }
                        }
                    }

                    //////////////////

                    // SqlCommand cmd;
                    //                  SqlCommand cmd = new SqlCommand(query, cnsql);
                    //                   SqlDataReader reader = cmd.ExecuteReader();
                    //                   DataTable dt = new DataTable();
                    ///                    dt.Load(reader1);
                    ///                   dataGridView1.DataSource = dt;
                    ///                   cnsql.Close();
                }  //Sqlconn

            }   //try
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);     //Console.WriteLine("Erreur : " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Disp_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

 