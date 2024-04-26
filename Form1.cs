using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Database_Project
{
    public partial class Form1 : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("Project");
        static IMongoCollection<Student> collection = db.GetCollection<Student>("Student");

        public void ReadAllDocuments() 
        {
            List<Student> list = collection.AsQueryable().ToList<Student>();
            dataGridView1.DataSource = list;

            textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
        }
        public Form1()
        {
            InitializeComponent();
            ReadAllDocuments();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student s = new Student(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, int.Parse(textBox6.Text), textBox7.Text);
            collection.InsertOne(s);
            ReadAllDocuments();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // TextBox'ların Text özelliklerini kullanarak güncelleme alanlarını ayarlayın
            var updateField = Builders<Student>.Update
                .Set("FirstName", textBox2.Text)
                .Set("LastName", textBox3.Text)
                .Set("phone", textBox4.Text)
                .Set("email", textBox5.Text)
                .Set("birth_year", textBox6.Text)
                .Set("major", textBox7.Text);

            // textBox1 boş değilse ve ObjectId olarak geçerli bir değere dönüştürülebiliyorsa güncelleme işlemini gerçekleştirin
            if (!string.IsNullOrEmpty(textBox1.Text) && ObjectId.TryParse(textBox1.Text, out ObjectId id))
            {
                collection.UpdateOne(s => s.Id == id, updateField);
                // Güncelleme işlemi gerçekleştikten sonra belgeleri tekrar okuyun
                ReadAllDocuments();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            collection.DeleteOne(s => s.Id == ObjectId.Parse(textBox1.Text));
            ReadAllDocuments();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
