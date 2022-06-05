using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Objects.Sports
{
    public interface ISport
    {
        public string Name { get; }
        public string Scoring { get; }
        public bool ScoreIsValid(object home, object away);
        public string ToString();
    }
}
