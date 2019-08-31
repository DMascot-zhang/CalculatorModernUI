using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using ControllerDLL;

namespace Calculator
{
    public partial class BaseForm : MetroFramework.Forms.MetroForm
    {
        Controller ctrl = new Controller();

        public BaseForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            if (!ctrl.changeText(textBox1.Text))
            {
                MessageBox.Show("Превышено ограничение символов");
            }
            
        }

        public void Written(string text)
        {
            textBox1.Text = text;
        }

        /**
         * Сектор кнопок
         **/

        private void bt1_Click(object sender, System.EventArgs e)
        {
            Written(ctrl.clicOnNum(this.bt1.Text, textBox1.Text));
        }

        private void bt2_Click(object sender, System.EventArgs e)
        {
            Written(ctrl.clicOnNum(this.bt2.Text, textBox1.Text));
        }

        private void bt3_Click(object sender, System.EventArgs e)
        {
            Written(ctrl.clicOnNum(this.bt3.Text, textBox1.Text));
        }

        private void bt4_Click(object sender, System.EventArgs e)
        {
            Written(ctrl.clicOnNum(this.bt4.Text, textBox1.Text));
        }

        private void bt5_Click(object sender, System.EventArgs e)
        {
            Written(ctrl.clicOnNum(this.bt5.Text, textBox1.Text));
        }

        private void bt6_Click(object sender, System.EventArgs e)
        {
            Written(ctrl.clicOnNum(this.bt6.Text, textBox1.Text));
        }

        private void bt7_Click(object sender, System.EventArgs e)
        {
            Written(ctrl.clicOnNum(this.bt7.Text, textBox1.Text));
        }

        private void bt8_Click(object sender, System.EventArgs e)
        {
            Written(ctrl.clicOnNum(this.bt8.Text, textBox1.Text));
        }

        private void bt9_Click(object sender, System.EventArgs e)
        {
            Written(ctrl.clicOnNum(this.bt9.Text, textBox1.Text));
        }

        private void null_bt_Click(object sender, System.EventArgs e)
        {
            Written(ctrl.clickOnNull(this.bt0.Text, textBox1.Text));
        }

        private void dot_bt_Click(object sender, EventArgs e)
        {
            Written(ctrl.clickOnDot(this.dot_bt.Text, textBox1.Text));
        }

        private void leftScobka_bt_Click(object sender, EventArgs e)
        {
            Written(ctrl.clickOnLeftScobka(this.leftScobka_bt.Text, textBox1.Text));
        }

        private void rightScobka_bt_Click(object sender, EventArgs e)
        {
            Written(ctrl.clickOnRightScobka(this.rightScobka_bt.Text, textBox1.Text));
        }

        /**
        *  Очищение знаков
        **/

        private void delone_bt_Click(object sender, EventArgs e)
        {
            Written(ctrl.cleanOneChar(textBox1.Text)); 
        }

        private void ce_bt_Click(object sender, EventArgs e)
        {
            Written(ctrl.restartCalc(textBox1.Text)); 
        }

        /**
         *  Сектор знаков 
         **/

        private void plus_bt_Click(object sender, EventArgs e)
        {
            Written(ctrl.clicOnChar(this.plus_bt.Text, textBox1.Text));
        }

        private void minus_bt_Click(object sender, EventArgs e)
        {
            Written(ctrl.clicOnChar(this.minus_bt.Text, textBox1.Text));
        }

        private void multi_bt_Click(object sender, EventArgs e)
        {
            Written(ctrl.clicOnChar(this.multi_bt.Text, textBox1.Text));
        }

        private void delene_bt_Click(object sender, EventArgs e)
        {
            Written(ctrl.clicOnChar(this.delene_bt.Text, textBox1.Text));
        }

        private void pm_bt_Click(object sender, EventArgs e)
        {

        }

        private void root_bt_Click(object sender, EventArgs e)
        {

        }

        /**
        *  Сектор ответа 
        **/

        private void answer_bt_Click(object sender, EventArgs e)
        {
            Written(ctrl.answerCalc(textBox1.Text));
          
        }





    }
}
