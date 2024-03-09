using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

public class EmailTestResults
{
    public void SendEmailWithAttachment()
    {
        // Sender's email details
        string senderEmail = "sender@gmail.com";
        string senderPassword = "senderPassWord";
        string smtpServer = "smtp.gmail.com";
        string trxFilePath = "";
        int smtpPort = 587;

        // Execute .bat file
        int exitCode = ExecuteBatchFile(@"C:\Users\nguye\source\repos\OregonTrailTesting\OregonTrailTests\runTestSuite.bat");

        // Determine build result
        string buildResult = (exitCode == 0) ? "succeeded" : "failed";

        // Create message
        string recipientEmail = "receiver@gmail.com";
        MailMessage mail = new MailMessage(senderEmail, recipientEmail);
        mail.Subject = $"Build {buildResult}";
        mail.Body = $"The build {buildResult}";
        trxFilePath = @"C:\Users\nguye\source\repos\OregonTrailTesting\OregonTrailTests\TestResults\test_results.trx";
        if (File.Exists(trxFilePath))
        {
            Attachment attachment = new Attachment(trxFilePath, MediaTypeNames.Application.Octet);
            mail.Attachments.Add(attachment);
        }
        else
        {
            Console.WriteLine("TRX file not found.");
        }

        // Send email
        SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
        smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
        smtpClient.EnableSsl = true;
        smtpClient.Send(mail);
    }

    private int ExecuteBatchFile(string batFilePath)
    {
        Process process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.Arguments = batFilePath;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.Start();
        process.WaitForExit();
        return process.ExitCode;
    }

    //public static void Main(string[] args)
    //{
    //    EmailTestResults emailSender = new EmailTestResults();
    //    emailSender.SendEmailWithAttachment();
    //}
}
