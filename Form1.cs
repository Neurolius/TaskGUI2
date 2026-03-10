namespace TaskGUI2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.InputText.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string text = textBox1.Text ?? "0";
            int inputText = int.Parse(text);

            Properties.Settings.Default.InputText = text;
            Properties.Settings.Default.Save();

            var result = Logic.ConvertToMoney(inputText);
            Result.Text = result;  
        }
    }

    public class Logic
    {
        public static string GetWord(int number, string form1, string form2, string form3)
        {

            number = number % 100;
            int lastDigit = number % 10;

            if (number >= 11 && number <= 19)
                return form3;

            if (lastDigit == 1)
                return form1;

            if (lastDigit >= 2 && lastDigit <= 4)
                return form2;

            return form3;
        }

        public static bool inInterval(int number)
        {
            return number < 1 || number > 9999;
        }

        public static string ConvertToMoney(int input)
        {

            if (inInterval(input))
            {
                return "Значение числа должно быть в рамках: [1;9999]";
            }
            else
            {
                string ruble = GetWord(input / 100, "рубль", "рубля", "рублей"),
                    penny = GetWord(input % 100, "копейка", "копейки", "копеек");

                if (input % 100 == 0)
                    return $"{input / 100} {ruble}";

                return $"{input / 100} {ruble} {input % 100} {penny}";
            }
        }
    }

}
