namespace HiddenSolutionsAPI.Persistence.Model
{
    public class Path
    {
        public string Value { get; set; }

        public Path(string p_value)
        {
            Value = p_value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}