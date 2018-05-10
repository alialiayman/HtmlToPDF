using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Codaxy.WkHtmlToPdf;

namespace HtmlToPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dfsFileName.Text)) return;
            if (string.IsNullOrEmpty(dfsUrl.Text)) return;
            var coo = new Dictionary<string, string>();
            //Cookie: 
            //f5_cspm = 1234; 
            //visa.mofa.gov.sa = i5un5pi3nzbzmobfyrtvzqmc; 
            //__RequestVerificationToken = MVoR0xYlGkXY6_6FVpWS5jYaxr8fWM4sACfe7x8ZjYrdSsjSq08okLL6J2Vbe4NbTlefAFQ4pg4w3ygCv4sC4BtlhiaHe8f57bou89rH_t01; 
            //BIGipServerVS_Visa_Eexternal.app~VS_Visa_Eexternal_pool = !6wSge + C0lxnxGiLT1TJS3QOVPD1sHPsr9MHFfQKl / +nYxu6ruQrDsYyw2PFRzD3MDn2FvoXkJ8gxEA ==; 
            //TS0156c15d = 011b14958a4afa8b83e2ea5361a9889b5bbacb920830ed2e0e3cf17e31860aa79b558cc3ded5f824736a2871eb8c978409ed5b878b7d937c9287540f25f2c52eba7310f272d31f0186a55dc2fc7c4229f86f4686851387a7744d268eec9c15d20b348d96f5
            if (!string.IsNullOrEmpty(dfsCookie.Text))
            {
                var items = dfsCookie.Text.Split(';');
                foreach (var item in items)
                {
                    coo.Add(item.Split('=')[0], item.Split('=')[1]);
                }
            }
            PdfConvert.ConvertHtmlToPdf(new PdfDocument
            {
                Url = dfsUrl.Text, 
                Cookies = coo,
                //HeaderLeft = "[title]",
                //HeaderRight = "[date] [time]",
                //FooterCenter = "Page [page] of [topage]"

            }, new PdfOutput
            {
                OutputFilePath = dfsFileName.Text
            });
        }
    }
}
