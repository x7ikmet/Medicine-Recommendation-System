using CsvHelper;
using System.Globalization;
using System.Text;
using MedicineRecommendationSystem.Classes;
using MedicineRecommendationSystem.Models;
namespace MedicineRecommendationSystem;

public partial class FrmDoctor : Form
{

    private bool isMaximized = false;
    private Point mouseLocation;
    private XGBoostHelper xgboostHelper;
    private Interaction interaction;
    private List<String> symptoms;

    public FrmDoctor()
    {
        InitializeComponent();
    }


    private void FrmDoctor_Load(object sender, EventArgs e)
    {

        xgboostHelper = new XGBoostHelper("C:\\Users\\hikmet\\Desktop\\MedicineRecommendationSystem\\Resources\\xgboost.json");
        //interaction = new Interaction();

        LoadSymptoms();
        LoadDiseases();
        LoadMedication();

    }

    private void LoadSymptoms()
    {
        string csvText = Encoding.UTF8.GetString(Properties.Resources.Symptom);
        using (var reader = new StringReader(csvText))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<SymptomEntry>();
            foreach (var record in records)
            {
                comboBoxSymptoms.Items.Add(record.Symptom);
                //symptoms.Add(record.Symptom);
            }
        }
    }

    private void LoadDiseases()
    {
        string csvText = Encoding.UTF8.GetString(Properties.Resources.Medications);
        using (var reader = new StringReader(csvText))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<MedicationsEntry>();
            foreach (var record in records)
            {
                comboBoxDiseases.Items.Add(record.Disease);
            }
        }
    }

    private void LoadMedication()
    {
        string csvText = Encoding.UTF8.GetString(Properties.Resources.Medications);
        using (var reader = new StringReader(csvText))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<MedicationsEntry>();
            foreach (var record in records)
            {
                var meds = record.Medication
                    .Trim('[', ']') 
                    .Split(',')
                    .Select(m => m.Trim(' ', '\'', '\"'))
                    .Where(m => !string.IsNullOrWhiteSpace(m));
                foreach (var med in meds)
                {
                    if (!comboBoxMedication.Items.Contains(med))
                    {
                        comboBoxMedication.Items.Add(med);
                    }
                }
            }
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        UpdateDiseaseData();
        UpdateMedicationData();


    }


    private void UpdateMedicationData()
    {
        string[] diseases = new string[listBox2.Items.Count];
        string csvText = Encoding.UTF8.GetString(Properties.Resources.Medications);
        using (var reader = new StringReader(csvText))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<MedicationsEntry>();
            foreach (var record in records)
            {
                if (listBox2.Items.Contains(record.Disease))
                {
                    var meds = record.Medication
                    .Trim('[', ']')
                    .Split(',')
                    .Select(m => m.Trim(' ', '\'', '\"'))
                    .Where(m => !string.IsNullOrWhiteSpace(m));
                    foreach (var med in meds)
                    {
                        // Eklmek için
                    }
                }

            }
        }
    }

    private void UpdateDiseaseData()
    {
        string[] symptoms = new string[listBox1.Items.Count];
        for (int i = 0; i < listBox1.Items.Count; i++)
        {
            symptoms[i] = listBox1.Items[i].ToString();
        }
        var result = xgboostHelper.Predict(symptoms);
        var results = result.Take(5).ToList();


        listView1.Clear();
        foreach (var disease in results)
        {
            listBox2.Items.Add(disease.Disease + " - " + disease.Probability + "%");
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (comboBoxSymptoms.SelectedItem == null)
        {
            MessageBox.Show("Please select a symptom.", "Error");
            return;
        }
        listBox1.Items.Add(comboBoxSymptoms.SelectedItem.ToString());
        comboBoxSymptoms.Items.Remove(comboBoxSymptoms?.SelectedItem?.ToString());

    }

    private void button7_Click(object sender, EventArgs e)
    {
        if(comboBoxDiseases.SelectedItem == null)
        {
            MessageBox.Show("Please select a disease.", "Error");
            return;
        }
        listBox2.Items.Add(comboBoxDiseases.SelectedItem.ToString());
        comboBoxDiseases.Items.Remove(comboBoxDiseases?.SelectedItem?.ToString());
    }

    private void button5_Click(object sender, EventArgs e)
    {
        if (listBox1.SelectedItems.Count == 0)
        {
            MessageBox.Show("Please select an item to remove.", "Error");
            return;
        }
        listBox1.Items.Remove(listBox1.SelectedItem.ToString());
        if (listBox1.Items.Count > 0)
            listBox1.SelectedIndex = 0;
    }

    private void button6_Click(object sender, EventArgs e)
    {
        if (listBox2.Items.Count == 0)
        {
            MessageBox.Show("Please select an item to remove.", "Error");
            return;
        }
        listBox2.Items.Remove(listBox2.SelectedItem.ToString());

        if (listBox2.Items.Count > 0)
            listBox2.SelectedIndex = 0;


    }

    private void button3_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Minimized;
    }

    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }
    }
    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                isMaximized = false;
            }
            Point mousePose = Control.MousePosition;
            mousePose.Offset(mouseLocation.X, mouseLocation.Y);
            Location = mousePose;
        }
    }

    private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (isMaximized)
        {
            WindowState = FormWindowState.Normal;
            isMaximized = false;
        }



        else
        {
            WindowState = FormWindowState.Maximized;
            isMaximized = true;
        }

    }

    
}



