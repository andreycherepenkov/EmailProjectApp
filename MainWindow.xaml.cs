using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmailProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string letter = Letter.Text;
                string adress = Adress.Text;
                string text = Teext.Text;
                SmtpClient mySmtpClient = new SmtpClient("smtp.mail.ru");

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = true;
                mySmtpClient.EnableSsl = true;
                System.Net.NetworkCredential basicAuthenticationInfo = new
                   System.Net.NetworkCredential("testfortest1.01@mail.ru", "gTdTpz07TjHaKY7bqfgM");
                mySmtpClient.Credentials = basicAuthenticationInfo;

                // add from,to mailaddresses
                MailAddress from = new MailAddress("testfortest1.01@mail.ru", "Anonim"); //откуда
                MailAddress to = new MailAddress(adress, "Вам"); //куда
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                // add ReplyTo
                MailAddress replyTo = new MailAddress("testfortest1.01@mail.ru"); // почта на ответ = откуда (обычно)
                myMail.ReplyToList.Add(replyTo);

                // set subject and encoding
                myMail.Subject = letter;
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = text;
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = true;

                mySmtpClient.Send(myMail);
            }

            catch (SmtpException ex)
            {
                throw new ApplicationException
                  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        
    }
}
