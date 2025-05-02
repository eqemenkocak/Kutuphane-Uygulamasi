using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace kutuphane_uygulamasi
{
    public partial class Form1 : Form
    {
        // Üyelerin ödünç aldýðý kitap sayýsýný tutan sözlük
        private Dictionary<string, int> uyeKitapDurumu = new Dictionary<string, int>();
        private HashSet<string> alinanKitaplar = new HashSet<string>();

        public Form1()
        {
            InitializeComponent();
        }

        // TC nin 11 haneden az yazýlmamasý için kontrol eden kod
        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Trim().Length < 11)
            {
                MessageBox.Show("Lütfen TC'nizi 11 haneli olarak girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Lütfen bir kullanýcý adý girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            comboBox3.Items.Add(textBox1.Text);
            textBox1.Clear();
            maskedTextBox1.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Trim().Length < 11)
            {
                MessageBox.Show("Lütfen TC'nizi 11 haneli olarak girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            comboBox3.Items.Remove(textBox1.Text);
            textBox1.Clear();
            maskedTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Lütfen bir kitap adý girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Lütfen bir yazar adý girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            comboBox4.Items.Add(textBox3.Text);
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox4.Items.Remove(textBox3.Text);
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string uye = comboBox3.Text;
            string kitap = comboBox4.Text;

            if (string.IsNullOrWhiteSpace(uye))
            {
                MessageBox.Show("Lütfen bir üye adý seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(kitap))
            {
                MessageBox.Show("Lütfen bir kitap adý seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (uyeKitapDurumu.ContainsKey(uye) && uyeKitapDurumu[uye] >= 1)
            {
                MessageBox.Show("Bu üye zaten bir kitap aldý. Önce iade etmeli!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (alinanKitaplar.Contains(kitap))
            {
                MessageBox.Show("Bu kitap þu anda ödünç alýnmýþ durumda.", "Kitap Mevcut Deðil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ödünç alma baþarýlý
            richTextBox1.AppendText(string.Format("{0} adlý kullanýcý \"{1}\" adlý kitabý aldý\n", uye, kitap));


            if (!uyeKitapDurumu.ContainsKey(uye))
                uyeKitapDurumu[uye] = 0;

            uyeKitapDurumu[uye]++;
            alinanKitaplar.Add(kitap); // kitap artýk alýnmýþ sayýlýr

            comboBox3.Text = "";
            comboBox4.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string uye = comboBox3.Text;
            string kitap = comboBox4.Text;

            if (string.IsNullOrWhiteSpace(uye))
            {
                MessageBox.Show("Lütfen bir üye adý seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(kitap))
            {
                MessageBox.Show("Lütfen bir kitap adý seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ýade iþlemi
            richTextBox1.AppendText(string.Format("{0} adlý kullanýcý \"{1}\" adlý kitabý iade etti\n", uye, kitap));


            if (uyeKitapDurumu.ContainsKey(uye))
                uyeKitapDurumu[uye] = 0;

            alinanKitaplar.Remove(kitap); // kitap tekrar alýnabilir

            comboBox3.Text = "";
            comboBox4.Text = "";
        }
    }
}

