namespace MedicineRecommendationSystem;

public partial class Main : Form
{

    private bool isMaximized = false;
    private Point mouseLocation;
    public Main()
    {
        InitializeComponent();
    }
    
    
    private void button3_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (isMaximized)
        {
            this.WindowState = FormWindowState.Normal;
            isMaximized = false;
        }
        else
        {
            this.WindowState = FormWindowState.Maximized;
            isMaximized = true;
        }
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

    private void button4_Click(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Minimized;
    }

    private void BtnDoctor_Click(object sender, EventArgs e)
    {
        FrmDoctor doctor = new FrmDoctor();
        doctor.Show();
        this.Hide();
    }
}
