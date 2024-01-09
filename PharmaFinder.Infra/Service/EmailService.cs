﻿using MailKit.Net.Smtp;
using MailKit.Security;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Service;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using PharmaFinder.Api.Settings;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.Text;
using PharmaFinder.Core.Data;

namespace PharmaFinder.Infra.Service
{
    public class EmailService: IEmailService
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly IConverter _pdfConverter;

        public EmailService(IOptions<EmailConfiguration> emailConfig, IConverter pdfConverter)
        {
            _emailConfig = emailConfig.Value;
            _pdfConverter = pdfConverter;
            
        }
        public void SendEmail(SendEmailDto emailDto)
        {
            var email = new MimeMessage
            {
                Subject = emailDto.Subject,
                To = { MailboxAddress.Parse(emailDto.To) },
                Body = new TextPart(TextFormat.Html)
                {
                    Text = emailDto.Html
                },
                From = { MailboxAddress.Parse(_emailConfig.From) }
            };
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_emailConfig.Host, _emailConfig.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailConfig.From, _emailConfig.Password);
                var response = smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
         public void SendInvoice(SendEmailDto emailDto, List<PharmaMedResult> items, InvoiceDTO invoiceDTO)
        {
            var email = new MimeMessage
            {
                Subject = emailDto.Subject,
                To = { MailboxAddress.Parse(emailDto.To) },
                Body = new TextPart(TextFormat.Html)
                {
                    Text = emailDto.Html
                },
                From = { MailboxAddress.Parse(_emailConfig.From) }
            };

            var builder = new BodyBuilder();
            builder.HtmlBody = emailDto.Html;


            byte[] pdfAttachment = GeneratePdfFromHtml(items, invoiceDTO);
            if (pdfAttachment != null)
            {
                builder.Attachments.Add("Invoice.pdf", pdfAttachment);
            }


            email.Body = builder.ToMessageBody();
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_emailConfig.Host, _emailConfig.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailConfig.From, _emailConfig.Password);
                var response = smtp.Send(email);
                smtp.Disconnect(true);
            }
        }

        public byte[] GeneratePdfFromHtml(List<PharmaMedResult> items,InvoiceDTO invoiceDTO )
        {
            StringBuilder htmlContent = new StringBuilder();
			htmlContent.Append($@"<!DOCTYPE html>
           <html>
	          <head>
		   <meta charset=""utf-8"" />
	       	<title>A simple, clean, and responsive HTML invoice template</title>
 
	       	<style>
		     	.invoice-box {{
				max-width: 800px;
				margin: auto;
				padding: 30px;
				border: 1px solid #eee;
				box-shadow: 0 0 10px rgba(0, 0, 0, 0.15);
				font-size: 16px;
				line-height: 24px;
				font-family: 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
		  		color: #555;
		       	}}

			   .invoice-box table {{
				width: 100%;
				line-height: inherit;
				text-align: left;
			     }}

			.invoice-box table td {{
				padding: 5px;
				vertical-align: top;
			}}

			.invoice-box table tr td:nth-child(2) {{
				text-align: right;
			}}

			.invoice-box table tr.top table td {{
				padding-bottom: 20px;
			}}

			.invoice-box table tr.top table td.title {{
				font-size: 45px;
				line-height: 45px;
				color: #333;
			}}

			.invoice-box table tr.information table td {{
				padding-bottom: 40px;
			}}

			.invoice-box table tr.heading td {{
				background: #eee;
				border-bottom: 1px solid #ddd;
				font-weight: bold;
			}}

			.invoice-box table tr.details td {{
				padding-bottom: 20px;
			}}

			.invoice-box table tr.item td {{
				border-bottom: 1px solid #eee;
			}}

			.invoice-box table tr.item.last td {{
				border-bottom: none;
			}}

			.invoice-box table tr.total td:nth-child(2) {{
				border-top: 2px solid #eee;
				font-weight: bold;
			}}

			@media only screen and (max-width: 600px) {{
				.invoice-box table tr.top table td {{
					width: 100%;
					display: block;
					text-align: center;
				}}

				.invoice-box table tr.information table td {{
					width: 100%;
					display: block;
					text-align: center;
				}}
			}}

			/** RTL **/
			.invoice-box.rtl {{
				direction: rtl;
				font-family: Tahoma, 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
			}}

			.invoice-box.rtl table {{
				text-align: right;
			}}

			.invoice-box.rtl table tr td:nth-child(2) {{
				text-align: left;
			}}
		</style>
	</head>

	<body>
		<div class=""invoice-box"">
			<table cellpadding=""0"" cellspacing=""0"">
				<tr class=""top"">
					<td colspan=""2"">
						<table>
							<tr>
								<td class=""title"">
									<img
										src=""https://i.ibb.co/hgkftBt/Pharma-Finder.png""
										style=""width: 100%; max-width: 300px""
									/>
								</td>

								<td>
									Invoice #: {invoiceDTO.Orderid}<br />
									Due: {invoiceDTO.Orderdate}
								</td>
							</tr>
						</table>
					</td>
				</tr>

				<tr class=""information"">
					<td colspan=""2"">
						<table>
							<tr>
								<td>
									PharmaFinder, Inc.<br />
									King Abdullah II St<br />
									+962-79-6217882
								</td>

								<td>
									
									{invoiceDTO.Username}<br />
									{invoiceDTO.Email}
								</td>
							</tr>
						</table>
					</td>
				</tr>

				<tr class=""heading"">
					<td>Payment Method</td>

					<td>PayPal</td>
				</tr>

				<tr class=""details"">
					<td>PayPal</td>

					<td>${invoiceDTO.Orderprice}</td>
				</tr>
<tr class=""heading"">
					<td>Pharmacy Name</td>

					<td>Item</td>
					<td>Quantity</td>

					<td>Price</td>
					<td>Total</td>
				</tr>

");
			foreach (var item in items)
			{
				htmlContent.Append($@"<tr class=""item"">
					<td>{item.Pharmacyname}</td>
					<td>{item.Medicinename}</td>
					<td>{item.Quantity}</td>
					<td>${item.Medicineprice}</td>
					<td>${item.Medicineprice*item.Quantity}</td>

				</tr>");

			}

			htmlContent.Append($@"<tr class=""total"">
					<td></td>

					<td>Total: ${invoiceDTO.Orderprice}</td>
				</tr>
			</table>
		</div>
	</body>
</html>");

			var pdf = _pdfConverter.Convert(new HtmlToPdfDocument()
			{
				GlobalSettings = {
			PaperSize = PaperKind.A4,
			Orientation = Orientation.Landscape
		},
				Objects = {
			new ObjectSettings() {
				HtmlContent =htmlContent.ToString()

			}
		}
			}) ;

            return pdf;
        }




    }

    }

