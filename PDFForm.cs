using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Kino_AB_V.A.TARpv23
{
    public partial class PDFForm : Form
    {
        private string filmiNimetus;
        private string posterFile;
        private List<string> selectedSeats;
        private string showTime;

        // Добавляем конструктор с 4 параметрами
        public PDFForm(string filmiNimetus, string posterFile, List<string> selectedSeats, string showTime)
        {
            this.filmiNimetus = filmiNimetus;
            this.posterFile = posterFile;
            this.selectedSeats = selectedSeats;
            this.showTime = showTime;


            // Отображаем информацию о билете
            Label labelMovieTitle = new Label() { Text = $"Фильм: {filmiNimetus}", Location = new System.Drawing.Point(50, 50) };
            Label labelSeats = new Label() { Text = $"Места: {string.Join(", ", selectedSeats)}", Location = new System.Drawing.Point(50, 80) };
            Label labelTime = new Label() { Text = $"Время: {showTime}", Location = new System.Drawing.Point(50, 110) };

            Controls.Add(labelMovieTitle);
            Controls.Add(labelSeats);
            Controls.Add(labelTime);

            TextBox emailTextBox = new TextBox() { Location = new Point(50, 170), Width = 200 };
            Controls.Add(emailTextBox);

            // Кнопка для отправки билета по почте
            Button sendButton = new Button() { Text = "Отправить билет", Location = new System.Drawing.Point(50, 150) };
            sendButton.Click += SendButton_Click;
            Controls.Add(sendButton);
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            // Генерация изображения билета
            string imagePath = GenerateTicketImage();

            // Отправка email с изображением
            SendEmail(imagePath);

            MessageBox.Show("Билет отправлен на почту!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Метод для генерации изображения билета
        private string GenerateTicketImage()
        {
            string filePath = "Ticket.png";

            // Создаем изображение
            using (Bitmap bitmap = new Bitmap(400, 200))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                g.DrawString($"Фильм: {filmiNimetus}", new Font("Arial", 14), Brushes.Black, new PointF(20, 20));
                g.DrawString($"Места: {string.Join(", ", selectedSeats)}", new Font("Arial", 12), Brushes.Black, new PointF(20, 50));
                g.DrawString($"Время: {showTime}", new Font("Arial", 12), Brushes.Black, new PointF(20, 80));

                // Сохраняем изображение
                bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            }

            return filePath;
        }

        // Метод для отправки email с изображением
        private void SendEmail(string imagePath)
        {
            // Настройки SMTP
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("allikvaleria@gmail.com", "ndnm ipny bgxd aopo "),
                EnableSsl = true
            };

            // Сообщение для отправки
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("allikvaleria@gmail.com"),
                Subject = "Ваш билет в кино",
                Body = "Спасибо за покупку билета. Вложен ваш билет в виде изображения."
            };

            mailMessage.To.Add("recipient-email@example.com");

            // Добавляем вложение (изображение билета)
            mailMessage.Attachments.Add(new Attachment(imagePath));

            // Отправляем email
            smtpClient.Send(mailMessage);
        }
    }
}
