using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace SAPA.Clases
{
    public class Mail
    {
        private string _remitente; //de quien procede, puede ser un alias
        private string _destinatario;  //a quien vamos a enviar el mail
        private string _mensaje;  //mensaje
        private string _asunto; //asunto
        private List<string> _archivosAdjuntos = new List<string>(); //lista de archivos a enviar  "correo.de.prueba.123@hotmail.com";
        private string _correo = "sapa.facturacion1@gmail.com"; //;//"desarrollo@sapa.com.mx";// //nuestro usuario de smtp
        private string _contrasena = "SAPA.123+-";// //nuestro password de smtp  "123456+-"

        MailMessage Email;

        public string error = "";

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="remitente">Procedencia</param>
        /// <param name="destinatario">Mail al cual se enviara</param>
        /// <param name="mensaje">Mensaje del mail</param>
        /// <param name="asunto">Asunto del mail</param>
        /// <param name="archivosAdjuntos">Archivo a adjuntar, no es obligatorio</param>
        public Mail(string remitente, string destinatario, string mensaje, string asunto, List<string> archivosAdjuntos = null)
        {
            _remitente = remitente;
            _destinatario = destinatario;
            _mensaje = mensaje;
            _asunto = asunto;
            _archivosAdjuntos = archivosAdjuntos;
        }

        /// <summary>
        /// metodo que envia el mail
        /// </summary>
        /// <returns></returns>
        public bool enviaMail()
        {

            // una validación básica
            if (string.IsNullOrWhiteSpace(_destinatario) || string.IsNullOrWhiteSpace(_mensaje) || string.IsNullOrWhiteSpace(_asunto))
            {
                error = "El mail, el asunto y el mensaje son obligatorios";
                return false;
            }

            //aqui comenzamos el proceso
            //comienza-------------------------------------------------------------------------
            try
            {
                //creamos un objeto tipo MailMessage
                //este objeto recibe el sujeto o persona que envia el mail,
                //la direccion de procedencia, el asunto y el mensaje
                Email = new MailMessage(_remitente, _destinatario, _asunto, _mensaje);

                //si viene archivo a adjuntar
                //realizamos un recorrido por todos los adjuntos enviados en la lista
                //la lista se llena con direcciones fisicas, por ejemplo: c:/pato.txt
                if (_archivosAdjuntos != null)
                {
                    //agregado de archivo
                    foreach (string adjunto in _archivosAdjuntos)
                    {
                        //comprobamos si existe el archivo y lo agregamos a los adjuntos
                        if (File.Exists(adjunto))
                            Email.Attachments.Add(new Attachment(adjunto));

                    }
                }

                Email.IsBodyHtml = true; //definimos si el contenido sera html
                Email.From = new MailAddress(_remitente); //definimos la direccion de procedencia

                //aqui creamos un objeto tipo SmtpClient el cual recibe el servidor que utilizaremos como smtp
                //en este caso me colgare de gmail
                SmtpClient smtpMail = new SmtpClient("smtp.gmail.com");//();// ("mail.sapa.com.mx");

                smtpMail.EnableSsl = true;//le definimos si es conexión ssl
                smtpMail.UseDefaultCredentials = false; //le decimos que no utilice la credencial por defecto
                smtpMail.Host = "smtp.gmail.com" ;////"mail.sapa.com.mx";//"smtp.live.com"; //agregamos el servidor smtp
                smtpMail.Port = 587;/*465;*/ //587; /*25;*/ //le asignamos el puerto, en este caso gmail utiliza el 465
                smtpMail.Credentials = new NetworkCredential(_correo, _contrasena); //agregamos nuestro usuario y pass de gmail

                //enviamos el mail
                smtpMail.Send(Email);
                
                //eliminamos el objeto
                smtpMail.Dispose();

                //regresamos true
                return true;

                
            }
            catch (Exception ex)
            {
                // si ocurre un error regresamos false y el error
                error = "Ocurrio un error: " + ex.Message;
                return false;
            }

            //return false;

        }
    }
}

