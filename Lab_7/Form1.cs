using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TextBox textBox1;
        private void Form1_Load(object sender, EventArgs e) // Создание кнопок
        {
            textBox1 = new TextBox();
            textBox1.Location = new Point(50, 50);
            textBox1.Size = new Size(300, 50);
            textBox1.TabIndex = 50;
            textBox1.Text = "";
            textBox1.Tag = 50;
            Controls.Add(textBox1);

            int SizeOfButtonsX = textBox1.Width / 6;
            int SpaceBetweenButtonsX = textBox1.Width / 9;
            int SizeOfButtonsY = SizeOfButtonsX / 2;
            int SpaceBetweenButtonsY = SizeOfButtonsX / 4;
            Button[] buttons = new Button[19];
            int i = 0;

            buttons[i] = new Button();
            buttons[i].Location = new Point(textBox1.Location.X + (0) * (SizeOfButtonsX + SpaceBetweenButtonsX), textBox1.Location.Y + textBox1.Height + SpaceBetweenButtonsY + (4) * (SizeOfButtonsY + SpaceBetweenButtonsY));
            buttons[i].Size = new Size(SizeOfButtonsX * 2 + SpaceBetweenButtonsX, SizeOfButtonsY);
            buttons[i].TabIndex = i;
            buttons[i].Text = Convert.ToString(i);
            buttons[i].UseVisualStyleBackColor = true;
            buttons[i].Tag = i;
            Controls.Add(buttons[i]);

            for (i = 1; i < 10; ++i)
            {
                buttons[i] = new Button();
                buttons[i].Location = new Point(textBox1.Location.X + ((i - 1) % 3) * (SizeOfButtonsX + SpaceBetweenButtonsX), textBox1.Location.Y + textBox1.Height + SpaceBetweenButtonsY + (3 - (i - 1) / 3) * (SizeOfButtonsY + SpaceBetweenButtonsY));
                buttons[i].Size = new Size(SizeOfButtonsX, SizeOfButtonsY);
                buttons[i].TabIndex = i;
                buttons[i].Text = Convert.ToString(i);
                buttons[i].UseVisualStyleBackColor = true;
                buttons[i].Tag = i;
                Controls.Add(buttons[i]);
            }

            for (i = 10; i < 14; ++i)
            {
                buttons[i] = new Button();
                buttons[i].Location = new Point(textBox1.Location.X + (3) * (SizeOfButtonsX + SpaceBetweenButtonsX), textBox1.Location.Y + textBox1.Height + SpaceBetweenButtonsY + (i - 9) * (SizeOfButtonsY + SpaceBetweenButtonsY));
                buttons[i].Size = new Size(SizeOfButtonsX, SizeOfButtonsY);
                buttons[i].TabIndex = i;
                buttons[i].UseVisualStyleBackColor = true;
                buttons[i].Tag = i;
                Controls.Add(buttons[i]);
            }

            i = 14;
            buttons[i] = new Button();
            buttons[i].Location = new Point(textBox1.Location.X + (2) * (SizeOfButtonsX + SpaceBetweenButtonsX), textBox1.Location.Y + textBox1.Height + SpaceBetweenButtonsY + (4) * (SizeOfButtonsY + SpaceBetweenButtonsY));
            buttons[i].Size = new Size(SizeOfButtonsX, SizeOfButtonsY);
            buttons[i].TabIndex = i;
            buttons[i].UseVisualStyleBackColor = true;
            buttons[i].Tag = i;
            Controls.Add(buttons[i]);

            for (i = 15; i < 19; ++i)
            {
                buttons[i] = new Button();
                buttons[i].Location = new Point(textBox1.Location.X + (i - 15) * (SizeOfButtonsX + SpaceBetweenButtonsX), textBox1.Location.Y + textBox1.Height + SpaceBetweenButtonsY + (5) * (SizeOfButtonsY + SpaceBetweenButtonsY));
                buttons[i].Size = new Size(SizeOfButtonsX, SizeOfButtonsY);
                buttons[i].TabIndex = i;
                buttons[i].UseVisualStyleBackColor = true;
                buttons[i].Tag = i;
                Controls.Add(buttons[i]);
            }

            buttons[10].Text = "+";
            buttons[11].Text = "-";
            buttons[12].Text = "=";
            buttons[13].Text = "C";
            buttons[14].Text = ",";
            buttons[15].Text = "*";
            buttons[16].Text = "/";
            buttons[17].Text = "(";
            buttons[18].Text = ")";

            for (i = 0; i < 12; ++i)
            {
                buttons[i].Click += new System.EventHandler(this.Button_Click);
            }
            buttons[14].Click += new System.EventHandler(this.Button_Click);
            buttons[12].Click += new System.EventHandler(this.Count_Click);
            buttons[13].Click += new System.EventHandler(this.Erase_Click);
            for (i = 15; i < 19; ++i)
            {
                buttons[i].Click += new System.EventHandler(this.Button_Click);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        private double Count(string s, int start)
        {
            int n = 1;
            for (int i = start; i < textBox1.Text.Length; ++i) // Считаем количество чисел
            {
                if (((s[i] > '9') || (s[i] < '0')) && (s[i] != ','))
                {
                    ++n;
                }
            }
            double[] numbers = new double[n];
            char[] signs = new char[n - 1];
            int j = 0;
            int skobki = 0;
            for (int i = start; (i < textBox1.Text.Length) && (s[i] != ')'); ++i) // Заполняем массив чисел числами, а массив знаков - знаками
            {
                while ((s[i] <= '9') && (s[i] >= '0') && (i < textBox1.Text.Length))
                {
                    numbers[j] = numbers[j] * 10 + s[i] - 48;
                    ++i;
                    if (i == textBox1.Text.Length)
                    {
                        break;
                    }
                }
                if (i == textBox1.Text.Length)
                {
                    break;
                }
                if (s[i] == ',')
                {
                    ++i;
                    int k = 10;
                    while ((s[i] <= '9') && (s[i] >= '0') && (i < textBox1.Text.Length))
                    {
                        numbers[j] = numbers[j] + Convert.ToDouble(s[i] - 48) / k;
                        k *= 10;
                        ++i;
                        if (i == textBox1.Text.Length)
                        {
                            break;
                        }
                    }
                }
                if (s[i] == '(')
                {
                    numbers[j] = Count(s, i + 1);
                    skobki = 1;
                    while (skobki > 0)
                    {
                        ++i;
                        if (s[i] == '(')
                        {
                            ++skobki;
                        }
                        if (s[i] == ')')
                        {
                            --skobki;
                        }
                    }
                    ++i;
                }
                if (i < textBox1.Text.Length) signs[j] = s[i];
                ++j;
            }
            j = 0;
            for (int i = 0; i < n - 1; ++i) // Выполняем все операции умножения и деления. При умножении двух чисел результат записывается в левое, а затем все числа после  правого сдвигаются влево
            {
                while ((signs[i] != '*') && (signs[i] != '/') && (i < n - 1))
                {
                    ++i;
                    ++j;
                    if (i == n - 1)
                    {
                        break;
                    }
                }
                if (i == n - 1)
                {
                    break;
                }
                if (signs[i] == '*')
                {
                    numbers[j] *= numbers[j + 1];
                    for (int i1 = i + 1; i1 < n - 1; ++i1)
                    {
                        numbers[i1] = numbers[i1 + 1];
                    }
                }
                if (signs[i] == '/')
                {
                    numbers[j] /= numbers[j + 1];
                    for (int i1 = j + 1; i1 < n - 1; ++i1)
                    {
                        numbers[i1] = numbers[i1 + 1];
                    }
                }
            }
            j = 1;
            double rezult = numbers[0];
            for (int i = 0; i < n - 1; ++i) // Производим по очереди все операции сложения и вычитания среди результатов умножения и деления
            {
                while ((signs[i] != '+') && (signs[i] != '-') && (i < n - 1))
                {
                    ++i;
                    if (i == n - 1)
                    {
                        break;
                    }
                }
                if (i == n - 1)
                {
                    break;
                }
                if (signs[i] == '+')
                {
                    rezult += numbers[j];
                    ++j;
                }
                if (signs[i] == '-')
                {
                    rezult -= numbers[j];
                    ++j;
                }
            }
            return rezult;
        }

        private void Count_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            textBox1.Text = Convert.ToString(Count(s, 0));
        }

        private void Erase_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        /**/
        /**/
    }
}

