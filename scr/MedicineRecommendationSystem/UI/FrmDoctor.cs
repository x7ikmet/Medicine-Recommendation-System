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

        xgboostHelper = new XGBoostHelper("C:\\Users\\hikmet\\Desktop\\Medicine-Recommendation-System\\scr\\MedicineRecommendationSystem\\Resources\\xgboost.json");
        interaction = new Interaction();
        //interaction.InteractCheck("Citalopram", "Omeprazole");
        LoadSymptoms();
        LoadDiseases();
        LoadMedication();
        SetupListView();

    }


    private void SetupListView()
    {
        listView1.View = View.Details;
        listView1.Columns.Add("İlaç Adı", 200);
        listView1.Columns.Add("Açıklama", 200);
        listView1.Columns.Add("Alerji", 200);
        listView1.Columns.Add("Level", 150);
        listView1.FullRowSelect = true;
        listView1.GridLines = true;


        listView3.View = View.Details;
        listView3.Columns.Add("Hastalık Adı", 200);
        listView3.Columns.Add("Oranı", 200);
        listView3.FullRowSelect = true;
        listView3.GridLines = true;

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


    private void button14_Click(object sender, EventArgs e)
    {
        
        string receteId = new string(Enumerable.Range(0, 5)
            .Select(_ => "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"[new Random().Next(36)]).ToArray());

        SaveReceteToCsv(receteId, listView1, "C:\\Users\\hikmet\\Desktop\\Medicine-Recommendation-System\\scr\\MedicineRecommendationSystem\\Resources\\Receteler.csv");
        MessageBox.Show($"Recete ID: {receteId}", "Recete kaydedildi.", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    private void SaveReceteToCsv(string receteId, ListView listView1, string filePath)
    {
        var ilaclar = new List<string>();
        foreach (ListViewItem item in listView1.Items)
        {
            ilaclar.Add(item.Text);
        }

        var record = new
        {
            ReceteId = receteId,
            Ilaclar = string.Join(";", ilaclar)
        };

        bool fileExists = File.Exists(filePath);

        using (var stream = File.Open(filePath, FileMode.Append, FileAccess.Write))
        using (var writer = new StreamWriter(stream, Encoding.UTF8))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            if (!fileExists)
            {
                csv.WriteHeader(record.GetType());
                csv.NextRecord();
            }
            csv.WriteRecord(record);
            csv.NextRecord();
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
        //UpdateMedicationData();


    }
    private void button8_Click(object sender, EventArgs e)
    {
        UpdateMedicationData();
    }


    private void UpdateMedicationData()
    {
        listView1.Items.Clear();
        HashSet<string> addedMedications = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        string csvText = Encoding.UTF8.GetString(Properties.Resources.Medications);
        using (var reader = new StringReader(csvText))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<MedicationsEntry>();
            foreach (var record in records)
            {
                bool diseaseExistsInListView3 = listView3.Items
                    .Cast<ListViewItem>()
                    .Any(item => item.SubItems[0].Text.Equals(record.Disease, StringComparison.OrdinalIgnoreCase));

                if (!diseaseExistsInListView3)
                    continue;

                var meds = record.Medication
                    .Trim('[', ']')
                    .Split(',')
                    .Select(m => m.Trim(' ', '\'', '\"'))
                    .Where(m => !string.IsNullOrWhiteSpace(m));

                foreach (var med in meds)
                {
                    // Avoid duplicates
                    string uniqueKey = $"{med}|{record.Disease}";
                    if (addedMedications.Contains(uniqueKey))
                        continue;

                    ListViewItem item = new ListViewItem(med);
                    item.SubItems.Add(record.Disease);

                    // Check for interactions with other meds already in the list
                    string description = "";
                    string level = "";
                    Color? color = null;
                    foreach (ListViewItem existing in listView1.Items)
                    {
                        var result = interaction.InteractCheck(med, existing.Text);
                        if (result != null)
                        {
                            //description = result.Value.Description;
                            description = $"{med} | {existing.Text}";
                            level = result.Value.Level;
                            color = Color.FromName(result.Value.Color);
                            break; // Stop at first found interaction
                        }
                    }
                    item.SubItems.Add(description);
                    item.SubItems.Add(level);
                    if (color.HasValue)
                        item.ForeColor = color.Value;

                    listView1.Items.Add(item);
                    addedMedications.Add(uniqueKey);
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



        listView3.Items.Clear();
        foreach (var disease in results)
        {
            ListViewItem item = new ListViewItem(disease.Disease);
            item.SubItems.Add(disease.Probability.ToString("0.00") + "%");
            listView3.Items.Add(item);
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
        if (comboBoxDiseases.SelectedItem == null)
        {
            MessageBox.Show("Please select a disease.", "Error");
            return;
        }
        ListViewItem item = new ListViewItem(comboBoxDiseases.SelectedItem.ToString());

        listView3.Items.Add(item);
        comboBoxDiseases.Items.Remove(comboBoxDiseases?.SelectedItem?.ToString());
        UpdateMedicationData();
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
        if (listView3.SelectedItems.Count == 0)
        {
            MessageBox.Show("Please select an item to remove.", "Error");
            return;
        }

        listView3.Items.Remove(listView3.SelectedItems[0]);

    }

    private void button10_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count == 0)
        {
            MessageBox.Show("Please select an item to remove.", "Error");
            return;
        }
        listView1.Items.Remove(listView1.SelectedItems[0]);

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



