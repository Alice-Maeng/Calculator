using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp_calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        enum operation  //enum으로 연산자 저장
        {
            plus,
            minus,
            divide,
            multiple,
            power,
            equal
        }

        operation op;   //연산 변수 선언

        double a; // 첫번째 숫자
        double b; // 두번째 숫자
        double result; // 결과

        bool result_Num = false; //현재 값이 연산 결과인지 판별하는 bool 변수
        char[] operators = { '+', '-', '/', '*', '^', '='}; //연산자들

        bool justcal = false; // 연산직후 여부 판단
 

        #region #숫자 코드
        private void button1_Click(object sender, EventArgs e)
        {
            if (result_Num)
            {
                if (textBox_result.Text != "-" && !textBox_result.Text.StartsWith("-")) //-만 있거나 음수일 경우
                {
                    textBox_result.Text = "";
                    result_Num = false;
                }
            }
            textBox_result.Text += "1";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (result_Num)
            {
                if (textBox_result.Text != "-" && !textBox_result.Text.StartsWith("-"))
                {
                    textBox_result.Text = "";
                    result_Num = false;
                }
            }
            textBox_result.Text += "2";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (result_Num)
            {
                if (textBox_result.Text != "-" && !textBox_result.Text.StartsWith("-"))
                {
                    textBox_result.Text = "";
                    result_Num = false;
                }
            }
            textBox_result.Text += "3";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (result_Num)
            {
                if (textBox_result.Text != "-" && !textBox_result.Text.StartsWith("-"))
                {
                    textBox_result.Text = "";
                    result_Num = false;
                }
            }
            textBox_result.Text += "4";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (result_Num)
            {
                if (textBox_result.Text != "-" && !textBox_result.Text.StartsWith("-"))
                {
                    textBox_result.Text = "";
                    result_Num = false;
                }
            }
            textBox_result.Text += "5";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (result_Num)
            {
                if (textBox_result.Text != "-" && !textBox_result.Text.StartsWith("-"))
                {
                    textBox_result.Text = "";
                    result_Num = false;
                }
            }
            textBox_result.Text += "6";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (result_Num)
            {
                if (textBox_result.Text != "-" && !textBox_result.Text.StartsWith("-"))
                {
                    textBox_result.Text = "";
                    result_Num = false;
                }
            }
            textBox_result.Text += "7";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (result_Num)
            {
                if (textBox_result.Text != "-" && !textBox_result.Text.StartsWith("-"))
                {
                    textBox_result.Text = "";
                    result_Num = false;
                }
            }
            textBox_result.Text += "8";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (result_Num)
            {
                if (textBox_result.Text != "-" && !textBox_result.Text.StartsWith("-"))
                {
                    textBox_result.Text = "";
                    result_Num = false;
                }
            }
            textBox_result.Text += "9";
        }
        private void button0_Click(object sender, EventArgs e)
        {
            if (textBox_result.Text == "0")
            {
                return;
            }
            textBox_result.Text += "0";
        }

        #endregion

        #region #사칙연산 코드

        private void button_plus_Click(object sender, EventArgs e)
        {
            string text = textBox_result.Text;

            if (justcal)
            {
                justcal = false;
            }

            if (string.IsNullOrEmpty(text) || operators.Any(op => text.EndsWith(op.ToString())) || text.EndsWith("."))
            {
                MessageBox.Show("잘못된 입력입니다.");
                result_Num = false;
            }
            else
            {
                if (double.TryParse(text, out a))
                {
                    op = operation.plus;
                    textBox_result.Text += "+";
                    result_Num = false;
                }
                else
                {
                    MessageBox.Show("숫자를 올바르게 입력해주세요.");
                }
            }
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            string text = textBox_result.Text;

            if (operators.Any(op => text.EndsWith(op.ToString())) || text.EndsWith("."))
            {
                MessageBox.Show("잘못된 입력입니다.");
                result_Num = false;
                return;
            }

            if (string.IsNullOrEmpty(text))
            {
                textBox_result.Text = "-";
                result_Num = true;
            }
            else
            {
                if (double.TryParse(text, out a))
                {
                    op = operation.minus;
                    textBox_result.Text += "-";
                    result_Num = false;
                }
                else
                {
                    MessageBox.Show("숫자를 올바르게 입력해주세요.");
                }
            }
        }

        private void button_multiple_Click(object sender, EventArgs e)
        {
            string text = textBox_result.Text;

            if (string.IsNullOrEmpty(text) || operators.Any(op => text.EndsWith(op.ToString())) || text.EndsWith("."))
            {
                MessageBox.Show("잘못된 입력입니다.");
                result_Num = false;
            }
            else
            {
                if (double.TryParse(text, out a))
                {
                    op = operation.multiple;
                    textBox_result.Text += "*";
                    result_Num = false;
                }
                else
                {
                    MessageBox.Show("숫자를 올바르게 입력해주세요.");
                }
            }
        }

        private void button_divide_Click(object sender, EventArgs e)
        {
            string text = textBox_result.Text;

            if (string.IsNullOrEmpty(text) || operators.Any(op => text.EndsWith(op.ToString())) || text.EndsWith("."))
            {
                MessageBox.Show("잘못된 입력입니다.");
                result_Num = false;
            }
            else
            {
                if (double.TryParse(text, out a))
                {
                    op = operation.divide;
                    textBox_result.Text += "/";
                    result_Num = false;
                }
                else
                {
                    MessageBox.Show("숫자를 올바르게 입력해주세요.");
                }
            }
        }

        private void button_eq_Click(object sender, EventArgs e)
        {
            string text = textBox_result.Text;
            result_Num = true;

            if (string.IsNullOrEmpty(text) || operators.Any(op => text.EndsWith(op.ToString())))
            {
                MessageBox.Show("잘못된 입력입니다.");
                return;
            }

            string[] parts = null;

            switch (op)
            {
                case operation.plus:
                    parts = text.Split('+');
                    break;
                case operation.minus:
                    int idx = text.LastIndexOf('-');
                    if (idx > 0)
                        parts = new string[] { text.Substring(0, idx), text.Substring(idx + 1) };
                    break;
                case operation.multiple:
                    parts = text.Split('*');
                    break;
                case operation.divide:
                    parts = text.Split('/');
                    break;
                case operation.power:
                    parts = text.Split('^');
                    break;
            }

            if (parts == null || parts.Length != 2 || !double.TryParse(parts[0], out a) || !double.TryParse(parts[1], out b))
            {
                MessageBox.Show("잘못된 숫자 입력입니다.");
                return;
            }

            switch (op)
            {
                case operation.plus:
                    result = a + b;
                    break;
                case operation.minus:
                    result = a - b;
                    break;
                case operation.multiple:
                    result = a * b;
                    break;
                case operation.divide:
                    if (b == 0)
                    {
                        MessageBox.Show("0으로 나눌 수 없습니다.");
                        return;
                    }
                    result = a / b;
                    break;
                case operation.power:
                    result = Math.Pow(a, b);
                    break;
            }

            textBox_result.Text = result.ToString();
       
            a = result;
            justcal = true;
        }


        #endregion

        // 음수 양수 코드 
        private void button_pm_Click(object sender, EventArgs e)
        {
            string text = textBox_result.Text;
            if (textBox_result.Text == string.Empty || operators.Any(op => text.LastIndexOf(op) > 0) || textBox_result.Text.EndsWith("."))
            {
                MessageBox.Show("잘못된 입력입니다.");
                result_Num = false;
            }
            else
            {
                textBox_result.Text = (-double.Parse(textBox_result.Text)).ToString();  //음수/양수 변환
            }
        }

        // 소수점 표기 
        private void button_dot_Click(object sender, EventArgs e)
        {
            string text = textBox_result.Text;
            if (operators.Any(op => textBox_result.Text.EndsWith(op.ToString()))) //문자열의 끝이 연산기호일 경우
            {
                MessageBox.Show("잘못된 입력입니다.");
                result_Num = false;
                return;
            }
            string[] parts = text.Split(operators);
            if (parts.Length > 0 && parts[parts.Length - 1].Contains("."))  //소수점이 바로 앞에 존재할 경우
            {
                MessageBox.Show("잘못된 입력입니다.");
                result_Num = false;
                return;
            }
            textBox_result.Text += ".";
        }

        // 초기화 버튼 
        private void button_CE_Click(object sender, EventArgs e)
        {
            textBox_result.Text = string.Empty; //입력값 초기화
        }

        private void button_C_Click(object sender, EventArgs e)
        {
            textBox_result.Text = string.Empty; //입력값 초기화
        }

        private void button_delete_Click(object sender, EventArgs e) //입력값 하나씩 삭제
        {
            
           if (textBox_result.Text.Length > 0)
           {
               textBox_result.Text = textBox_result.Text.Remove(textBox_result.Text.Length - 1);   // 마지막 문자 삭제
           }
           else
           {
               textBox_result.Text = string.Empty; // 빈 문자열 유지
           }
            
        }

        #region 고급기능 구현 
        private void button_square_Click(object sender, EventArgs e)    //제곱 연산
        {
            string text = textBox_result.Text;
            int eNum = textBox_result.Text.LastIndexOfAny(new char[] { 'E', 'e' });
            if (eNum > 0 && eNum + 1 < textBox_result.Text.Length)
            {
                char nextChar = textBox_result.Text[eNum + 1];
                if (nextChar == '+')
                {
                    MessageBox.Show("숫자가 너무 큽니다. 새로운 값을 입력 후 연산을 다시 시도해주세요.");
                    return;
                }
                else if (nextChar == '-')
                {
                    MessageBox.Show("숫자가 너무 작습니다.새로운 값을 입력 후 연산을 다시 시도해주세요.");
                    return;
                }
            }
            if (textBox_result.Text == string.Empty || operators.Any(op => text.LastIndexOf(op) > 0) || textBox_result.Text.EndsWith("."))
            {
                MessageBox.Show("잘못된 입력입니다.");
                result_Num = false;
            }
            else
            {
                textBox_result.Text = Math.Pow(double.Parse(textBox_result.Text), 2).ToString();
                result_Num = true;
            }
        }

        private void button_power_Click(object sender, EventArgs e) //거듭제곱 연산
        {
            string text = textBox_result.Text;
            int eNum = textBox_result.Text.LastIndexOfAny(new char[] { 'E', 'e' });
            if (eNum > 0 && eNum + 1 < textBox_result.Text.Length)
            {
                char nextChar = textBox_result.Text[eNum + 1];
                if (nextChar == '+')
                {
                    MessageBox.Show("숫자가 너무 큽니다. 새로운 값을 입력 후 연산을 다시 시도해주세요.");
                    return;
                }
                else if (nextChar == '-')
                {
                    MessageBox.Show("숫자가 너무 작습니다.새로운 값을 입력 후 연산을 다시 시도해주세요.");
                    return;
                }
            }
            if (textBox_result.Text == string.Empty || operators.Any(op => text.LastIndexOf(op) > 0) || textBox_result.Text.EndsWith("."))
            {
                MessageBox.Show("잘못된 입력입니다.");
                result_Num = false;
            }
            else
            {
                a = double.Parse(textBox_result.Text);
                op = operation.power;
                textBox_result.Text += "^";
                result_Num = false;
            }
        }
        private void button_sqrt_Click(object sender, EventArgs e)  //루트 연산
        {
            string text = textBox_result.Text;
            int eNum = textBox_result.Text.LastIndexOfAny(new char[] { 'E', 'e' });
            if (eNum > 0 && eNum + 1 < textBox_result.Text.Length)
            {
                char nextChar = textBox_result.Text[eNum + 1];
                if (nextChar == '+')
                {
                    MessageBox.Show("숫자가 너무 큽니다. 새로운 값을 입력 후 연산을 다시 시도해주세요.");
                    return;
                }
                else if (nextChar == '-')
                {
                    MessageBox.Show("숫자가 너무 작습니다.새로운 값을 입력 후 연산을 다시 시도해주세요.");
                    return;
                }
            }
            if (textBox_result.Text == string.Empty || operators.Any(op => text.LastIndexOf(op) > 0) || textBox_result.Text.EndsWith("."))
            {
                MessageBox.Show("잘못된 입력입니다.");
                result_Num = false;
            }
            else if (double.Parse(textBox_result.Text) < 0)
            {
                MessageBox.Show("음수의 제곱근은 계산할 수 없습니다. 다시 입력해주세요.");
                return;
            }
            else
            {
                textBox_result.Text = Math.Sqrt(double.Parse(textBox_result.Text)).ToString();
                result_Num = true;
            }
        }
        private void button_percent_Click(object sender, EventArgs e)   //퍼센트 변환
        {
            string text = textBox_result.Text;
            int eNum = textBox_result.Text.LastIndexOfAny(new char[] { 'E', 'e' });
            if (eNum > 0 && eNum + 1 < textBox_result.Text.Length)
            {
                char nextChar = textBox_result.Text[eNum + 1];
                if (nextChar == '+')
                {
                    MessageBox.Show("숫자가 너무 큽니다. 새로운 값을 입력 후 연산을 다시 시도해주세요.");
                    return;
                }
                else if (nextChar == '-')
                {
                    MessageBox.Show("숫자가 너무 작습니다.새로운 값을 입력 후 연산을 다시 시도해주세요.");
                    return;
                }
            }
            if (textBox_result.Text == string.Empty || operators.Any(op => text.LastIndexOf(op) > 0) || textBox_result.Text.EndsWith("."))
            {
                MessageBox.Show("잘못된 입력입니다.");
                result_Num = false;
            }
            else
            {
                textBox_result.Text = (double.Parse(textBox_result.Text) * 1/100).ToString();
                result_Num = true;
            }
        }
        #endregion


        #region 기타 기능 
        //Background color 변경 
        private void rEDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }

        private void bLUEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Blue;
        }

        private void gRAYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
        }

        private void pINKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Pink;
        }
        #endregion

    }
}
