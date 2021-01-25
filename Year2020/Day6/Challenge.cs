using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Year2020.Day6
{
    public class Challenge
    {
        public static int GetCombinedCount()
        {
            return GetForms().Sum(form => form.CheckCount);
        }
        public static IEnumerable<Form> GetForms()
        {
            var forms = new List<Form>();
            var currentForm = new Form();
            foreach (var line in GetData())
            {
                if (line == string.Empty)
                {
                    forms.Add(currentForm);
                    currentForm = new Form();
                }
                currentForm.Check(line);
            }
            forms.Add(currentForm);
            return forms;
        }
        public static IEnumerable<string> GetData()
        {
            return File.ReadAllLines("Day6/Input.txt");
        }
    }
}