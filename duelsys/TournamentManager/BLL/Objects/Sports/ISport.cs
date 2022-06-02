using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Objects.Sports
{
    public interface ISport
    {
        public string Name { get; set; }
        public string Scoring { get; set; }
        public bool ScoreIsValid(object objHome, object objAway);
        public string ToString();
    }
}
