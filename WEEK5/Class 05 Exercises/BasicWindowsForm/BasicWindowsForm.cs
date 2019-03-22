using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicWindowsForm
{
    /// <summary>
    /// The form has a few textboxes. When the user types something in the
    /// first box, and hits return, the value of the textbox is placed in the label above.
    /// The second textbox requires a button click, but the same behaviour takes place.
    /// </summary>
    public partial class BasicWindowsForm : Form
    {
        public BasicWindowsForm()
        {
            InitializeComponent();

            // we can set form properties here as well, instead of in the designer
            Text = "Basic Windows Form";

            labelOutput.Text = "Hello World";

            textBoxInput.AcceptsReturn = true;
            textBoxInput.Multiline = true;
            textBoxInput.TextChanged += TextBoxInput_TextChanged;
            buttonAddText.Click += ButtonAddText_Click;
        }

        // textBoxInput properties need accept CR and multiline for this to work

        private void TextBoxInput_TextChanged(object sender, EventArgs e)
        {
            if (textBoxInput.Text.Length > 0 && textBoxInput.Text.Last() == '\n')
            {
                labelOutput.Text = textBoxInput.Text;
                // textBoxInput.Text = "";
                textBoxInput.ResetText(); // this is an alternative to the blank string
            }
        }

        private void ButtonAddText_Click(object sender, EventArgs e)
        {
            if(textBoxButtonInput.Text.Length > 0)
            {
                labelOutput.Text = textBoxButtonInput.Text;
                // textBoxInput.Text = "";
                textBoxButtonInput.ResetText();
            }

        }
    }
}
