public class RangedFighter : Enemy
{
    public int Distance;
    public RangedFighter(string name, int distance = 5): base(name)
    {
        Distance = distance;
        
        Attack ShootArrow = new Attack("ShootArrow", 20);
        Attack ThrowKnife = new Attack("ThrowKnife", 15);
        AttackList.Add(ShootArrow);
        AttackList.Add(ThrowKnife);

    }

    public void Dash()
    {
        Distance = 20;
        Console.WriteLine($"Dash Action Taken distance is now: {Distance}");
    }

    public void RangedAttack(List<Attack> attackList, Enemy target)
    {
        //if too close return "must dash before attacking"
        if(Distance <= 10) 
        {
            Dash();
            Attack RandAttack = RandomAttack(AttackList);
            PerformAttack(target, RandAttack);
        } 
    }


}