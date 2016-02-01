using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMainProject.Interfaces
{
    public interface IBlob
    {
        int Health { get; set; }

        int Damage { get; set; }

        string Name { get; set; }

        IBehavior Behavior { get; }

        ISpell BlobSpell { get; }

        int RoundDelay { get; set; }

        void Attack(IBlob enemyBlob);
    }
}
