using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using MedicineRecommendationSystem.Classes;

namespace MedicineRecommendationSystem.UI
{
    public partial class FrmEczaci : Form
    {
        public FrmEczaci()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string receteID = textBox1.Text;
            UpdateIlaclar(receteID);

        }

        private void UpdateIlaclar(string receteID)
        {
            using (var reader = new StreamReader("C:\\Users\\hikmet\\Desktop\\Medicine-Recommendation-System\\scr\\MedicineRecommendationSystem\\Resources\\Receteler.csv", Encoding.UTF8))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<ReceteEntry>();
                foreach (var record in records)
                {
                    if (record.ReceteId == receteID)
                    {
                        var meds = record.Ilaclar
                            .Split(';')
                            .Select(m => m.Trim(' ', '\'', '\"'))
                            .Where(m => !string.IsNullOrWhiteSpace(m));
                        foreach (var med in meds)
                        {
                            listBox1.Items.Add(med);
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
