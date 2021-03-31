public class RaftItem : Item
{
    public int RaftID;
    public RaftItem(string name, float weight, int raftID) : base(name, weight)
    {
        this.RaftID = raftID;
    }
}
