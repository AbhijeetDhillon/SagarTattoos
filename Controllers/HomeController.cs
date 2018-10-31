using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SagarTattoos.Models;
using System.Net;
using System.Net.Mail;

namespace SagarTattoos.Controllers
{
    
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {

            
                Contact details = new Contact();
                {
                    details.Name = frm["Name"];
                    details.Mail = frm["Email"];
                    details.Phone = frm["Phone"];
                    details.Message = frm["Message"];



                }

                if (ModelState.IsValid)
                {
                    var body = details.Name + "\n" + details.Mail + "\n" + details.Phone + "\n" + details.Message;
                                
                                var message = new MailMessage();
                                message.To.Add(new MailAddress("sagartattooarts@gmail.com"));  // replace with valid value 
                                message.From = new MailAddress(details.Mail);
                                message.Subject = "SAGAR TATTOOS";
                                
                                message.Body = string.Format(body);
                                message.IsBodyHtml = true;
                                


                                try
                                {
                                    using (var smtp = new SmtpClient())
                                    {
                                        var credential = new NetworkCredential
                                        {
                                            UserName = "sagartattoos555@gmail.com",  // replace with valid value
                                            Password = "sumansonu143"  // replace with valid value
                                        };
                                        

                                        smtp.Host = " smtp.gmail.com";
                                        smtp.Port = 587;
                                        smtp.UseDefaultCredentials = false;
                                        smtp.Credentials = credential;
                                        smtp.EnableSsl = true;
                                        smtp.Send(message);
                                    }
                                }
                                catch (SmtpException ex)
{
//catched smtp exception
ViewBag.Text = "SMTP Exception: " + ex.Message.ToString();
ViewBag.ForeColor = System.Drawing.Color.Red;
return View();
}
catch (Exception ex)
{
ViewBag.Text = "Error: " + ex.Message.ToString();
ViewBag.ForeColor = System.Drawing.Color.Red;
return View();
}

                    }

                return View();
            


        }
       
        public ActionResult Portfolio() {


            return View();
        
        }

    }
    
}


    


    



    

