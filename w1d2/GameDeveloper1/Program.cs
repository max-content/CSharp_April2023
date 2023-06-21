Attack Fireball = new Attack("Fireball", 60);
Attack Punch = new Attack("Punch", 5);
Attack Mock = new Attack("Mock", 3);
Attack Kick = new Attack("Kick", 15);
Attack DestroyEvil = new Attack("Consume", 150);

Console.WriteLine($"Attack: {Fireball.Name}  |  Damage: {Fireball.DamageAmount}");
Console.WriteLine($"Attack: {Punch.Name}  |  Damage: {Punch.DamageAmount}");
Console.WriteLine($"Attack: {Mock.Name}  |  Damage: {Mock.DamageAmount}");

Enemy LittleBuddy = new Enemy("minion");
LittleBuddy.AttackList.Add(Fireball);
LittleBuddy.AttackList.Add(Punch);
LittleBuddy.AttackList.Add(Mock);
Console.WriteLine(LittleBuddy.RandomAttack(LittleBuddy.AttackList).Name);

Console.WriteLine(LittleBuddy.Health);

Enemy LilBud2 = new Enemy("gremlin", 55);
Console.WriteLine(LilBud2.Health);

LilBud2.AddAttack(Fireball);
LilBud2.AddAttack(Kick);
LilBud2.AddAttack(DestroyEvil);
Console.WriteLine(LilBud2.RandomAttack(LilBud2.AttackList).Name);

// The start of Game Developer II Assignment

LilBud2.PerformAttack(LittleBuddy, Fireball);

MeleeFighter MeleeBoi = new MeleeFighter();

Console.WriteLine(MeleeBoi.RandomAttack(MeleeBoi.AttackList).Name);

MeleeBoi.PerformAttack(LittleBuddy, MeleeBoi.AttackList[1]);

MeleeBoi.RageAttack(MeleeBoi.AttackList, LittleBuddy);

RangedFighter Ranger = new RangedFighter("Ranger");

Ranger.RangedAttack(Ranger.AttackList, MeleeBoi);

MagicCaster Mage = new MagicCaster("Mage");

Mage.Heal(MeleeBoi);