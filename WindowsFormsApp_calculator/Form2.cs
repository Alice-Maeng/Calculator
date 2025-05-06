using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_calculator
{
    public partial class Form2 : Form
    {
        public Form2(string[] history)  //연산 기록을 넘겨받아 팝업 창 생성
        {
            InitializeComponent();
            
            listBox_cal_Log.Items.Clear();  //기록 초기화
            foreach (string entry in history)
            {
                listBox_cal_Log.Items.Add(entry); //기록 추가
                listBox_cal_Log.Items.Add("=====================");
            }
        }

    }
}
