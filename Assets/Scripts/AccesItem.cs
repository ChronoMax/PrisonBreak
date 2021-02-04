public class AccesItem : Item
{
    private int doorId;

    //constructor
    public AccesItem(string name, float weight, int door) : base(name, weight)
    {
        this.doorId = door;
    }

    public int GetDoorId()
    {
        return doorId;
    }

    public bool OpensDoor(int id)
    {
        return doorId == id;
    }
}
