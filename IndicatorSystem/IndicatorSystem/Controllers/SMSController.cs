using IndicatorData;
using IndicatorData.Models;
using IndicatorSystem.Models.Catalog;
using IndicatorSystem.Models.SMS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndicatorSystem.Controllers
{
    public class SMSController : Controller
    {

        static private IIndicatorTable _assets;
        static private IUser _users;
        static private IIndicatorPerson _workers;
        static private IIndicatorType _types;
        public SMSController(IIndicatorTable asset, IUser user, IIndicatorPerson worker, IIndicatorType types)
        {
            _assets = asset;
            _users = user;
            _workers = worker;
            _types = types;
        }
        static string path = "C:/Users/Hp/Dropbox/Main-Project-2018-2019/smsDB/data.txt";
        static List<SMSConstructor> smsList;
       

        public static void GetSMS()
        {
            string today = DateTime.Now.ToString("yyyy/MM/dd");
            today = today.Replace(".", "");
            string commands =
@"D:
cd D:\sdk-tools-windows-4333796\platform-tools
adb shell input keyevent 26
adb shell am start -n com.smeiti.smstotext/com.smeiti.smstotext.SMStoTextActivity
adb shell input tap 550 905

adb shell input tap 600 840
adb shell mv sdcard/SMS-DataBase/sms_" + today + ".txt sdcard/SMS-DataBase/data.txt\n" +
"adb pull sdcard/SMS-DataBase/data.txt C:/Users/Hp/Dropbox/Main-Project-2018-2019/smsDB\n" +
"adb shell rm -f /sdcard/SMS-DataBase/data.txt \n" +
"adb shell input keyevent 26";
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false

                }
            };
            process.Start();

            using (StreamWriter pWriter = process.StandardInput)
            {
                if (pWriter.BaseStream.CanWrite)
                {
                    foreach (var line in commands.Split('\n'))
                    {
                        pWriter.WriteLine(line);
                        System.Threading.Thread.Sleep(4000);
                    }
                }
            }
           
            

        }

        public static void GetSmsInfo() {
            StreamReader sr = new StreamReader(path);
            string line, name, number, date, time,text, idS="", valueS="";
            int id=0, type=0, value=0;
            bool idB=true, typeB=false, valueB=false;
            smsList = new List<SMSConstructor>();
            while (!sr.EndOfStream)
            {
                idB = true; typeB = false; valueB = false;
                line = sr.ReadLine();
                string[] arr = line.Split("\t");                
                date = arr[0];
                time = arr[1];
                number = arr[3];
                name = arr[4];
                text = arr[5];
                text += ' ';
                bool check = true;
                string[] textArr = text.Split(' ');
                idS = textArr[0];
                if (idS.Length == 8)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if (!(idS[i] >= 48 && idS[i] <= 57))
                        {
                            check = false;
                        }
                    }
                    if (check)
                    {
                        value = int.Parse(textArr[1]);
                    }
                    if (check)
                    {
                        string[] nDate = date.Split('/');
                        string[] nTime = time.Split(':');
                        DateTime DATE = new DateTime(int.Parse(nDate[2]), int.Parse(nDate[1]), int.Parse(nDate[0]), int.Parse(nTime[0]), int.Parse(nTime[1]), int.Parse(nTime[2]));
                        SMSConstructor sms = new SMSConstructor(DATE, name, number, idS, value);
                        smsList.Add(sms);
                    }
                }
                /*
                if (text[0] == 'О' && text[1] == '/' && text[2] == 'Р')
                {
                    List<KeyValuePair<int, int>> pair = new List<KeyValuePair<int, int>>();                       
                    for (int i = 4; i < text.Length; i++)
                    {
                        if (idB)
                        {
                            idS = "";
                            for (int j = 0; j < 8; j++)
                            {
                                idS += text[i++];
                            }
                            
                                
                                idB = false;
                                typeB = true;
                                
                                continue;                                
                            
                        }
                        if (typeB && k<3)
                        {
                            if(text[i]=='Г')
                            {
                                type = 1;
                            }
                            else if (text[i] == 'Е')
                            {
                                type = 2;
                            }
                            else if (text[i] == 'В')
                            {
                                type = 3;
                            }
                            else
                            {
                                valueB = false;
                                    typeB = false;
                                continue;
                            }
                            i++;
                            k++;
                            typeB = false;
                            valueB = true;
                            continue;
                        }
                        if (valueB)
                        {
                            valueS += text[i];
                            if (text[i] == ' ' || i == text.Length -1)
                            {
                                value = int.Parse(valueS);
                                valueS = "";
                                valueB = false;
                                typeB = true;
                                KeyValuePair<int, int> q= new KeyValuePair<int, int>(type, value);
                                pair.Add(q);
                                continue;
                            }
                        }
                    }
                    string[] nDate = date.Split('/');
                    string[] nTime = time.Split(':');
                    DateTime DATE = new DateTime(int.Parse(nDate[2]), int.Parse(nDate[1]), int.Parse(nDate[0]), int.Parse(nTime[0]), int.Parse(nTime[1]), int.Parse(nTime[2]));
                    SMSConstructor sms = new SMSConstructor(DATE, name, number, idS, pair);
                    smsList.Add(sms);
                }*/
            }
            sr.Close();
        }

      

        public  IActionResult Refresh()
        {
            GetSMS();
            GetSmsInfo();
            var UsersList = _users.getAll()
               .Select(result => new User() {
                   Id = result.Id
               });
            var WorkersList = _workers.getAll()
               .Select(result => new IndicatorPerson()
               {
                   MobilePhone = result.MobilePhone
               });
            var DatesList = _assets.getAll()
               .Select(result => new IndicatorTable()
               {
                   date = result.date
                });
            
          
            DateTime max = new DateTime(1100, 1, 1, 0, 0, 1);
            foreach (var date in DatesList)
            {
                if (date.date > max)
                {
                    max = date.date;
                }
            }
            foreach (var sms in smsList)
            {
                if (sms.date > max)
                {
                    if (sms.name == "Internet")
                    {
                        sms.number = "+380508792738";
                        sms.name = "Klymko Innessa Mykolayivna";
                    }
                    bool z = true;
                    foreach (var workerN in WorkersList)
                    {
                        if (workerN.MobilePhone == sms.number)
                        {
                            z = false;
                            break;
                        }
                    }
                    if (!z)
                    {                        
                        bool l = true;
                        foreach (var userN in UsersList)
                        {
                            if (userN.Id == sms.id)
                            {
                                l = false;
                                break;
                            }
                        }
                        if (l)
                        {
                            User use = new User()
                            {
                                Id = sms.id,
                                FullName = "Unregistered client"
                            };
                            _users.Add(use);
                        }
                                                
                            IndicatorTable a = new IndicatorTable()
                            {
                                user = _users.GetById(sms.id),                               
                                amount = sms.value,
                                date = sms.date,
                                worker = _workers.GetByPhone(sms.number)
                            };
                            _assets.Add(a);
                        
                    }
                    
                }
            }

            var assetModels = _assets.getAll();
            var ListingResult = assetModels
                .Select(result => new AssetIndexListingModel()
                {
                    Id = result.Id,
                    UsersId = result.user.Id,
                    UsersFullName = result.user.FullName,
                    UsersBirthDay = result.user.BirthDate,
                    // Email = result.user.LoginInfo.Email,
                    //Password = result.user.LoginInfo.Password,
                    typeId = result.worker.type.Id,
                    unit = result.worker.type.Unit,
                    limit = result.worker.type.Limit,
                    amount = result.amount,
                    date = result.date,
                    workerFullName = result.worker.FullName,
                    workerPhone = result.worker.MobilePhone
                });

            var model = new CatalogIndexModel()
            {
                Assets = ListingResult
            };

            return View(model);
        }
    }
}


