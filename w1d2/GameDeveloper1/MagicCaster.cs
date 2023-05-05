public class MagicCaster : Enemy
{
    public MagicCaster(string name): base(name)
    {
        Health = 80;

        Attack Fireball = new Attack("Fireball", 25);
        Attack LightningBolt = new Attack("LightningBolt", 15);
        Attack StaffStrike = new Attack("StaffStrike", 10);
        AttackList.Add(Fireball);
        AttackList.Add(LightningBolt);
        AttackList.Add(StaffStrike);

    }

    public void Heal(Enemy target)
    {
        target.Health += 40;
        Console.WriteLine($"The {target.Name} health is now {target.Health}");
    }
    
}