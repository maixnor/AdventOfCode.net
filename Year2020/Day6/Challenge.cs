using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Year2020.Day6
{
    public class Challenge
    {
        public static int GetCombinedCountAll()
        {
            return GetFormsAll().Sum(form => form.AllCheckCount);
        }
        public static int GetCombinedCountAny()
        {
            return GetFormsAny().Sum(form => form.AnyCheckCount);
        }

        public static IEnumerable<Form> GetFormsAll(string[] data = null)
        {
            var forms = new List<Form>();
            var currentForm = new Form();
            foreach (var line in data ?? GetData())
            {
                if (line == string.Empty)
                {
                    forms.Add(currentForm);
                    currentForm = new Form();
                }
                else
                {
                    currentForm.AllCheck(line);
                }
            }
            forms.Add(currentForm);
            return forms;
        }
        public static IEnumerable<Form> GetFormsAny()
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
                else
                {
                    currentForm.AnyCheck(line);
                }
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