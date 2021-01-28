using System.Collections.Generic;

class NickChecker
{
    public static bool IsCorrect(List<string> nicks)
    {
        return IsNickLengthAllowed(nicks) & AreNicksDifferent(nicks);
    }

    private static bool IsNickLengthAllowed(List<string> nicks)
    {
        for (int i = 0; i < nicks.Count; i++)
            if (!Validator.IsLengthAllowed(nicks[i], 1, 12))
                return false;
        return true;
    }

    private static bool AreNicksDifferent(List<string> nicks)
    {
        for (int i = 0; i < nicks.Count; i++)
            for (int j = i; j < nicks.Count; j++)
                if (i != j &&
                    nicks[i].CompareTo(nicks[j]) == 0)
                        return false; // если равны, вернуть false
        return true; 
    }
}
