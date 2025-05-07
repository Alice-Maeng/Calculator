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
        enum operation
        {
            plus,
            minus,
            divide,
            multiple,
            equal
        }

        operation op;

        double a; // 첫 번째 숫자
        double b; // 두 번째 숫자
        double result; // 결과값

        bool result_Num = false; // 현재 값이 연산 결과인지 판단
        char[] operators = { '+', '-', '/', '*', '^', '=' };

        // 공통 오류 메시지 표시 함수
        private void ShowError(string message = "잘못된 입력입니다.")
        {
            MessageBox.Show(message);
            result_Num = false;
        }


        // 숫자 버튼 공통 처리 함수
        private void AppendNumber(string num)
        {
            if (result_Num)
            {
                textBox_result.Text = "";
                result_Num = false;
            }
            textBox_result.Text += num;
       
        }

        // 숫자 버튼 이벤트
        private void button1_Click(object sender, EventArgs e) => AppendNumber("1");
        private void button2_Click(object sender, EventArgs e) => AppendNumber("2");
        private void button3_Click(object sender, EventArgs e) => AppendNumber("3");
        private void button4_Click(object sender, EventArgs e) => AppendNumber("4");
        private void button5_Click(object sender, EventArgs e) => AppendNumber("5");
        private void button6_Click(object sender, EventArgs e) => AppendNumber("6");
        private void button7_Click(object sender, EventArgs e) => AppendNumber("7");
        private void button8_Click(object sender, EventArgs e) => AppendNumber("8");
        private void button9_Click(object sender, EventArgs e) => AppendNumber("9");
        private void button0_Click(object sender, EventArgs e)
        {
            if (textBox_result.Text != "0")
                AppendNumber("0");
        }

        // 사칙연산 공통 처리 함수
        private void HandleOperation(operation selectedOp, char symbol)
        {
            string text = textBox_result.Text;

            //빈칸 / 3+ / 3. 처럼 연산자로 끝나거나 소수점으로 끝났을때 error 팝업 
            if (string.IsNullOrEmpty(text) || operators.Any(op => text.EndsWith(op.ToString())) || text.EndsWith("."))
            {
                MessageBox.Show("Error");
                result_Num = false;
                return;
            }

            if (double.TryParse(text, out a)) // 3+과 같은 숫자+연산자 표시를 위해 필요
            {
                op = selectedOp; //연산자 선택
                textBox_result.Text += symbol; // 연산자 추가
                result_Num = false;
            }
            else
            {
                MessageBox.Show("숫자를 올바르게 입력해주세요.");
            }
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            HandleOperation(operation.plus, '+');
        }
        private void button_minus_Click(object sender, EventArgs e)
        {
            string text = textBox_result.Text;

            if (operators.Any(op => text.EndsWith(op.ToString())) || text.EndsWith("."))
            {
                MessageBox.Show("Error");
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
            HandleOperation(operation.multiple, '*');
        }
        private void button_divide_Click(object sender, EventArgs e)
        {
            HandleOperation(operation.divide, '/');
        }

        // = 버튼
        private void button_eq_Click(object sender, EventArgs e)
        {
            string text = textBox_result.Text;
            result_Num = true;

            if (string.IsNullOrEmpty(text) || operators.Any(op => text.EndsWith(op.ToString())))
            {
                MessageBox.Show("Error");
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
                        parts = new[] { text.Substring(0, idx), text.Substring(idx + 1) };
                    break;
                case operation.multiple: 
                    parts = text.Split('*'); 
                    break;
                case operation.divide: 
                    parts = text.Split('/'); 
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
            }

            textBox_result.Text = result.ToString();
            a = result;
        }

        // ± 부호 전환
        private void button_pm_Click(object sender, EventArgs e)
        {
            string text = textBox_result.Text;
            if (string.IsNullOrEmpty(text) || operators.Any(op => text.LastIndexOf(op) > 0) || text.EndsWith("."))
            {
                MessageBox.Show("Error");
                result_Num = false;
                return;
            }

            if (double.TryParse(text, out double value))
            {
                textBox_result.Text = (-value).ToString();
            }
        }

       

        // 초기화
        private void button_C_Click(object sender, EventArgs e)
        {
            textBox_result.Text = string.Empty;
        }

        // 삭제
        private void button_delete_Click(object sender, EventArgs e)
        {
            if (textBox_result.Text.Length > 0)
                textBox_result.Text = textBox_result.Text.Remove(textBox_result.Text.Length - 1);
     
        }


        #region 소수점, 퍼센트

        // 소수점
        private void button_dot_Click(object sender, EventArgs e)
        {
            string text = textBox_result.Text;
            if (operators.Any(op => text.EndsWith(op.ToString())))
            {
                MessageBox.Show("Error");
                result_Num = false;
                return;
            }

            string[] parts = text.Split(operators);
            if (parts.Length > 0 && parts[parts.Length - 1].Contains("."))
            {
                MessageBox.Show("Error");
                result_Num = false;
                return;
            }

            textBox_result.Text += ".";
        }
        // 퍼센트
        private void button_percent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_result.Text) || operators.Any(op => textBox_result.Text.LastIndexOf(op) > 0) || textBox_result.Text.EndsWith("."))
            {
                MessageBox.Show("잘못된 입력입니다.");
                result_Num = false;
                return;
            }

            double value = double.Parse(textBox_result.Text);
            textBox_result.Text = (value / 100).ToString();
            result_Num = true;
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
