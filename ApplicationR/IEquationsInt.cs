namespace ApplicationR
{
    public interface IEquationsInt : IEquate, ICalculateAnswer
    {
        void PopulateArguments_Range100();

        int ArgumentA { get; set; }

        int ArgumentB { get; set; }

        int ArgumentC { get; set; }

        int ArgumentD { get; set; }

        int ArgumentE { get; set; }

        int ArgumentsAnswer { get; set; }
    }

}