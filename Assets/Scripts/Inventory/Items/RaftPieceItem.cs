public class RaftPieceItem : Item
{
    private int RaftPieceID;
    public RaftPieceItem(string name, float weight, int RaftPieceID) : base(name, weight)
    {
        this.RaftPieceID = RaftPieceID;
    }
}
