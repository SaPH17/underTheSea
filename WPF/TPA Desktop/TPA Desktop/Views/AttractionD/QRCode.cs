using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPA_Desktop.Views.AttractionD
{
    public partial class QRCode : Form
    {
        public QRCode()
        {
            InitializeComponent();

            Zen.Barcode.CodeQrBarcodeDraw qrCode = Zen.Barcode.BarcodeDrawFactory.CodeQr;

            pictureBox1.Image = qrCode.Draw(GeneratedQRCode.ticket.ticketID.ToString(), 50);

            ticketID.Text = "TicketID = " + GeneratedQRCode.ticket.ticketID.ToString();

        }
    }
}
