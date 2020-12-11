using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp6.Entidades
{
    public class Helper
    {
        public static Cadete BuscarPorId(List<Cadete> personita, int id)
        {
            return personita.Find(match: p => p.Id == id);
        }
    }
}
