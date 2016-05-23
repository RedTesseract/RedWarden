using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace RedWarden
{
    class Web
    {

        //metoda za slanje POST zahtjeva na PHP skripte na serveru.
        //Kao parametre predaje joj se URL PHP skripte te (paran) niz varijabli koji dolaze u parovima naziv varijable i vrijednost varijable.
        //U PHP skripti će se dohvaćati što je već poslano u tim varijablama
        public static string GetPost(string Url, params string[] postdata)  
        {
            string result = string.Empty;
            string data = string.Empty;

            System.Text.ASCIIEncoding ascii = new ASCIIEncoding();

            if (postdata.Length % 2 != 0) //provjerava jesu li uneseni parametri u metodu parni
            {
                MessageBox.Show("Parameters must be even , \"user\" , \"value\" , ... etc", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;  
            }

            for (int i = 0; i < postdata.Length; i += 2)  
            {
                data += string.Format("&{0}={1}", postdata[i], postdata[i + 1]);  
            }

            data = data.Remove(0, 1); //

            byte[] bytesarr = ascii.GetBytes(data);
            try
            {
                //kreira se veza (stream) sa navedenim URL-om te se izmjenjuju podaci.

                WebRequest request = WebRequest.Create(Url);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = bytesarr.Length;

                System.IO.Stream streamwriter = request.GetRequestStream();
                streamwriter.Write(bytesarr, 0, bytesarr.Length);
                streamwriter.Close();

                WebResponse response = request.GetResponse();
                streamwriter = response.GetResponseStream();

                //dohvaća podatke s kraja streama, tj. ono što je skripta vratila nakon izvršenja

                System.IO.StreamReader streamread = new System.IO.StreamReader(streamwriter);
                result = streamread.ReadToEnd();
                streamread.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}
