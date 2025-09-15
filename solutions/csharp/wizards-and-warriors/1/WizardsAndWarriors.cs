abstract class Character
{
    private string charType = "";
    protected Character(string characterType)
    {
        charType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {charType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable())
        {
            return 10;
        }
        return 6;
    }
}

class Wizard : Character
{
    private bool spellPrepared = false;
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (spellPrepared)
        {
            return 12;
        }
        return 3;
    }

    public void PrepareSpell()
    {
        spellPrepared = true;
    }
    public override bool Vulnerable()
    {
        return !spellPrepared;
    }
}
