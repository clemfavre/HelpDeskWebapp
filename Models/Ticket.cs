/// <summary>
/// class representing a single ticket describing a problem to be resolved by IT support
/// </summary>
public class Ticket
{
    //unique identifier
    public int Id {get; set;}
    public string Title {get; set;}
    public string Description {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    //open --> in progress --> resolved
    public string Status {get; set;} = "open";
    //low/medium/high priority
    public string Priority {get; set;}
}