namespace NYPFormProject3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            void InitializeComponent()
            {
                this.Text = "Digit Sum Calculator";

                // Ýlk TextBox
                textBox1 = new TextBox();
                textBox1.TextChanged += textBox1_TextChanged;
                textBox1.Dock = DockStyle.Left;

                // Ýkinci TextBox (Sonuç gösterilecek olan)
                textBox2 = new TextBox();
                textBox2.ReadOnly = true;
                textBox2.Dock = DockStyle.Right;

                // Hesapla Butonu
                button1 = new Button();
                button1.Text = "Calculate";
                button1.Click += button1_Click;
                button1.Dock = DockStyle.Fill;

                // Form üzerine kontrol eklemeleri
                this.Controls.Add(textBox1);
                this.Controls.Add(textBox2);
                this.Controls.Add(button1);

                textBox1.Visible = true;
                textBox2.Visible = true;
                button1.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            // Kullanýcýnýn girdiði metni al
            string userInput = textBox1.Text;

            // Girilen metni bir sayýya çevirmeye çalýþ
            if (int.TryParse(userInput, out int parsedValue))
            {
                // Giriþ bir sayýdýr
                if (parsedValue > 99999)
                {
                    // Sayý 99999'dan büyükse, bir iþlem yapamazsýnýz
                    label1.Text = "Entered number is too large. Cannot perform the operation.";
                }
                else
                {
                    // Sayý 99999 veya daha küçükse, istediðiniz iþlemi yapabilirsiniz
                    //label1.Text = "Entered number is valid.";
                }
            }
            else
            {
                // Giriþ bir sayý deðildir
                label1.Text = "Please enter a valid number.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int number = int.Parse(textBox1.Text);
                int result = SumOfDigits(number);
                textBox2.Text = result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.", "Error");
            }


        }
        private int SumOfDigits(int number)
        {
            // Sayýyý basamaklarýna ayýr, her bir basamaðý al ve topla
            if (number < 10)
            {
                return number;
            }
            else
            {
                return number % 10 + SumOfDigits(number / 10);
            }
        }
    }
}