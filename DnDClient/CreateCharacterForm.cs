using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DnDClient
{
    public partial class CreateCharacterForm : Form
    {
        private const int CHARACTER_POINT_HEIGHT = 80;
        private const int SAVE_HEIGHT = 20;

        public CreateCharacterForm()
        {
            InitializeComponent();
        }

        private string[] parametres =
        {
            "Сила",
            "Ловкость",
            "Телосложение",
            "Интеллект",
            "Мудрость",
            "Харизма"
        };

        private void ChangeCharacteristic(object sender, EventArgs e)
        {
            CalculateBonusValue(sender);
            CalculateSave(sender);
        }

        private void ChangeSave(object sender, EventArgs e)
        {
            CalculateSave(sender);
        }

        private void CalculateSave(object sender)
        {

        }

        private void CalculateBonusValue(object sender)
        {
            var elem = sender as TextBox;
            Control tb;

            try
            {
                tb = elem.Parent.Controls.Find("textBoxBonus", true)[0];
            }
            catch
            {
                return;
            }

            if (!int.TryParse(sender.ToString(), out int value))
            {
                return;
            }

            if (Enumerable.Range(6, 7).Contains(value))
            {
                tb.Text = "-2";
            }
            else if (Enumerable.Range(8, 9).Contains(value))
            {
                tb.Text = "-1";
            }
            else if (Enumerable.Range(10, 11).Contains(value))
            {
                tb.Text = "0";
            }
            else if (Enumerable.Range(12, 13).Contains(value))
            {
                tb.Text = "1";
            }
            else if (Enumerable.Range(14, 15).Contains(value))
            {
                tb.Text = "2";
            }
            else if (Enumerable.Range(16, 17).Contains(value))
            {
                tb.Text = "3";
            }
            else if (Enumerable.Range(18, 19).Contains(value))
            {
                tb.Text = "4";
            }
            else
            {
                tb.Text = "NaN";
            }
        }

        private Panel GetCharacterPanel(string name, int y)
        {
            const int numbersHeight = 20;
            int panelwidth = panelCharacteristic.Width;

            var panel = new Panel
            {
                Width = panelwidth,
                Height = CHARACTER_POINT_HEIGHT,
                Location = new Point(0, y),
                BorderStyle = BorderStyle.FixedSingle
            };

            var textBoxName = new TextBox
            {
                Text = name,
                Width = panel.Width,
                ReadOnly = true,
                Height = numbersHeight,
                Location = new Point(0, 0),
                TextAlign = HorizontalAlignment.Center,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Parent = panel
            };

            var valuePanel = new Panel
            {
                Width = panelwidth,
                Height = CHARACTER_POINT_HEIGHT - 2 * numbersHeight,
                Location = new Point(0, numbersHeight),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            var textBoxValue = new TextBox
            {
                Width = valuePanel.Width,
                Height = numbersHeight,
                Location = new Point(0, valuePanel.Height / 2 - numbersHeight / 2),
                TextAlign = HorizontalAlignment.Center,
                BorderStyle = BorderStyle.None,
                Parent = panel
            };

            textBoxValue.TextChanged += ChangeCharacteristic;

            valuePanel.Controls.Add(textBoxValue);

            var textBoxBonus = new TextBox
            {
                Height = numbersHeight,
                Width = panel.Width,
                Location = new Point(0, panel.Height - numbersHeight),
                TextAlign = HorizontalAlignment.Center,
                ReadOnly = true,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Parent = panel,
                Name = "textBoxBonus"
            };

            panel.Controls.Add(textBoxName);
            panel.Controls.Add(valuePanel);
            panel.Controls.Add(textBoxBonus);

            return panel;
        }

        private Panel GetSavePanel(string name, int y)
        {
            int panelwidth = panelSave.Width;
            int panelHeight = 20;
            int checkBoxWidth = 20;
            int valueWidth = 20;
            int margin = 2;

            var panel = new Panel
            {
                Width = panelwidth,
                Height = panelHeight,
                Location = new Point(0, y),
                BorderStyle = BorderStyle.FixedSingle
            };

            var checkBoxEnabled = new CheckBox
            {
                Height = panelHeight,
                Parent = panel,
                Width = checkBoxWidth
            };

            checkBoxEnabled.CheckedChanged += ChangeSave;

            var textBoxValue = new TextBox
            {
                Width = valueWidth,
                ReadOnly = true,
                Location = new Point(checkBoxEnabled.Width + margin, 0),
                Text = "0",
                BorderStyle = BorderStyle.None
            };

            /*var tbHeight = textBoxValue.Height;
            var topMargin = (panelHeight - tbHeight) / 2;

            textBoxValue.Margin.Top = topMargin;*/

            var textBoxName = new TextBox
            {
                Width = panelwidth - checkBoxEnabled.Width - 2 * margin,
                Parent = panel,
                Location = new Point(checkBoxEnabled.Width + textBoxValue.Width + 2 * margin, 0),
                Text = name,
                BorderStyle = BorderStyle.None,
                ReadOnly = true
            };

            panel.Controls.Add(checkBoxEnabled);
            panel.Controls.Add(textBoxValue);
            panel.Controls.Add(textBoxName);

            return panel;
        }

        private void CreateCharacterForm_Load(object sender, EventArgs e)
        {
            var height = parametres.Length* CHARACTER_POINT_HEIGHT;
            Height = height + 300;
            panelCharacteristic.Height = height + 300;

            var save_margin = 10;
            var saveHeight = parametres.Length * (SAVE_HEIGHT + save_margin);

            panelSave.Height = saveHeight;

            var characterPanelY = 0;
            var saveY = 0;

            foreach(var elem in parametres)
            {
                var panel = GetCharacterPanel(elem, characterPanelY);
                var save = GetSavePanel(elem, saveY);

                characterPanelY += panel.Height + 10;
                saveY += save.Height + 10;

                panelCharacteristic.Controls.Add(panel);
                panelSave.Controls.Add(save);
            }
        }

        private void ButtonDecline_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {

        }
    }
}
