using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace RandomChoice
{
    public partial class Form2 : Form
    {
        private String name;
        private List<String> List;
        private XmlSerializer xs;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           start_save(txtInput.Text);

        }
        

        public void start_save(String name)
        {
            if (name != null)
            {
                this.name = name;
                List = new List<String>();
                List.Add(name);
                save();
                verif.Text = "Création réussi!";
                
            }
            else
            {
                Console.Out.WriteLine("Question(): name is null");
            }
        }
       
       
        public void save()
        {

            XmlSerializer xs = new XmlSerializer(typeof(List<String>));
            using (StreamWriter wr = new StreamWriter("./listes/" + this.name + ".xml"))
            {
                xs.Serialize(wr, List);
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
