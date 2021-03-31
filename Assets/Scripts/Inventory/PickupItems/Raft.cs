public class Raft : Pickup
{
    public int RaftID;

    public override Item CreateItem()
    {
        return new RaftPieceItem(itemName, weight, RaftID);
    }
}
