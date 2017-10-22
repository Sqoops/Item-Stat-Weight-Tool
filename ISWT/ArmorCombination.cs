namespace ISWT
{
    class ArmorCombination
    {
        public Armor HeadArmor { get; set; }
        public Armor NeckArmor { get; set; }
        public Armor ShouldersArmor { get; set; }
        public Armor BackArmor { get; set; }
        public Armor ChestArmor { get; set; }
        public Armor WristArmor { get; set; }
        public Armor HandsArmor { get; set; }
        public Armor WaistArmor { get; set; }
        public Armor LegsArmor { get; set; }
        public Armor FeetArmor { get; set; }
        public Armor FingerArmor { get; set; }
        public Armor Finger2Armor { get; set; }
        public Armor TrinketArmor { get; set; }
        public Armor Trinket2Armor { get; set; }

        public float Rating { get; set; }

        public float Strength { get { return HeadArmor.Strength + NeckArmor.Strength + ShouldersArmor.Strength + BackArmor.Strength + ChestArmor.Strength + WristArmor.Strength + HandsArmor.Strength + WaistArmor.Strength + LegsArmor.Strength + FeetArmor.Strength + FingerArmor.Strength + Finger2Armor.Strength + TrinketArmor.Strength + Trinket2Armor.Strength; } }
        public float Agility { get { return HeadArmor.Agility + NeckArmor.Agility + ShouldersArmor.Agility + BackArmor.Agility + ChestArmor.Agility + WristArmor.Agility + HandsArmor.Agility + WaistArmor.Agility + LegsArmor.Agility + FeetArmor.Agility + FingerArmor.Agility + Finger2Armor.Agility + TrinketArmor.Agility + Trinket2Armor.Agility; } }
        public float Stamina { get { return HeadArmor.Stamina + NeckArmor.Stamina + ShouldersArmor.Stamina + BackArmor.Stamina + ChestArmor.Stamina + WristArmor.Stamina + HandsArmor.Stamina + WaistArmor.Stamina + LegsArmor.Stamina + FeetArmor.Stamina + FingerArmor.Stamina + Finger2Armor.Stamina + TrinketArmor.Stamina + Trinket2Armor.Stamina; } }
        public float Intellect { get { return HeadArmor.Intellect + NeckArmor.Intellect + ShouldersArmor.Intellect + BackArmor.Intellect + ChestArmor.Intellect + WristArmor.Intellect + HandsArmor.Intellect + WaistArmor.Intellect + LegsArmor.Intellect + FeetArmor.Intellect + FingerArmor.Intellect + Finger2Armor.Intellect + TrinketArmor.Intellect + Trinket2Armor.Intellect; } }
        public float Spirit { get { return HeadArmor.Spirit + NeckArmor.Spirit + ShouldersArmor.Spirit + BackArmor.Spirit + ChestArmor.Spirit + WristArmor.Spirit + HandsArmor.Spirit + WaistArmor.Spirit + LegsArmor.Spirit + FeetArmor.Spirit + FingerArmor.Spirit + Finger2Armor.Spirit + TrinketArmor.Spirit + Trinket2Armor.Spirit; } }
        public float Armorvalue { get { return HeadArmor.Armorvalue + NeckArmor.Armorvalue + ShouldersArmor.Armorvalue + BackArmor.Armorvalue + ChestArmor.Armorvalue + WristArmor.Armorvalue + HandsArmor.Armorvalue + WaistArmor.Armorvalue + LegsArmor.Armorvalue + FeetArmor.Armorvalue + FingerArmor.Armorvalue + Finger2Armor.Armorvalue + TrinketArmor.Armorvalue + Trinket2Armor.Armorvalue; } }
        public float Arcaneresistance { get { return HeadArmor.Arcaneresistance + NeckArmor.Arcaneresistance + ShouldersArmor.Arcaneresistance + BackArmor.Arcaneresistance + ChestArmor.Arcaneresistance + WristArmor.Arcaneresistance + HandsArmor.Arcaneresistance + WaistArmor.Arcaneresistance + LegsArmor.Arcaneresistance + FeetArmor.Arcaneresistance + FingerArmor.Arcaneresistance + Finger2Armor.Arcaneresistance + TrinketArmor.Arcaneresistance + Trinket2Armor.Arcaneresistance; } }
        public float Fireresistance { get { return HeadArmor.Fireresistance + NeckArmor.Fireresistance + ShouldersArmor.Fireresistance + BackArmor.Fireresistance + ChestArmor.Fireresistance + WristArmor.Fireresistance + HandsArmor.Fireresistance + WaistArmor.Fireresistance + LegsArmor.Fireresistance + FeetArmor.Fireresistance + FingerArmor.Fireresistance + Finger2Armor.Fireresistance + TrinketArmor.Fireresistance + Trinket2Armor.Fireresistance; } }
        public float Natureresistance { get { return HeadArmor.Natureresistance + NeckArmor.Natureresistance + ShouldersArmor.Natureresistance + BackArmor.Natureresistance + ChestArmor.Natureresistance + WristArmor.Natureresistance + HandsArmor.Natureresistance + WaistArmor.Natureresistance + LegsArmor.Natureresistance + FeetArmor.Natureresistance + FingerArmor.Natureresistance + Finger2Armor.Natureresistance + TrinketArmor.Natureresistance + Trinket2Armor.Natureresistance; } }
        public float Frostresistance { get { return HeadArmor.Frostresistance + NeckArmor.Frostresistance + ShouldersArmor.Frostresistance + BackArmor.Frostresistance + ChestArmor.Frostresistance + WristArmor.Frostresistance + HandsArmor.Frostresistance + WaistArmor.Frostresistance + LegsArmor.Frostresistance + FeetArmor.Frostresistance + FingerArmor.Frostresistance + Finger2Armor.Frostresistance + TrinketArmor.Frostresistance + Trinket2Armor.Frostresistance; } }
        public float Shadowresistance { get { return HeadArmor.Shadowresistance + NeckArmor.Shadowresistance + ShouldersArmor.Shadowresistance + BackArmor.Shadowresistance + ChestArmor.Shadowresistance + WristArmor.Shadowresistance + HandsArmor.Shadowresistance + WaistArmor.Shadowresistance + LegsArmor.Shadowresistance + FeetArmor.Shadowresistance + FingerArmor.Shadowresistance + Finger2Armor.Shadowresistance + TrinketArmor.Shadowresistance + Trinket2Armor.Shadowresistance; } }
        public float Attackpower { get { return HeadArmor.Attackpower + NeckArmor.Attackpower + ShouldersArmor.Attackpower + BackArmor.Attackpower + ChestArmor.Attackpower + WristArmor.Attackpower + HandsArmor.Attackpower + WaistArmor.Attackpower + LegsArmor.Attackpower + FeetArmor.Attackpower + FingerArmor.Attackpower + Finger2Armor.Attackpower + TrinketArmor.Attackpower + Trinket2Armor.Attackpower; } }
        public float Attackspeed { get { return HeadArmor.Attackspeed + NeckArmor.Attackspeed + ShouldersArmor.Attackspeed + BackArmor.Attackspeed + ChestArmor.Attackspeed + WristArmor.Attackspeed + HandsArmor.Attackspeed + WaistArmor.Attackspeed + LegsArmor.Attackspeed + FeetArmor.Attackspeed + FingerArmor.Attackspeed + Finger2Armor.Attackspeed + TrinketArmor.Attackspeed + Trinket2Armor.Attackspeed; } }
        public float Blockchance { get { return HeadArmor.Blockchance + NeckArmor.Blockchance + ShouldersArmor.Blockchance + BackArmor.Blockchance + ChestArmor.Blockchance + WristArmor.Blockchance + HandsArmor.Blockchance + WaistArmor.Blockchance + LegsArmor.Blockchance + FeetArmor.Blockchance + FingerArmor.Blockchance + Finger2Armor.Blockchance + TrinketArmor.Blockchance + Trinket2Armor.Blockchance; } }
        public float Blockvalue { get { return HeadArmor.Blockvalue + NeckArmor.Blockvalue + ShouldersArmor.Blockvalue + BackArmor.Blockvalue + ChestArmor.Blockvalue + WristArmor.Blockvalue + HandsArmor.Blockvalue + WaistArmor.Blockvalue + LegsArmor.Blockvalue + FeetArmor.Blockvalue + FingerArmor.Blockvalue + Finger2Armor.Blockvalue + TrinketArmor.Blockvalue + Trinket2Armor.Blockvalue; } }
        public float Critchance { get { return HeadArmor.Critchance + NeckArmor.Critchance + ShouldersArmor.Critchance + BackArmor.Critchance + ChestArmor.Critchance + WristArmor.Critchance + HandsArmor.Critchance + WaistArmor.Critchance + LegsArmor.Critchance + FeetArmor.Critchance + FingerArmor.Critchance + Finger2Armor.Critchance + TrinketArmor.Critchance + Trinket2Armor.Critchance; } }
        public float Damage { get { return HeadArmor.Damage + NeckArmor.Damage + ShouldersArmor.Damage + BackArmor.Damage + ChestArmor.Damage + WristArmor.Damage + HandsArmor.Damage + WaistArmor.Damage + LegsArmor.Damage + FeetArmor.Damage + FingerArmor.Damage + Finger2Armor.Damage + TrinketArmor.Damage + Trinket2Armor.Damage; } }
        public float Defense { get { return HeadArmor.Defense + NeckArmor.Defense + ShouldersArmor.Defense + BackArmor.Defense + ChestArmor.Defense + WristArmor.Defense + HandsArmor.Defense + WaistArmor.Defense + LegsArmor.Defense + FeetArmor.Defense + FingerArmor.Defense + Finger2Armor.Defense + TrinketArmor.Defense + Trinket2Armor.Defense; } }
        public float Dodgechance { get { return HeadArmor.Dodgechance + NeckArmor.Dodgechance + ShouldersArmor.Dodgechance + BackArmor.Dodgechance + ChestArmor.Dodgechance + WristArmor.Dodgechance + HandsArmor.Dodgechance + WaistArmor.Dodgechance + LegsArmor.Dodgechance + FeetArmor.Dodgechance + FingerArmor.Dodgechance + Finger2Armor.Dodgechance + TrinketArmor.Dodgechance + Trinket2Armor.Dodgechance; } }
        public float Healing { get { return HeadArmor.Healing + NeckArmor.Healing + ShouldersArmor.Healing + BackArmor.Healing + ChestArmor.Healing + WristArmor.Healing + HandsArmor.Healing + WaistArmor.Healing + LegsArmor.Healing + FeetArmor.Healing + FingerArmor.Healing + Finger2Armor.Healing + TrinketArmor.Healing + Trinket2Armor.Healing; } }
        public float Health { get { return HeadArmor.Health + NeckArmor.Health + ShouldersArmor.Health + BackArmor.Health + ChestArmor.Health + WristArmor.Health + HandsArmor.Health + WaistArmor.Health + LegsArmor.Health + FeetArmor.Health + FingerArmor.Health + Finger2Armor.Health + TrinketArmor.Health + Trinket2Armor.Health; } }
        public float Hitchance { get { return HeadArmor.Hitchance + NeckArmor.Hitchance + ShouldersArmor.Hitchance + BackArmor.Hitchance + ChestArmor.Hitchance + WristArmor.Hitchance + HandsArmor.Hitchance + WaistArmor.Hitchance + LegsArmor.Hitchance + FeetArmor.Hitchance + FingerArmor.Hitchance + Finger2Armor.Hitchance + TrinketArmor.Hitchance + Trinket2Armor.Hitchance; } }
        public float Hp5 { get { return HeadArmor.Hp5 + NeckArmor.Hp5 + ShouldersArmor.Hp5 + BackArmor.Hp5 + ChestArmor.Hp5 + WristArmor.Hp5 + HandsArmor.Hp5 + WaistArmor.Hp5 + LegsArmor.Hp5 + FeetArmor.Hp5 + FingerArmor.Hp5 + Finger2Armor.Hp5 + TrinketArmor.Hp5 + Trinket2Armor.Hp5; } }
        public float Mana { get { return HeadArmor.Mana + NeckArmor.Mana + ShouldersArmor.Mana + BackArmor.Mana + ChestArmor.Mana + WristArmor.Mana + HandsArmor.Mana + WaistArmor.Mana + LegsArmor.Mana + FeetArmor.Mana + FingerArmor.Mana + Finger2Armor.Mana + TrinketArmor.Mana + Trinket2Armor.Mana; } }
        public float Mp5 { get { return HeadArmor.Mp5 + NeckArmor.Mp5 + ShouldersArmor.Mp5 + BackArmor.Mp5 + ChestArmor.Mp5 + WristArmor.Mp5 + HandsArmor.Mp5 + WaistArmor.Mp5 + LegsArmor.Mp5 + FeetArmor.Mp5 + FingerArmor.Mp5 + Finger2Armor.Mp5 + TrinketArmor.Mp5 + Trinket2Armor.Mp5; } }
        public float Parrychance { get { return HeadArmor.Parrychance + NeckArmor.Parrychance + ShouldersArmor.Parrychance + BackArmor.Parrychance + ChestArmor.Parrychance + WristArmor.Parrychance + HandsArmor.Parrychance + WaistArmor.Parrychance + LegsArmor.Parrychance + FeetArmor.Parrychance + FingerArmor.Parrychance + Finger2Armor.Parrychance + TrinketArmor.Parrychance + Trinket2Armor.Parrychance; } }
        public float Reflect { get { return HeadArmor.Reflect + NeckArmor.Reflect + ShouldersArmor.Reflect + BackArmor.Reflect + ChestArmor.Reflect + WristArmor.Reflect + HandsArmor.Reflect + WaistArmor.Reflect + LegsArmor.Reflect + FeetArmor.Reflect + FingerArmor.Reflect + Finger2Armor.Reflect + TrinketArmor.Reflect + Trinket2Armor.Reflect; } }

        public string HeadArmorToolTip { get { return HeadArmor.Tooltip; } }
        public string NeckArmorToolTip { get { return NeckArmor.Tooltip; } }
        public string ShouldersArmorToolTip { get { return ShouldersArmor.Tooltip; } }
        public string BackArmorToolTip { get { return BackArmor.Tooltip; } }
        public string ChestArmorToolTip { get { return ChestArmor.Tooltip; } }
        public string WristArmorToolTip { get { return WristArmor.Tooltip; } }
        public string HandsArmorToolTip { get { return HandsArmor.Tooltip; } }
        public string WaistArmorToolTip { get { return WaistArmor.Tooltip; } }
        public string LegsArmorToolTip { get { return LegsArmor.Tooltip; } }
        public string FeetArmorToolTip { get { return FeetArmor.Tooltip; } }
        public string FingerArmorToolTip { get { return FingerArmor.Tooltip; } }
        public string Finger2ArmorToolTip { get { return Finger2Armor.Tooltip; } }
        public string TrinketArmorToolTip { get { return TrinketArmor.Tooltip; } }
        public string Trinket2ArmorToolTip { get { return Trinket2Armor.Tooltip; } }

        public ArmorCombination(Armor headArmor, Armor neckArmor, Armor shouldersArmor, Armor backArmor, Armor chestArmor, Armor wristArmor, Armor handsArmor, Armor waistArmor, Armor legsArmor, Armor feetArmor, Armor fingerArmor, Armor finger2Armor, Armor trinketArmor, Armor trinket2Armor)
        {
            HeadArmor = headArmor;
            NeckArmor = neckArmor;
            ShouldersArmor = shouldersArmor;
            BackArmor = backArmor;
            ChestArmor = chestArmor;
            WristArmor = wristArmor;
            HandsArmor = handsArmor;
            WaistArmor = waistArmor;
            LegsArmor = legsArmor;
            FeetArmor = feetArmor;
            FingerArmor = fingerArmor;
            Finger2Armor = finger2Armor;
            TrinketArmor = trinketArmor;
            Trinket2Armor = trinket2Armor;
            Rating = 0f;
        }
    }
}
