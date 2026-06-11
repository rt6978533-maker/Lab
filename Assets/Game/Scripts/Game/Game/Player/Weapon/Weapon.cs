namespace Game.Player.Weapon
{
    public abstract class Weapon : Items, IFireable
    {
        public abstract void Fire();
    }
}