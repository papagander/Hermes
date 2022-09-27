using Domain.Interfaces.Models;

using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.DataCore
{

    public class Conjoiner : INamed
    {
        // AND, OR
        public int ConjoinerId { get; set; }
        public string ConjoinerName { get; set; }


        string INamed.Name { get { return ConjoinerName; } set { ConjoinerName = value; } }
        int IIndexed.Id { get { return ConjoinerId; } set { ConjoinerId = value; } }
    }

}

