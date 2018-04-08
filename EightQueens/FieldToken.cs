namespace EightQueens
{
    public class FieldToken
    {
        public bool IsValid { get; private set; }
        public string Field { get; private set; }

        public static FieldToken ValidToken(string field)
        {
            return new FieldToken
            {
                Field = field,
                IsValid = true
            };
        }

        public static FieldToken Invalid()
        {
            return new FieldToken
            {
                Field = null,
                IsValid = false
            };
        }
    }
}