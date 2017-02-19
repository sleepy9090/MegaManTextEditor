using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MegaManTextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setMaxLengthOfTextBoxes();
        }

        private void buttonOpenROM_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open file...";
            ofd.Filter = "nes files (*.nes)|*.nes|All files (*.*)|*.*";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxAbsoluteFilename.Text = ofd.FileName;

                readRomText();
            }
        }

        private void setMaxLengthOfTextBoxes() {
            textBoxMM1.MaxLength = 0x9;
            textBoxMM2.MaxLength = 0x8;
            textBoxMM3.MaxLength = 0xC;
            textBoxMM4.MaxLength = 0xB;
            textBoxMM5.MaxLength = 0x1F;
            textBoxMM6.MaxLength = 0xB;
            textBoxMM7.MaxLength = 0x18;
            textBoxMM8.MaxLength = 0x2;
            textBoxMM9.MaxLength = 0x7;
            textBoxMM10.MaxLength = 0x7;
            textBoxMM11.MaxLength = 0x7;
            textBoxMM12.MaxLength = 0x7;
            textBoxMM13.MaxLength = 0x7;
            textBoxMM14.MaxLength = 0x7;
            textBoxMM15.MaxLength = 0x7;
            textBoxMM16.MaxLength = 0xC;
            textBoxMM17.MaxLength = 0x6;
            textBoxMM18.MaxLength = 0x6;
            textBoxMM19.MaxLength = 0x6;
            textBoxMM20.MaxLength = 0x6;
            textBoxMM21.MaxLength = 0x11;
            textBoxMM22.MaxLength = 0x13;
            textBoxMM23.MaxLength = 0x9;
            textBoxMM24.MaxLength = 0xC;
            textBoxMM25.MaxLength = 0x13;
            textBoxMM26.MaxLength = 0x18;
            textBoxMM27.MaxLength = 0x10;
            textBoxMM28.MaxLength = 0x1C;
            textBoxMM29.MaxLength = 0xD;
            textBoxMM30.MaxLength = 0xE;
            textBoxMM31.MaxLength = 0x16;
            textBoxMM32.MaxLength = 0x5;
            textBoxMM33.MaxLength = 0x7;
            textBoxMM34.MaxLength = 0x3;
            textBoxMM35.MaxLength = 0x12;
            textBoxMM36.MaxLength = 0x9;
            textBoxMM37.MaxLength = 0x12;
            textBoxMM38.MaxLength = 0x7;
            textBoxMM39.MaxLength = 0x9;
            textBoxMM40.MaxLength = 0x7;
            textBoxMM41.MaxLength = 0x12;
            textBoxMM42.MaxLength = 0x9;
            textBoxMM43.MaxLength = 0x12;
            textBoxMM44.MaxLength = 0x13;
            textBoxMM45.MaxLength = 0x10;
            textBoxMM46.MaxLength = 0x10;
            textBoxMM47.MaxLength = 0xC;
            textBoxMM48.MaxLength = 0xE;
        }

        private void readRomText()
        {
            try
            {
                string absoluteFilename = textBoxAbsoluteFilename.Text;

                Backend backend = new Backend();

                backend.getText(absoluteFilename, textBoxMM1, 0x9, 0x10EB4, 2);
                backend.getText(absoluteFilename, textBoxMM2, 0x8, 0x10EC0, 2);
                backend.getText(absoluteFilename, textBoxMM3, 0xC, 0x10ECB, 2);
                backend.getText(absoluteFilename, textBoxMM4, 0xB, 0x10EF7, 2);
                backend.getText(absoluteFilename, textBoxMM5, 0x1F, 0x10F05, 2);
                backend.getText(absoluteFilename, textBoxMM6, 0xB, 0x10F27, 2);
                backend.getText(absoluteFilename, textBoxMM7, 0x18, 0x10F35, 2);
                backend.getText(absoluteFilename, textBoxMM8, 0x2, 0x10F4E, 2);

                backend.getText(absoluteFilename, textBoxMM9, 0x7, 0x1BF7F, 1);
                backend.getText(absoluteFilename, textBoxMM10, 0x7, 0x1BF86, 1);
                backend.getText(absoluteFilename, textBoxMM11, 0x7, 0x1BF8D, 1);
                backend.getText(absoluteFilename, textBoxMM12, 0x7, 0x1BF94, 1);
                backend.getText(absoluteFilename, textBoxMM13, 0x7, 0x1BF9B, 1);
                backend.getText(absoluteFilename, textBoxMM14, 0x7, 0x1BFA2, 1);
                backend.getText(absoluteFilename, textBoxMM15, 0x7, 0x1BFA9, 1);
                backend.getText(absoluteFilename, textBoxMM16, 0xC, 0x1BFB0, 1);
                backend.getText(absoluteFilename, textBoxMM17, 0x6, 0x1BFBE, 1);
                backend.getText(absoluteFilename, textBoxMM18, 0x6, 0x1BFC6, 1);
                backend.getText(absoluteFilename, textBoxMM19, 0x6, 0x1BFCE, 1);
                backend.getText(absoluteFilename, textBoxMM20, 0x6, 0x1BFD6, 1);

                backend.getText(absoluteFilename, textBoxMM21, 0x11, 0x1AECF, 3);
                backend.getText(absoluteFilename, textBoxMM22, 0x13, 0x1AEE3, 3);
                backend.getText(absoluteFilename, textBoxMM23, 0x9, 0x1AEF9, 3);
                backend.getText(absoluteFilename, textBoxMM24, 0xC, 0x1AF05, 3);
                backend.getText(absoluteFilename, textBoxMM25, 0x13, 0x1AF14, 3);
                backend.getText(absoluteFilename, textBoxMM26, 0x18, 0x1AF2A, 3);
                backend.getText(absoluteFilename, textBoxMM27, 0x10, 0x1AF45, 3);
                backend.getText(absoluteFilename, textBoxMM28, 0x1C, 0x1AF58, 3);
                backend.getText(absoluteFilename, textBoxMM29, 0xD, 0x1AF77, 3);
                backend.getText(absoluteFilename, textBoxMM30, 0xE, 0x1AF88, 3);
                backend.getText(absoluteFilename, textBoxMM31, 0x16, 0x1AF99, 3);
                backend.getText(absoluteFilename, textBoxMM32, 0x5, 0x1AFB3, 3);
                backend.getText(absoluteFilename, textBoxMM33, 0x7, 0x1AFBB, 3);
                backend.getText(absoluteFilename, textBoxMM34, 0x3, 0x1AFC5, 3);
                backend.getText(absoluteFilename, textBoxMM35, 0x12, 0x1AFCB, 3);
                backend.getText(absoluteFilename, textBoxMM36, 0x9, 0x1AFE0, 3);
                backend.getText(absoluteFilename, textBoxMM37, 0x12, 0x1AFEC, 3);
                backend.getText(absoluteFilename, textBoxMM38, 0x7, 0x1B001, 3);
                backend.getText(absoluteFilename, textBoxMM39, 0x9, 0x1B00C, 3);
                backend.getText(absoluteFilename, textBoxMM40, 0x7, 0x1B01B, 3);
                backend.getText(absoluteFilename, textBoxMM41, 0x12, 0x1B023, 3);
                backend.getText(absoluteFilename, textBoxMM42, 0x9, 0x1B038, 3);
                backend.getText(absoluteFilename, textBoxMM43, 0x12, 0x1B044, 3);
                backend.getText(absoluteFilename, textBoxMM44, 0x13, 0x1B059, 3);
                backend.getText(absoluteFilename, textBoxMM45, 0x10, 0x1B06F, 3);
                backend.getText(absoluteFilename, textBoxMM46, 0x10, 0x1B082, 3);
                backend.getText(absoluteFilename, textBoxMM47, 0xC, 0x1B0BE, 3);
                backend.getText(absoluteFilename, textBoxMM48, 0xE, 0x1B0CD, 3);

                enableButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enableButtons()
        {
            updateTextToolStripMenuItem.Enabled = true;
            buttonUpdateText.Enabled = true;
        }

        private void openROmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonOpenROM_Click(sender, e);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUpdateText_Click(object sender, EventArgs e)
        {
            try {

                string absoluteFilename = textBoxAbsoluteFilename.Text;

                Backend backend = new Backend();

                backend.updateROMText(absoluteFilename, 0x9, textBoxMM1, 0x10EB4, 2);
                backend.updateROMText(absoluteFilename, 0x8, textBoxMM2, 0x10EC0, 2);
                backend.updateROMText(absoluteFilename, 0xC, textBoxMM3, 0x10ECB, 2);
                backend.updateROMText(absoluteFilename, 0xB, textBoxMM4, 0x10EF7, 2);
                backend.updateROMText(absoluteFilename, 0x1F, textBoxMM5, 0x10F05, 2);
                backend.updateROMText(absoluteFilename, 0xB, textBoxMM6, 0x10F27, 2);
                backend.updateROMText(absoluteFilename, 0x18, textBoxMM7, 0x10F35, 2);
                backend.updateROMText(absoluteFilename, 0x2, textBoxMM8, 0x10F4E, 2);

                backend.updateROMText(absoluteFilename, 0x7, textBoxMM9, 0x1BF7F, 1);
                backend.updateROMText(absoluteFilename, 0x7, textBoxMM10, 0x1BF86, 1);
                backend.updateROMText(absoluteFilename, 0x7, textBoxMM11, 0x1BF8D, 1);
                backend.updateROMText(absoluteFilename, 0x7, textBoxMM12, 0x1BF94, 1);
                backend.updateROMText(absoluteFilename, 0x7, textBoxMM13, 0x1BF9B, 1);
                backend.updateROMText(absoluteFilename, 0x7, textBoxMM14, 0x1BFA2, 1);
                backend.updateROMText(absoluteFilename, 0x7, textBoxMM15, 0x1BFA9, 1);
                backend.updateROMText(absoluteFilename, 0xC, textBoxMM16, 0x1BFB0, 1);
                backend.updateROMText(absoluteFilename, 0x6, textBoxMM17, 0x1BFBE, 1);
                backend.updateROMText(absoluteFilename, 0x6, textBoxMM18, 0x1BFC6, 1);
                backend.updateROMText(absoluteFilename, 0x6, textBoxMM19, 0x1BFCE, 1);
                backend.updateROMText(absoluteFilename, 0x6, textBoxMM20, 0x1BFD6, 1);

                backend.updateROMText(absoluteFilename, 0x11, textBoxMM21, 0x1AECF, 3);
                backend.updateROMText(absoluteFilename, 0x13, textBoxMM22, 0x1AEE3, 3);
                backend.updateROMText(absoluteFilename, 0x9, textBoxMM23, 0x1AEF9, 3);
                backend.updateROMText(absoluteFilename, 0xC, textBoxMM24, 0x1AF05, 3);
                backend.updateROMText(absoluteFilename, 0x13, textBoxMM25, 0x1AF14, 3);
                backend.updateROMText(absoluteFilename, 0x18, textBoxMM26, 0x1AF2A, 3);
                backend.updateROMText(absoluteFilename, 0x10, textBoxMM27, 0x1AF45, 3);
                backend.updateROMText(absoluteFilename, 0x1C, textBoxMM28, 0x1AF58, 3);
                backend.updateROMText(absoluteFilename, 0xD, textBoxMM29, 0x1AF77, 3);
                backend.updateROMText(absoluteFilename, 0xE, textBoxMM30, 0x1AF88, 3);
                backend.updateROMText(absoluteFilename, 0x16, textBoxMM31, 0x1AF99, 3);
                backend.updateROMText(absoluteFilename, 0x5, textBoxMM32, 0x1AFB3, 3);
                backend.updateROMText(absoluteFilename, 0x7, textBoxMM33, 0x1AFBB, 3);
                backend.updateROMText(absoluteFilename, 0x3, textBoxMM34, 0x1AFC5, 3);
                backend.updateROMText(absoluteFilename, 0x12, textBoxMM35, 0x1AFCB, 3);
                backend.updateROMText(absoluteFilename, 0x9, textBoxMM36, 0x1AFE0, 3);
                backend.updateROMText(absoluteFilename, 0x12, textBoxMM37, 0x1AFEC, 3);
                backend.updateROMText(absoluteFilename, 0x7, textBoxMM38, 0x1B001, 3);
                backend.updateROMText(absoluteFilename, 0x9, textBoxMM39, 0x1B00C, 3);
                backend.updateROMText(absoluteFilename, 0x7, textBoxMM40, 0x1B01B, 3);
                backend.updateROMText(absoluteFilename, 0x12, textBoxMM41, 0x1B023, 3);
                backend.updateROMText(absoluteFilename, 0x9, textBoxMM42, 0x1B038, 3);
                backend.updateROMText(absoluteFilename, 0x12, textBoxMM43, 0x1B044, 3);
                backend.updateROMText(absoluteFilename, 0x13, textBoxMM44, 0x1B059, 3);
                backend.updateROMText(absoluteFilename, 0x10, textBoxMM45, 0x1B06F, 3);
                backend.updateROMText(absoluteFilename, 0x10, textBoxMM46, 0x1B082, 3);
                backend.updateROMText(absoluteFilename, 0xC, textBoxMM47, 0x1B0BE, 3);
                backend.updateROMText(absoluteFilename, 0xE, textBoxMM48, 0x1B0CD, 3);

                MessageBox.Show("MegaMan ROM Text Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonUpdateText_Click(sender, e);
        }
    }
}
