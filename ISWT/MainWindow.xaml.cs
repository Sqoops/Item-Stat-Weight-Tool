using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
namespace ISWT
{
    public partial class MainWindow : Window
    {
        public static CultureInfo cultureInfo = new CultureInfo("en-US");
        private Dictionary<string, List<Armor>> headArmors = new Dictionary<string, List<Armor>>();
        private Dictionary<string, List<Armor>> neckArmors = new Dictionary<string, List<Armor>>();
        private Dictionary<string, List<Armor>> shouldersArmors = new Dictionary<string, List<Armor>>();
        private Dictionary<string, List<Armor>> backArmors = new Dictionary<string, List<Armor>>();
        private Dictionary<string, List<Armor>> chestArmors = new Dictionary<string, List<Armor>>();
        private Dictionary<string, List<Armor>> wristArmors = new Dictionary<string, List<Armor>>();
        private Dictionary<string, List<Armor>> handsArmors = new Dictionary<string, List<Armor>>();
        private Dictionary<string, List<Armor>> waistArmors = new Dictionary<string, List<Armor>>();
        private Dictionary<string, List<Armor>> legsArmors = new Dictionary<string, List<Armor>>();
        private Dictionary<string, List<Armor>> feetArmors = new Dictionary<string, List<Armor>>();
        private Dictionary<string, List<Armor>> fingerArmors = new Dictionary<string, List<Armor>>();
        private Dictionary<string, List<Armor>> trinketArmors = new Dictionary<string, List<Armor>>();
        private bool canSearch = true;
        private int resultSize = 15;
        public MainWindow()
        {
            InitializeComponent();
            LoadArmors();
            LoadEnchants();
            SortArmors();
            AddArmorToolTipTriggers();
        }
        private void AddArmorToolTipTriggers()
        {
            for (int i = 0; i < 14; i++)
            {
                Trigger armorToolTipTrigger = new Trigger();
                armorToolTipTrigger.Property = DataGridCell.IsMouseOverProperty;
                armorToolTipTrigger.Value = true;
                switch (i)
                {
                    case 0:
                        armorToolTipTrigger.Setters.Add(new Setter(DataGridCell.ToolTipProperty, new Binding("HeadArmorToolTip")));
                        break;
                    case 1:
                        armorToolTipTrigger.Setters.Add(new Setter(DataGridCell.ToolTipProperty, new Binding("NeckArmorToolTip")));
                        break;
                    case 2:
                        armorToolTipTrigger.Setters.Add(new Setter(DataGridCell.ToolTipProperty, new Binding("ShouldersArmorToolTip")));
                        break;
                    case 3:
                        armorToolTipTrigger.Setters.Add(new Setter(DataGridCell.ToolTipProperty, new Binding("BackArmorToolTip")));
                        break;
                    case 4:
                        armorToolTipTrigger.Setters.Add(new Setter(DataGridCell.ToolTipProperty, new Binding("ChestArmorToolTip")));
                        break;
                    case 5:
                        armorToolTipTrigger.Setters.Add(new Setter(DataGridCell.ToolTipProperty, new Binding("WristArmorToolTip")));
                        break;
                    case 6:
                        armorToolTipTrigger.Setters.Add(new Setter(DataGridCell.ToolTipProperty, new Binding("HandsArmorToolTip")));
                        break;
                    case 7:
                        armorToolTipTrigger.Setters.Add(new Setter(DataGridCell.ToolTipProperty, new Binding("WaistArmorToolTip")));
                        break;
                    case 8:
                        armorToolTipTrigger.Setters.Add(new Setter(DataGridCell.ToolTipProperty, new Binding("LegsArmorToolTip")));
                        break;
                    case 9:
                        armorToolTipTrigger.Setters.Add(new Setter(DataGridCell.ToolTipProperty, new Binding("FeetArmorToolTip")));
                        break;
                    case 10:
                        armorToolTipTrigger.Setters.Add(new Setter(DataGridCell.ToolTipProperty, new Binding("FingerArmorToolTip")));
                        break;
                    case 11:
                        armorToolTipTrigger.Setters.Add(new Setter(DataGridCell.ToolTipProperty, new Binding("Finger2ArmorToolTip")));
                        break;
                    case 12:
                        armorToolTipTrigger.Setters.Add(new Setter(DataGridCell.ToolTipProperty, new Binding("TrinketArmorToolTip")));
                        break;
                    case 13:
                        armorToolTipTrigger.Setters.Add(new Setter(DataGridCell.ToolTipProperty, new Binding("Trinket2ArmorToolTip")));
                        break;
                }
                Style cellStyle = new Style(typeof(DataGridCell), dataGrid1.Columns[i].CellStyle);
                cellStyle.Triggers.Add(armorToolTipTrigger);
                dataGrid1.Columns[i].CellStyle = cellStyle;
            }
        }
        private void SortArmors()
        {
            foreach (KeyValuePair<string, List<Armor>> kvp in headArmors)
                kvp.Value.Sort((Armor a1, Armor a2) => { return 0; });
            foreach (KeyValuePair<string, List<Armor>> kvp in neckArmors)
                kvp.Value.Sort((Armor a1, Armor a2) => { return 0; });
            foreach (KeyValuePair<string, List<Armor>> kvp in shouldersArmors)
                kvp.Value.Sort((Armor a1, Armor a2) => { return 0; });
            foreach (KeyValuePair<string, List<Armor>> kvp in backArmors)
                kvp.Value.Sort((Armor a1, Armor a2) => { return 0; });
            foreach (KeyValuePair<string, List<Armor>> kvp in chestArmors)
                kvp.Value.Sort((Armor a1, Armor a2) => { return 0; });
            foreach (KeyValuePair<string, List<Armor>> kvp in wristArmors)
                kvp.Value.Sort((Armor a1, Armor a2) => { return 0; });
            foreach (KeyValuePair<string, List<Armor>> kvp in handsArmors)
                kvp.Value.Sort((Armor a1, Armor a2) => { return 0; });
            foreach (KeyValuePair<string, List<Armor>> kvp in waistArmors)
                kvp.Value.Sort((Armor a1, Armor a2) => { return 0; });
            foreach (KeyValuePair<string, List<Armor>> kvp in legsArmors)
                kvp.Value.Sort((Armor a1, Armor a2) => { return 0; });
            foreach (KeyValuePair<string, List<Armor>> kvp in feetArmors)
                kvp.Value.Sort((Armor a1, Armor a2) => { return 0; });
            foreach (KeyValuePair<string, List<Armor>> kvp in fingerArmors)
                kvp.Value.Sort((Armor a1, Armor a2) => { return 0; });
            foreach (KeyValuePair<string, List<Armor>> kvp in trinketArmors)
                kvp.Value.Sort((Armor a1, Armor a2) => { return 0; });
        }
        private void LoadArmors()
        {
            AddArmorToDictionary(new Armor("<No Armor>", Armor.EquipLocation.Head, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""));
            AddArmorToDictionary(new Armor("<No Armor>", Armor.EquipLocation.Neck, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""));
            AddArmorToDictionary(new Armor("<No Armor>", Armor.EquipLocation.Shoulders, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""));
            AddArmorToDictionary(new Armor("<No Armor>", Armor.EquipLocation.Back, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""));
            AddArmorToDictionary(new Armor("<No Armor>", Armor.EquipLocation.Chest, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""));
            AddArmorToDictionary(new Armor("<No Armor>", Armor.EquipLocation.Wrist, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""));
            AddArmorToDictionary(new Armor("<No Armor>", Armor.EquipLocation.Hands, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""));
            AddArmorToDictionary(new Armor("<No Armor>", Armor.EquipLocation.Waist, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""));
            AddArmorToDictionary(new Armor("<No Armor>", Armor.EquipLocation.Legs, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""));
            AddArmorToDictionary(new Armor("<No Armor>", Armor.EquipLocation.Feet, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""));
            AddArmorToDictionary(new Armor("<No Armor>", Armor.EquipLocation.Finger, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""));
            AddArmorToDictionary(new Armor("<No Armor>", Armor.EquipLocation.Trinket, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ""));
            string currentArmorName = "";
            Armor.EquipLocation currentEquippedLocation = Armor.EquipLocation.Head;
            using (StreamReader reader = new StreamReader("Items.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    {
                        try
                        {
                            if (line.Length > 0 && !line.StartsWith("//") && !line.StartsWith("Slot") && !line.StartsWith("StatWeight"))
                            {
                                string[] split = line.Split('\t');
                                switch (split[0])
                                {
                                    case "Head": currentEquippedLocation = Armor.EquipLocation.Head; break;
                                    case "head": currentEquippedLocation = Armor.EquipLocation.Head; break;
                                    case "Neck": currentEquippedLocation = Armor.EquipLocation.Neck; break;
                                    case "neck": currentEquippedLocation = Armor.EquipLocation.Neck; break;
                                    case "Shoulders": currentEquippedLocation = Armor.EquipLocation.Shoulders; break;
                                    case "shoulders": currentEquippedLocation = Armor.EquipLocation.Shoulders; break;
                                    case "Back": currentEquippedLocation = Armor.EquipLocation.Back; break;
                                    case "back": currentEquippedLocation = Armor.EquipLocation.Back; break;
                                    case "Cloak": currentEquippedLocation = Armor.EquipLocation.Back; break;
                                    case "cloak": currentEquippedLocation = Armor.EquipLocation.Back; break;
                                    case "Chest": currentEquippedLocation = Armor.EquipLocation.Chest; break;
                                    case "chest": currentEquippedLocation = Armor.EquipLocation.Chest; break;
                                    case "Wrist": currentEquippedLocation = Armor.EquipLocation.Wrist; break;
                                    case "wrist": currentEquippedLocation = Armor.EquipLocation.Wrist; break;
                                    case "Hands": currentEquippedLocation = Armor.EquipLocation.Hands; break;
                                    case "hands": currentEquippedLocation = Armor.EquipLocation.Hands; break;
                                    case "Gloves": currentEquippedLocation = Armor.EquipLocation.Hands; break;
                                    case "gloves": currentEquippedLocation = Armor.EquipLocation.Hands; break;
                                    case "Waist": currentEquippedLocation = Armor.EquipLocation.Waist; break;
                                    case "waist": currentEquippedLocation = Armor.EquipLocation.Waist; break;
                                    case "Belt": currentEquippedLocation = Armor.EquipLocation.Waist; break;
                                    case "belt": currentEquippedLocation = Armor.EquipLocation.Waist; break;
                                    case "Legs": currentEquippedLocation = Armor.EquipLocation.Legs; break;
                                    case "legs": currentEquippedLocation = Armor.EquipLocation.Legs; break;
                                    case "Feet": currentEquippedLocation = Armor.EquipLocation.Feet; break;
                                    case "feet": currentEquippedLocation = Armor.EquipLocation.Feet; break;
                                    case "Boots": currentEquippedLocation = Armor.EquipLocation.Feet; break;
                                    case "boots": currentEquippedLocation = Armor.EquipLocation.Feet; break;
                                    case "Finger": currentEquippedLocation = Armor.EquipLocation.Finger; break;
                                    case "finger": currentEquippedLocation = Armor.EquipLocation.Finger; break;
                                    case "Ring": currentEquippedLocation = Armor.EquipLocation.Finger; break;
                                    case "ring": currentEquippedLocation = Armor.EquipLocation.Finger; break;
                                    case "Trinket": currentEquippedLocation = Armor.EquipLocation.Trinket; break;
                                    case "trinket": currentEquippedLocation = Armor.EquipLocation.Trinket; break;
                                }
                                currentArmorName = split[1];
                                float strength = 0f;
                                float agility = 0f;
                                float stamina = 0f;
                                float intellect = 0f;
                                float spirit = 0f;
                                float armorvalue = 0f;
                                float arcaneresistance = 0f;
                                float fireresistance = 0f;
                                float natureresistance = 0f;
                                float frostresistance = 0f;
                                float shadowresistance = 0f;
                                float attackpower = 0f;
                                float attackspeed = 0f;
                                float blockchance = 0f;
                                float blockvalue = 0f;
                                float critchance = 0f;
                                float damage = 0f;
                                float defense = 0f;
                                float dodgechance = 0f;
                                float healing = 0f;
                                float health = 0f;
                                float hitchance = 0f;
                                float hp5 = 0f;
                                float mana = 0f;
                                float mp5 = 0f;
                                float parrychance = 0f;
                                float reflect = 0f;
                                if (split.Length > 2 && split[2].Length > 0) { strength = float.Parse(split[2], cultureInfo); }
                                if (split.Length > 3 && split[3].Length > 0) { agility = float.Parse(split[3], cultureInfo); }
                                if (split.Length > 4 && split[4].Length > 0) { stamina = float.Parse(split[4], cultureInfo); }
                                if (split.Length > 5 && split[5].Length > 0) { intellect = float.Parse(split[5], cultureInfo); }
                                if (split.Length > 6 && split[6].Length > 0) { spirit = float.Parse(split[6], cultureInfo); }
                                if (split.Length > 7 && split[7].Length > 0) { armorvalue = float.Parse(split[7], cultureInfo); }
                                if (split.Length > 8 && split[8].Length > 0) { arcaneresistance = float.Parse(split[8], cultureInfo); }
                                if (split.Length > 9 && split[9].Length > 0) { fireresistance = float.Parse(split[9], cultureInfo); }
                                if (split.Length > 10 && split[10].Length > 0) { natureresistance = float.Parse(split[10], cultureInfo); }
                                if (split.Length > 11 && split[11].Length > 0) { frostresistance = float.Parse(split[11], cultureInfo); }
                                if (split.Length > 12 && split[12].Length > 0) { shadowresistance = float.Parse(split[12], cultureInfo); }
                                if (split.Length > 13 && split[13].Length > 0) { attackpower = float.Parse(split[13], cultureInfo); }
                                if (split.Length > 14 && split[14].Length > 0) { attackspeed = float.Parse(split[14], cultureInfo); }
                                if (split.Length > 15 && split[15].Length > 0) { blockchance = float.Parse(split[15], cultureInfo); }
                                if (split.Length > 16 && split[16].Length > 0) { blockvalue = float.Parse(split[16], cultureInfo); }
                                if (split.Length > 17 && split[17].Length > 0) { critchance = float.Parse(split[17], cultureInfo); }
                                if (split.Length > 18 && split[18].Length > 0) { damage = float.Parse(split[18], cultureInfo); }
                                if (split.Length > 19 && split[19].Length > 0) { defense = float.Parse(split[19], cultureInfo); }
                                if (split.Length > 20 && split[20].Length > 0) { dodgechance = float.Parse(split[20], cultureInfo); }
                                if (split.Length > 21 && split[21].Length > 0) { healing = float.Parse(split[21], cultureInfo); }
                                if (split.Length > 22 && split[22].Length > 0) { health = float.Parse(split[22], cultureInfo); }
                                if (split.Length > 23 && split[23].Length > 0) { hitchance = float.Parse(split[23], cultureInfo); }
                                if (split.Length > 24 && split[24].Length > 0) { hp5 = float.Parse(split[24], cultureInfo); }
                                if (split.Length > 25 && split[25].Length > 0) { mana = float.Parse(split[25], cultureInfo); }
                                if (split.Length > 26 && split[26].Length > 0) { mp5 = float.Parse(split[26], cultureInfo); }
                                if (split.Length > 27 && split[27].Length > 0) { parrychance = float.Parse(split[27], cultureInfo); }
                                if (split.Length > 28 && split[28].Length > 0) { reflect = float.Parse(split[28], cultureInfo); }
                                Armor armor = new Armor(currentArmorName, currentEquippedLocation, strength, agility, stamina, intellect,
                                spirit, armorvalue, arcaneresistance, fireresistance, natureresistance, frostresistance, shadowresistance,
                                attackpower, attackspeed, blockchance, blockvalue, critchance, damage, defense, dodgechance,
                                healing, health, hitchance, hp5, mana, mp5, parrychance, reflect, "");
                                AddArmorToDictionary(armor);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("One or more lines in the Items.txt file are broken.\nMake sure you have enough columns, the right order and the correct format.");
                            throw ex;
                        }
                        try
                        {
                            if (line.Length > 0 && line.StartsWith("StatWeight"))
                            {
                                string[] split = line.Split('\t');
                                if (split.Length > 2 && split[2].Length > 0) { textBoxWeightStrength.Text = (split[2].Replace(",", ".")); }
                                if (split.Length > 3 && split[3].Length > 0) { textBoxWeightAgility.Text = (split[3].Replace(",", ".")); }
                                if (split.Length > 4 && split[4].Length > 0) { textBoxWeightStamina.Text = (split[4].Replace(",", ".")); }
                                if (split.Length > 5 && split[5].Length > 0) { textBoxWeightIntellect.Text = (split[5].Replace(",", ".")); }
                                if (split.Length > 6 && split[6].Length > 0) { textBoxWeightSpirit.Text = (split[6].Replace(",", ".")); }
                                if (split.Length > 7 && split[7].Length > 0) { textBoxWeightArmorvalue.Text = (split[7].Replace(",", ".")); }
                                if (split.Length > 8 && split[8].Length > 0) { textBoxWeightArcaneresistance.Text = (split[8].Replace(",", ".")); }
                                if (split.Length > 9 && split[9].Length > 0) { textBoxWeightFireresistance.Text = (split[9].Replace(",", ".")); }
                                if (split.Length > 10 && split[10].Length > 0) { textBoxWeightNatureresistance.Text = (split[10].Replace(",", ".")); }
                                if (split.Length > 11 && split[11].Length > 0) { textBoxWeightFrostresistance.Text = (split[11].Replace(",", ".")); }
                                if (split.Length > 12 && split[12].Length > 0) { textBoxWeightShadowresistance.Text = (split[12].Replace(",", ".")); }
                                if (split.Length > 13 && split[13].Length > 0) { textBoxWeightAttackpower.Text = (split[13].Replace(",", ".")); }
                                if (split.Length > 14 && split[14].Length > 0) { textBoxWeightAttackspeed.Text = (split[14].Replace(",", ".")); }
                                if (split.Length > 15 && split[15].Length > 0) { textBoxWeightBlockchance.Text = (split[15].Replace(",", ".")); }
                                if (split.Length > 16 && split[16].Length > 0) { textBoxWeightBlockvalue.Text = (split[16].Replace(",", ".")); }
                                if (split.Length > 17 && split[17].Length > 0) { textBoxWeightCritchance.Text = (split[17].Replace(",", ".")); }
                                if (split.Length > 18 && split[18].Length > 0) { textBoxWeightDamage.Text = (split[18].Replace(",", ".")); }
                                if (split.Length > 19 && split[19].Length > 0) { textBoxWeightDefense.Text = (split[19].Replace(",", ".")); }
                                if (split.Length > 20 && split[20].Length > 0) { textBoxWeightDodgechance.Text = (split[20].Replace(",", ".")); }
                                if (split.Length > 21 && split[21].Length > 0) { textBoxWeightHealing.Text = (split[21].Replace(",", ".")); }
                                if (split.Length > 22 && split[22].Length > 0) { textBoxWeightHealth.Text = (split[22].Replace(",", ".")); }
                                if (split.Length > 23 && split[23].Length > 0) { textBoxWeightHitchance.Text = (split[23].Replace(",", ".")); }
                                if (split.Length > 24 && split[24].Length > 0) { textBoxWeightHp5.Text = (split[24].Replace(",", ".")); }
                                if (split.Length > 25 && split[25].Length > 0) { textBoxWeightMana.Text = (split[25].Replace(",", ".")); }
                                if (split.Length > 26 && split[26].Length > 0) { textBoxWeightMp5.Text = (split[26].Replace(",", ".")); }
                                if (split.Length > 27 && split[27].Length > 0) { textBoxWeightParrychance.Text = (split[27].Replace(",", ".")); }
                                if (split.Length > 28 && split[28].Length > 0) { textBoxWeightReflect.Text = (split[28].Replace(",", ".")); }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("The StatWeight line in the Items.txt file is broken.\nMake sure you have enough columns and the right format.\n',' gets automatically changed into '.'");
                            throw ex;
                        }
                    }
                }
            }
        }
        private void LoadEnchants()
        {
            List<Armor> headCandidates = new List<Armor>();
            List<Armor> neckCandidates = new List<Armor>();
            List<Armor> shouldersCandidates = new List<Armor>();
            List<Armor> backCandidates = new List<Armor>();
            List<Armor> chestCandidates = new List<Armor>();
            List<Armor> wristCandidates = new List<Armor>();
            List<Armor> handsCandidates = new List<Armor>();
            List<Armor> waistCandidates = new List<Armor>();
            List<Armor> legsCandidates = new List<Armor>();
            List<Armor> feetCandidates = new List<Armor>();
            List<Armor> fingerCandidates = new List<Armor>();
            List<Armor> trinketCandidates = new List<Armor>();
            AddArmorCandidates(headArmors, headCandidates);
            AddArmorCandidates(neckArmors, neckCandidates);
            AddArmorCandidates(shouldersArmors, shouldersCandidates);
            AddArmorCandidates(backArmors, backCandidates);
            AddArmorCandidates(chestArmors, chestCandidates);
            AddArmorCandidates(wristArmors, wristCandidates);
            AddArmorCandidates(handsArmors, handsCandidates);
            AddArmorCandidates(waistArmors, waistCandidates);
            AddArmorCandidates(legsArmors, legsCandidates);
            AddArmorCandidates(feetArmors, feetCandidates);
            AddArmorCandidates(fingerArmors, fingerCandidates);
            AddArmorCandidates(trinketArmors, trinketCandidates);
            string currentEnchantName = "";
            using (StreamReader reader = new StreamReader("Enchants.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    {
                        try
                        {
                            if (line.Length > 0 && !line.StartsWith("//") && !line.StartsWith("Slot") && !line.StartsWith("StatWeight"))
                            {
                                string[] split = line.Split('\t');
                                currentEnchantName = split[1];
                                float strength = 0f;
                                float agility = 0f;
                                float stamina = 0f;
                                float intellect = 0f;
                                float spirit = 0f;
                                float armorvalue = 0f;
                                float arcaneresistance = 0f;
                                float fireresistance = 0f;
                                float natureresistance = 0f;
                                float frostresistance = 0f;
                                float shadowresistance = 0f;
                                float attackpower = 0f;
                                float attackspeed = 0f;
                                float blockchance = 0f;
                                float blockvalue = 0f;
                                float critchance = 0f;
                                float damage = 0f;
                                float defense = 0f;
                                float dodgechance = 0f;
                                float healing = 0f;
                                float health = 0f;
                                float hitchance = 0f;
                                float hp5 = 0f;
                                float mana = 0f;
                                float mp5 = 0f;
                                float parrychance = 0f;
                                float reflect = 0f;
                                if (split.Length > 2 && split[2].Length > 0) { strength = float.Parse(split[2], cultureInfo); }
                                if (split.Length > 3 && split[3].Length > 0) { agility = float.Parse(split[3], cultureInfo); }
                                if (split.Length > 4 && split[4].Length > 0) { stamina = float.Parse(split[4], cultureInfo); }
                                if (split.Length > 5 && split[5].Length > 0) { intellect = float.Parse(split[5], cultureInfo); }
                                if (split.Length > 6 && split[6].Length > 0) { spirit = float.Parse(split[6], cultureInfo); }
                                if (split.Length > 7 && split[7].Length > 0) { armorvalue = float.Parse(split[7], cultureInfo); }
                                if (split.Length > 8 && split[8].Length > 0) { arcaneresistance = float.Parse(split[8], cultureInfo); }
                                if (split.Length > 9 && split[9].Length > 0) { fireresistance = float.Parse(split[9], cultureInfo); }
                                if (split.Length > 10 && split[10].Length > 0) { natureresistance = float.Parse(split[10], cultureInfo); }
                                if (split.Length > 11 && split[11].Length > 0) { frostresistance = float.Parse(split[11], cultureInfo); }
                                if (split.Length > 12 && split[12].Length > 0) { shadowresistance = float.Parse(split[12], cultureInfo); }
                                if (split.Length > 13 && split[13].Length > 0) { attackpower = float.Parse(split[13], cultureInfo); }
                                if (split.Length > 14 && split[14].Length > 0) { attackspeed = float.Parse(split[14], cultureInfo); }
                                if (split.Length > 15 && split[15].Length > 0) { blockchance = float.Parse(split[15], cultureInfo); }
                                if (split.Length > 16 && split[16].Length > 0) { blockvalue = float.Parse(split[16], cultureInfo); }
                                if (split.Length > 17 && split[17].Length > 0) { critchance = float.Parse(split[17], cultureInfo); }
                                if (split.Length > 18 && split[18].Length > 0) { damage = float.Parse(split[18], cultureInfo); }
                                if (split.Length > 19 && split[19].Length > 0) { defense = float.Parse(split[19], cultureInfo); }
                                if (split.Length > 20 && split[20].Length > 0) { dodgechance = float.Parse(split[20], cultureInfo); }
                                if (split.Length > 21 && split[21].Length > 0) { healing = float.Parse(split[21], cultureInfo); }
                                if (split.Length > 22 && split[22].Length > 0) { health = float.Parse(split[22], cultureInfo); }
                                if (split.Length > 23 && split[23].Length > 0) { hitchance = float.Parse(split[23], cultureInfo); }
                                if (split.Length > 24 && split[24].Length > 0) { hp5 = float.Parse(split[24], cultureInfo); }
                                if (split.Length > 25 && split[25].Length > 0) { mana = float.Parse(split[25], cultureInfo); }
                                if (split.Length > 26 && split[26].Length > 0) { mp5 = float.Parse(split[26], cultureInfo); }
                                if (split.Length > 27 && split[27].Length > 0) { parrychance = float.Parse(split[27], cultureInfo); }
                                if (split.Length > 28 && split[28].Length > 0) { reflect = float.Parse(split[28], cultureInfo); }
                                switch (split[0])
                                {
                                    case "Head":
                                        foreach (Armor x in headCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "head":
                                        foreach (Armor x in headCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "Neck":
                                        foreach (Armor x in neckCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "neck":
                                        foreach (Armor x in neckCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "Shoulders":
                                        foreach (Armor x in shouldersCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "shoulders":
                                        foreach (Armor x in shouldersCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "Back":
                                        foreach (Armor x in backCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "back":
                                        foreach (Armor x in backCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "Cloak":
                                        foreach (Armor x in backCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "cloak":
                                        foreach (Armor x in backCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "Chest":
                                        foreach (Armor x in chestCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "chest":
                                        foreach (Armor x in chestCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "Wrist":
                                        foreach (Armor x in wristCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "wrist":
                                        foreach (Armor x in wristCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "Hands":
                                        foreach (Armor x in handsCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "hands":
                                        foreach (Armor x in handsCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "Gloves":
                                        foreach (Armor x in handsCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "gloves":
                                        foreach (Armor x in handsCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "Waist":
                                        foreach (Armor x in waistCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "waist":
                                        foreach (Armor x in waistCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "Belt":
                                        foreach (Armor x in waistCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "belt":
                                        foreach (Armor x in waistCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "Legs":
                                        foreach (Armor x in legsCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "legs":
                                        foreach (Armor x in legsCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "Feet":
                                        foreach (Armor x in feetCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "feet":
                                        foreach (Armor x in feetCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "Boots":
                                        foreach (Armor x in feetCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "boots":
                                        foreach (Armor x in feetCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "Finger":
                                        foreach (Armor x in fingerCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "finger":
                                        foreach (Armor x in fingerCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "Ring":
                                        foreach (Armor x in fingerCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "ring":
                                        foreach (Armor x in fingerCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "Trinket":
                                        foreach (Armor x in trinketCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                    case "trinket":
                                        foreach (Armor x in trinketCandidates)
                                            AddArmorToDictionary(new Armor(x.Name, x.EquippedLocation, x.Strength + strength, x.Agility + agility, x.Stamina + stamina, x.Intellect + intellect,
                                            x.Spirit + spirit, x.Armorvalue + armorvalue, x.Arcaneresistance + arcaneresistance, x.Fireresistance + fireresistance, x.Natureresistance + natureresistance,
                                            x.Frostresistance + frostresistance, x.Shadowresistance + shadowresistance, x.Attackpower + attackpower, x.Attackspeed + attackspeed, x.Blockchance + blockchance,
                                            x.Blockvalue + blockvalue, x.Critchance + critchance, x.Damage + damage, x.Defense + defense, x.Dodgechance + dodgechance, x.Healing + healing, x.Health + health,
                                            x.Hitchance + hitchance, x.Hp5 + hp5, x.Mana + mana, x.Mp5 + mp5, x.Parrychance + parrychance, x.Reflect + reflect, currentEnchantName));
                                        break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("One or more lines in the Enchants.txt file are broken.\nMake sure you have enough columns, the right order and the correct format.");
                            throw ex;
                        }
                    }
                }
            }
        }
        private void AddArmorToDictionary(Armor armor)
        {
            Dictionary<string, List<Armor>> currentDictionary;
            switch (armor.EquippedLocation)
            {
                case Armor.EquipLocation.Head:
                    currentDictionary = headArmors;
                    break;
                case Armor.EquipLocation.Neck:
                    currentDictionary = neckArmors;
                    break;
                case Armor.EquipLocation.Shoulders:
                    currentDictionary = shouldersArmors;
                    break;
                case Armor.EquipLocation.Back:
                    currentDictionary = backArmors;
                    break;
                case Armor.EquipLocation.Chest:
                    currentDictionary = chestArmors;
                    break;
                case Armor.EquipLocation.Wrist:
                    currentDictionary = wristArmors;
                    break;
                case Armor.EquipLocation.Hands:
                    currentDictionary = handsArmors;
                    break;
                case Armor.EquipLocation.Waist:
                    currentDictionary = waistArmors;
                    break;
                case Armor.EquipLocation.Legs:
                    currentDictionary = legsArmors;
                    break;
                case Armor.EquipLocation.Feet:
                    currentDictionary = feetArmors;
                    break;
                case Armor.EquipLocation.Finger:
                    currentDictionary = fingerArmors;
                    break;
                case Armor.EquipLocation.Trinket:
                    currentDictionary = trinketArmors;
                    break;
                default:
                    return;
            }
            List<Armor> currentList;
            if (!currentDictionary.ContainsKey(armor.Name + armor.Enchant))
            {
                currentList = new List<Armor>();
                currentDictionary.Add(armor.Name + armor.Enchant, currentList);
            }
            else
                currentList = currentDictionary[armor.Name + armor.Enchant];
            currentList.Add(armor);
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridMain.Focus();
        }
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (canSearch)
            {
                canSearch = false;
                List<Armor> headCandidates = new List<Armor>();
                List<Armor> neckCandidates = new List<Armor>();
                List<Armor> shouldersCandidates = new List<Armor>();
                List<Armor> backCandidates = new List<Armor>();
                List<Armor> chestCandidates = new List<Armor>();
                List<Armor> wristCandidates = new List<Armor>();
                List<Armor> handsCandidates = new List<Armor>();
                List<Armor> waistCandidates = new List<Armor>();
                List<Armor> legsCandidates = new List<Armor>();
                List<Armor> feetCandidates = new List<Armor>();
                List<Armor> fingerCandidates = new List<Armor>();
                List<Armor> trinketCandidates = new List<Armor>();
                AddArmorCandidates(headArmors, headCandidates);
                AddArmorCandidates(neckArmors, neckCandidates);
                AddArmorCandidates(shouldersArmors, shouldersCandidates);
                AddArmorCandidates(backArmors, backCandidates);
                AddArmorCandidates(chestArmors, chestCandidates);
                AddArmorCandidates(wristArmors, wristCandidates);
                AddArmorCandidates(handsArmors, handsCandidates);
                AddArmorCandidates(waistArmors, waistCandidates);
                AddArmorCandidates(legsArmors, legsCandidates);
                AddArmorCandidates(feetArmors, feetCandidates);
                AddArmorCandidates(fingerArmors, fingerCandidates);
                AddArmorCandidates(trinketArmors, trinketCandidates);
                System.Diagnostics.Debug.WriteLine("headCandidates.Count before: " + headCandidates.Count);
                List<Armor> removeheadCandidates = new List<Armor>();
                List<Armor> removeneckCandidates = new List<Armor>();
                List<Armor> removeshouldersCandidates = new List<Armor>();
                List<Armor> removebackCandidates = new List<Armor>();
                List<Armor> removechestCandidates = new List<Armor>();
                List<Armor> removewristCandidates = new List<Armor>();
                List<Armor> removehandsCandidates = new List<Armor>();
                List<Armor> removewaistCandidates = new List<Armor>();
                List<Armor> removelegsCandidates = new List<Armor>();
                List<Armor> removefeetCandidates = new List<Armor>();
                foreach (Armor x in headCandidates)
                    foreach (Armor y in headCandidates)
                        if (!(x.Equals(y)) && (x.Strength >= y.Strength) && (x.Agility >= y.Agility) && (x.Stamina >= y.Stamina) && (x.Intellect >= y.Intellect) && (x.Spirit >= y.Spirit) && (x.Armorvalue >= y.Armorvalue) && (x.Arcaneresistance >= y.Arcaneresistance) && (x.Fireresistance >= y.Fireresistance) && (x.Natureresistance >= y.Natureresistance) && (x.Frostresistance >= y.Frostresistance) && (x.Shadowresistance >= y.Shadowresistance) && (x.Attackpower >= y.Attackpower) && (x.Attackspeed >= y.Attackspeed) && (x.Blockchance >= y.Blockchance) && (x.Blockvalue >= y.Blockvalue) && (x.Critchance >= y.Critchance) && (x.Damage >= y.Damage) && (x.Defense >= y.Defense) && (x.Dodgechance >= y.Dodgechance) && (x.Healing >= y.Healing) && (x.Health >= y.Health) && (x.Hitchance >= y.Hitchance) && (x.Hp5 >= y.Hp5) && (x.Mana >= y.Mana) && (x.Mp5 >= y.Mp5) && (x.Parrychance >= y.Parrychance) && (x.Reflect >= y.Reflect))
                            removeheadCandidates.Add(y);
                foreach (Armor z in removeheadCandidates)
                    headCandidates.Remove(z);
                foreach (Armor x in neckCandidates)
                    foreach (Armor y in neckCandidates)
                        if (!(x.Equals(y)) && (x.Strength >= y.Strength) && (x.Agility >= y.Agility) && (x.Stamina >= y.Stamina) && (x.Intellect >= y.Intellect) && (x.Spirit >= y.Spirit) && (x.Armorvalue >= y.Armorvalue) && (x.Arcaneresistance >= y.Arcaneresistance) && (x.Fireresistance >= y.Fireresistance) && (x.Natureresistance >= y.Natureresistance) && (x.Frostresistance >= y.Frostresistance) && (x.Shadowresistance >= y.Shadowresistance) && (x.Attackpower >= y.Attackpower) && (x.Attackspeed >= y.Attackspeed) && (x.Blockchance >= y.Blockchance) && (x.Blockvalue >= y.Blockvalue) && (x.Critchance >= y.Critchance) && (x.Damage >= y.Damage) && (x.Defense >= y.Defense) && (x.Dodgechance >= y.Dodgechance) && (x.Healing >= y.Healing) && (x.Health >= y.Health) && (x.Hitchance >= y.Hitchance) && (x.Hp5 >= y.Hp5) && (x.Mana >= y.Mana) && (x.Mp5 >= y.Mp5) && (x.Parrychance >= y.Parrychance) && (x.Reflect >= y.Reflect))
                            removeneckCandidates.Add(y);
                foreach (Armor z in removeneckCandidates)
                    neckCandidates.Remove(z);
                foreach (Armor x in shouldersCandidates)
                    foreach (Armor y in shouldersCandidates)
                        if (!(x.Equals(y)) && (x.Strength >= y.Strength) && (x.Agility >= y.Agility) && (x.Stamina >= y.Stamina) && (x.Intellect >= y.Intellect) && (x.Spirit >= y.Spirit) && (x.Armorvalue >= y.Armorvalue) && (x.Arcaneresistance >= y.Arcaneresistance) && (x.Fireresistance >= y.Fireresistance) && (x.Natureresistance >= y.Natureresistance) && (x.Frostresistance >= y.Frostresistance) && (x.Shadowresistance >= y.Shadowresistance) && (x.Attackpower >= y.Attackpower) && (x.Attackspeed >= y.Attackspeed) && (x.Blockchance >= y.Blockchance) && (x.Blockvalue >= y.Blockvalue) && (x.Critchance >= y.Critchance) && (x.Damage >= y.Damage) && (x.Defense >= y.Defense) && (x.Dodgechance >= y.Dodgechance) && (x.Healing >= y.Healing) && (x.Health >= y.Health) && (x.Hitchance >= y.Hitchance) && (x.Hp5 >= y.Hp5) && (x.Mana >= y.Mana) && (x.Mp5 >= y.Mp5) && (x.Parrychance >= y.Parrychance) && (x.Reflect >= y.Reflect))
                            removeshouldersCandidates.Add(y);
                foreach (Armor z in removeshouldersCandidates)
                    shouldersCandidates.Remove(z);
                foreach (Armor x in backCandidates)
                    foreach (Armor y in backCandidates)
                        if (!(x.Equals(y)) && (x.Strength >= y.Strength) && (x.Agility >= y.Agility) && (x.Stamina >= y.Stamina) && (x.Intellect >= y.Intellect) && (x.Spirit >= y.Spirit) && (x.Armorvalue >= y.Armorvalue) && (x.Arcaneresistance >= y.Arcaneresistance) && (x.Fireresistance >= y.Fireresistance) && (x.Natureresistance >= y.Natureresistance) && (x.Frostresistance >= y.Frostresistance) && (x.Shadowresistance >= y.Shadowresistance) && (x.Attackpower >= y.Attackpower) && (x.Attackspeed >= y.Attackspeed) && (x.Blockchance >= y.Blockchance) && (x.Blockvalue >= y.Blockvalue) && (x.Critchance >= y.Critchance) && (x.Damage >= y.Damage) && (x.Defense >= y.Defense) && (x.Dodgechance >= y.Dodgechance) && (x.Healing >= y.Healing) && (x.Health >= y.Health) && (x.Hitchance >= y.Hitchance) && (x.Hp5 >= y.Hp5) && (x.Mana >= y.Mana) && (x.Mp5 >= y.Mp5) && (x.Parrychance >= y.Parrychance) && (x.Reflect >= y.Reflect))
                            removebackCandidates.Add(y);
                foreach (Armor z in removebackCandidates)
                    backCandidates.Remove(z);
                foreach (Armor x in chestCandidates)
                    foreach (Armor y in chestCandidates)
                        if (!(x.Equals(y)) && (x.Strength >= y.Strength) && (x.Agility >= y.Agility) && (x.Stamina >= y.Stamina) && (x.Intellect >= y.Intellect) && (x.Spirit >= y.Spirit) && (x.Armorvalue >= y.Armorvalue) && (x.Arcaneresistance >= y.Arcaneresistance) && (x.Fireresistance >= y.Fireresistance) && (x.Natureresistance >= y.Natureresistance) && (x.Frostresistance >= y.Frostresistance) && (x.Shadowresistance >= y.Shadowresistance) && (x.Attackpower >= y.Attackpower) && (x.Attackspeed >= y.Attackspeed) && (x.Blockchance >= y.Blockchance) && (x.Blockvalue >= y.Blockvalue) && (x.Critchance >= y.Critchance) && (x.Damage >= y.Damage) && (x.Defense >= y.Defense) && (x.Dodgechance >= y.Dodgechance) && (x.Healing >= y.Healing) && (x.Health >= y.Health) && (x.Hitchance >= y.Hitchance) && (x.Hp5 >= y.Hp5) && (x.Mana >= y.Mana) && (x.Mp5 >= y.Mp5) && (x.Parrychance >= y.Parrychance) && (x.Reflect >= y.Reflect))
                            removechestCandidates.Add(y);
                foreach (Armor z in removechestCandidates)
                    chestCandidates.Remove(z);
                foreach (Armor x in wristCandidates)
                    foreach (Armor y in wristCandidates)
                        if (!(x.Equals(y)) && (x.Strength >= y.Strength) && (x.Agility >= y.Agility) && (x.Stamina >= y.Stamina) && (x.Intellect >= y.Intellect) && (x.Spirit >= y.Spirit) && (x.Armorvalue >= y.Armorvalue) && (x.Arcaneresistance >= y.Arcaneresistance) && (x.Fireresistance >= y.Fireresistance) && (x.Natureresistance >= y.Natureresistance) && (x.Frostresistance >= y.Frostresistance) && (x.Shadowresistance >= y.Shadowresistance) && (x.Attackpower >= y.Attackpower) && (x.Attackspeed >= y.Attackspeed) && (x.Blockchance >= y.Blockchance) && (x.Blockvalue >= y.Blockvalue) && (x.Critchance >= y.Critchance) && (x.Damage >= y.Damage) && (x.Defense >= y.Defense) && (x.Dodgechance >= y.Dodgechance) && (x.Healing >= y.Healing) && (x.Health >= y.Health) && (x.Hitchance >= y.Hitchance) && (x.Hp5 >= y.Hp5) && (x.Mana >= y.Mana) && (x.Mp5 >= y.Mp5) && (x.Parrychance >= y.Parrychance) && (x.Reflect >= y.Reflect))
                            removewristCandidates.Add(y);
                foreach (Armor z in removewristCandidates)
                    wristCandidates.Remove(z);
                foreach (Armor x in handsCandidates)
                    foreach (Armor y in handsCandidates)
                        if (!(x.Equals(y)) && (x.Strength >= y.Strength) && (x.Agility >= y.Agility) && (x.Stamina >= y.Stamina) && (x.Intellect >= y.Intellect) && (x.Spirit >= y.Spirit) && (x.Armorvalue >= y.Armorvalue) && (x.Arcaneresistance >= y.Arcaneresistance) && (x.Fireresistance >= y.Fireresistance) && (x.Natureresistance >= y.Natureresistance) && (x.Frostresistance >= y.Frostresistance) && (x.Shadowresistance >= y.Shadowresistance) && (x.Attackpower >= y.Attackpower) && (x.Attackspeed >= y.Attackspeed) && (x.Blockchance >= y.Blockchance) && (x.Blockvalue >= y.Blockvalue) && (x.Critchance >= y.Critchance) && (x.Damage >= y.Damage) && (x.Defense >= y.Defense) && (x.Dodgechance >= y.Dodgechance) && (x.Healing >= y.Healing) && (x.Health >= y.Health) && (x.Hitchance >= y.Hitchance) && (x.Hp5 >= y.Hp5) && (x.Mana >= y.Mana) && (x.Mp5 >= y.Mp5) && (x.Parrychance >= y.Parrychance) && (x.Reflect >= y.Reflect))
                            removehandsCandidates.Add(y);
                foreach (Armor z in removehandsCandidates)
                    handsCandidates.Remove(z);
                foreach (Armor x in waistCandidates)
                    foreach (Armor y in waistCandidates)
                        if (!(x.Equals(y)) && (x.Strength >= y.Strength) && (x.Agility >= y.Agility) && (x.Stamina >= y.Stamina) && (x.Intellect >= y.Intellect) && (x.Spirit >= y.Spirit) && (x.Armorvalue >= y.Armorvalue) && (x.Arcaneresistance >= y.Arcaneresistance) && (x.Fireresistance >= y.Fireresistance) && (x.Natureresistance >= y.Natureresistance) && (x.Frostresistance >= y.Frostresistance) && (x.Shadowresistance >= y.Shadowresistance) && (x.Attackpower >= y.Attackpower) && (x.Attackspeed >= y.Attackspeed) && (x.Blockchance >= y.Blockchance) && (x.Blockvalue >= y.Blockvalue) && (x.Critchance >= y.Critchance) && (x.Damage >= y.Damage) && (x.Defense >= y.Defense) && (x.Dodgechance >= y.Dodgechance) && (x.Healing >= y.Healing) && (x.Health >= y.Health) && (x.Hitchance >= y.Hitchance) && (x.Hp5 >= y.Hp5) && (x.Mana >= y.Mana) && (x.Mp5 >= y.Mp5) && (x.Parrychance >= y.Parrychance) && (x.Reflect >= y.Reflect))
                            removewaistCandidates.Add(y);
                foreach (Armor z in removewaistCandidates)
                    waistCandidates.Remove(z);
                foreach (Armor x in legsCandidates)
                    foreach (Armor y in legsCandidates)
                        if (!(x.Equals(y)) && (x.Strength >= y.Strength) && (x.Agility >= y.Agility) && (x.Stamina >= y.Stamina) && (x.Intellect >= y.Intellect) && (x.Spirit >= y.Spirit) && (x.Armorvalue >= y.Armorvalue) && (x.Arcaneresistance >= y.Arcaneresistance) && (x.Fireresistance >= y.Fireresistance) && (x.Natureresistance >= y.Natureresistance) && (x.Frostresistance >= y.Frostresistance) && (x.Shadowresistance >= y.Shadowresistance) && (x.Attackpower >= y.Attackpower) && (x.Attackspeed >= y.Attackspeed) && (x.Blockchance >= y.Blockchance) && (x.Blockvalue >= y.Blockvalue) && (x.Critchance >= y.Critchance) && (x.Damage >= y.Damage) && (x.Defense >= y.Defense) && (x.Dodgechance >= y.Dodgechance) && (x.Healing >= y.Healing) && (x.Health >= y.Health) && (x.Hitchance >= y.Hitchance) && (x.Hp5 >= y.Hp5) && (x.Mana >= y.Mana) && (x.Mp5 >= y.Mp5) && (x.Parrychance >= y.Parrychance) && (x.Reflect >= y.Reflect))
                            removelegsCandidates.Add(y);
                foreach (Armor z in removelegsCandidates)
                    legsCandidates.Remove(z);
                foreach (Armor x in feetCandidates)
                    foreach (Armor y in feetCandidates)
                        if (!(x.Equals(y)) && (x.Strength >= y.Strength) && (x.Agility >= y.Agility) && (x.Stamina >= y.Stamina) && (x.Intellect >= y.Intellect) && (x.Spirit >= y.Spirit) && (x.Armorvalue >= y.Armorvalue) && (x.Arcaneresistance >= y.Arcaneresistance) && (x.Fireresistance >= y.Fireresistance) && (x.Natureresistance >= y.Natureresistance) && (x.Frostresistance >= y.Frostresistance) && (x.Shadowresistance >= y.Shadowresistance) && (x.Attackpower >= y.Attackpower) && (x.Attackspeed >= y.Attackspeed) && (x.Blockchance >= y.Blockchance) && (x.Blockvalue >= y.Blockvalue) && (x.Critchance >= y.Critchance) && (x.Damage >= y.Damage) && (x.Defense >= y.Defense) && (x.Dodgechance >= y.Dodgechance) && (x.Healing >= y.Healing) && (x.Health >= y.Health) && (x.Hitchance >= y.Hitchance) && (x.Hp5 >= y.Hp5) && (x.Mana >= y.Mana) && (x.Mp5 >= y.Mp5) && (x.Parrychance >= y.Parrychance) && (x.Reflect >= y.Reflect))
                            removefeetCandidates.Add(y);
                foreach (Armor z in removefeetCandidates)
                    feetCandidates.Remove(z);
                System.Diagnostics.Debug.WriteLine("headCandidates.Count:\t\t" + headCandidates.Count);
                System.Diagnostics.Debug.WriteLine("neckCandidates.Count:\t\t" + neckCandidates.Count);
                System.Diagnostics.Debug.WriteLine("shouldersCandidates.Count:\t" + shouldersCandidates.Count);
                System.Diagnostics.Debug.WriteLine("backCandidates.Count:\t\t" + backCandidates.Count);
                System.Diagnostics.Debug.WriteLine("chestCandidates.Count:\t\t" + chestCandidates.Count);
                System.Diagnostics.Debug.WriteLine("wristCandidates.Count:\t\t" + wristCandidates.Count);
                System.Diagnostics.Debug.WriteLine("handsCandidates.Count:\t\t" + handsCandidates.Count);
                System.Diagnostics.Debug.WriteLine("waistCandidates.Count:\t\t" + waistCandidates.Count);
                System.Diagnostics.Debug.WriteLine("legsCandidates.Count:\t\t" + legsCandidates.Count);
                System.Diagnostics.Debug.WriteLine("feetCandidates.Count:\t\t" + feetCandidates.Count);
                System.Diagnostics.Debug.WriteLine("fingerCandidates.Count:\t\t" + fingerCandidates.Count);
                System.Diagnostics.Debug.WriteLine("trinketCandidates.Count:\t" + trinketCandidates.Count);
                MinimumRequirements minimumRequirements;
                try
                {
                    minimumRequirements = GetMinimumRequirements();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return;
                }
                float weightStrength = float.Parse(textBoxWeightStrength.Text, cultureInfo);
                float weightAgility = float.Parse(textBoxWeightAgility.Text, cultureInfo);
                float weightStamina = float.Parse(textBoxWeightStamina.Text, cultureInfo);
                float weightIntellect = float.Parse(textBoxWeightIntellect.Text, cultureInfo);
                float weightSpirit = float.Parse(textBoxWeightSpirit.Text, cultureInfo);
                float weightArmorvalue = float.Parse(textBoxWeightArmorvalue.Text, cultureInfo);
                float weightArcaneresistance = float.Parse(textBoxWeightArcaneresistance.Text, cultureInfo);
                float weightFireresistance = float.Parse(textBoxWeightFireresistance.Text, cultureInfo);
                float weightNatureresistance = float.Parse(textBoxWeightNatureresistance.Text, cultureInfo);
                float weightFrostresistance = float.Parse(textBoxWeightFrostresistance.Text, cultureInfo);
                float weightShadowresistance = float.Parse(textBoxWeightShadowresistance.Text, cultureInfo);
                float weightAttackpower = float.Parse(textBoxWeightAttackpower.Text, cultureInfo);
                float weightAttackspeed = float.Parse(textBoxWeightAttackspeed.Text, cultureInfo);
                float weightBlockchance = float.Parse(textBoxWeightBlockchance.Text, cultureInfo);
                float weightBlockvalue = float.Parse(textBoxWeightBlockvalue.Text, cultureInfo);
                float weightCritchance = float.Parse(textBoxWeightCritchance.Text, cultureInfo);
                float weightDamage = float.Parse(textBoxWeightDamage.Text, cultureInfo);
                float weightDefense = float.Parse(textBoxWeightDefense.Text, cultureInfo);
                float weightDodgechance = float.Parse(textBoxWeightDodgechance.Text, cultureInfo);
                float weightHealing = float.Parse(textBoxWeightHealing.Text, cultureInfo);
                float weightHealth = float.Parse(textBoxWeightHealth.Text, cultureInfo);
                float weightHitchance = float.Parse(textBoxWeightHitchance.Text, cultureInfo);
                float weightHp5 = float.Parse(textBoxWeightHp5.Text, cultureInfo);
                float weightMana = float.Parse(textBoxWeightMana.Text, cultureInfo);
                float weightMp5 = float.Parse(textBoxWeightMp5.Text, cultureInfo);
                float weightParrychance = float.Parse(textBoxWeightParrychance.Text, cultureInfo);
                float weightReflect = float.Parse(textBoxWeightReflect.Text, cultureInfo);
                Thread searchTread = new Thread(new ThreadStart(delegate
                {
                    DoSearch(headCandidates, neckCandidates, shouldersCandidates, backCandidates, chestCandidates, wristCandidates,
                     handsCandidates, waistCandidates, legsCandidates, feetCandidates, fingerCandidates, trinketCandidates, minimumRequirements,
                     weightStrength, weightAgility, weightStamina, weightIntellect, weightSpirit, weightArmorvalue, weightArcaneresistance,
                     weightFireresistance, weightNatureresistance, weightFrostresistance, weightShadowresistance, weightAttackpower, weightAttackspeed,
                     weightBlockchance, weightBlockvalue, weightCritchance, weightDamage, weightDefense, weightDodgechance, weightHealing,
                     weightHealth, weightHitchance, weightHp5, weightMana, weightMp5, weightParrychance, weightReflect);
                }
                ));
                searchTread.Start();
            }
        }
        private void AddArmorCandidates(Dictionary<string, List<Armor>> armors, List<Armor> armorCandidates)
        {
            foreach (KeyValuePair<string, List<Armor>> kvp in armors)
            {
                foreach (Armor armor in kvp.Value)
                {
                    armorCandidates.Add(armor);
                    break;
                }
            }
        }
        private MinimumRequirements GetMinimumRequirements()
        {
            MinimumRequirements minimumRequirements = new MinimumRequirements();
            try
            {
                minimumRequirements.Strength = float.Parse(textBoxMinReqStrength.Text, cultureInfo);
                minimumRequirements.Agility = float.Parse(textBoxMinReqAgility.Text, cultureInfo);
                minimumRequirements.Stamina = float.Parse(textBoxMinReqStamina.Text, cultureInfo);
                minimumRequirements.Intellect = float.Parse(textBoxMinReqIntellect.Text, cultureInfo);
                minimumRequirements.Spirit = float.Parse(textBoxMinReqSpirit.Text, cultureInfo);
                minimumRequirements.Armorvalue = float.Parse(textBoxMinReqArmorvalue.Text, cultureInfo);
                minimumRequirements.Arcaneresistance = float.Parse(textBoxMinReqArcaneresistance.Text, cultureInfo);
                minimumRequirements.Fireresistance = float.Parse(textBoxMinReqFireresistance.Text, cultureInfo);
                minimumRequirements.Natureresistance = float.Parse(textBoxMinReqNatureresistance.Text, cultureInfo);
                minimumRequirements.Frostresistance = float.Parse(textBoxMinReqFrostresistance.Text, cultureInfo);
                minimumRequirements.Shadowresistance = float.Parse(textBoxMinReqShadowresistance.Text, cultureInfo);
                minimumRequirements.Attackpower = float.Parse(textBoxMinReqAttackpower.Text, cultureInfo);
                minimumRequirements.Attackspeed = float.Parse(textBoxMinReqAttackspeed.Text, cultureInfo);
                minimumRequirements.Blockchance = float.Parse(textBoxMinReqBlockchance.Text, cultureInfo);
                minimumRequirements.Blockvalue = float.Parse(textBoxMinReqBlockvalue.Text, cultureInfo);
                minimumRequirements.Critchance = float.Parse(textBoxMinReqCritchance.Text, cultureInfo);
                minimumRequirements.Damage = float.Parse(textBoxMinReqDamage.Text, cultureInfo);
                minimumRequirements.Defense = float.Parse(textBoxMinReqDefense.Text, cultureInfo);
                minimumRequirements.Dodgechance = float.Parse(textBoxMinReqDodgechance.Text, cultureInfo);
                minimumRequirements.Healing = float.Parse(textBoxMinReqHealing.Text, cultureInfo);
                minimumRequirements.Health = float.Parse(textBoxMinReqHealth.Text, cultureInfo);
                minimumRequirements.Hitchance = float.Parse(textBoxMinReqHitchance.Text, cultureInfo);
                minimumRequirements.Hp5 = float.Parse(textBoxMinReqHp5.Text, cultureInfo);
                minimumRequirements.Mana = float.Parse(textBoxMinReqMana.Text, cultureInfo);
                minimumRequirements.Mp5 = float.Parse(textBoxMinReqMp5.Text, cultureInfo);
                minimumRequirements.Parrychance = float.Parse(textBoxMinReqParrychance.Text, cultureInfo);
                minimumRequirements.Reflect = float.Parse(textBoxMinReqReflect.Text, cultureInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("One or more of the minimum requirements has an invalid format.\nOnly whole numbers accepted.");
                throw ex;
            }
            return minimumRequirements;
        }
        private void DoSearch(List<Armor> headCandidates, List<Armor> neckCandidates, List<Armor> shouldersCandidates, List<Armor> backCandidates,
        List<Armor> chestCandidates, List<Armor> wristCandidates, List<Armor> handsCandidates, List<Armor> waistCandidates,
        List<Armor> legsCandidates, List<Armor> feetCandidates, List<Armor> fingerCandidates, List<Armor> trinketCandidates,
        MinimumRequirements minimumRequirements, float weightStrength, float weightAgility, float weightStamina, float weightIntellect,
        float weightSpirit, float weightArmorvalue, float weightArcaneresistance, float weightFireresistance, float weightNatureresistance,
        float weightFrostresistance, float weightShadowresistance, float weightAttackpower, float weightAttackspeed, float weightBlockchance,
        float weightBlockvalue, float weightCritchance, float weightDamage, float weightDefense, float weightDodgechance, float weightHealing,
        float weightHealth, float weightHitchance, float weightHp5, float weightMana, float weightMp5, float weightParrychance, float weightReflect)
        {
            DateTime startTime = DateTime.Now;
            long totalCombinations = (headCandidates.Count * neckCandidates.Count * shouldersCandidates.Count *
            backCandidates.Count * chestCandidates.Count * wristCandidates.Count * handsCandidates.Count * waistCandidates.Count *
            legsCandidates.Count * feetCandidates.Count * fingerCandidates.Count * trinketCandidates.Count);
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate ()
            {
                progressBarSearch.Minimum = 0;
                progressBarSearch.Maximum = 100;
                progressBarSearch.Value = 0;
                progressBarSearch.Visibility = System.Windows.Visibility.Visible;
                labelProgressBarSearch.Visibility = System.Windows.Visibility.Visible;
                labelProgressBarSearch.Content = "Calculating!!!  Don't shut down the tool - wait at least 5mins!   Number of calculations to process: " + totalCombinations;
            });
            var sync = new object();
            List<ArmorCombination> weightResultList = new List<ArmorCombination>();
            Parallel.ForEach(fingerCandidates, fingerArmor =>
            {
                if ((fingerCandidates.Count > 2) & (fingerArmor.Name == "<No Armor>"))
                    return;
                foreach (Armor finger2Armor in fingerCandidates)
                {
                    if ((fingerCandidates.Count > 2) & (finger2Armor.Name == "<No Armor>"))
                        continue;
                    if ((fingerArmor == finger2Armor) & (fingerArmor.Name != "<No Armor>"))
                        continue;
                    if ((fingerArmor.Name.CompareTo(finger2Armor.Name)) > 0)
                        continue;
                    foreach (Armor trinketArmor in trinketCandidates)
                    {
                        if ((trinketCandidates.Count > 2) & (trinketArmor.Name == "<No Armor>"))
                            continue;
                        foreach (Armor trinket2Armor in trinketCandidates)
                        {
                            if ((trinketCandidates.Count > 2) & (trinket2Armor.Name == "<No Armor>"))
                                continue;
                            if ((trinketArmor == trinket2Armor) & (trinketArmor.Name != "<No Armor>"))
                                continue;
                            if ((trinketArmor.Name.CompareTo(trinket2Armor.Name)) > 0)
                                continue;
                            foreach (Armor chestArmor in chestCandidates)
                            {
                                foreach (Armor wristArmor in wristCandidates)
                                {
                                    foreach (Armor handsArmor in handsCandidates)
                                    {
                                        foreach (Armor waistArmor in waistCandidates)
                                        {
                                            foreach (Armor legsArmor in legsCandidates)
                                            {
                                                foreach (Armor feetArmor in feetCandidates)
                                                {
                                                    foreach (Armor backArmor in backCandidates)
                                                    {
                                                        foreach (Armor shouldersArmor in shouldersCandidates)
                                                        {
                                                            foreach (Armor neckArmor in neckCandidates)
                                                            {
                                                                foreach (Armor headArmor in headCandidates)
                                                                {
                                                                    ArmorCombination armorCombination = new ArmorCombination(headArmor, neckArmor, shouldersArmor, backArmor, chestArmor, wristArmor, handsArmor, waistArmor, legsArmor, feetArmor, fingerArmor, finger2Armor, trinketArmor, trinket2Armor);
                                                                    if (!minimumRequirements.PassesRequirements(armorCombination))
                                                                        continue;
                                                                    RateArmorCombination(armorCombination, weightStrength, weightAgility, weightStamina, weightIntellect, weightSpirit, weightArmorvalue, weightArcaneresistance,
                                                                    weightFireresistance, weightNatureresistance, weightFrostresistance, weightShadowresistance, weightAttackpower, weightAttackspeed,
                                                                    weightBlockchance, weightBlockvalue, weightCritchance, weightDamage, weightDefense, weightDodgechance,
                                                                    weightHealing, weightHealth, weightHitchance, weightHp5, weightMana, weightMp5, weightParrychance, weightReflect);
                                                                    lock (sync)
                                                                    {
                                                                        if (weightResultList.Count < resultSize)
                                                                            AddArmorCombinationToList(weightResultList, armorCombination);
                                                                        else if (armorCombination.Rating > weightResultList[resultSize - 1].Rating)
                                                                        {
                                                                            weightResultList.RemoveAt(resultSize - 1);
                                                                            AddArmorCombinationToList(weightResultList, armorCombination);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate ()
            {
                dataGrid1.RowStyleSelector = null;
                dataGrid1.Items.Clear();
                foreach (ArmorCombination armorCombination in weightResultList)
                    dataGrid1.Items.Add(armorCombination);
            });
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate () { progressBarSearch.Visibility = System.Windows.Visibility.Hidden; labelProgressBarSearch.Visibility = System.Windows.Visibility.Hidden; });
            System.Diagnostics.Debug.WriteLine("Search Time: " + (DateTime.Now - startTime).TotalSeconds + " s");
            System.Diagnostics.Debug.WriteLine("Estimated calculations (totalCombinations): " + totalCombinations);
            canSearch = true;
        }
        private void AddArmorCombinationToList(List<ArmorCombination> resultList, ArmorCombination armorCombination)
        {
            bool inserted = false;
            for (int i = 0; i < resultList.Count; i++)
            {
                if (armorCombination.Rating > resultList[i].Rating)
                {
                    resultList.Insert(i, armorCombination);
                    inserted = true;
                    break;
                }
            }
            if (!inserted)
                resultList.Add(armorCombination);
        }
        private void RateArmorCombination(ArmorCombination armorCombination, float weightStrength, float weightAgility, float weightStamina, float weightIntellect,
        float weightSpirit, float weightArmorvalue, float weightArcaneresistance, float weightFireresistance, float weightNatureresistance, float weightFrostresistance,
        float weightShadowresistance, float weightAttackpower, float weightAttackspeed, float weightBlockchance, float weightBlockvalue, float weightCritchance,
        float weightDamage, float weightDefense, float weightDodgechance, float weightHealing, float weightHealth, float weightHitchance, float weightHp5,
        float weightMana, float weightMp5, float weightParrychance, float weightReflect)
        {
            float rating = armorCombination.Strength * weightStrength + armorCombination.Agility * weightAgility + armorCombination.Stamina * weightStamina +
            armorCombination.Intellect * weightIntellect + armorCombination.Spirit * weightSpirit + armorCombination.Armorvalue * weightArmorvalue +
            armorCombination.Arcaneresistance * weightArcaneresistance + armorCombination.Fireresistance * weightFireresistance +
            armorCombination.Natureresistance * weightNatureresistance + armorCombination.Frostresistance * weightFrostresistance +
            armorCombination.Shadowresistance * weightShadowresistance + armorCombination.Attackpower * weightAttackpower + armorCombination.Attackspeed * weightAttackspeed +
            armorCombination.Blockchance * weightBlockchance + armorCombination.Blockvalue * weightBlockvalue + armorCombination.Critchance * weightCritchance +
            armorCombination.Damage * weightDamage + armorCombination.Defense * weightDefense + armorCombination.Dodgechance * weightDodgechance +
            armorCombination.Healing * weightHealing + armorCombination.Health * weightHealth + armorCombination.Hitchance * weightHitchance +
            armorCombination.Hp5 * weightHp5 + armorCombination.Mana * weightMana + armorCombination.Mp5 * weightMp5 + armorCombination.Parrychance * weightParrychance +
            armorCombination.Reflect * weightReflect;
            armorCombination.Rating = rating;
        }
        private void menuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Made by HYPE\nServer: Nostalrius PvE / Darrowshire\n\n\nPayPal Donation:\n0hype0@gmail.com", "About: Item Stat Weight Tool");
        }
        private void menuItemUpdate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "If you want to change items use the Items.xlsx Excel file." + "\n" +
                "The first row describes what slot the items fits in, its name and what stats it has." + "\n" +
                "In the second row you can set the stat weights. ',' will automatically get changed into '.'" + "\n" +
                "When you are done editing it press the following two buttons while you have the excel file still opened: " + "\n" +
                "'ctrl' 'a'" + "\n" +
                "now every column and row should be marked. Now press:" + "\n" +
                "'ctrl' 'c'" + "\n" +
                "Now open the Items.txt Text file and press:" + "\n" +
                "'ctrl' 'a'" + "\n" +
                "Now press:" + "\n" +
                "'ctrl' 'v'" + "\n" +
                "You should now see your updated items from your excel file in the text file, seperated by tabs." + "\n" +
                "Close the program and open it again - if you don't see an error message your new items should have loaded correctly."
                , "How to change / update items:");
        }
        private void menuItemTip_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "1. Try to use the least amount of items & enchants." + "\n" +
                "2. Setup a minimum requirement for at least one stat." + "\n"
                , "Performance tips:");
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
