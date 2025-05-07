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
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
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
                richTextBox1.Text = "";
                result_Num = false;
            }
            richTextBox1.Font = new Font("Arial", 14);
            richTextBox1.Text += num;
       
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
            if (richTextBox1.Text != "0")
                AppendNumber("0");
        }

        // 사칙연산 공통 처리 함수
        private void HandleOperation(operation selectedOp, char symbol)
        {
            string text = richTextBox1.Text;

            //빈칸 / 3+ / 3. 처럼 연산자로 끝나거나 소수점으로 끝났을때 error 팝업 

            if (string.IsNullOrEmpty(text) || operators.Any(op => text.EndsWith(op.ToString())) || text.EndsWith("."))
            {
                ShowError("연산자를 입력할 수 없는 위치입니다.");
                return;
            }

            if (double.TryParse(text, out a)) // 3+과 같은 숫자+연산자 표시를 위해 필요
            {
                op = selectedOp; //연산자 선택
                richTextBox1.Text += symbol; // 연산자 추가
                result_Num = false;
            }
            else
            {
                ShowError("숫자를 올바르게 입력해주세요.");
            }
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            HandleOperation(operation.plus, '+');
        }
        private void button_minus_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
                
            if (string.IsNullOrEmpty(text))
            {
                richTextBox1.Text = "-";
                result_Num = false;
                return;
            }

            HandleOperation(operation.minus, '-');
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
            string text = richTextBox1.Text;
            result_Num = true;

            if (string.IsNullOrEmpty(text) || operators.Any(op => text.EndsWith(op.ToString())))
            {
                ShowError("연산할 수 없습니다.");
                return;
            }

            string[] parts = null;
            char operatorSymbol = ' ';  // 연산자 기호를 저장할 변수

            switch (op)
            {
                case operation.plus:
                    parts = text.Split('+');
                    operatorSymbol = '+';  // 연산자 기호 설정
                    break;
                case operation.minus:
                    int idx = text.LastIndexOf('-');
                    if (idx > 0)
                        parts = new[] { text.Substring(0, idx), text.Substring(idx + 1) };
                    operatorSymbol = '-';  // 연산자 기호 설정
                    break;
                case operation.multiple:
                    parts = text.Split('*');
                    operatorSymbol = '*';  // 연산자 기호 설정
                    break;
                case operation.divide:
                    parts = text.Split('/');
                    operatorSymbol = '/';  // 연산자 기호 설정
                    break;
            }

            if (parts == null || parts.Length != 2 || !double.TryParse(parts[0], out a) || !double.TryParse(parts[1], out b))
            {
                ShowError("올바른 계산식이 아닙니다.");
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

            // RichTextBox 사용 --- 각각의 폰트에 텍스트 스타일 설정하는 tool 
            richTextBox1.Clear();  // 이전 내용 지우기
            
            richTextBox1.SelectionFont = new Font("Arial", 14); 
            richTextBox1.AppendText($"{a}");  // 첫 번째 숫자

            richTextBox1.SelectionFont = new Font("Arial", 14); 
            richTextBox1.AppendText($"{operatorSymbol}");  

            richTextBox1.SelectionFont = new Font("Arial", 14); 
            richTextBox1.AppendText($"{b}=");  // 두 번째 숫자

            richTextBox1.SelectionFont = new Font("Arial", 18, FontStyle.Bold); // 결과 크기
            richTextBox1.AppendText($"\r\n\r\n{result}");  // 결과

            a = result;
        }

        // ± 부호 전환
        private void button_pm_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            if (string.IsNullOrEmpty(text) || operators.Any(op => text.LastIndexOf(op) > 0) || text.EndsWith("."))
            {
                ShowError("부호를 바꿀 수 없습니다.");
                return;
            }

            if (double.TryParse(text, out double value))
            {
                richTextBox1.Text = (-value).ToString();
            }
        }

       

        // 초기화
        private void button_C_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
        }

        // 삭제
        private void button_delete_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 1);
     
        }


        #region 소수점, 퍼센트

        // 소수점
        private void button_dot_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            if (operators.Any(op => text.EndsWith(op.ToString())))
            {
                ShowError("소수점 위치가 잘못되었습니다.");
                return;
            }

            // 텍스트를 연산자 기준으로 나눔
            string[] parts = text.Split(operators);

            // 마지막 부분이 소수점이 있는지 확인
            if (parts.Length > 0 && parts[parts.Length - 1].Contains("."))
            {
                ShowError("이미 소수점이 존재합니다.");
                return;
            }


            richTextBox1.Text += ".";
        }
        // 퍼센트
        private void button_percent_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            if (string.IsNullOrEmpty(text) || operators.Any(op => text.LastIndexOf(op) > 0) || text.EndsWith("."))
            {
                ShowError("퍼센트를 적용할 수 없습니다.");
                return;
            }

            if (double.TryParse(text, out double value))
            {
                richTextBox1.Text = (value / 100).ToString();
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
