using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        private Dictionary<string, TextBox> characteristicsValueTextBoxes;
        private Dictionary<string, TextBox> bonusValueTextBoxes;
        private Dictionary<string, CheckBox> saveCheckBoxes;
        private Dictionary<string, TextBox> saveTextBoxes;

        private TextBox GetCharacteristicsValueTextBoxByName(string name)
        {
            return characteristicsValueTextBoxes.First(x => x.Key.Equals(name)).Value;
        }

        private TextBox GetBonusValueTextBoxesByName(string name)
        {
            return bonusValueTextBoxes.First(x => x.Key.Equals(name)).Value;
        }

        private CheckBox GetSaveCheckBoxByName(string name)
        {
            return saveCheckBoxes.First(x => x.Key.Equals(name)).Value;
        }

        private TextBox GetSaveTextBoxesByName(string name)
        {
            return saveTextBoxes.First(x => x.Key.Equals(name)).Value;
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

            if (!int.TryParse(elem.Text, out int result))
            {
                return;
            }

            var name = characteristicsValueTextBoxes.FirstOrDefault(x => x.Value.Equals(elem)).Key;
            
            int bonus = CalculateBonusValue(result);

            GetBonusValueTextBoxesByName(name).Text = bonus.ToString();

            int save = CalculateSave(name);

            GetSaveTextBoxesByName(name).Text = save.ToString();
        }

        private void ChangeSave(object sender, EventArgs e)
        {
            var elem = sender as CheckBox;

            var name = saveCheckBoxes.First(x => x.Value.Equals(elem)).Key;

            int value = CalculateSave(name);

            GetSaveTextBoxesByName(name).Text = value.ToString();
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

        private int CalculateSave(string name)
        {
            var value = GetBonusValueTextBoxesByName(name).Text;

            if (!int.TryParse(value, out int bonus))
            {
                return 0;
            }

            if(bonus == int.MinValue)
            {
                return 0;
            }

            var checkBox = GetSaveCheckBoxByName(name);

            var save = CalculateSaveValue(bonus, checkBox.Checked);

            return save;
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
                BorderStyle = BorderStyle.None
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
                Text = CalculateBonusValue(int.Parse(textBoxValue.Text)).ToString()
            };

            panel.Controls.Add(textBoxName);
            panel.Controls.Add(valuePanel);
            panel.Controls.Add(textBoxBonus);

            characteristicsValueTextBoxes.Add(name, textBoxValue);
            bonusValueTextBoxes.Add(name, textBoxBonus);

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

            saveCheckBoxes.Add(name, checkBoxEnabled);
            saveTextBoxes.Add(name, textBoxValue);

            return panel;
        }

        private void CreateCharacterForm_Load(object sender, EventArgs e)
        {
            characteristicsValueTextBoxes = new Dictionary<string, TextBox>();
            bonusValueTextBoxes = new Dictionary<string, TextBox>();
            saveCheckBoxes = new Dictionary<string, CheckBox>();
            saveTextBoxes = new Dictionary<string, TextBox>();

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

        private bool IsValidData()
        {
            return true;
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                SaveCharacter();
            }
        }

        private void SaveCharacter()
        {
            string name = textBoxName.Text;

            string path = Directory.GetCurrentDirectory() + "\\" + name;

            var stream = File.Create(path);

            stream.Close();

            List<Character.Characteristic> characteristics = new List<Character.Characteristic>();

            foreach (var elem in parametres)
            {
                var paramValueTextBox = GetCharacteristicsValueTextBoxByName(elem);

                var paramBonusTextBox = GetBonusValueTextBoxesByName(elem);

                var characteristic = new Character.Characteristic(elem, int.Parse(paramValueTextBox.Text), int.Parse(paramBonusTextBox.Text));

                characteristics.Add(characteristic);
            }

            int mastery = (int)numericUpDownMastery.Value;

            var character = new Character(name, characteristics, mastery);

            var json = JsonConvert.SerializeObject(character);

            File.WriteAllText(path, json);
        }

        private void ChangeAllSaves(int mastery)
        {
            foreach(var e in bonusValueTextBoxes)
            {
                var newValue = CalculateSave(e.Key);

                GetSaveTextBoxesByName(e.Key).Text = newValue.ToString();
            }
        }

        private void NumericUpDownMastery_ValueChanged(object sender, EventArgs e)
        {
            ChangeAllSaves((int)numericUpDownMastery.Value);
        }
    }
}