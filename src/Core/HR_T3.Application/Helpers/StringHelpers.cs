using System.Text;

namespace HR_T3.Application.Helpers
{
    public static class StringHelpers
    {
        public static string ToEnglishChar(string text)
        {
            char[] turkishChars = { 'ı', 'ğ', 'İ', 'Ğ', 'ç', 'Ç', 'ş', 'Ş', 'ö', 'Ö', 'ü', 'Ü' };
            char[] englishChars = { 'i', 'g', 'I', 'G', 'c', 'C', 's', 'S', 'o', 'O', 'u', 'U' };

            for (int i = 0; i < turkishChars.Length; i++)
                text = text.Replace(turkishChars[i], englishChars[i]);

            return text;
        }
        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public static bool IsValidIdentityNumber(string id)
        {
            if (id == null)
            {
                return false;
            }
            string tcKimlikNo = id.ToString();
            bool returnValue = false;
            if (tcKimlikNo.Length == 11)
            {
                if (!long.TryParse(tcKimlikNo, out long TcNo)) return false;
                long ATCNO, BTCNO;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;
                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;
                C1 = ATCNO % 10;
                ATCNO /= 10;
                C2 = ATCNO % 10;
                ATCNO /= 10;
                C3 = ATCNO % 10;
                ATCNO /= 10;
                C4 = ATCNO % 10;
                ATCNO /= 10;
                C5 = ATCNO % 10;
                ATCNO /= 10;
                C6 = ATCNO % 10;
                ATCNO /= 10;
                C7 = ATCNO % 10;
                ATCNO /= 10;
                C8 = ATCNO % 10;
                ATCNO /= 10;
                C9 = ATCNO % 10;
                Q1 = (10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10;
                Q2 = (10 - ((((C2 + C4 + C6 + C8 + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10;
                returnValue = (BTCNO * 100) + (Q1 * 10) + Q2 == TcNo;
            }
            return returnValue;
        }
    }
}
