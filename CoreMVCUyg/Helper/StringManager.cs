using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CoreMVCUyg.Helper
{
    public class StringManager
    {
        public static string ToSlug(string incomingText)
        {
            incomingText = incomingText.Replace("ş", "s");
            incomingText = incomingText.Replace("Ş", "s");
            incomingText = incomingText.Replace("İ", "i");
            incomingText = incomingText.Replace("I", "i");
            incomingText = incomingText.Replace("ı", "i");
            incomingText = incomingText.Replace("ö", "o");
            incomingText = incomingText.Replace("Ö", "o");
            incomingText = incomingText.Replace("ü", "u");
            incomingText = incomingText.Replace("Ü", "u");
            incomingText = incomingText.Replace("Ö", "o");
            incomingText = incomingText.Replace("Ç", "c");
            incomingText = incomingText.Replace("ç", "c");
            incomingText = incomingText.Replace("ğ", "g");
            incomingText = incomingText.Replace("Ğ", "g");
            incomingText = incomingText.Replace(" ", "-");
            incomingText = incomingText.Replace("---", "-");
            incomingText = incomingText.Replace("?", "");
            incomingText = incomingText.Replace("/", "");
            incomingText = incomingText.Replace(".", "");
            incomingText = incomingText.Replace("'", "");
            incomingText = incomingText.Replace("#", "");
            incomingText = incomingText.Replace("%", "");
            incomingText = incomingText.Replace("&", "");
            incomingText = incomingText.Replace("*", "");
            incomingText = incomingText.Replace("!", "");
            incomingText = incomingText.Replace("@", "");
            incomingText = incomingText.Replace("+", "");
            incomingText = incomingText.ToLower();
            incomingText = incomingText.Trim();

            //tüm harfleri küçült
            string encodeUrl = (incomingText ?? "").ToLower();

            // & ile "" yer değiştirme
            encodeUrl = Regex.Replace(encodeUrl, @"\&+", "and");

            //" " karakterini silme
            encodeUrl = encodeUrl.Replace("'", "");

            //geçersiz karakterleri sil
            encodeUrl = Regex.Replace(encodeUrl, @"[^a-z0-9]", "-");

            //tekrar edenleri sil
            encodeUrl = Regex.Replace(encodeUrl, @"-+", "-");

            //karakterlerin arasına tire(-) koy    
            encodeUrl = encodeUrl.Trim('-');

            return encodeUrl;
        }

        /// <summary>
        /// Parametre olarak verilen string değeri default olarak 0 dan 70 karaktere kadar alır.
        /// Parametre olarak kesilecek sayıyı verebilirsiniz..
        /// </summary>
        /// <param name="incomingText"></param>
        /// <param name="kesilecekSayi"></param>
        /// <returns></returns>
        public static string Kisalt(string incomingText, int kesilecekSayi = 70)
        {
            if (!String.IsNullOrEmpty(incomingText))
            {
                if (kesilecekSayi > incomingText.Count())
                {
                    return incomingText;
                }
                else
                {
                    return incomingText.Substring(0, kesilecekSayi) + "...";
                }
            }
            else
            {
                return "";
            }

        }

        /// <summary>
        /// Parametre olarak verilen DateTime değeri (15 Ağus 2017) biçiminde yazar.. 
        /// </summary>
        /// <param name="tarih"></param>
        /// <returns></returns>
        public static string TarihYaz(DateTime tarih)
        {
            if (tarih != null)
            {
                return tarih.ToString("dd.MM.yyyy");
            }
            else
            {
                return "01.Ocak.1900";
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string SureYaz(DateTime tarih)
        {

            TimeSpan sure = DateTime.Now - tarih;
            //if (sure.TotalMinutes < 1)
            //{
            //    return "<small><i class='fa fa-clock-o'></i>&nbsp; Şimdi </small>";
            //}
            if (sure.TotalHours < 1)
            {
                return "<small><i class='fa fa-clock-o'></i>&nbsp;  " + sure.Minutes + " Dakika Önce </small>";
            }
            else if (sure.TotalDays < 1)
            {
                return "<small><i class='fa fa-clock-o'></i>&nbsp;  " + sure.Hours + " Saat Önce </small>";
            }
            else
            {
                return "<small><i class='fa fa-clock-o'></i>&nbsp;  " + tarih.ToString("dd.MM.yyyy") + " tarihinde </small>";
            }
        }

        /// <summary>
        /// Parametre olarak verilen DateTime değerinden günü yazdırma..
        /// Bknz : (15 Mart 1995 )
        /// Dönen değer 15
        /// </summary>
        /// <param name="tarih"></param>
        public static string GunVer(DateTime tarih)
        {
            if (tarih != null)
            {
                return tarih.ToString("dd");
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Parametre olarak verilen DateTime değerinden ayı yazdırma..
        /// Bknz : (15 Mart 1995 )
        /// Dönen değer Mart
        /// </summary>
        /// <param name="tarih"></param>
        /// <returns></returns>
        public static string AyVer(DateTime tarih)
        {
            if (tarih != null)
            {
                return tarih.ToString("MMM");
            }
            else
            {
                return "";
            }
        }
    }
}