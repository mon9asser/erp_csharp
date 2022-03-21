using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;
using IronBarCode;
using System.Drawing;

namespace sales_management.PL
{
    class QR_Code
    {
        public QRCode Generator(string name, string total_price, string vat_value, string invoice_number, string datemade, string vat_number)
        {

            string name_hex = this.convertToHexData(1, name);
            string vat_number_hex = this.convertToHexData(2, vat_number);
            string date_made_texts_hex = this.convertToHexData(3, datemade.ToString());
            string total_w_vat_hex = this.convertToHexData(4, total_price);
            string vat_value_hex = this.convertToHexData(5, vat_value);

            string concateAll = name_hex.ToLower() +
                                vat_number_hex.ToLower() +
                                date_made_texts_hex.ToLower() +
                                total_w_vat_hex.ToLower() +
                                vat_value_hex.ToLower();

            var encoder64 = this.HexToBase64(concateAll); 

            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(encoder64.ToString(), QRCodeGenerator.ECCLevel.H, true, true, QRCodeGenerator.EciMode.Utf8);
            QRCode code = new QRCode(data);

            return code; 

        }




        public GeneratedBarcode Generator1(string name, string total_price, string vat_value, string invoice_number, string datemade, string vat_number)
        {

            string name_hex = this.convertToHexData(1, name);
            string vat_number_hex = this.convertToHexData(2, vat_number);
            string date_made_texts_hex = this.convertToHexData(3, datemade.ToString());
            string total_w_vat_hex = this.convertToHexData(4, total_price);
            string vat_value_hex = this.convertToHexData(5, vat_value);

            string concateAll = name_hex.ToLower() +
                                vat_number_hex.ToLower() +
                                date_made_texts_hex.ToLower() +
                                total_w_vat_hex.ToLower() +
                                vat_value_hex.ToLower();

            var encoder64 = this.HexToBase64(concateAll);

            GeneratedBarcode MyQRWithLogo = IronBarCode.QRCodeWriter.CreateQrCode(encoder64);

             

            return MyQRWithLogo;

        }


        public string HexToBase64(string strInput)
        {
            var bytes = new byte[strInput.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(strInput.Substring(i * 2, 2), 16);
            }
            return Convert.ToBase64String(bytes);

        }
         

        string convertToHexData(int tag, string value)
        {
            // cal tag 
            string number = "0" + tag.ToString();

            // cal string leng 
            string valLenght = value.Length.ToString("x2");

            // cal value   
            
            byte[] ba = Encoding.ASCII.GetBytes(value);
            //Encoding.UTF32.GetBytes(value);// Encoding.ASCII.GetBytes(value); // Encoding.Convert(Encoding.ASCII, Encoding.ASCII, Encoding.ASCII.GetBytes(value)); // Encoding.Default.GetBytes(value);
             
            var hexString = BitConverter.ToString(ba); 
            hexString = hexString.Replace("-", "");

            // return final value 
            string hexered = number + valLenght + hexString;

            return hexered;
        }

        public string convertToHexData1(int tag, string value)
        {
            // cal tag 
            string number = "0" + tag.ToString();

            // cal string leng 
            string valLenght = value.Length.ToString("x2");

            // cal value  
            byte[] ba = Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(value)); // Encoding.Default.GetBytes(value);
            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");

            // return final value 
            string hexered = number + valLenght + hexString;

            return hexered;
        }
    }
}
