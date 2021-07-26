using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Service;
using Application.ViewModel.Sms;
using Data.Repository;
using Domin.Interface;
using Kavenegar;

namespace Application.Other
{
    public class SmsSender
    {
        
      
        public static bool SendSms(string receptor, string message, Sender send)
        {

            try
            {
                var codePanelSms = send.Number;
                KavenegarApi Api = new KavenegarApi(send.Api);

                Api.Send(codePanelSms, receptor, message);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        //public static bool ActiveCode(string receptor, int code)
        //{
        //    try
        //    {
        //        KavenegarApi api = new KavenegarApi("
        // 37416557426B76566B2B4D49547A756C3768315256715444614A504D6E597A2B6B62636E474353627672733D
        // ");

        //        var sender = "10008663";

        //        var message = $"به رزرو اسپرت خوش آمدید کد فعال سازی{code}";
        //        api.Send(sender, receptor, message);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {

        //        return false;
        //    }
        //}
        //public static bool ForgetCode(string receptor, string link)
        //{
        //    try
        //    {
        //        KavenegarApi api = new KavenegarApi("37416557426B76566B2B4D49547A756C3768315256715444614A504D6E597A2B6B62636E474353627672733D");

        //        var sender = "10008663";

        //        var message = link + "برای بازیابی گذر واژه روی لینک کلیک کنید";
        //        api.Send(sender, receptor, message);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {

        //        return false;
        //    }
        //}
        //public static bool ActiveCollection(string receptor)
        //{
        //    try
        //    {
        //        KavenegarApi api = new KavenegarApi("37416557426B76566B2B4D49547A756C3768315256715444614A504D6E597A2B6B62636E474353627672733D");

        //        var sender = "10008663";

        //        var message = "مجموعه شما با موفقیت در رزرو اسپرت ثبت شد";
        //        api.Send(sender, receptor, message);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {

        //        return false;
        //    }
        //}
        //public static bool FinishOrder(FinishOrderViewModel model)
        //{
        //    try
        //    {
        //        KavenegarApi api = new KavenegarApi("37416557426B76566B2B4D49547A756C3768315256715444614A504D6E597A2B6B62636E474353627672733D");

        //        var sender = "10008663";
        //        var welcomeText = $"{model.Name} عزیز رزرو شما ثبت شد ";
        //        var place = $"مجموعه:{model.PlaceName}";
        //        var start = $"ساعت شروع سانس{model.StartTime}:";
        //        var end = $"ساعت اتمام سانس:{model.EndTime}";
        //        var day = $"تاریخ سانس:{model.DayTime}";
        //        var price = $"مبلغ سانس:{model.PriceItem}";
        //        var location = $"نشانی:{model.PlaceLocation}";
        //        string textOne = "رعایت بهداشت فردی الزامی است";
        //        string textTwo = "سامانه رزرو اسپرت";
        //        string link = "https://reservsport.ir/";
        //        var message = welcomeText + "\n" + place + "\n" + start + "\n" + end + "\n" + day + "\n" + price + "\n" + location + "\n" + textOne + "\n" +
        //                      textTwo + "\n" + link;
        //        api.Send(sender, model.Receptor, message);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {

        //        return false;
        //    }
        //}
        //public static bool AdminFinishOrder(AdminCollectionViewModel model)
        //{
        //    try
        //    {
        //        KavenegarApi api = new KavenegarApi("37416557426B76566B2B4D49547A756C3768315256715444614A504D6E597A2B6B62636E474353627672733D");

        //        var sender = "10008663";
        //        var userName = $"نام خریدار:{model.Name}";
        //        var place = $"مجموعه:{model.PlaceName}";
        //        var start = $"ساعت شروع سانس{model.StartTime}:";
        //        var end = $"ساعت اتمام سانس:{model.EndTime}";
        //        var day = $"تاریخ سانس:{model.DayTime}";
        //        var price = $"مبلغ سانس:{model.PriceItem}";
        //        var userNumber = $"شماره سانس:{model.UserNumber}";

        //        string textTwo = "سامانه رزرو اسپرت";
        //        string link = "https://reservsport.ir/";
        //        var message = userName + "\n" + place + "\n" + start + "\n" + end + "\n" + day + "\n" + price + "\n" +
        //                      textTwo + "\n" + link;
        //        api.Send(sender, model.Receptor, message);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {

        //        return false;
        //    }
        //}
        //public static bool AnsweredTicket(string receptor, string ticketTitle)
        //{
        //    try
        //    {
        //        KavenegarApi api = new KavenegarApi("37416557426B76566B2B4D49547A756C3768315256715444614A504D6E597A2B6B62636E474353627672733D");

        //        var sender = "10008663";

        //        var message = $"تیکت شما با عنوان {ticketTitle} در رزرو اسپورت در حالت پاسخ داده شده قرار گرفت";
        //        api.Send(sender, receptor, message);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {

        //        return false;
        //    }
        //}
        //public static bool TomorrowSms(TomorrowSmsViewModel model)
        //{
        //    try
        //    {
        //        KavenegarApi api = new KavenegarApi("37416557426B76566B2B4D49547A756C3768315256715444614A504D6E597A2B6B62636E474353627672733D");

        //        var sender = "10008663";
        //        var userName = $"جناب/سرکار:{model.Name}";
        //        var place = $"فردا در مجموعه:{model.Place}";
        //        var day = $"در تاریخ:{model.Place}";
        //        var start = $"در ساعت:{model.Time}";

        //        string textTwo = "منتظر حضور شما هستیم  لطفا مواد ضد عفونی کننده به همراه  داشته باشید-سامانه رزرو اسپرت";
        //        string link = "https://reservsport.ir/";
        //        var message = userName + "\n" + place + "\n" + day + "\n" + start + "\n" + textTwo;
        //        api.Send(sender, model.UserNumber, message);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {

        //        return false;
        //    }
        //}
        //public static bool YesterdaySms(YesterdaySmsViewModel model)
        //{
        //    try
        //    {
        //        KavenegarApi api = new KavenegarApi("37416557426B76566B2B4D49547A756C3768315256715444614A504D6E597A2B6B62636E474353627672733D");

        //        var sender = "10008663";
        //        var userName = $"جناب/سرکار:{model.Name}";
        //        var place = $"از انتخاب مجموعه:{model.Place}";


        //        string textTwo = "در سامانه رزرو اسپرت سپاسگذاریم امیدواریم رضایت شما را جلب کرده باشیم منتظر دیدار مجدد شما هستیم-سامانه رزرو اسپرت";
        //        string link = "https://reservsport.ir/";
        //        var message = userName + "\n" + place + "\n" + textTwo;
        //        api.Send(sender, model.UserNumber, message);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {

        //        return false;
        //    }
        //}
    }
}
