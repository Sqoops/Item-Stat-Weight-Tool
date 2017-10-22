using System.Globalization;
namespace ISWT
{
    class Armor
    {
        public static CultureInfo cultureInfo = new CultureInfo("en-US");
        public enum EquipLocation
        {
            Head,
            Neck,
            Shoulders,
            Back,
            Chest,
            Wrist,
            Hands,
            Waist,
            Legs,
            Feet,
            Finger,
            Trinket
        }
        public Armor(string name, EquipLocation equippedLocation, float strength, float agility, float stamina, float intellect, float spirit,
            float armorvalue, float arcaneresistance, float fireresistance, float natureresistance, float frostresistance, float shadowresistance,
            float attackpower, float attackspeed, float blockchance, float blockvalue, float critchance, float damage, float defense,
            float dodgechance, float healing, float health, float hitchance, float hp5, float mana, float mp5, float parrychance, float reflect, string enchant)
        {
            Name = name;
            EquippedLocation = equippedLocation;
            Strength = strength;
            Agility = agility;
            Stamina = stamina;
            Intellect = intellect;
            Spirit = spirit;
            Armorvalue = armorvalue;
            Arcaneresistance = arcaneresistance;
            Fireresistance = fireresistance;
            Natureresistance = natureresistance;
            Frostresistance = frostresistance;
            Shadowresistance = shadowresistance;
            Attackpower = attackpower;
            Attackspeed = attackspeed;
            Blockchance = blockchance;
            Blockvalue = blockvalue;
            Critchance = critchance;
            Damage = damage;
            Defense = defense;
            Dodgechance = dodgechance;
            Healing = healing;
            Health = health;
            Hitchance = hitchance;
            Hp5 = hp5;
            Mana = mana;
            Mp5 = mp5;
            Parrychance = parrychance;
            Reflect = reflect;
            Enchant = enchant;
        }
        public string Name { get; set; }
        public EquipLocation EquippedLocation { get; set; }
        public float Strength { get; set; }
        public float Agility { get; set; }
        public float Stamina { get; set; }
        public float Intellect { get; set; }
        public float Spirit { get; set; }
        public float Armorvalue { get; set; }
        public float Arcaneresistance { get; set; }
        public float Fireresistance { get; set; }
        public float Natureresistance { get; set; }
        public float Frostresistance { get; set; }
        public float Shadowresistance { get; set; }
        public float Attackpower { get; set; }
        public float Attackspeed { get; set; }
        public float Blockchance { get; set; }
        public float Blockvalue { get; set; }
        public float Critchance { get; set; }
        public float Damage { get; set; }
        public float Defense { get; set; }
        public float Dodgechance { get; set; }
        public float Healing { get; set; }
        public float Health { get; set; }
        public float Hitchance { get; set; }
        public float Hp5 { get; set; }
        public float Mana { get; set; }
        public float Mp5 { get; set; }
        public float Parrychance { get; set; }
        public float Reflect { get; set; }
        public string Enchant { get; set; }
        public override string ToString()
        {
            return Name;
        }
        public string Tooltip
        {
            get
            {
                string toolTip = Name + "\n" +
                Enchant + "\n" +
                "    " + Strength + "\tStrength\n" +
                "    " + Agility + "\tAgility\n" +
                "    " + Stamina + "\tStamina\n" +
                "    " + Intellect + "\tIntellect\n" +
                "    " + Spirit + "\tSpirit\n" +
                "    " + Armorvalue + "\tArmorvalue\n" +
                "    " + Arcaneresistance + "\tArcaneresistance\n" +
                "    " + Fireresistance + "\tFireresistance\n" +
                "    " + Natureresistance + "\tNatureresistance\n" +
                "    " + Frostresistance + "\tFrostresistance\n" +
                "    " + Shadowresistance + "\tShadowresistance\n" +
                "    " + Attackpower + "\tAttackpower\n" +
                "    " + Attackspeed + "\tAttackspeed\n" +
                "    " + Blockchance + "\tBlockchance\n" +
                "    " + Blockvalue + "\tBlockvalue\n" +
                "    " + Critchance + "\tCritchance\n" +
                "    " + Damage + "\tDamage\n" +
                "    " + Defense + "\tDefense\n" +
                "    " + Dodgechance + "\tDodgechance\n" +
                "    " + Healing + "\tHealing\n" +
                "    " + Health + "\tHealth\n" +
                "    " + Hitchance + "\tHitchance\n" +
                "    " + Hp5 + "\tHp5\n" +
                "    " + Mana + "\tMana\n" +
                "    " + Mp5 + "\tMp5\n" +
                "    " + Parrychance + "\tParrychance\n" +
                "    " + Reflect + "\tReflect\n"
                ;
                return toolTip;
            }
        }
    }
}
