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
        string[] cal_Log = new string[5] { " ", " ", " ", " ", " " };   //최근 5번의 결과값
        public static double mNum = 0; //메모리 숫자
        private void SaveResult(double a, double b, string op, double result)   //결과값을 저장하기 위한 함수
        {
            for (int i = cal_Log.Length - 1; i > 0; i--)    //0부터 한칸씩 밀어내며 연산값 저장
            {
                cal_Log[i] = cal_Log[i - 1]; 
            }
            if (Enum.TryParse(op, out operation operationType)) //op 문자열을 enum 값으로 변환
            {
                int index = (int)operationType;
                cal_Log[0] = $"{a} {operators[index]} {b} = {result}"; //연산 기록 저장
            }
        }
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

        private void button_plus_Click(object sender, EventArgs e)
        {
            string text = textBox_result.Text;
            int eNum = textBox_result.Text.LastIndexOfAny(new char[] { 'E', 'e' }); //E나 e를 활용한 매우 큰 수와 매우 작은 수를 구별하기 위한 변수
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
            if (textBox_result.Text == string.Empty || operators.Any(op => text.LastIndexOf(op) > 0)    //빈칸에 연산자 입력, 연산자 연속 입력,
                || textBox_result.Text.EndsWith("."))                                                   //소수점 뒤에 연산자 입력시 오류 메세지 출력
            {
                MessageBox.Show("잘못된 입력입니다.");
                result_Num = false;
            }
            else
            {
                a = double.Parse(textBox_result.Text);
                op = operation.plus;
                textBox_result.Text += "+";
                result_Num = false;
            }
        }

        private void button_minus_Click(object sender, EventArgs e)
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
            if (operators.Any(op => text.LastIndexOf(op) > 0) || textBox_result.Text.EndsWith("."))
            {
                MessageBox.Show("잘못된 입력입니다.");
                result_Num = false;
                return;
            }
            if (textBox_result.Text == string.Empty)    //처음에 입력시 음수 처리
            {
                textBox_result.Text = "-";
                result_Num = true;
            }
            else
            {
                a = double.Parse(textBox_result.Text);
                op = operation.minus;
                textBox_result.Text += "-";
                result_Num = false;
            }
        }

        private void button_multiple_Click(object sender, EventArgs e)
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
            }else 
            {
                a = double.Parse(textBox_result.Text);
                op = operation.multiple;
                textBox_result.Text += "*";
                result_Num = false;
            }
        }

        private void button_divide_Click(object sender, EventArgs e)
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
                op = operation.divide;
                textBox_result.Text += "/";
                result_Num = false;
            }
        }
        private void button_eq_Click(object sender, EventArgs e)
        {
            string[] strings = null;
            string text = textBox_result.Text;
            result_Num = true;
            if (string.IsNullOrEmpty(text) || operators.Any(op => text.EndsWith(op.ToString())))    //빈칸에 = 입력, 연산자 이후 숫자 미입력시 오류메세지 출력
            {
                MessageBox.Show("잘못된 입력입니다.");
                return;
            }
            switch (op) //각 연산자에 따라 문자열 나누기
            {
                case operation.plus:
                    strings = textBox_result.Text.Split('+');
                    break;
                case operation.minus:
                    int index = text.LastIndexOf('-');
                    if (index > 0)  
                    {
                        strings = new string[] { text.Substring(0, index), text.Substring(index + 1) };
                    }

                    break;
                case operation.multiple:
                    strings = textBox_result.Text.Split('*');
                    break;
                case operation.divide:
                    strings = textBox_result.Text.Split('/');
                    break;
                case operation.power:
                    strings = textBox_result.Text.Split('^');
                    break;
            }

            a = double.Parse(strings[0]);
            b = double.Parse(strings[1]);

            textBox_result.Text += " = ";
            switch (op) //각 연산자에 따라 연산을 진행
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
                        MessageBox.Show("0으로 나눌 수 없습니다. 다시 입력하세요.");
                        return;
                    }
                    else
                    {
                        result = a / b;
                    }
                    break;
                case operation.power:
                    result = Math.Pow(a, b);
                    break;
            }
            textBox_result.Text = result.ToString();    //연산 결과값 출력
            SaveResult(a, b, op.ToString(), result);    //연산 기록 저장
        }
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
        private void button_CE_Click(object sender, EventArgs e)
        {
            textBox_result.Text = string.Empty; //입력값 초기화
        }
        private void button_C_Click(object sender, EventArgs e) //입력값 하나씩 삭제
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
        private void button_cal_log_Click(object sender, EventArgs e)   //계산 기록 보기
        {
            //Form2 popupForm = new Form2(cal_Log); //계산 기록을 넘겨줌
            //popupForm.ShowDialog(); //팝업 창 띄우기
        }
        private void button_m_Click(object sender, EventArgs e) //저장된 값 출력
        {
            MessageBox.Show("저장된 값: " + mNum.ToString());
        }

        private void button_m_save_Click(object sender, EventArgs e)    //값 저장
        {
            mNum = result;
        }

        private void button_m_clear_Click(object sender, EventArgs e)   //저장된 값 초기화
        {
            mNum = 0;
        }

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
    }
}

