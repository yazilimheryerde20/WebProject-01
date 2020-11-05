using Onixa.Bussiness.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.IO;
using Onixa_Web.Models;

namespace Onixa_Web.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(ICategoryService categoryService) : base(categoryService)
        {
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult myOrders()
        {
            return View();
        }

        public ActionResult OrderMailSend()
        {
            
            string urun_bilgileri = "";
            List<BasketModel> basket = (List<BasketModel>)Session["Basket"];
            foreach (var item in basket)
            {
                
                

                urun_bilgileri += @"<tr><td class=""esd - structure es - p20t es - p20r es - p20l"" align=""left""><table cellpadding = ""0"" cellspacing = ""0"" width = ""100%"">"+
                                  @"<tbody><tr><td width = ""560"" class=""esd-container-frame"" align=""center"" valign=""top""><table cellpadding = ""0"" cellspacing=""0"" width=""100%"">"+
                                  @"<tbody><tr><td align = ""left"" class=""esd-block-text""><p style = ""color: #ffffff;""><br/></p></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td class=""esd-structure es-p20t es-p20r es-p20l"" align=""left"">"+
                                  @"<table cellpadding = ""0"" cellspacing=""0"" class=""es-left"" align=""left""><tbody><tr><td width = ""270"" class=""es-m-p20b esd-container-frame"" align=""left""><table cellpadding = ""0"" cellspacing=""0"" width=""100%"">"+
                                  @"<tbody><tr><td align = ""center"" class=""esd-block-image"" style=""font-size: 0px;""><a target = ""_blank"" ><img class=""adapt-img"" src="+Server.MapPath(@"../img/")+ item.MyBasketbyProducts.MainImage+@" style=""display: block;"" width=""270"" /></a></td>" +
                                  @"</tr></tbody></table></td></tr></tbody></table>"+
                                  @"<table cellpadding = ""0"" cellspacing=""0"" class=""es-right"" align=""right""><tbody><tr><td width = ""270"" align=""left"" class=""esd-container-frame"">"+
                                  @"<table cellpadding = ""0"" cellspacing=""0"" width=""100%""><tbody><tr><td align = ""left"" class=""esd-block-text""><p><b>Ürün ID:</b> "+item.MyBasketbyProducts.Product_Id+"</p>"+
                                  @"</td></tr><tr><td align = ""left"" class=""esd-block-text""><p><b>Ürün Adı:</b> "+item.MyBasketbyProducts.Name+"</p></td></tr><tr>"+@"<td align = ""left"" class=""esd-block-text"">"+
                                  @"<p><b>Oda Adı:</b> "+item.MyBasketbyProducts.Room_Name+"</p></td></tr><tr>"+@"<td align = ""left"" class=""esd-block-text""><p><b>Proje Adı:</b> "+item.MyBasketbyProducts.Project_ID+"</p>"+
                                  @"</td></tr><tr><td align = ""left"" class=""esd-block-text""><p><b>Müşteri Açıklaması:</b> "+item.MyBasketbyProducts.Note+"</p></td></tr></tbody></table></td></tr></tbody></table>"+
                                  @"</td></tr><tr><td class=""esd-structure es-p20t es-p20r es-p20l"" align=""left""><table cellpadding = ""0"" cellspacing=""0"" width=""100%""><tbody><tr>"+
                                  @"<td width = ""560"" class=""esd-container-frame"" align=""center"" valign=""top""><table cellpadding = ""0"" cellspacing=""0"" width=""100%""><tbody><tr><td align = ""center"" class=""esd-block-spacer es-p20"" style=""font-size:0""><table border = ""0"" width=""100%"" height=""100%"" cellpadding=""0"" cellspacing=""0""><tbody><tr><td style = ""border-bottom: 1px solid #333333; background: none; height: 1px; width: 100%; margin: 0px;"" ></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr>"+
                                  @"<td class=""esd-structure es-p20t es-p20r es-p20l"" align=""left""><table cellpadding = ""0"" cellspacing=""0"" width=""100%""><tbody><tr><td width = ""560"" class=""esd-container-frame"" align=""center"" valign=""top""><table cellpadding = ""0"" cellspacing=""0"" width=""100%""><tbody>"+
                                  @"<tr><td align = ""left"" class=""esd-block-text""><p style = ""color: #ffffff;"" ><br/></p></td></tr></tbody></table></td></tr></tbody></table></td></tr>";









            }


            MailMessage msg = new MailMessage();
            msg.Subject = "Onixa Sipariş Bilgileri";
            msg.From = new MailAddress("akdenizerkin@hotmail.com");
            msg.To.Add(new MailAddress("Erdogan@onixa.com.tr", "Erdogan@onixa.com.tr"));
            string header = Server.MapPath(@"..\Views\Mail\") + "admin_order_mail_header.cshtml";
            
            string footer = Server.MapPath(@"..\Views\Mail\") + "admin_order_mail_footer.cshtml";
            StreamReader headereader = new StreamReader(header);
            StreamReader footerReader = new StreamReader(footer);
            
            string MailText = headereader.ReadToEnd() + urun_bilgileri + footerReader.ReadToEnd();
            MailText = MailText.Replace("{CustomerName}", "Erkin");
            MailText = MailText.Replace("{CustomerSurname}", "Akdeniz");
            MailText = MailText.Replace("{CustomerNumber}", "05557655555");
            MailText = MailText.Replace("{CustomerMail}", "erkinakdeniz@hotmail.com");
            MailText = MailText.Replace("{CompanyName}", "Erkin İnşaat");
            MailText = MailText.Replace("{CustomerAddress}", "Bıla bıla sokak");
            headereader.Close();
            footerReader.Close();
            

            msg.Body = MailText;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;
            // Host ve Port Gereklidir!
            SmtpClient smtp = new SmtpClient("smtp.live.com", 587);
            // Güvenli bağlantı gerektiğinden kullanıcı adı ve şifrenizi giriniz.
            NetworkCredential AccountInfo = new NetworkCredential("akdenizerkin@hotmail.com", "19959595");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = AccountInfo;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(msg);

            return View();
        }
    }
}