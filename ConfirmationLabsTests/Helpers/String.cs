namespace ConfirmationLabsTests.Helpers
{
    public class String
    {
        public static string After(string searchHere, string searchThisOne)
        {
            int posA = searchHere.LastIndexOf(searchThisOne);
            if (posA == -1)
            {
                return "";
            }
            int adjustedPosA = posA + searchThisOne.Length;
            if (adjustedPosA >= searchHere.Length)
            {
                return "";
            }
            return searchHere.Substring(adjustedPosA);
        }

        public static string Between(string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }

        public static string Before(string searchHere, string searchThisOne)
        {
            int posA = searchHere.IndexOf(searchThisOne);
            if (posA == -1)
            {
                return "";
            }
            return searchHere.Substring(0, posA);
        }
    }
}