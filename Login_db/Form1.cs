using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite; //uvozenje paketa

namespace Login_db
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection sql = new SQLiteConnection("Data Source= login.db;Version=3;"); //pravljenje objekta za koriscenje f-ja vezanih za sqlite, login,db je naziv baze koju si koristila
            sql.Open(); //otvaranje sqlite baze
            SQLiteCommand cmd = new SQLiteCommand("select * from tabela", sql); //prvljenje objekta vezano za komande u sqlite bazi da bih ispod mogli da koristimo read
            SQLiteDataReader read = cmd.ExecuteReader(); //pravljenje objekta koji nam omogucava poziv f-ja pomocu kojih citamo podatke iz baze
            bool b = false; //bool vrednost koja nam je false, trenutno nije bitna, na kraju je koristimo ako ona ostane false da se izvrsi sta je u if-u
            while (read.Read()) //petlja while koja cita podatke iz baze
            {
                if (textBox1.Text == read.GetString(0) && textBox2.Text == read.GetString(1)) //uslov da proveri podatke iz text.Box1 i text.Box2 da li su jednaki read.GetString(0) i read.GetString(1)
                                                                                              //read.GetString(0) je prva kolona u bazi u ovom slucaju username,a read.GetString(1) je druga kolona u bazi a to nam je password
                {
                    MessageBox.Show("Ulogovali ste se!");//MessageBox.Show() ispisuje na ekran ovo u zagradi
                    b = true; //menja vrednost b koja je bila false u true
                }
            }
            sql.Close(); //Zatvaramo bazu
            if (b == false) MessageBox.Show("Nalog ne postoji!");//uslov ako nam je b false da nam se ispise ovo u zagradama
        }
    }
}
