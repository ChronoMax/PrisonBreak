public class RaftPiece : Pickup
{
    public int RaftPieceID;

    public override Item CreateItem()
    {
        return new RaftPieceItem(itemName, weight, RaftPieceID);
    }
}
