using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Service;
using Application.ViewModel.Sms;
using Data.Repository;
using Domin.Entity;
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
                var sender = send.Number;
                KavenegarApi Api = new KavenegarApi(send.Api);

                Api.Send(sender, receptor, message);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }


        public static bool ActiveCollection(string receptor, Sender send,string text)
        {
            try
            {
                var sender = send.Number;
                KavenegarApi Api = new KavenegarApi(send.Api);
                var message = text;
                Api.Send(sender, receptor, message);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        public static bool FinishOrder(FinishOrderViewModel model,Sender send,SmsCustomerModel text)
        {
            try
            {
                var sender = send.Number;
                KavenegarApi Api = new KavenegarApi(send.Api);
                var welcomeText = text.NameText + model.Name;
                var place = text.CollectionText + model.PlaceName;
                var start = text.StartText + model.StartTime;
                var end = text.EndText + model.EndTime;
                var day = text.DayText + model.DayTime;
                var price = text.PriceText + model.PriceItem;
                var location = text.AddressText + model.PlaceLocation;
                string textOne = text.SiteText;
              
                string link = text.SiteLink;
                var message = welcomeText + "\n" + place + "\n" + start + "\n" + end + "\n" + day + "\n" + price + "\n" + location + "\n" + textOne +
                               "\n" + link;
                Api.Send(sender, model.Receptor, message);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        public static bool AdminFinishOrder(AdminCollectionViewModel model,Sender send,SmsAdminModel text)
        {
            try
            {
                var sender = send.Number;
                KavenegarApi Api = new KavenegarApi(send.Api);
                var userName = text.NameText + model.Name;
                var place = text.SportText+model.PlaceName;
            var start = text.StartText + model.StartTime;
            var end = text.EndText + model.EndTime;
            var day = text.DayText + model.DayTime;
            var price = text.PriceText + model.PriceItem;
            var userNumber = text.CodeText + model.UserNumber;

            string textTwo = text.SiteText;
            string link = text.SiteLink;
                var message = userName + "\n" + place + "\n" + start + "\n" + end + "\n" + day + "\n" + price + "\n" +
                              textTwo + "\n" + link;
                Api.Send(sender, model.Receptor, message);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        public static bool AnsweredTicket(string receptor,Sender sender,string message)
        {
            try
            {
                var send = sender.Number;
                KavenegarApi Api = new KavenegarApi(sender.Api);
                Api.Send(send, receptor, message);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        public static bool TomorrowSms(TomorrowSmsViewModel model,Sender sender,SmsRememberModel remember)
        {
            try
            {

                var userName = remember.NameText + model.Name;
                var place = remember.CollectionText + model.Place;
                var day = remember.DayText + model.Time;
                var start = remember.StartText + model.Start;
                string textTwo = remember.Description + remember.SiteText;
                string link = remember.SiteLink;
                var message = userName + "\n" + place + "\n" + day + "\n" + start + "\n" + textTwo;
                var send = sender.Number;
                KavenegarApi Api = new KavenegarApi(sender.Api);
                Api.Send(send, model.UserNumber, message);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        public static bool YesterdaySms(YesterdaySmsViewModel model, Sender sender, SmsThankModel thank)
        {
            try
            {
                var send = sender.Number;
                KavenegarApi Api = new KavenegarApi(sender.Api);
                var userName = thank.NameText + model.Name;
                var place = thank.ThankText + model.Place;


                string textTwo = thank.DescriptionText;
                string link = thank.SiteLink;
                var message = userName + "\n" + place + "\n" + textTwo;
                Api.Send(send, model.UserNumber, message);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
