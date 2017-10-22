namespace ISWT
{
    class MinimumRequirements
    {
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

        public MinimumRequirements()
        {
        }

        public bool PassesRequirements(ArmorCombination armorCombination)
        {
            if (armorCombination.Strength < Strength)
                return false;
            if (armorCombination.Agility < Agility)
                return false;
            if (armorCombination.Stamina < Stamina)
                return false;
            if (armorCombination.Intellect < Intellect)
                return false;
            if (armorCombination.Spirit < Spirit)
                return false;
            if (armorCombination.Armorvalue < Armorvalue)
                return false;
            if (armorCombination.Arcaneresistance < Arcaneresistance)
                return false;
            if (armorCombination.Fireresistance < Fireresistance)
                return false;
            if (armorCombination.Natureresistance < Natureresistance)
                return false;
            if (armorCombination.Frostresistance < Frostresistance)
                return false;
            if (armorCombination.Shadowresistance < Shadowresistance)
                return false;
            if (armorCombination.Attackpower < Attackpower)
                return false;
            if (armorCombination.Attackspeed < Attackspeed)
                return false;
            if (armorCombination.Blockchance < Blockchance)
                return false;
            if (armorCombination.Blockvalue < Blockvalue)
                return false;
            if (armorCombination.Critchance < Critchance)
                return false;
            if (armorCombination.Damage < Damage)
                return false;
            if (armorCombination.Defense < Defense)
                return false;
            if (armorCombination.Dodgechance < Dodgechance)
                return false;
            if (armorCombination.Healing < Healing)
                return false;
            if (armorCombination.Health < Health)
                return false;
            if (armorCombination.Hitchance < Hitchance)
                return false;
            if (armorCombination.Hp5 < Hp5)
                return false;
            if (armorCombination.Mana < Mana)
                return false;
            if (armorCombination.Mp5 < Mp5)
                return false;
            if (armorCombination.Parrychance < Parrychance)
                return false;
            if (armorCombination.Reflect < Reflect)
                return false;
            return true;
        }
    }
}
