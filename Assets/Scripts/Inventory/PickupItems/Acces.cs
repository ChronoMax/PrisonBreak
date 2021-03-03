public class Acces : Pickup
{
    public int doorId;

    public override Item CreateItem()
    {
        return new AccesItem(itemName, weight, doorId);
    }
}
