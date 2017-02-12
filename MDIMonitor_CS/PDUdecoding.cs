using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDIMonitor_CS
{
    public class PDUdecoding
    {
        public string nLength;
        public string smsPDUEncoded(string srvContent)
        {
            Encoding encodingUTF = System.Text.Encoding.BigEndianUnicode;
            string s = null;
            byte[] encodedBytes = encodingUTF.GetBytes(srvContent);
            for (int i = 0; i < encodedBytes.Length; i++)
            {
                s += BitConverter.ToString(encodedBytes, i, 1);
            }
            s = String.Format("{0:X2}{1}", s.Length / 2, s);
            return s;
        }
        public string smsDecodedCenterNumber(string srvCenterNumber)
        {
            string s = null;
            int length = 0;
            if (srvCenterNumber == null)
            {
                s = "";
                return s;
            }
            length = srvCenterNumber.Length;
            for (int i = 1; i < length; i += 2)
            {//进行奇偶互换
                s += srvCenterNumber[i];
                s += srvCenterNumber[i - 1];
            }
            if (!(length % 2 == 0))
            {//判断是否为偶数，不是就加上F，并互换
                s += 'F';
                s += srvCenterNumber[length - 1];
            }
            s = String.Format("91{0}", s); //加上91,代表短信中心类型为国际化
            s = String.Format("{0:X2}{1}", s.Length / 2, s);   //编码后短信中心号长度，并格式化成二位十六制
            return s;
        }
        public string smsDecodedNumber(string srvNumber)
        {
            string s = null;
            if (!(srvNumber.Substring(0, 2) == "86"))
            {
                srvNumber = String.Format("86{0}", srvNumber);     //检查当前接收手机号是否按标准格式书写，不是，就补上“86”
            }
            int nLength = srvNumber.Length;
            for (int i = 1; i < nLength; i += 2)
            {      //将奇数位和偶数位交换
                s += srvNumber[i];
                s += srvNumber[i - 1];
            }
            if (!(nLength % 2 == 0))
            {  //是否为偶数，不是就加上F，并对最后一位与加上的F位互换 
                s += 'F';
                s += srvNumber[nLength - 1];
            }
            return s;
        }
        public string smsDecodedsms(string strCenterNumber, string strNumber, string strSMScontent)
        {
            string s = String.Format("{0}11000D91{1}000800{2}", smsDecodedCenterNumber(strCenterNumber), smsDecodedNumber(strNumber), smsPDUEncoded(strSMScontent));
            nLength = String.Format("{0:D2}", (s.Length - smsDecodedCenterNumber(strCenterNumber).Length) / 2);
            //获取短信内容加上手机号码长度
            return s;
        }
    }
}
