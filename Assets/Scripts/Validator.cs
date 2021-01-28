/// <summary>
/// Проверяет строки на коректность
/// </summary>
class Validator
{
    /// <summary>
    /// Проверяет, сколько символов может содержать строка
    /// </summary>
    /// <param name="str">Проверяемая строка</param>
    /// <param name="minNumChars">Минимальное число символов</param>
    /// <param name="maxNumChars">Максимальное число символов</param>
    /// <returns></returns>
    public static bool IsLengthAllowed(string str, int minNumChars, int maxNumChars)
    {
        if (minNumChars <= str.Length && maxNumChars >= str.Length) 
            return true;
        return false;
    }   
}
