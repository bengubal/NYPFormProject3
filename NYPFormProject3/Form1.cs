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

                // �lk TextBox
                textBox1 = new TextBox();
                textBox1.TextChanged += textBox1_TextChanged;
                textBox1.Dock = DockStyle.Left;

                // �kinci TextBox (Sonu� g�sterilecek olan)
                textBox2 = new TextBox();
                textBox2.ReadOnly = true;
                textBox2.Dock = DockStyle.Right;

                // Hesapla Butonu
                button1 = new Button();
                button1.Text = "Calculate";
                button1.Click += button1_Click;
                button1.Dock = DockStyle.Fill;

                // Form �zerine kontrol eklemeleri
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

            // Kullan�c�n�n girdi�i metni al
            string userInput = textBox1.Text;

            // Girilen metni bir say�ya �evirmeye �al��
            if (int.TryParse(userInput, out int parsedValue))
            {
                // Giri� bir say�d�r
                if (parsedValue > 99999)
                {
                    // Say� 99999'dan b�y�kse, bir i�lem yapamazs�n�z
                    label1.Text = "Entered number is too large. Cannot perform the operation.";
                }
                else
                {
                    // Say� 99999 veya daha k���kse, istedi�iniz i�lemi yapabilirsiniz
                    //label1.Text = "Entered number is valid.";
                }
            }
            else
            {
                // Giri� bir say� de�ildir
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
            // Say�y� basamaklar�na ay�r, her bir basama�� al ve topla
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