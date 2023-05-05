public class MeleeFighter : Enemy
{
    public MeleeFighter() : base("MeleFighter", 120)
    {
        Attack Punch = new Attack("Punch", 20);
        Attack Kick = new Attack("Kick", 15);
        Attack Tackle = new Attack("Tackle", 25);
        
        AddAttack(Punch);
        AddAttack(Kick);
        AddAttack(Tackle);

    }

    public void RageAttack(List<Attack> attackList, Enemy target)
    {
        Attack RandRage = RandomAttack(AttackList);
        target.Health = target.Health - 10;
        PerformAttack(target, RandRage);
    }
}