using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ArrayList myAL = new ArrayList();
        int id = 0;
        int i = 0;
        
        
        public Form1()
        {
            InitializeComponent();
            button1.Text = "Inserir";
            label2.Text = "";
            label1.Text = "Pessoas";
            label3.Text = "Nome:";
            label4.Text = "Idade:";
            label5.Text = "";
            label6.BackColor = System.Drawing.Color.Blue;
            label6.ForeColor = System.Drawing.Color.Blue;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label2.Text = "";
            numericUpDown1_ValueChanged(sender, e);
            Pessoa pessoa = new Pessoa(id++,textBox1.Text, Convert.ToInt32(textBox2.Text));

            // listView1.
            string message = "Pessoa Adicionada";
            if (NewMethod() == 0)
            {
                myAL.Add(pessoa);

                MessageBox.Show(message);
            }

            //  label2.Text = myAL.Count.ToString();
        }

        private int NewMethod()
        {
            IEnumerator EmpEnumerator = myAL.GetEnumerator(); //Getting the Enumerator    
            EmpEnumerator.Reset(); //Position at the Beginning    
            int j = 0;
            while (EmpEnumerator.MoveNext()) //Till not finished do print    
            {
                Console.WriteLine((Pessoa)EmpEnumerator.Current);
                Pessoa p = (Pessoa)EmpEnumerator.Current;
                if (textBox1.Text == p.getnome())
                {
                    MessageBox.Show("Nome ja existe");
                    return 1;
                }
                j++;
            }
            return 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
            label2.Text = "";
            //numericUpDown1.;
            IEnumerator EmpEnumerator = myAL.GetEnumerator(); //Getting the Enumerator    
            EmpEnumerator.Reset(); //Position at the Beginning    
            int j = 0;
            while (EmpEnumerator.MoveNext()) //Till not finished do print    
            {
                if (j == numericUpDown1.Value)
                {
                    Console.WriteLine((Pessoa)EmpEnumerator.Current);
                    Pessoa p = (Pessoa)EmpEnumerator.Current;

                    label2.Text = label2.Text + "\n\nNome:" + p.getnome() + "\nAge:" + p.getage() + "\nId:" + p.getid();
                }
                j++;
            }
            //label5
            
          EmpEnumerator.Reset();
          int count = myAL.Count;
            label5.Text = "";
          j = 0;//Position at the Beginning   
          while (EmpEnumerator.MoveNext()) //Till not finished do print    
          {
              if (j <= numericUpDown1.Value +2 && j>= numericUpDown1.Value)
              {
                  Console.WriteLine((Pessoa)EmpEnumerator.Current);
                  Pessoa p = (Pessoa)EmpEnumerator.Current;

                  label5.Text = label5.Text + "\n\nNome:" + p.getnome() + "\nAge:" + p.getage();
              }
              j++;
          }
          

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            mysqlligar(label3.Text,label4.Text);


//            string text = 
// WriteAllText creates a file, writes the specified string to the file,
// and then closes the file.    You do NOT need to call Flush() or Close().
// System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\WriteText.txt", text);
        }
        public void ultimoid()
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=pessoasc#");
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                button3.BackColor = Color.Green;

                //string myInsertQuery = "INSERT INTO pessoa (id_pessoa,nome,idade) Values(101, %s,%d)";
                MySqlCommand Command = new MySqlCommand();
                MySqlDataReader reader;
                IEnumerator EmpEnumerator = myAL.GetEnumerator(); //Getting the Enumerator    
                EmpEnumerator.Reset(); //Position at the Beginning    
                int j = 0;
              
                    
                       
                        Command.CommandText = "SELECT * FROM pessoa WHERE id_pessoa = (SELECT MAX(id_pessoa) FROM pessoa)";



                // Command.Parameters.Add("@nome", MySqlDbType.Text).Value = textBox1.Text;
                //Command.Parameters.Add("@idade", MySqlDbType.Int32).Value = Convert.ToInt32(textBox2.Text);
                //Command.Parameters.Add("@id", MySqlDbType.Int32).Value= 

                // Command.CommandText = "INSERT INTO pessoa(id_pessoa, nome, idade) Values(102,@nome,@idade)";
                Command.Connection = connection;

                //  connection.Open();Convert.ToInt32(textBox2.Text)
                //Command.ExecuteNonQuery();
                reader=Command.ExecuteReader() ;
                reader.Read();
                button3.Text = reader.GetString("id_pessoa");
                id = Convert.ToInt32(button3.Text)+1;
                Command.Connection.Close();

            }
            else
                button3.BackColor = Color.Red;


        }
        public void mysqlligar(String l3,String l4)
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=pessoasc#");
            connection.Open();
            
            if (connection.State == ConnectionState.Open)
            {
                button2.BackColor = Color.Green;

                //string myInsertQuery = "INSERT INTO pessoa (id_pessoa,nome,idade) Values(101, %s,%d)";
                MySqlCommand Command = new MySqlCommand();
                IEnumerator EmpEnumerator = myAL.GetEnumerator(); //Getting the Enumerator    
                EmpEnumerator.Reset(); //Position at the Beginning    
                int j = 0;
                while (EmpEnumerator.MoveNext()) //Till not finished do print    
                {
                    if (j == numericUpDown1.Value)
                    {
                        Console.WriteLine((Pessoa)EmpEnumerator.Current);
                        Pessoa p = (Pessoa)EmpEnumerator.Current;
                        Command.Parameters.Add("@nome", MySqlDbType.Text).Value = p.getnome();
                        Command.Parameters.Add("@idade", MySqlDbType.Int32).Value = Convert.ToInt32(p.getage());
                        Command.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(p.getid());
                        Command.CommandText = "INSERT INTO pessoa(id_pessoa, nome, idade) Values(@id,@nome,@idade)";
                    }
                    j++;
                }
               // Command.Parameters.Add("@nome", MySqlDbType.Text).Value = textBox1.Text;
                //Command.Parameters.Add("@idade", MySqlDbType.Int32).Value = Convert.ToInt32(textBox2.Text);
                //Command.Parameters.Add("@id", MySqlDbType.Int32).Value= 

               // Command.CommandText = "INSERT INTO pessoa(id_pessoa, nome, idade) Values(102,@nome,@idade)";
                Command.Connection = connection;
                
                //  connection.Open();Convert.ToInt32(textBox2.Text)
                Command.ExecuteNonQuery();
                Command.Connection.Close();

            }
            else
                button2.BackColor = Color.Red;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ultimoid();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
