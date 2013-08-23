using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Countries
/// </summary>
/// 
namespace Countreis.CountryList
{
    public static class Countries
    {
        public static List<string> BindCountries()
        {
        List<string> myList = new List<string>();
        myList.Insert(0, "");
        myList.Add("ألبانيا");
        myList.Add("الجزائر");
        myList.Add("أنغولا");
        myList.Add("أنجويلا");
        myList.Add("أذربيجان");
        myList.Add("البحرين");
        myList.Add("بنغلاديش");
        myList.Add("البوسنة والهرسك");
        myList.Add("بوركينا فاسو");
        myList.Add("مصر");
        myList.Add("إيران");
        myList.Add("العراق");
        myList.Add("المنطقة المحايدة بين العراق والسعودية");
        myList.Add("الكويت");
        myList.Add("ليبيا");
        myList.Add("لبنان");
        myList.Add("ليتوانيا");
        myList.Add("مقدونيا");
        myList.Add("مدغشقر");
        myList.Add("ماليزيا");
        myList.Add("مالطا");
        myList.Add("موريتانيا");
        myList.Add("المغرب");
        myList.Add("عمان");
        myList.Add("فلسطين");
        myList.Add("قطر");
        myList.Add("المملكة العربية السعودية");
        myList.Add("جزر سليمان");
        myList.Add("الصومال");
        myList.Add("السودان");
        myList.Add("سوريا");
        myList.Add("تونس");
        myList.Add("تركيا");
        myList.Add("الإمارات العربية المتحدة");
        myList.Add("اليمن");
        myList.Add("الجزائر");
        myList.Add("الأردن");

        return myList;
    

        }
    }

}