namespace PetShopManagementSystem
{
    public partial class Splash : Form
    {
        int startP = 0;
        public Splash()
        {
            InitializeComponent();
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            startP += 1;
            myProcess.Value = startP;
            loadPercent.Text = startP + "%";
            if(myProcess.Value == 100)
            {
                myProcess.Value = 0;
                Login login = new Login();
                login.Show();
                this.Hide();
                timer.Stop();
            }
        }
    }
}
