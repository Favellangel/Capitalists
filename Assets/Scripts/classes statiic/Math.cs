public static class Math
    {
    /// <summary>
    /// расчитывает % от числа по заданному проценту
    /// </summary>
    /// <param name="num">Число, от которого берем процент</param>
    /// <param name="k">процент от числа</param>
    /// <returns>возвращает процент от числа</returns>
    public static int calculatePercentage(int num, float k) 
    {
        return (int)(num * k);
    }

    /// <summary>
    /// Проверяет входит ли число в диапазон 50% - 150% от заданного числа
    /// </summary>
    /// <param name="num">проверяемое число</param>
    /// <param name="numBorder">число, от которого берется диапазон</param>
    /// <returns></returns>
    public static int IsNumAcceptable(this int num, int numBorder) 
    {
        int min = numBorder / 2;
        int max = numBorder * 2;
        if (num > min || num < max)
            return num;
        else
            return numBorder;
    }
    /// <summary>
    /// возвращает рандомное число(+- 1/3 от num)
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static int Random(int num)
    {
        int rand = UnityEngine.Random.Range(-num / 3, num / 3);
        return rand;
    }
}

