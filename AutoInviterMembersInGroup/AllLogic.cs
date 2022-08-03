using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;

namespace AutoInviterMembersInGroup
{
    public class AllLogic
    {
        public IList<string> GetListWithIdAndHashMembers(string path)
        {
            var list = new List<string>();

            using (StreamReader reader = new StreamReader(path))
            {
                string? line;

                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line);
                }

                return list;
            }
        }

        public IList<string> CreatedThirtyMembersFromListAndSavingBigListInFile(IList<string> list, string path)
        {
            List<string> thirtyMembers = new List<string>();

            for (int i = 0; i < 20 ; i++)
            {
                thirtyMembers.Add(list[i]);
                list.Remove(list[i]);
            }
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (var member in list)
                {
                    writer.WriteLine(member);
                }
            }

            return thirtyMembers;
        }

        public IDictionary<long, long> TransformListInDictionary(IList<string> list)
        {
            IDictionary<long, long> result = new Dictionary<long, long>();

            foreach (var member in list)
            {
                string key = null;
                string value = null;

                for (int i = 0; i < member.Length; i++)
                {
                    if (member[i] == ':')
                    {
                        for (int a = i+1; a < member.Length; a++)
                        {
                            value += member[a];
                        }
                        break;
                    }
                    key += member[i];
                }
                result.Add(Convert.ToInt64(key), Convert.ToInt64(value));
            }
            return result;
        }
    }
}
