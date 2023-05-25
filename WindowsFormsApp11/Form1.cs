using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        FontFamily[] fontFamilies;
        public Form1()
        {
            InitializeComponent();
        }

        private void NewClick(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.SelectionFont = new Font(fontFamilies[fontName.SelectedIndex], Convert.ToSingle(fontSize.SelectedItem));
        }

        private void OpenClick(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Текстовые документы|*.rtf|Все файлы|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(openFileDialog1.FileName);
        }

        private void SaveAsClick(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Текстовые документы|*.rtf|Все файлы|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(saveFileDialog1.FileName);
        }

        private void FontClick(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionFont = fontDialog1.Font;
        }

        private void ColorClick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionColor = colorDialog1.Color;
        }

        private void CopyClick(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void PasteClick(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fontSize.SelectedIndex = 3;

            leftAllign.CheckState = CheckState.Checked;

            InstalledFontCollection installedFontCollection = new InstalledFontCollection();

            fontFamilies = installedFontCollection.Families;
            foreach (FontFamily font in fontFamilies)
                fontName.Items.Add(font.Name);
            fontName.Items.Add(" ");
            fontName.SelectedIndex = 9;
        }

        private void SizeChanged(object sender, EventArgs e)
        {
            if (fontSize.SelectedItem != " ")
            {
                int start;
                int len;
                start = richTextBox1.SelectionStart;
                len = richTextBox1.SelectionLength;
                for (int iter = start; iter <= start + len; iter++)
                {
                    richTextBox1.Select(iter, 1);
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, Convert.ToSingle(fontSize.SelectedItem), richTextBox1.SelectionFont.Style);
                }
                richTextBox1.Select(start, len);
            }
        }

        private void fontNameChanged(object sender, EventArgs e)
        {
            if (fontName.SelectedItem != " ")
            {
                FontFamily name = fontFamilies[fontName.SelectedIndex];
                int start;
                int len;
                start = richTextBox1.SelectionStart;
                len = richTextBox1.SelectionLength;
                for (int iter = start; iter <= start + len; iter++)
                {
                    richTextBox1.Select(iter, 1);
                    richTextBox1.SelectionFont = new Font(name, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
                }
                richTextBox1.Select(start, len);
            }
        }

        private void bold_Click(object sender, EventArgs e)
        {
            int start;
            int len;
            start = richTextBox1.SelectionStart;
            len = richTextBox1.SelectionLength;
            bool isAllBold = true;
            bool isBold = false;
            
            for (int iter = start; iter <= start + len; iter++)
            {
                richTextBox1.Select(iter, 1);
                if (richTextBox1.SelectionFont.Bold)
                    isBold = true;
                else
                    isAllBold = false;
            }
            for (int iter = start; iter <= start + len; iter++)
            {
                richTextBox1.Select(iter, 1);
                if (isAllBold)
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ FontStyle.Bold);
                else if (isBold)
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Bold);
                else
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ FontStyle.Bold);

                if (!richTextBox1.SelectionFont.Bold)
                    Bold.CheckState = CheckState.Unchecked;
                else
                    Bold.CheckState = CheckState.Checked;
            }
            richTextBox1.Select(start, len);
        }


        private void italic_Click(object sender, EventArgs e)
        {
            int start;
            int len;
            start = richTextBox1.SelectionStart;
            len = richTextBox1.SelectionLength;
            bool isAllItalic = true;
            bool isItalic = false;
            for (int iter = start; iter <= start + len; iter++)
            {
                richTextBox1.Select(iter, 1);
                if (richTextBox1.SelectionFont.Italic)
                    isItalic = true;
                else
                    isAllItalic = false;
            }
            for (int iter = start; iter <= start + len; iter++)
            {
                richTextBox1.Select(iter, 1);
                if (isAllItalic)
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ FontStyle.Italic);
                else if (isItalic)
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Italic);
                else
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ FontStyle.Italic);

                if (!richTextBox1.SelectionFont.Italic)
                    italic.CheckState = CheckState.Unchecked;
                else
                    italic.CheckState = CheckState.Checked;
            }
            richTextBox1.Select(start, len);
        }

        private void underlined_Click(object sender, EventArgs e)
        {
            int start;
            int len;
            start = richTextBox1.SelectionStart;
            len = richTextBox1.SelectionLength;
            bool isAllUnderlined = true;
            bool isUnderlined = false;
            for (int iter = start; iter <= start + len; iter++)
            {
                richTextBox1.Select(iter, 1);
                if (richTextBox1.SelectionFont.Underline)
                    isUnderlined = true;
                else
                    isAllUnderlined = false;
            }
            for (int iter = start; iter <= start + len; iter++)
            {
                richTextBox1.Select(iter, 1);
                if (isAllUnderlined)
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ FontStyle.Underline);
                else if (isUnderlined)
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Underline);
                else
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ FontStyle.Underline);

                if (!richTextBox1.SelectionFont.Bold)
                    underlined.CheckState = CheckState.Unchecked;
                else
                    underlined.CheckState = CheckState.Checked;
            }
            richTextBox1.Select(start, len);
        }

        private void leftAllign_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            leftAllign.CheckState = CheckState.Checked;
            Central.CheckState = CheckState.Unchecked;
            rightAllign.CheckState = CheckState.Unchecked;
        }

        private void Central_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            leftAllign.CheckState = CheckState.Unchecked;
            Central.CheckState = CheckState.Checked;
            rightAllign.CheckState = CheckState.Unchecked;
        }

        private void rightAllign_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            leftAllign.CheckState = CheckState.Unchecked;
            Central.CheckState = CheckState.Unchecked;
            rightAllign.CheckState = CheckState.Checked;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;
            int searchTextLen = searchText.IndexOf(textBox1.Text);
            int index_of_search = richTextBox1.Find(searchText);
            if (index_of_search >= 0)
            {
                richTextBox1.Select(index_of_search, searchTextLen);
            }
            else
            {
                MessageBox.Show("Нет текста!", "Результат поиска");
            }
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
                Bold.CheckState = CheckState.Unchecked;
            else if (!richTextBox1.SelectionFont.Bold)
                Bold.CheckState = CheckState.Unchecked;
            else
                Bold.CheckState = CheckState.Checked;

            if (richTextBox1.SelectionFont == null)
                italic.CheckState = CheckState.Unchecked;
            else if (!richTextBox1.SelectionFont.Italic)
                italic.CheckState = CheckState.Unchecked;
            else
                italic.CheckState = CheckState.Checked;

            if (richTextBox1.SelectionFont == null)
                underlined.CheckState = CheckState.Unchecked;
            else if (!richTextBox1.SelectionFont.Underline)
                underlined.CheckState = CheckState.Unchecked;
            else
                underlined.CheckState = CheckState.Checked;

            if (richTextBox1.SelectionAlignment == HorizontalAlignment.Left)
                leftAllign.CheckState = CheckState.Checked;
            else
                leftAllign.CheckState = CheckState.Unchecked;

            if (richTextBox1.SelectionAlignment == HorizontalAlignment.Right)
                rightAllign.CheckState = CheckState.Checked;
            else
                rightAllign.CheckState = CheckState.Unchecked;

            if (richTextBox1.SelectionAlignment == HorizontalAlignment.Center)
                Central.CheckState = CheckState.Checked;
            else
                Central.CheckState = CheckState.Unchecked;

            if (richTextBox1.SelectionAlignment == HorizontalAlignment.Center)
                Central.CheckState = CheckState.Checked;
            else
                Central.CheckState = CheckState.Unchecked;

            if (richTextBox1.SelectionFont == null)
                fontName.SelectedItem = " ";
            else
                fontName.SelectedItem = richTextBox1.SelectionFont.Name;

            if (richTextBox1.SelectionFont == null)
                fontSize.SelectedItem = " ";
            else
                fontSize.SelectedItem = richTextBox1.SelectionFont.Size;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Сделал студент группы ПИ-121 Пупанов Кирилл Юрьевич";
            string caption = "Справка о программе";
            MessageBox.Show(this, message, caption);
        }

        private void view_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                if (MessageBox.Show("Вы хотите сохранить изменения в файле?", "Выход",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveAsClick(sender, e);
                }
            }
        }

        private void ExitClicked(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                if (MessageBox.Show("Вы хотите сохранить изменения в файле?", "Выход",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveAsClick(sender, e);
                }
            }
            this.Close();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void Cut(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void SelectAll_clicked(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void ZoomIn_clicked(object sender, EventArgs e)
        {
            
            richTextBox1.ZoomFactor = 2.0f;
            приблизитьToolStripMenuItem.Enabled = false;
            отдалитьToolStripMenuItem.Enabled=true;
        }

        private void ZoomOut_Clicked(object sender, EventArgs e)
        {
            приблизитьToolStripMenuItem.Enabled=true;
            отдалитьToolStripMenuItem.Enabled=false;
            richTextBox1.ZoomFactor = 1.0f;
        }

        private void UpperFontSize_Click(object sender, EventArgs e)
        {
            if (fontSize.SelectedItem != "36")
            {
                fontSize.SelectedIndex++;
                int start;
                int len;
                start = richTextBox1.SelectionStart;
                len = richTextBox1.SelectionLength;
                for (int iter = start; iter <= start + len; iter++)
                {
                    richTextBox1.Select(iter, 1);
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, Convert.ToSingle(fontSize.SelectedItem), richTextBox1.SelectionFont.Style);
                }
                richTextBox1.Select(start, len);
            }
        }

        private void LowerFontSize_Click(object sender, EventArgs e)
        {
            if (fontSize.SelectedItem != "8")
            {
                fontSize.SelectedIndex--;
                int start;
                int len;
                start = richTextBox1.SelectionStart;
                len = richTextBox1.SelectionLength;
                for (int iter = start; iter <= start + len; iter++)
                {
                    richTextBox1.Select(iter, 1);
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, Convert.ToSingle(fontSize.SelectedItem), richTextBox1.SelectionFont.Style);
                }
                richTextBox1.Select(start, len);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionCharOffset = 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionCharOffset = 0;
        }

        private void fontName_Click(object sender, EventArgs e)
        {

        }
    }
}
