class Enemy
{
    public string Name {get;set;}
    public List<Attack> AttackList;
    private int Health;
    public int _Health {get;set;}


    public Enemy(string name, int health = 100)
    {
        Name = name;
        AttackList = new List<Attack>();
        _Health = health;
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

}