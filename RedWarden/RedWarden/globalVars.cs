using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedWarden
{
    //klasa s globalnim varijablama korištenim u ostalim dijelovima aplikacije i njihovim standardnim konstruktorima
    public class globalVars
    {
        //varijabla za login status. Ako je 0, korisnik nije ulogiran.
        public static bool LoginStatus { get; set; }

        //nakon logina, tu se sprema korisničko ime
        public static string LoginIme { get; set; }

        //Ovisno o odabiru u Main formi, sprema se da li je offline ili online način rada odabran
        //kako bi forma za rad znala što napraviti
        public static int TipRada { get; set; }
    }
}
