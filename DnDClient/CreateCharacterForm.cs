﻿using Newtonsoft.Json;
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
        private const int SKILL_HEIGHT = 20;
        private const int DEFAULT_MASTERY_VALUE = 2;

        private bool isLoad;

        public CreateCharacterForm(bool isLoad)
        {
            InitializeComponent();

            this.isLoad = isLoad;

            if (isLoad)
            {
                DisableLoadElements();
            }
        }

        private Dictionary<string, TextBox> characteristicsValueTextBoxes;
        private Dictionary<string, TextBox> bonusValueTextBoxes;
        private Dictionary<string, CheckBox> saveCheckBoxes;
        private Dictionary<string, TextBox> saveTextBoxes;

        private void DisableLoadElements()
        {
            buttonAccept.Enabled = false;
            buttonAccept.Visible = false;
            buttonDecline.Enabled = false;
            buttonDecline.Visible = false;

            textBoxName.ReadOnly = true;
            textBoxUserName.ReadOnly = true;
            textBoxClassAndLevel.ReadOnly = true;
            textBoxHistory.ReadOnly = true;
            textBoxUserName.ReadOnly = true;
            textBoxRace.ReadOnly = true;
            textBoxGod.ReadOnly = true;
            textBoxKD.ReadOnly = true;
            textBoxInitiative.ReadOnly = true;
            textBoxSpeed.ReadOnly = true;
            textBoxMaxHP.ReadOnly = true;
            textBoxPassive.ReadOnly = true;

            richTextBoxTraits.ReadOnly = true;
            richTextBoxIdeals.ReadOnly = true;
            richTextBoxAttachment.ReadOnly = true;
            richTextBoxWeaknesses.ReadOnly = true;

            numericUpDownMastery.ReadOnly = true;
        }

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

        private Dictionary<string, string> parametres;

        private string GetParametresByName(string name)
        {
            return parametres.First(x => x.Key.Equals(name)).Value;
        }

        private Dictionary<string, string> skills;

        private string GetSkillByName(string name)
        {
            return skills.First(x => x.Key.Equals(name)).Value;
        }

        private void ChangeCharacteristic(object sender, EventArgs e)
        {
            var elem = sender as TextBox;

            if (!int.TryParse(elem.Text, out int result))
            {
                return;
            }

            var name = characteristicsValueTextBoxes.First(x => x.Value.Equals(elem)).Key;
            
            int bonus = CalculateBonusValue(result);

            GetBonusValueTextBoxesByName(name).Text = bonus.ToString();

            int save = CalculateSave(name);

            GetSaveTextBoxesByName(name).Text = save.ToString();

            ChangeAllSkills(name, bonus);
        }

        private void ChangeAllSkills(string name, int value)
        {
            foreach(var cb in skillsCheckBoxes)
            {
                var charType = skills.First(x => x.Key.Equals(cb.Key));
                if (charType.Value.Equals(name))
                {
                    var val = CalculateSkill(charType.Key, cb.Value.Checked);

                    var tb = GetSkillTextBoxByName(charType.Key);

                    tb.Text = val.ToString();
                }
            }
        }

        private void ChangeAllSkills(int value)
        {
            foreach (var cb in skillsCheckBoxes)
            {
                var charType = skills.First(x => x.Key.Equals(cb.Key));
                var val = CalculateSkill(charType.Key, cb.Value.Checked);

                var tb = GetSkillTextBoxByName(charType.Key);

                tb.Text = val.ToString();
            }
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
                Text = GetParametresByName(name),
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
                ReadOnly = isLoad
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

        private Dictionary<string, CheckBox> skillsCheckBoxes;
        private Dictionary<string, TextBox> skillsTextBoxes;

        private TextBox GetSkillTextBoxByName(string name)
        {
            return skillsTextBoxes.First(x => x.Key.Equals(name)).Value;
        }

        private int CalculateSkill(string name, bool isMastery)
        {
            var parameter = GetBonusValueTextBoxesByName(GetSkillByKey(name)).Text;

            if(!int.TryParse(parameter, out int value))
            {
                return 0;
            }

            if(value == int.MinValue)
            {
                return 0;
            }

            return CalculateSaveValue(value, isMastery);
        }

        private void ChangeSkill(object sender, EventArgs e)
        {
            var elem = sender as CheckBox;

            var name = skillsCheckBoxes.First(x => x.Value.Equals(elem)).Key;

            int value = CalculateSkill(name, elem.Checked);

            GetSkillTextBoxByName(name).Text = value.ToString();
        }

        private string GetSkillByKey(string key)
        {
            return skills.First(x => x.Key.Equals(key)).Value;
        }

        private Panel GetSkillPanel(string name, int y)
        {
            var panelWidth = panelSkills.Width;
            var checkBoxWidth = 20;
            var valueWidth = 20;
            var margin = 2;

            var panel = new Panel
            {
                Width = panelWidth,
                Height = SKILL_HEIGHT,
                Location = new Point(0, y),
                BorderStyle = BorderStyle.FixedSingle
            };

            var checkBoxEnabled = new CheckBox
            {
                Height = SKILL_HEIGHT,
                Width = checkBoxWidth,
                Enabled = !isLoad
            };

            checkBoxEnabled.CheckedChanged += ChangeSkill;

            skillsCheckBoxes.Add(name, checkBoxEnabled);

            var textBoxValue = new TextBox
            {
                Width = valueWidth,
                ReadOnly = true,
                Location = new Point(checkBoxEnabled.Width + margin, 0),
                BorderStyle = BorderStyle.None
            };

            skillsTextBoxes.Add(name, textBoxValue);

            var textBoxName = new TextBox
            {
                Width = panelWidth - checkBoxEnabled.Width - 2 * margin,
                Location = new Point(checkBoxEnabled.Width + textBoxValue.Width + 2 * margin, 0),
                Text = name + " (" + GetParametresByName(GetSkillByKey(name)) + ")",
                BorderStyle = BorderStyle.None,
                ReadOnly = true
            };

            panel.Controls.Add(checkBoxEnabled);
            panel.Controls.Add(textBoxValue);
            panel.Controls.Add(textBoxName);

            return panel;
        }

        private Panel GetSavePanel(string name, int y)
        {
            var panelWidth = panelSave.Width;
            var panelHeight = 20;
            var checkBoxWidth = 20;
            var valueWidth = 20;
            var margin = 2;

            var panel = new Panel
            {
                Width = panelWidth,
                Height = panelHeight,
                Location = new Point(0, y),
                BorderStyle = BorderStyle.FixedSingle
            };

            var checkBoxEnabled = new CheckBox
            {
                Height = panelHeight,
                Width = checkBoxWidth,
                Enabled = !isLoad
            };

            checkBoxEnabled.CheckedChanged += ChangeSave;

            var textBoxValue = new TextBox
            {
                Width = valueWidth,
                ReadOnly = true,
                Location = new Point(checkBoxEnabled.Width + margin, 0),
                BorderStyle = BorderStyle.None
            };

            var textBoxName = new TextBox
            {
                Width = panelWidth - checkBoxEnabled.Width - 2 * margin,
                Location = new Point(checkBoxEnabled.Width + textBoxValue.Width + 2 * margin, 0),
                Text = GetParametresByName(name),
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

        private void FillParametres()
        {
            parametres.Add("Strength", "Сила");
            parametres.Add("Agility", "Ловкость");
            parametres.Add("Body", "Телосложение");
            parametres.Add("Intelligence", "Интеллект");
            parametres.Add("Wisdom", "Мудрость");
            parametres.Add("Charism", "Харизма");
        }

        private void CreateCharacterForm_Load(object sender, EventArgs e)
        {
            characteristicsValueTextBoxes = new Dictionary<string, TextBox>();
            bonusValueTextBoxes = new Dictionary<string, TextBox>();
            saveCheckBoxes = new Dictionary<string, CheckBox>();
            saveTextBoxes = new Dictionary<string, TextBox>();
            skills = new Dictionary<string, string>();

            skillsCheckBoxes = new Dictionary<string, CheckBox>();
            skillsTextBoxes = new Dictionary<string, TextBox>();

            parametres = new Dictionary<string, string>();

            FillParametres();

            var height = parametres.Count * CHARACTER_POINT_HEIGHT;
            Height = height + 300;
            panelCharacteristic.Height = height + 300;

            var save_margin = 10;
            var saveHeight = parametres.Count * (SAVE_HEIGHT + save_margin);

            panelSave.Height = saveHeight;

            var characterPanelY = 0;
            var saveY = 0;

            int value = 0;

            foreach (var elem in parametres)
            {
                var panel = GetCharacterPanel(elem.Key, value, characterPanelY);
                var save = GetSavePanel(elem.Key, saveY);

                characterPanelY += panel.Height + 10;
                saveY += save.Height + 5;

                panelCharacteristic.Controls.Add(panel);
                panelSave.Controls.Add(save);
            }

            var skillsY = 5;

            FillSkills();
            foreach(var elem in skills)
            {
                var panel = GetSkillPanel(elem.Key, skillsY);

                panelSkills.Controls.Add(panel);

                skillsY += SKILL_HEIGHT + 5;
            }

            numericUpDownMastery.Value = DEFAULT_MASTERY_VALUE;
        }

        private void FillSkills()
        {
            skills.Add("Акробатика", "Agility");
            skills.Add("Анализ", "Intelligence");
            skills.Add("Атлетика", "Strength");
            skills.Add("Внимательность", "Wisdom");
            skills.Add("Выживание", "Wisdom");
            skills.Add("Выступление", "Charism");
            skills.Add("Запугивание", "Charism");
            skills.Add("История", "Intelligence");
            skills.Add("Ловкость рук", "Agility");
            skills.Add("Магия", "Intelligence");
            skills.Add("Медицина", "Wisdom");
            skills.Add("Обман", "Charism");
            skills.Add("Природа", "Intelligence");
            skills.Add("Проницательность", "Wisdom");
            skills.Add("Религия", "Intelligence");
            skills.Add("Скрытность", "Agility");
            skills.Add("Убеждение", "Charism");
            skills.Add("Уход за животными", "Wisdom");
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
                var paramValueTextBox = GetCharacteristicsValueTextBoxByName(elem.Key);

                var paramBonusTextBox = GetBonusValueTextBoxesByName(elem.Key);

                var characteristic = new Character.Characteristic(elem.Key, int.Parse(paramValueTextBox.Text), int.Parse(paramBonusTextBox.Text));

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
            ChangeAllSkills((int)numericUpDownMastery.Value);
        }
    }
}