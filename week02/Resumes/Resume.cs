public class Resume
{
    public string _name;
    public List<Job> _jobs;


    //method
    public void Display()
    {
        Console.WriteLine(_name);
        Console.WriteLine("Jobs: ");
        for (int i=0; i<_jobs.Count; i++)
        {     
            _jobs[i].DisplayJobDetails();
        }
        
    }
}