using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineTriangle
{
    public partial class Treangle : Form
    {
        public Treangle()
        {
            InitializeComponent();
        }
        private void buttonCount_Click(object sender, EventArgs e)
        {
            //data input
            float[] aLine = new float[] { float.Parse(textBoxA1.Text),
                                        float.Parse(textBoxB1.Text),
                                        float.Parse(textBoxC1.Text) };
            float[] bLine = new float[] { float.Parse(textBoxA2.Text),
                                        float.Parse(textBoxB2.Text),
                                        float.Parse(textBoxC2.Text) };
            float[] cLine = new float[] { float.Parse(textBoxA3.Text),
                                        float.Parse(textBoxB3.Text),
                                        float.Parse(textBoxC3.Text) };
            TreangleDat data;
            try
            {
                //catch Exception with non intersect lines
                data = TreangleOperations.TriangleDataCount(aLine, bLine, cLine);
            }
            catch (Exception)
            {
                MessageBox.Show("Прямые паралельны! Невозможно образовать треугольник.","Ошибка!");
                textBoxPer.Text = null;
                textBoxArea.Text = null;
                textBoxA.Text = null;//
                textBoxB.Text = null;
                textBoxC.Text = null;//
                return;
            }
            //data output
            textBoxPer.Text = data.Perimetr.ToString("0.00");
            textBoxArea.Text = data.Area.ToString("0.00");
            textBoxA.Text = TreangleOperations.A.X.ToString("0.00")+"; "+TreangleOperations.A.Y.ToString("0.00");
            textBoxB.Text = TreangleOperations.B.X.ToString("0.00") + "; " + TreangleOperations.B.Y.ToString("0.00");
            textBoxC.Text = TreangleOperations.C.X.ToString("0.00") + "; " + TreangleOperations.C.Y.ToString("0.00");
        }
        /// <summary>
        /// Close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Field validation
        /// </summary>
        /// <param name="currentTB">current text box</param>
        private void FieldValidation(TextBox currentTB)
        {
            float buff;
            if (float.TryParse(currentTB.Text, out buff))
            {
                //set error
                buttonCount.Enabled = true;
                currentTB.BackColor = Color.White;
            }
            else
            {
                //reset error
                buttonCount.Enabled = false;
                currentTB.BackColor = Color.Red;
            }

        }
        /// <summary>
        /// TextBox Lost focus handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxA1_Leave(object sender, EventArgs e)
        {
            FieldValidation(sender as TextBox);
        }

        private void Treangle_Load(object sender, EventArgs e)
        {

        }
    }
}
