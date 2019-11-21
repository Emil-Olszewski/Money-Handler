using System.Collections.Generic;

namespace Money_App.Model
{
    public static class Sorter
    {
        public static void SortAlphabetically(List<string> list)
        {
            bool changed;
            do
            {
                changed = false;
                for (int i = 1; i < list.Count; i++)
                {
                    if (IsAlphabeticallyFirst(list[i].ToUpper(), list[i - 1].ToUpper()))
                    {
                        string temp = list[i];
                        list[i] = list[i - 1];
                        list[i - 1] = temp;
                        changed = true;
                    }
                }

            } while (changed == true);
        }

        public static bool IsAlphabeticallyFirst(string what, string than)
        {
            int lenght = what.Length > than.Length ? than.Length : what.Length;
            for (int i = 0; i < lenght; i++)
            {
                if (what[i] > than[i])
                    return false;
                else if (what[i] < than[i])
                    return true;
                else
                    continue;
            }

            return what.Length < than.Length;
        }
    }
}
