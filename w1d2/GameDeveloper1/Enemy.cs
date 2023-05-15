public class Enemy
{
    public string Name;
    public List<Attack> AttackList;
    private int _health;
    public int Health;


    public Enemy(string name, int _health = 100)
    {
        Name = name;
        AttackList = new List<Attack>();
        Health = _health;
    }

    public Attack RandomAttack(List<Attack> attackList)
    {
        Random randAttack = new Random();
        int AttackListPos = randAttack.Next(0, AttackList.Count);
        Attack AnAttack = AttackList[AttackListPos];

        return AnAttack;
    }

    public List<Attack> AddAttack(Attack attack)
    {
        AttackList.Add(attack);
        return AttackList;
    }

// The Start of Game Developer II Assignment
    public void PerformAttack(Enemy target, Attack chosenAttack) 
    {
        int TargetHealth = target.Health - chosenAttack.DamageAmount;
        Console.WriteLine($"{Name} attacks {target.Name} with {chosenAttack.Name} dealing {chosenAttack.DamageAmount} reducing {target.Name}'s health to {TargetHealth}");
    }
}