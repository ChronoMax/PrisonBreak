public class PuzzelItem : Item
{
    private string anwser;
    private string question;
    private bool solved;

    public PuzzelItem(string name, float weight, string question, string answer) : base(name, weight)
    {
        this.question = question;
        this.anwser = answer;
        solved = false;
    }

    public string GetRiddle()
    {
        return question;
    }

    public string GetAnwser()
    {
        return anwser;
    }

    public bool checkAnwser(string possibleAnwser)
    {
        if (possibleAnwser == anwser)
        {
            solved = true;
            return solved;
        }
        return false;
    }

    public bool IsSolved()
    {
        return solved;
    }

    public void Reset()
    {
        solved = false;
    }
}
