using DnDClient.EthernetControllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnDClient
{
    public partial class CreateCharacterForm : Form
    {
        private bool IsLoad { get; set; }
        private CheckBox[] AliveCheckBoxes { get; set; }
        private CheckBox[] DeadCheckBoxes { get; set; }
        private dynamic LoadedCharacter { get; set; }

        private const int CHARACTER_POINT_HEIGHT = 80;
        private const int SAVE_HEIGHT = 20;
        private const int SKILL_HEIGHT = 20;
        private const int DEFAULT_MASTERY_VALUE = 2;

        public CreateCharacterForm(bool isLoad, dynamic element, bool isOnlyRead)
        {
            InitializeComponent();
            IsLoad = isLoad;

            if (isLoad)
            {
                DisableLoadElements();
            }

            LoadedCharacter = element;

            if (isOnlyRead)
            {
                DisableAllElements();
                CreateCharacterForm_Load(null, null);
            }
        }

        private void DisableAllElements()
        {
            numericUpDownCurrentHP.ReadOnly = true;

            checkBoxBoneHP.Enabled = false;
            textBoxBoneHP.ReadOnly = true;

            richTextBoxLanguages.ReadOnly = true;

            checkBoxInspiration.Enabled = false;

            numericUpDownTimeHp.Enabled = false;
            numericUpDownCurrentHP.Enabled = false;

            numericUpDownXP.Enabled = false;

            checkBoxAliveOne.Enabled = false;
            checkBoxAliveTwo.Enabled = false;
            checkBoxAliveThree.Enabled = false;
            checkBoxDeathOne.Enabled = false;
            checkBoxDeathTwo.Enabled = false;
            checkBoxDeathThree.Enabled = false;

            dataGridViewAbilities.ReadOnly = true;
            dataGridViewEquipment.ReadOnly = true;
            dataGridViewWeapons.ReadOnly = true;

            numericUpDownCopperMoney.Enabled = false;
            numericUpDownSilverMoney.Enabled = false;
            numericUpDownGoldMoney.Enabled = false;
            numericUpDownElectroMoney.Enabled = false;
            numericUpDownPlatinumMoney.Enabled = false;

            numericUpDownPassive.Enabled = false;

            richTextBoxSpellsAbout.ReadOnly = true;
            dataGridViewTalking.ReadOnly = true;

            numericUpDownFirstSpellLevelCount.Enabled = false;
            numericUpDownFirstSpellLevelUsed.Enabled = false;
            dataGridViewFirstSpellLevel.Enabled = false;

            numericUpDownSecondSpellLevelCount.Enabled = false;
            numericUpDownSecondSpellLevelUsed.Enabled = false;
            dataGridViewSecondSpellLevel.Enabled = false;

            numericUpDownThirdSpellLevelCount.Enabled = false;
            numericUpDownThirdSpellLevelUsed.Enabled = false;
            dataGridViewThirdSpellLevel.Enabled = false;

            numericUpDownFourthSpellLevelCount.Enabled = false;
            numericUpDownFourthSpellLevelUsed.Enabled = false;
            dataGridViewFourthSpellLevel.Enabled = false;

            numericUpDownFifthSpellLevelCount.Enabled = false;
            numericUpDownFifthSpellLevelUsed.Enabled = false;
            dataGridViewFifthSpellLevel.Enabled = false;

            numericUpDownSixthSpellLevelCount.Enabled = false;
            numericUpDownSixthSpellLevelUsed.Enabled = false;
            dataGridViewSixthSpellLevel.Enabled = false;

            numericUpDownSeventhSpellLevelCount.Enabled = false;
            numericUpDownSeventhSpellLevelUsed.Enabled = false;
            dataGridViewSeventhSpellLevel.Enabled = false;

            numericUpDownEighthSpellLevelCount.Enabled = false;
            numericUpDownEighthSpellLevelUsed.Enabled = false;
            dataGridViewEighthSpellLevel.Enabled = false;

            numericUpDownNinthSpellLevelCount.Enabled = false;
            numericUpDownNinthSpellLevelUsed.Enabled = false;
            dataGridViewNinthSpellLevel.Enabled = false;
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
            numericUpDownKD.Enabled = false;
            numericUpDownInitiative.Enabled = false;
            numericUpDownSpeed.Enabled = false;
            numericUpDownMaximumHP.Enabled = false;
            numericUpDownPassive.Enabled = false;

            richTextBoxTraits.ReadOnly = true;
            richTextBoxIdeals.ReadOnly = true;
            richTextBoxAttachment.ReadOnly = true;
            richTextBoxWeaknesses.ReadOnly = true;
            richTextBoxHist.ReadOnly = true;

            numericUpDownMastery.Enabled = false;

            comboBoxBaseCharacter.Enabled = false;
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

        private string GetParametresByValue(string value)
        {
            return parametres.First(x => x.Value.Equals(value)).Key;
        }

        private Dictionary<string, string> skills;

        private void ChangeInitiative(int value)
        {
            if (value != int.MinValue)
            {
                numericUpDownInitiative.Value = value;
            }
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

            if (name.Equals("Agility"))
            {
                ChangeInitiative(bonus);
            }

            GetBonusValueTextBoxesByName(name).Text = bonus.ToString();

            if (name.Equals(GetParametresByValue(comboBoxBaseCharacter.SelectedItem.ToString())))
            {
                ChangeDifficult();
                ChangeSpellBonus();
            }

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

                    var tb = GetSkillValueTextBoxByName(charType.Key);

                    tb.Text = val.ToString();
                }
            }
        }

        private void ChangeAllSkills()
        {
            foreach (var cb in skillsCheckBoxes)
            {
                var charType = skills.First(x => x.Key.Equals(cb.Key));
                var val = CalculateSkill(charType.Key, cb.Value.Checked);

                var tb = GetSkillValueTextBoxByName(charType.Key);

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

            if (bonus == int.MinValue)
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
                ReadOnly = IsLoad
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
        private Dictionary<string, TextBox> skillsValueTextBoxes;
        private Dictionary<string, TextBox> skillsNameTextBoxes;

        private TextBox GetSkillValueTextBoxByName(string name)
        {
            return skillsValueTextBoxes.First(x => x.Key.Equals(name)).Value;
        }

        private TextBox GetSkillNameTextBoxByName(string name)
        {
            return skillsNameTextBoxes.First(x => x.Key.Equals(name)).Value;
        }

        private CheckBox GetSkillCheckBoxByName(string name)
        {
            return skillsCheckBoxes.First(x => x.Key.Equals(name)).Value;
        }

        private int CalculateSkill(string name, bool isMastery)
        {
            var parameter = GetBonusValueTextBoxesByName(GetSkillByKey(name)).Text;
            if (!int.TryParse(parameter, out int value))
            {
                return 0;
            }

            if (value == int.MinValue)
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

            GetSkillValueTextBoxByName(name).Text = value.ToString();
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
                Enabled = !IsLoad
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

            skillsValueTextBoxes.Add(name, textBoxValue);

            var textBoxName = new TextBox
            {
                Width = panelWidth - checkBoxEnabled.Width - 2 * margin,
                Location = new Point(checkBoxEnabled.Width + textBoxValue.Width + 2 * margin, 0),
                Text = name + " (" + GetParametresByName(GetSkillByKey(name)) + ")",
                BorderStyle = BorderStyle.None,
                ReadOnly = true
            };

            skillsNameTextBoxes.Add(name, textBoxName);

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
                Enabled = !IsLoad
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
            skillsValueTextBoxes = new Dictionary<string, TextBox>();
            skillsNameTextBoxes = new Dictionary<string, TextBox>();

            AliveCheckBoxes = new CheckBox[3];
            DeadCheckBoxes = new CheckBox[3];

            AliveCheckBoxes[0] = checkBoxAliveOne;
            AliveCheckBoxes[1] = checkBoxAliveTwo;
            AliveCheckBoxes[2] = checkBoxAliveThree;

            DeadCheckBoxes[0] = checkBoxDeathOne;
            DeadCheckBoxes[1] = checkBoxDeathTwo;
            DeadCheckBoxes[2] = checkBoxDeathThree;

            parametres = new Dictionary<string, string>();

            FillParametres();

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

                comboBoxBaseCharacter.Items.Add(elem.Value);
            }

            comboBoxBaseCharacter.SelectedIndex = 0;

            var skillsY = 5;

            FillSkills();
            foreach(var elem in skills)
            {
                var panel = GetSkillPanel(elem.Key, skillsY);

                panelSkills.Controls.Add(panel);

                skillsY += SKILL_HEIGHT + 5;
            }

            NumericUpDownMastery_ValueChanged(null, null);

            numericUpDownMastery.Value = DEFAULT_MASTERY_VALUE;

            if (LoadedCharacter != null)
            {
                LoadCharacter();
            }
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

        private bool ValidateData()
        {
            if(textBoxName.Text == "")
            {
                MessageBox.Show("Введите имя!");
                return false;
            }

            if(textBoxUserName.Text == "")
            {
                MessageBox.Show("Введите имя игрока!");
                return false;
            }

            foreach(var elem in characteristicsValueTextBoxes)
            {
                if (!int.TryParse(elem.Value.Text, out int value))
                {
                    MessageBox.Show("Введите {0}!", elem.Key);
                    return false;
                }

                if (value == int.MinValue)
                {
                    MessageBox.Show("Введите {0}!", elem.Key);
                    return false;
                }
            }

            if(textBoxClassAndLevel.Text == "")
            {
                MessageBox.Show("Введите класс и уровень!");
                return false;
            }

            if(textBoxHistory.Text == "")
            {
                MessageBox.Show("Введите предысторию!");
                return false;
            }

            if(textBoxRace.Text == "")
            {
                MessageBox.Show("Введите расуу!");
                return false;
            }

            if(textBoxGod.Text == "")
            {
                MessageBox.Show("Введите мировоззрение!");
                return false;
            }

            if (richTextBoxTraits.Text == "")
            {
                MessageBox.Show("Черты характера!");
                return false;
            }

            if(richTextBoxIdeals.Text == "")
            {
                MessageBox.Show("Введите идеалы!");
                return false;
            }

            if(richTextBoxAttachment.Text == "")
            {
                MessageBox.Show("Введите привязанности!");
                return false;
            }

            if(richTextBoxWeaknesses.Text == "")
            {
                MessageBox.Show("Введите слабости!");
                return false;
            }

            if(richTextBoxLanguages.Text == "")
            {
                MessageBox.Show("Введите владение языками!");
                return false;
            }

            if((int)numericUpDownMaximumHP.Value <= 0)
            {
                MessageBox.Show("Неверное значение HP!");
                return false;
            }

            if(textBoxBoneHP.Text == "")
            {
                MessageBox.Show("Введите кость хитов!");
                return false;
            }

            return true;
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            SaveCharacter();
        }

        public void SaveCharacter()
        {
            if (!ValidateData())
            {
                return;
            }

            string name = textBoxName.Text;

            List<Character.Characteristic> characteristics = new List<Character.Characteristic>();

            foreach (var elem in parametres)
            {
                var paramValueTextBox = GetCharacteristicsValueTextBoxByName(elem.Key);

                var paramBonusTextBox = GetBonusValueTextBoxesByName(elem.Key);

                var characteristic = new Character.Characteristic(elem.Key, int.Parse(paramValueTextBox.Text), int.Parse(paramBonusTextBox.Text));

                characteristics.Add(characteristic);
            }

            int mastery = (int)numericUpDownMastery.Value;

            List<Character.Save> saves = new List<Character.Save>();

            foreach(var elem in parametres)
            {
                var checkBox = GetSaveCheckBoxByName(elem.Key);
                var value = GetSaveTextBoxesByName(elem.Key).Text;
                var paramName = elem.Key;

                saves.Add(new Character.Save(checkBox.Checked, value, paramName));
            }

            var aliveChecked = new bool[]
            {
                checkBoxAliveOne.Checked,
                checkBoxAliveTwo.Checked,
                checkBoxAliveThree.Checked
            };

            var deadChecked = new bool[]
            {
                checkBoxDeathOne.Checked,
                checkBoxDeathTwo.Checked,
                checkBoxDeathThree.Checked
            };

            var deadAlive = new Character.DeadAlive(aliveChecked, deadChecked);

            var weapons = new List<Character.Weapon>();

            foreach (DataGridViewRow elem in dataGridViewWeapons.Rows)
            {
                if (elem.Cells[0].Value != null)
                {
                    var weaponName = (elem.Cells[0].Value != null) ? elem.Cells[0].Value.ToString() : "";
                    var accuracy = (elem.Cells[1].Value != null) ? elem.Cells[1].Value.ToString() : "";
                    var damage = (elem.Cells[2].Value != null) ? elem.Cells[2].Value.ToString() : "";

                    weapons.Add(new Character.Weapon(weaponName, accuracy, damage));
                }
            }

            var abilities = new List<Character.Abilitiy>();

            foreach (DataGridViewRow elem in dataGridViewAbilities.Rows)
            {
                if (elem.Cells[0].Value != null)
                {
                    var abilityName = (elem.Cells[0].Value != null) ? elem.Cells[0].Value.ToString() : "";
                    var aboutAbility = (elem.Cells[1].Value != null) ? elem.Cells[1].Value.ToString() : "";
                    var textAbility = (elem.Cells[2].Value != null) ? elem.Cells[2].Value.ToString() : "";

                    abilities.Add(new Character.Abilitiy(abilityName, aboutAbility, textAbility));
                }
            }

            var equipments = new List<Character.Equipment>();

            foreach (DataGridViewRow elem in dataGridViewEquipment.Rows)
            {
                if (elem.Cells[0].Value != null)
                {
                    var equipmentName = (elem.Cells[0].Value != null) ? elem.Cells[0].Value.ToString() : "";
                    var equipmentAbout = (elem.Cells[1].Value != null) ? elem.Cells[1].Value.ToString() : "";

                    equipments.Add(new Character.Equipment(equipmentName, equipmentAbout));
                }
            }

            var skillList = new List<Character.Skill>();

            foreach(var elem in skills)
            {
                var cb = GetSkillCheckBoxByName(elem.Key);
                var val = GetSkillValueTextBoxByName(elem.Key);
                var tb = GetSkillNameTextBoxByName(elem.Key);

                skillList.Add(new Character.Skill(cb.Checked, int.Parse(val.Text), tb.Text));
            }

            var userName = textBoxUserName.Text;
            var classAndLevet = textBoxClassAndLevel.Text;
            var history = textBoxHistory.Text;
            var race = textBoxRace.Text;
            var god = textBoxGod.Text;
            var speed = (int)numericUpDownSpeed.Value;
            var traits = richTextBoxTraits.Text;
            var ideals = richTextBoxIdeals.Text;
            var attachment = richTextBoxAttachment.Text;
            var weakness = richTextBoxWeaknesses.Text;
            var maxHP = (int)numericUpDownMaximumHP.Value;
            var currentHP = (int)numericUpDownCurrentHP.Value;
            var timeHP = (int)numericUpDownTimeHp.Value;
            var boneHP = textBoxBoneHP.Text;
            var isCheckedBoneHP = checkBoxBoneHP.Checked;
            var languages = richTextBoxLanguages.Text;
            var passive = (int)numericUpDownPassive.Value;
            var XP = (int)numericUpDownXP.Value;
            var inspiration = checkBoxInspiration.Checked;
            var KD = (int)numericUpDownKD.Value;
            var initiative = (int)numericUpDownInitiative.Value;
            var copperMoney = (int)numericUpDownCopperMoney.Value;
            var silverMoney = (int)numericUpDownSilverMoney.Value;
            var electoMoney = (int)numericUpDownElectroMoney.Value;
            var goldMoney = (int)numericUpDownGoldMoney.Value;
            var platinumMoney = (int)numericUpDownPlatinumMoney.Value;

            var hist = richTextBoxHist.Text;

            List<Character.Talking> talkings = new List<Character.Talking>();

            foreach (DataGridViewRow elem in dataGridViewTalking.Rows)
            {
                if (elem.Cells[0].Value != null)
                {
                    var talkingName = (elem.Cells[0].Value != null) ? elem.Cells[0].Value.ToString() : "";
                    var talkingText = (elem.Cells[1].Value != null) ? elem.Cells[1].Value.ToString() : "";
                    var talkingAbout = (elem.Cells[2].Value != null) ? elem.Cells[2].Value.ToString() : "";

                    talkings.Add(new Character.Talking(talkingName, talkingAbout, talkingText));
                }
            }

            var spells = FillSpells();

            var spellCharacter = comboBoxBaseCharacter.SelectedItem.ToString();

            var spellBonus = textBoxSpellBonus.Text;
            var spellDifficult = textBoxDifficult.Text;

            var spellsAbout = richTextBoxSpellsAbout.Text;

            var character = new Character(name, characteristics, mastery, saves, skillList, deadAlive, weapons, abilities, equipments,
                userName, classAndLevet, history, race, god, speed, traits, ideals, attachment, weakness, maxHP, currentHP,
                timeHP, boneHP, isCheckedBoneHP, languages, passive, XP, inspiration, KD, initiative, copperMoney, silverMoney,
                electoMoney, goldMoney, platinumMoney, hist, talkings, spells, spellCharacter, spellBonus, spellDifficult, spellsAbout);

            var json = JsonConvert.SerializeObject(character);

            string path = Directory.GetCurrentDirectory() + "\\" + name;

            File.WriteAllText(path, json);

            if (!IsLoad)
            {
                Close();
            }
        }

        private Dictionary<int, Character.SpellsByLevel> FillSpells()
        {
            Dictionary<int, Character.SpellsByLevel> spells = new Dictionary<int, Character.SpellsByLevel>();

            var firstLevelSpells = GetSpellsByLevel("FirstSpellLevel");

            var firstCount = (int)numericUpDownFirstSpellLevelCount.Value;
            var firstUsed = (int)numericUpDownFirstSpellLevelUsed.Value;

            spells.Add(1, new Character.SpellsByLevel(firstCount, firstUsed, firstLevelSpells));

            var secondLevelSpells = GetSpellsByLevel("SecondSpellLevel");

            var secondCount = (int)numericUpDownSecondSpellLevelCount.Value;
            var secondUsed = (int)numericUpDownSecondSpellLevelUsed.Value;

            spells.Add(2, new Character.SpellsByLevel(secondCount, secondCount, secondLevelSpells));

            var thirdtLevelSpells = GetSpellsByLevel("ThirdSpellLevel");

            var thirdCount = (int)numericUpDownThirdSpellLevelCount.Value;
            var thirdUsed = (int)numericUpDownThirdSpellLevelUsed.Value;

            spells.Add(3, new Character.SpellsByLevel(thirdCount, thirdUsed, thirdtLevelSpells));

            var fourthLevelSpells = GetSpellsByLevel("FourthSpellLevel");

            var fourthCount = (int)numericUpDownFourthSpellLevelCount.Value;
            var fourthUsed = (int)numericUpDownFourthSpellLevelUsed.Value;

            spells.Add(4, new Character.SpellsByLevel(fourthCount, fourthUsed, fourthLevelSpells));

            var fifthLevelSpells = GetSpellsByLevel("FifthSpellLevel");

            var fifthCount = (int)numericUpDownFifthSpellLevelCount.Value;
            var fifthUsed = (int)numericUpDownFifthSpellLevelUsed.Value;

            spells.Add(5, new Character.SpellsByLevel(fifthCount, fifthUsed, fifthLevelSpells));

            var sixthLevelSpells = GetSpellsByLevel("SixthSpellLevel");

            var sixthCount = (int)numericUpDownSixthSpellLevelCount.Value;
            var sixthUsed = (int)numericUpDownSixthSpellLevelUsed.Value;

            spells.Add(6, new Character.SpellsByLevel(sixthCount, sixthUsed, sixthLevelSpells));

            var seventhLevelSpells = GetSpellsByLevel("SeventhSpellLevel");

            var seventhCount = (int)numericUpDownSeventhSpellLevelCount.Value;
            var seventhUsed = (int)numericUpDownSeventhSpellLevelUsed.Value;

            spells.Add(7, new Character.SpellsByLevel(seventhCount, seventhUsed, seventhLevelSpells));

            var eighthLevelSpells = GetSpellsByLevel("EighthSpellLevel");

            var eighthCount = (int)numericUpDownEighthSpellLevelCount.Value;
            var eighthUsed = (int)numericUpDownEighthSpellLevelUsed.Value;

            spells.Add(8, new Character.SpellsByLevel(eighthCount, eighthUsed, eighthLevelSpells));

            var ninthLevelSpells = GetSpellsByLevel("NinthSpellLevel");

            var ninthCount = (int)numericUpDownNinthSpellLevelCount.Value;
            var ninthUsed = (int)numericUpDownNinthSpellLevelUsed.Value;

            spells.Add(9, new Character.SpellsByLevel(ninthCount, ninthUsed, ninthLevelSpells));

            return spells;
        }

        private List<Character.Spell> GetSpellsByLevel(string level)
        {
            List<Character.Spell> spells = new List<Character.Spell>();

            try
            {
                DataGridView table = tabPageSpells.Controls.Find("dataGridView" + level, true)[0] as DataGridView;

                foreach(DataGridViewRow elem in table.Rows)
                {
                    if (elem.Cells[0].Value != null)
                    {
                        var isUsed = (elem.Cells[0].Value != null) ? elem.Cells[0].Value.ToString() : "";
                        var talkingName = (elem.Cells[1].Value != null) ? elem.Cells[1].Value.ToString() : "";
                        var talkingText = (elem.Cells[2].Value != null) ? elem.Cells[2].Value.ToString() : "";
                        var talkingAbout = (elem.Cells[3].Value != null) ? elem.Cells[3].Value.ToString() : "";

                        spells.Add(new Character.Spell(talkingName, talkingAbout, talkingText, isUsed));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return spells;
        }

        private void ChangeAllSaves()
        {
            foreach(var e in bonusValueTextBoxes)
            {
                var newValue = CalculateSave(e.Key);

                GetSaveTextBoxesByName(e.Key).Text = newValue.ToString();
            }
        }

        private void ChangeDifficult()
        {
            var baseCharValue = GetBonusValueTextBoxesByName(GetParametresByValue(comboBoxBaseCharacter.SelectedItem.ToString())).Text;
            var value = int.Parse(baseCharValue);

            if (value != int.MinValue)
            {
                int mastery = (int)numericUpDownMastery.Value;
                const int bonus = 8;

                textBoxDifficult.Text = (mastery + int.Parse(baseCharValue) + bonus).ToString();
            }
        }

        private void ChangeSpellBonus()
        {
            var baseCharValue = GetBonusValueTextBoxesByName(GetParametresByValue(comboBoxBaseCharacter.SelectedItem.ToString())).Text;
            var value = int.Parse(baseCharValue);

            if (value != int.MinValue)
            {
                int mastery = (int)numericUpDownMastery.Value;

                textBoxSpellBonus.Text = (mastery + int.Parse(baseCharValue)).ToString();
            }
        }

        private void NumericUpDownMastery_ValueChanged(object sender, EventArgs e)
        {
            ChangeAllSaves();
            ChangeAllSkills();
            ChangeDifficult();
            ChangeSpellBonus();
        }

        private void LoadCharacter()
        {
            try
            {
                var character = LoadedCharacter;
                var abilities = character.Abilities;
                foreach (var e in abilities)
                {
                    var index = dataGridViewAbilities.Rows.Add();

                    dataGridViewAbilities.Rows[index].Cells["ColumnAbilityName"].Value = e.Name;
                    dataGridViewAbilities.Rows[index].Cells["ColumnAbilityAbout"].Value = e.About;
                    dataGridViewAbilities.Rows[index].Cells["ColumnAbilityText"].Value = e.Text;
                }

                var attachment = character.Attachment;
                richTextBoxAttachment.Text = attachment;

                var boneHP = character.BoneHP;
                textBoxBoneHP.Text = boneHP;

                var characteristics = character.Characteristics;
                foreach(var e in characteristics)
                {
                    GetCharacteristicsValueTextBoxByName(e.Name.ToString()).Text = e.Value.ToString();
                }

                var classAndLevel = character.ClassAndLevel;
                textBoxClassAndLevel.Text = classAndLevel;
                
                var copperMoney = character.CopperMoney;
                numericUpDownCopperMoney.Value = int.Parse(copperMoney.ToString());

                var currentHP = character.CurrentHP;

                numericUpDownCurrentHP.Value = int.Parse(currentHP.ToString());

                var deadAndAlive = character.DeadAndAlive;

                foreach(var e in deadAndAlive)
                {
                    if (e.Name.Equals("Deathes"))
                    {
                        var deathes = e.Value;

                        int i = 0;
                        foreach(var d in deathes)
                        {
                            DeadCheckBoxes[i].Checked = d;
                            i++;
                        }
                    }
                    else if(e.Name.Equals("Alives"))
                    {
                        var alives = e.Value;

                        int i = 0;

                        foreach (var a in alives)
                        {
                            AliveCheckBoxes[i].Checked = a;
                            i++;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

                var electroMoney = character.ElectroMoney;
                numericUpDownElectroMoney.Value = int.Parse(electroMoney.ToString());

                var equipments = character.Equipments;
                foreach(var e in equipments)
                {
                    var index = dataGridViewEquipment.Rows.Add();

                    dataGridViewEquipment.Rows[index].Cells["ColumnEquipmentName"].Value = e.Name;
                    dataGridViewEquipment.Rows[index].Cells["ColumnEquipmentAbout"].Value = e.About;
                }

                var god = character.God;
                textBoxGod.Text = god;

                var goldMoney = character.GoldMoney;
                numericUpDownGoldMoney.Value = int.Parse(goldMoney.ToString());

                var hist = character.Hist;
                richTextBoxHist.Text = hist ?? "";

                var history = character.History;
                textBoxHistory.Text = history;

                var ideals = character.Ideals;
                richTextBoxIdeals.Text = ideals;

                var initiative = character.Initiative;
                numericUpDownInitiative.Value = int.Parse(initiative.ToString());

                var inspiration = character.Inspiration;
                checkBoxInspiration.Checked = inspiration;

                var isCheckedBoneHP = character.IsCheckedBoneHP;
                checkBoxBoneHP.Checked = isCheckedBoneHP;

                var KD = character.KD;
                numericUpDownKD.Value = int.Parse(KD.ToString());

                var languages = character.Languages;
                richTextBoxLanguages.Text = languages;

                var mastery = character.Mastery;
                numericUpDownMastery.Value = int.Parse(mastery.ToString());

                var maxHP = character.MaxHP;
                numericUpDownMaximumHP.Value = int.Parse(maxHP.ToString());

                var name = character.Name;
                textBoxName.Text = name;

                var passive = character.Passive;
                numericUpDownPassive.Value = int.Parse(passive.ToString());

                var platinumMoney = character.PlatinumMoney;
                numericUpDownPlatinumMoney.Value = int.Parse(platinumMoney.ToString());

                var race = character.Race;
                textBoxRace.Text = race;

                var saves = character.Saves;
                foreach(var e in saves)
                {
                    var saveName = e.Name.ToString();
                    GetSaveCheckBoxByName(saveName).Checked = bool.Parse(e.IsChecked.ToString());
                }

                var skills = character.Skills;
                foreach(var e in skills)
                {
                    var n = e.Name.ToString();
                    n = n.Substring(0, n.IndexOf('(') - 1);
                    GetSkillCheckBoxByName(n).Checked = bool.Parse(e.IsChecked.ToString());
                }

                var silverMoney = character.SilverMoney;
                numericUpDownSilverMoney.Value = int.Parse(silverMoney.ToString());

                var speed = character.Speed;
                numericUpDownSpeed.Value = int.Parse(speed.ToString());

                var timeHP = character.TimeHP;
                numericUpDownTimeHp.Value = int.Parse(timeHP.ToString());

                var traits = character.Traits;
                richTextBoxTraits.Text = traits;

                var userName = character.UserName;
                textBoxUserName.Text = userName;

                var weaknesses = character.Weaknesses;
                richTextBoxWeaknesses.Text = weaknesses;

                var weapons = character.Weapons;
                foreach(var e in weapons)
                {
                    var index = dataGridViewWeapons.Rows.Add();

                    dataGridViewWeapons.Rows[index].Cells["ColumnWeaponName"].Value = e.Name;
                    dataGridViewWeapons.Rows[index].Cells["ColumnWeaponAccuracy"].Value = e.Accuracy;
                    dataGridViewWeapons.Rows[index].Cells["ColumnWeaponDamage"].Value = e.Damage;
                }

                var XP = character.XP;
                numericUpDownXP.Value = int.Parse(XP.ToString());

                var spellBaseCharacteristic = character.SpellCharacter.ToString();
                comboBoxBaseCharacter.SelectedItem = spellBaseCharacteristic;

                var spellsAbout = character.SpellsAbout;
                richTextBoxSpellsAbout.Text = spellsAbout;

                var talkings = character.Talkings;
                foreach(var e in talkings)
                {
                    var index = dataGridViewTalking.Rows.Add();

                    dataGridViewTalking.Rows[index].Cells["ColumnTalkingName"].Value = e.Name;
                    dataGridViewTalking.Rows[index].Cells["ColumnTalkingText"].Value = e.Text;
                    dataGridViewTalking.Rows[index].Cells["ColumnTalkingAbout"].Value = e.About;
                }

                var spells = character.Spells;
                foreach(var e in spells)
                {
                    var level = int.Parse(e.Name);

                    switch (level)
                    {
                        case 1:
                            {
                                var spellsByLevel = e.Value;

                                var count = spellsByLevel.Count;
                                var used = spellsByLevel.Used;
                                var spellList = spellsByLevel.Spells;

                                numericUpDownFirstSpellLevelCount.Value = count;
                                numericUpDownFirstSpellLevelUsed.Value = used;

                                FillSpellsTable(dataGridViewFirstSpellLevel, spellList);

                                break;
                            }
                        case 2:
                            {
                                var spellsByLevel = e.Value;

                                var count = spellsByLevel.Count;
                                var used = spellsByLevel.Used;
                                var spellList = spellsByLevel.Spells;

                                numericUpDownSecondSpellLevelCount.Value = count;
                                numericUpDownSecondSpellLevelUsed.Value = used;

                                FillSpellsTable(dataGridViewSecondSpellLevel, spellList);

                                break;
                            }
                        case 3:
                            {
                                var spellsByLevel = e.Value;

                                var count = spellsByLevel.Count;
                                var used = spellsByLevel.Used;
                                var spellList = spellsByLevel.Spells;

                                numericUpDownThirdSpellLevelCount.Value = count;
                                numericUpDownThirdSpellLevelUsed.Value = used;

                                FillSpellsTable(dataGridViewThirdSpellLevel, spellList);

                                break;
                            }
                        case 4:
                            {
                                var spellsByLevel = e.Value;

                                var count = spellsByLevel.Count;
                                var used = spellsByLevel.Used;
                                var spellList = spellsByLevel.Spells;

                                numericUpDownFourthSpellLevelCount.Value = count;
                                numericUpDownFourthSpellLevelUsed.Value = used;

                                FillSpellsTable(dataGridViewFourthSpellLevel, spellList);

                                break;
                            }
                        case 5:
                            {
                                var spellsByLevel = e.Value;

                                var count = spellsByLevel.Count;
                                var used = spellsByLevel.Used;
                                var spellList = spellsByLevel.Spells;

                                numericUpDownFifthSpellLevelCount.Value = count;
                                numericUpDownFifthSpellLevelUsed.Value = used;

                                FillSpellsTable(dataGridViewFifthSpellLevel, spellList);

                                break;
                            }
                        case 6:
                            {
                                var spellsByLevel = e.Value;

                                var count = spellsByLevel.Count;
                                var used = spellsByLevel.Used;
                                var spellList = spellsByLevel.Spells;

                                numericUpDownSixthSpellLevelCount.Value = count;
                                numericUpDownSixthSpellLevelUsed.Value = used;

                                FillSpellsTable(dataGridViewSixthSpellLevel, spellList);

                                break;
                            }
                        case 7:
                            {
                                var spellsByLevel = e.Value;

                                var count = spellsByLevel.Count;
                                var used = spellsByLevel.Used;
                                var spellList = spellsByLevel.Spells;

                                numericUpDownSeventhSpellLevelCount.Value = count;
                                numericUpDownSeventhSpellLevelUsed.Value = used;

                                FillSpellsTable(dataGridViewSeventhSpellLevel, spellList);

                                break;
                            }
                        case 8:
                            {
                                var spellsByLevel = e.Value;

                                var count = spellsByLevel.Count;
                                var used = spellsByLevel.Used;
                                var spellList = spellsByLevel.Spells;

                                numericUpDownEighthSpellLevelCount.Value = count;
                                numericUpDownEighthSpellLevelUsed.Value = used;

                                FillSpellsTable(dataGridViewEighthSpellLevel, spellList);

                                break;
                            }
                        case 9:
                            {
                                var spellsByLevel = e.Value;

                                var count = spellsByLevel.Count;
                                var used = spellsByLevel.Used;
                                var spellList = spellsByLevel.Spells;

                                numericUpDownNinthSpellLevelCount.Value = count;
                                numericUpDownNinthSpellLevelUsed.Value = used;

                                FillSpellsTable(dataGridViewNinthSpellLevel, spellList);

                                break;
                            }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Close();
            }
        }

        private void FillSpellsTable(DataGridView table, dynamic spellList)
        {
            foreach (var s in spellList)
            {
                var isUsed = s.IsUsed;
                var nameSpell = s.Name;
                var text = s.Text;
                var aboutSpell = s.About;

                var index = table.Rows.Add();

                table.Rows[index].Cells[0].Value = isUsed;
                table.Rows[index].Cells[1].Value = nameSpell;
                table.Rows[index].Cells[2].Value = text;
                table.Rows[index].Cells[3].Value = aboutSpell;
            }
        }

        private void ComboBoxBaseCharacter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDifficult();
            ChangeSpellBonus();
        }

        private class ChangeCharacter
        {
            public string UserName { get; set; }
            public string ValueName;
            public dynamic Value;
            public string Action;

            public ChangeCharacter(string userName, string valueName, dynamic value)
            {
                UserName = userName;
                ValueName = valueName;
                Value = value;
                Action = "Change";
            }
        }

        private void SendChange(string value, object val)
        {
            try
            {
                Task.Factory.StartNew(() =>
                    CharacterEthernetController.GetController().SendRequest("POST", JsonConvert.SerializeObject(new ChangeCharacter(Controller.Controller.UserName, value, val)))
                );
            }
            catch { }
        }

        private void NumericUpDownXP_ValueChanged(object sender, EventArgs e)
        {
            SendChange("XP", numericUpDownXP.Value);
        }

        private void NumericUpDownCurrentHP_ValueChanged(object sender, EventArgs e)
        {
            SendChange("Current HP", numericUpDownCurrentHP.Value);
        }

        private void NumericUpDownTimeHp_ValueChanged(object sender, EventArgs e)
        {
            SendChange("Time HP", numericUpDownTimeHp.Value);
        }

        private void CheckBoxBoneHP_CheckedChanged(object sender, EventArgs e)
        {
            SendChange("CheckBox Bone HP", checkBoxBoneHP.Checked);
        }

        private void CheckBoxAliveOne_CheckedChanged(object sender, EventArgs e)
        {
            SendChange("CheckBox Alive One", checkBoxAliveOne.Checked);
        }

        private void CheckBoxAliveTwo_CheckedChanged(object sender, EventArgs e)
        {
            SendChange("CheckBox Alive Two", checkBoxAliveTwo.Checked);
        }

        private void CheckBoxAliveThree_CheckedChanged(object sender, EventArgs e)
        {
            SendChange("CheckBox Alive Three", checkBoxAliveThree.Checked);
        }

        private void CheckBoxDeathOne_CheckedChanged(object sender, EventArgs e)
        {
            SendChange("CheckBox Death One", checkBoxDeathOne.Checked);
        }

        private void CheckBoxDeathTwo_CheckedChanged(object sender, EventArgs e)
        {
            SendChange("CheckBox Death Two", checkBoxDeathTwo.Checked);
        }

        private void CheckBoxDeathThree_CheckedChanged(object sender, EventArgs e)
        {
            SendChange("CheckBox Death Three", checkBoxDeathThree.Checked);
        }

        private void NumericUpDownCopperMoney_ValueChanged(object sender, EventArgs e)
        {
            SendChange("Copper", numericUpDownCopperMoney.Value);
        }

        private void NumericUpDownSilverMoney_ValueChanged(object sender, EventArgs e)
        {
            SendChange("Silver", numericUpDownSilverMoney.Value);
        }

        private void NumericUpDownElectroMoney_ValueChanged(object sender, EventArgs e)
        {
            SendChange("Electro", numericUpDownElectroMoney.Value);
        }

        private void NumericUpDownGoldMoney_ValueChanged(object sender, EventArgs e)
        {
            SendChange("Gold", numericUpDownGoldMoney.Value);
        }

        private void NumericUpDownPlatinumMoney_ValueChanged(object sender, EventArgs e)
        {
            SendChange("Platinum", numericUpDownPlatinumMoney.Value);
        }

        private void DataGridViewWeapons_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //TODO
        }

        private void DataGridViewAbilities_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //TODO
        }

        private void DataGridViewEquipment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //TODO
        }

        private void CheckBoxInspiration_CheckedChanged(object sender, EventArgs e)
        {
            SendChange("Inspiration", checkBoxInspiration.Checked);
        }

        internal void ChangeValues(dynamic value)
        {
            throw new Exception();
        }
    }
}