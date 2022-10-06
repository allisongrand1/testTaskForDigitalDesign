using Microsoft.VisualBasic.Logging;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace testTaskForDigitalDesign
{
    public class SafeButton : Button
    {
        public int x { get; set; }
        public int y { get; set; }
    }
    public partial class Form1 : Form
    {
        SafeButton[,] _buttons;
        TextBox textBox = new TextBox();
        Label label = new Label();
        Button submitButton = new Button();
        private static Random random = new Random();
        int n;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Width = 700;
            Height = 700;
            ChangeText();
        }

        private void ChangeText()
        {
            label.Location = new Point(100, 102);
            label.Text = "Введите кол-во переключателей";
            label.Size = new Size(500, 20);
            label.Visible = true;
            this.Controls.Add(label);

            textBox.Size = new Size(300, 300);
            textBox.Location = new Point(100, 150);
            this.Controls.Add(textBox);
            textBox.Visible = true;

            submitButton.Location = new Point(100, 220);
            submitButton.Text = "Добавить";
            submitButton.AutoSize = true;
            submitButton.Visible = true;
            this.Controls.Add(submitButton);
            submitButton.Click += new EventHandler(SubmitButton_Click);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            textBox.TextChanged += textBox_TextChanged;
            n = Convert.ToInt32(textBox.Text);
            if (n < 9)
            {
                _buttons = new SafeButton[n, n];
                label.Visible = false;
                textBox.Visible = false;
                submitButton.Visible = false;
                Buttons();
            }
            else
            {
                MessageBox.Show("Введите число меньше 9");
                textBox.Clear();
            }
        }

        private void Buttons()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    SafeButton button = new SafeButton()
                    {
                        x = i,
                        y = j,
                        Size = new Size(this.Width / (2 * n), this.Height / (2 * n)),
                        Location = new Point((i * Size.Width) / (2 * n), (j * Size.Height) / (2 * n)),
                        TabStop = false,
                        Text = random.Next(2) == 0 ? "0" : "1",
                    };
                    button.Click += ButtonClick;
                    Controls.Add(button);
                    _buttons[i, j] = button;
                }

            }
        }


        private void ButtonClick(object? sender, EventArgs e)
        {
            SafeButton button = (SafeButton)sender;
            if (button.Text == "0")
            {
                button.Text = "1";
            }
            else
            {
                button.Text = "0";
            }

            for (int i = 0; i < n; i++)
            {
                if (_buttons[button.x, i].Text == "0")
                {
                    _buttons[button.x, i].Text = "1";
                }
                else
                {
                    _buttons[button.x, i].Text = "0";
                }

                if (_buttons[i, button.y].Text == "0")
                {
                    _buttons[i, button.y].Text = "1";
                }
                else
                {
                    _buttons[i, button.y].Text = "0";
                }

            }

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}