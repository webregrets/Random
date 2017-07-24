using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PW
{
    public partial class Form1 : Form


    {
        public Form1()
        {
            InitializeComponent();   
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            // TÄNK PÅ ATT fraser.txt MÅSTE LIGGA I SAMMA MAPP SOM .EXE-filen!
            //Lägger till alla rader i "fraser.txt" i en array
            string[] textrader = System.IO.File.ReadAllLines(@".\fraser.txt");

            //Räknar samtliga rader i fraser.txt och lägger in värdet i lineCount
            int lineCount = 0;
            using (var reader = System.IO.File.OpenText(@".\fraser.txt"))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }


            //En array med strings som kan användas som lösenordsbas
           // string[] random = { "Smultron", "Glassar", "Traktor", "Testing" };

            //initierar en randomrullning mellan 0 och 4 till strängarna över^
            Random rnd = new Random();
            int x = rnd.Next(0, lineCount);
            
            //denna rackare ska slumpmässigt ordna så siffran ska finnas före eller efter frasen
            Random truefalse = new Random();
            int tf = truefalse.Next(0, 2);

            //Spottar ut en randomsiffra mellan 0 - 99 för användning till lösenordet
            Random nollnittionio = new Random();
            int zeroninenine = nollnittionio.Next(0, 99);

            //Gör en sträng av randomsiffran så den går att printa ut
            string randomsiffra = zeroninenine.ToString();

            string fore = "";
            string efter = "";

            // IF-sats! Om INTen tf är 1 = siffrorna är före frasen. Om INTen tf inte är 1 = siffrorna efter frasen
            if (tf == 1)
            {
                fore = randomsiffra;
                efter = "";
            }
            else if(tf != 1)
            {
                fore = "";
                efter = randomsiffra;
            }
            
            //Printar ut information i textBox1
            textBox1.Text = fore + textrader[x] + efter;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Kopierar automatiskt det som finns i textbox1
            Clipboard.SetText(textBox1.Text);
        }
    }
}
