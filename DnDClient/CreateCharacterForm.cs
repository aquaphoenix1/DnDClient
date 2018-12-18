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
            var elem = sender as TextBox;
            Control tb;

            try
            {
                tb = elem.Parent.Parent.Controls.Find("textBoxBonus", true)[0];
            }
            catch
            {
                return;
            }

            if(!int.TryParse(elem.Text, out int result))
            {
                return;
            }

            int bonus = CalculateBonusValue(result);

            tb.Text = bonus.ToString();

            CalculateSave(sender);
        }

        private void ChangeSave(object sender, EventArgs e)
        {
            CalculateSave(sender as CheckBox);
        }

        private int CalculateSaveValue(int value, bool isCheckedSave)
        {
            if (isCheckedSave)
            {
                var mastery = numericUpDownMastery.Value;

                return (int)mastery + value;
            }
            else
            {
                return value;
            }
        }

        private void CalculateSave(object sender)
        {
            switch (sender){
                case TextBox textBox:
                    {
                       var elements = panelSave.Controls.Find(textBox.Name, true);

                        CheckBox checkBox = null;

                        foreach(var e in elements)
                        {
                            if(e is CheckBox)
                            {
                                checkBox = e as CheckBox;
                                break;
                            }
                        }

                        if (checkBox.Checked)
                        {
                            TextBox tb = null;

                            foreach (var e in elements)
                            {
                                if (e is TextBox && e.Name == textBox.Name)
                                {
                                    tb = e as TextBox;
                                    break;
                                }
                            }

                            if (!int.TryParse(textBox.Text, out int value))
                            {
                                return;
                            }

                            int bonus = CalculateBonusValue(value);

                            tb.Text = CalculateSaveValue(bonus, true).ToString();
                        }
                        else
                        {
                            foreach (var e in elements)
                            {
                                if (e is TextBox && e.Name == checkBox.Name)
                                {
                                    if (!int.TryParse(textBox.Text, out int value))
                                    {
                                        return;
                                    }

                                    int bonus = CalculateBonusValue(value);

                                    e.Text = CalculateSaveValue(bonus, false).ToString();
                                    break;
                                }
                            }
                        }

                        break;
                    }
                case CheckBox checkBox:
                    {
                        var state = panelCharacteristic.Controls.Find(checkBox.Name, true)[0].Parent.Parent.Controls.Find("textBoxBonus", true)[0] as TextBox;

                        if(!int.TryParse(state.Text, out int value))
                        {
                            return;
                        }

                        if(value == int.MinValue)
                        {
                            return;
                        }

                        if (checkBox.CheckState == CheckState.Checked)
                        {
                            var elements = panelSave.Controls.Find(checkBox.Name, true);

                            foreach (var e in elements)
                            {
                                if (e is TextBox && e.Name == checkBox.Name)
                                {
                                    e.Text = CalculateSaveValue(value, true).ToString();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            var elements = panelSave.Controls.Find(checkBox.Name, true);

                            foreach (var e in elements)
                            {
                                if (e is TextBox && e.Name == checkBox.Name)
                                {
                                    e.Text = state.Text;
                                    break;
                                }
                            }
                        }

                        break;
                    }
            }
        }

        private bool IsInRange(int value, int bottom, int top)
        {
            if (bottom > top)
            {
                return false;
            }

            return (value >= bottom && value <= top);
        }

        private int CalculateBonusValue(int value)
        {
            if (IsInRange(value, 6, 7))
            {
                return -2;
            }
            else if (IsInRange(value, 8, 9))
            {
                return -1;
            }
            else if (IsInRange(value, 10, 11))
            {
                return 0;
            }
            else if (IsInRange(value, 12, 13))
            {
                return 1;
            }
            else if (IsInRange(value, 14, 15))
            {
                return 2;
            }
            else if (IsInRange(value, 16, 17))
            {
                return 3;
            }
            else if (IsInRange(value, 18, 19))
            {
                return 4;
            }
            else
            {
                return int.MinValue;
            }
        }

        private Panel GetCharacterPanel(string name, int value, int y)
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
                BorderStyle = BorderStyle.FixedSingle
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
                Name = name
            };

            textBoxValue.Text = value.ToString();

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
                Name = "textBoxBonus",
                Text = CalculateBonusValue(int.Parse(textBoxValue.Text)).ToString()
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
                Width = checkBoxWidth,
                Name = name
            };

            checkBoxEnabled.CheckedChanged += ChangeSave;

            var textBoxValue = new TextBox
            {
                Width = valueWidth,
                ReadOnly = true,
                Location = new Point(checkBoxEnabled.Width + margin, 0),
                Text = "0",
                BorderStyle = BorderStyle.None,
                Name = name
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
            var height = parametres.Length * CHARACTER_POINT_HEIGHT;
            Height = height + 300;
            panelCharacteristic.Height = height + 300;

            var save_margin = 10;
            var saveHeight = parametres.Length * (SAVE_HEIGHT + save_margin);

            panelSave.Height = saveHeight;

            var characterPanelY = 0;
            var saveY = 0;

            int value = 0;

            foreach (var elem in parametres)
            {
                var panel = GetCharacterPanel(elem, value, characterPanelY);
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
