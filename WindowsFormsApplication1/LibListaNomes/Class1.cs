using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LibListaNomes
{

    public interface IListaNomes
    {
        void addName(String name);
        void clean();
    }
    public class ListaNomes : IListaNomes
    {
        private ArrayList nameList;

        public ListaNomes()
        {
            nameList = new ArrayList();
        }

        void addName(String name)
        {
            nameList.Add(name);
        }
    }
}
